using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Dal.Enum;
using NLog;

namespace bsx.DirLaguna.iOsDataStorage
{
    public class DataBuilder
    {
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public struct SetupStruct
        {
            public string TargetPath { get; set; }

            public string SourcePath { get; set; }

            public string TempPath { get; set; }

            public string PictureHandler { get; set; }

            public string LogoHandler { get; set; }

            public string CouponHandler { get; set; }

            public string LogoPath { get; set; }

            public string DbName { get; set; }

            public AccountConceptKeyEnum Device { get; set; }
        }

        SetupStruct setup;

        SqLiteCommander commander { get; set; }

        public List<string> Errors { get; set; }

        public DataBuilder(SetupStruct setup)
        {
            this.Errors = new List<string>();
            this.setup = setup;

            this.commander = new SqLiteCommander(setup.TempPath);
        }

        private bool CreateWorkingFile()
        {
            bool result = false;
            try
            {
                File.Copy(this.setup.SourcePath, this.setup.TempPath, true);

                System.IO.FileInfo fileInfo = new System.IO.FileInfo(this.setup.TempPath);
                if (fileInfo.IsReadOnly == true)
                    fileInfo.IsReadOnly = false;

                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
            }
            return result;
        }

        public bool ProccessData()
        {
            Logger.Info("== GENERACION DE LA BASE DE DATOS == {0}", Environment.NewLine);
            bool result = false;

            var lastUpdateDate = new SqliteUpdateController().FetchLastUpdateDate();
            int updatedAdvs = new AdvertiserController().FetchChangesSince(lastUpdateDate);

            if (updatedAdvs == 0)
            {
                Logger.Info("No se han encontrado modificaciones a la base de datos. Se suspende");
                Logger.Info("== FIN DE LA GENERACION =={0}", Environment.NewLine);

                this.Errors.Add("No se han detectado cambios en la base de datos. No se ha actualizado el archivo");
                return false;
            }

            AccountConceptKeyEnum[] deviceKeys = new[] { AccountConceptKeyEnum.iOsApp, AccountConceptKeyEnum.AndroidApp };
            Dictionary<AccountConceptKeyEnum, int> devices = new Dictionary<AccountConceptKeyEnum, int>();
            foreach (var item in deviceKeys)
                devices.Add(item, 0);

            foreach (var device in deviceKeys)
            {
                this.setup.Device = device;

                this.CreateWorkingFile();

                this.commander.OpenConnection();

                if (!this.FillCategories())
                {
                    this.Errors.Add("Error al cargar las categorias");
                    continue;
                }

                if (!this.FillCities())
                {
                    this.Errors.Add("Error al cargar las ciudades");
                    continue;
                }

                if (!this.commander.FlushCommands())
                {
                    this.Errors.Add("Error al vaciar las instrucciones de categorias y ciudades");
                    continue;
                }

                commander.ExecuteCommand("CREATE INDEX idx_Var on Advertiser (advName asc,Description,Tags,Categories);", new List<RawParameter>());
                commander.ExecuteCommand("CREATE INDEX idx_ord on Advertiser (advName asc);", new List<RawParameter>());

                int count = 0;
                if (!this.FillAdvertisers(out count))
                {
                    this.Errors.Add("Error al cargar los anunciantes");
                    continue;
                }
                devices[device] = count;
                result = true;

                int newVersion = new SqliteUpdateController().FetchNextVersion();

                if (!this.FillSetup(newVersion))
                {
                    this.Errors.Add("Error cargar la ultima version de base de datos generada");
                    continue;
                }

                if (!result)
                    continue;

                this.commander.CloseConnection();

                if (!this.CopyNewDataBase())
                {
                    this.Errors.Add("No se ha podido copiar la nueva bd en el directorio destino");
                    continue;
                }
            }

            SqliteUpdateController controller = new SqliteUpdateController();
            if (result && controller.Save(devices[AccountConceptKeyEnum.iOsApp], devices[AccountConceptKeyEnum.AndroidApp]))
                result = true;
            else
                this.Errors.Add("No se ha podido acutualizar la información de la publicación en la base de datos");

            return result;
        }

        private bool CopyNewDataBase()
        {
            Logger.Info("Copiando la nueva base de datos");

            bool result = false;
            try
            {
                FileInfo info = new FileInfo(this.setup.TempPath);

                GzipHelper.Compress2Gz(info);
                File.Delete(this.setup.TempPath);

                string newPath = string.Format("{0}{2}\\{1}", this.setup.TargetPath, this.setup.DbName.Replace(".db", ".gz"), (int)this.setup.Device);
                File.Copy(this.setup.TempPath + ".gz", newPath, true);
                result = true;
            }
            catch (Exception ex)
            {
                Logger.Error("Error al copiar la bd. {0}", ex.Message);
            }

            return result;
        }

        private bool FillSetup(int nextVersion)
        {
            Logger.Info("Cargando Configuracion");

            string tableName = "Gen";
            commander.AddCommand(commander.DeleTableData(tableName));
            commander.AddCommand(string.Format("insert into {0} (GenId,Version) values(1, {1})", tableName, nextVersion));

            return commander.FlushCommands();
        }

        private bool FillCategories()
        {
            Logger.Info("Cargando Categorias");

            string tableName = "Category";
            bool result = false;
            commander.AddCommand(commander.DeleTableData(tableName));
            var cats = new CategoryController().FetchAll();

            foreach (var item in cats)
            {
                if (item.LiveAdvertisers == 0)
                    continue;

                result = commander.AddCommand(this.CateogryCommand(tableName, item));
            }

            return result;
        }

        private bool FillCities()
        {
            Logger.Info("Cargando Ciudades");

            string tableName = "City";
            bool result = false;
            commander.AddCommand(commander.DeleTableData(tableName));
            var cities = new CityController().FechAllActive(this.setup.Device);

            foreach (var item in cities)
                result = commander.AddCommand(this.CityCommand(tableName, item));

            return result;
        }

        private bool FillAdvertisers(out int updates)
        {
            updates = 0;
            Logger.Info("Cargando Anunciantes");

            string tableName = "Advertiser";

            bool result = false;
            commander.ExecuteCommand(commander.DeleTableData(tableName), new List<RawParameter>());
            var advertisers = new AdvertiserController().FetchAllAliveFor(this.setup.Device);

            List<RawParameter> parameters = new List<RawParameter>();
            int count = 0;

            foreach (var item in advertisers)
            {
                Logger.Info("Advertiser: Id:{0}; Name: {1}", item.AdvertiserId, item.Name);
                result = this.SaveElement<Advertiser>(item, "Advertiser", CreateAdvertiserParameters);
                if (!result)
                    break;

                foreach (Office office in item.ActiveOffices)
                {
                    result = this.SaveElement<Office>(office, "Office", this.CreateOfficeParameters);

                    if (!result)
                        break;
                }

                var coupons = item.ActiveCoupon;
                foreach (Coupon cp in coupons)
                {
                    result = this.SaveElement<Coupon>(cp, "Coupon", this.CreateCouponParameters);
                    if (!result)
                        break;

                    foreach (var couponCat in cp.CouponCategory.Where(x => x.Deleted == false))
                    {
                        result = this.SaveElement<CouponCategory>(couponCat, "CouponCategory", this.CreateCouponCategoriesParameters);
                        if (!result)
                            break;
                    }
                }

                var galleries = item.ActiveGalleries;
                foreach (Gallery gallery in galleries)
                {
                    result = this.SaveElement<Gallery>(gallery, "Gallery", this.CreateGalleryParameters);

                    if (!result)
                        break;

                    foreach (Picture picture in gallery.ActivePictures)
                    {
                        result = this.SaveElement<Picture>(picture, "Picture", this.CreatePicturesParameters);

                        if (!result)
                            break;
                    }
                }

                if (++count % 50 == 0)
                    Logger.Info(string.Format("Guardadas {0}/{1}", count, advertisers.Count()));
            }
            updates = count - 1;
            return result;
        }

        public delegate List<RawParameter> ParameterBuilder(Object item);

        private bool SaveElement<T>(T item, string tableName, ParameterBuilder builder)
        {
            List<RawParameter> advParameters = builder(item);
            string advCmdText = this.CreateSqliteCmdText(advParameters, tableName);
            return this.commander.ExecuteCommand(advCmdText, advParameters);
        }

        private string CreateSqliteCmdText(List<RawParameter> parameters, string tableName)
        {
            StringBuilder columnNames = new StringBuilder();
            StringBuilder parameterNames = new StringBuilder();

            if (parameters.Count == 0)
                return string.Empty;

            columnNames = columnNames.Append(parameters[0].Name);
            parameterNames = parameterNames.AppendFormat("@{0}", parameters[0].Name);

            for (int i = 1; i < parameters.Count; i++)
            {
                columnNames = columnNames.AppendFormat(", {0}", parameters[i].Name);
                parameterNames = parameterNames.AppendFormat(", @{0}", parameters[i].Name);
            }

            string insertCmd = string.Format("Insert into {0} ({1}) values ({2})", tableName, columnNames.ToString(), parameterNames.ToString());
            //Logger.Info(insertCmd);
            return insertCmd;
        }

        private List<RawParameter> CreateCouponCategoriesParameters(Object item)
        {
            CouponCategory couponCategory = item as CouponCategory;
            List<RawParameter> parameters = new List<RawParameter>();

            parameters.Add(new RawParameter() { Name = "CouponCategoryId", Type = System.Data.DbType.Int32, Value = couponCategory.CouponCategoryId });
            parameters.Add(new RawParameter() { Name = "CouponId", Type = System.Data.DbType.Int32, Value = couponCategory.CouponId });
            parameters.Add(new RawParameter() { Name = "CategoryId", Type = System.Data.DbType.Int32, Value = couponCategory.CategoryId });

            return parameters;
        }

        private List<RawParameter> CreateOfficeParameters(Object item)
        {
            Office office = item as Office;
            List<RawParameter> parameters = new List<RawParameter>();

            parameters.Add(new RawParameter() { Name = "OfficeId", Type = System.Data.DbType.Int32, Value = office.OfficeId });
            parameters.Add(new RawParameter() { Name = "AdvertiserId", Type = System.Data.DbType.Int32, Value = office.AdvertiserId });
            parameters.Add(new RawParameter() { Name = "CityId", Type = System.Data.DbType.Int32, Value = office.CityId });
            parameters.Add(new RawParameter() { Name = "Name", Type = System.Data.DbType.String, Value = office.Name });
            parameters.Add(new RawParameter() { Name = "Address", Type = System.Data.DbType.String, Value = TextHelper.FullCleaner(office.Address) });
            parameters.Add(new RawParameter() { Name = "CityName", Type = System.Data.DbType.String, Value = office.City.Name });
            parameters.Add(new RawParameter() { Name = "PointX", Type = System.Data.DbType.String, Value = office.MapReferenceX });
            parameters.Add(new RawParameter() { Name = "PointY", Type = System.Data.DbType.String, Value = office.MapReferenceY });
            parameters.Add(new RawParameter() { Name = "Featured", Type = System.Data.DbType.String, Value = office.Advertiser.Featured ? 1 : 0 });

            return parameters;
        }

        private List<RawParameter> CreateCouponParameters(Object item)
        {
            Coupon coupon = item as Coupon;
            List<RawParameter> parameters = new List<RawParameter>();

            parameters.Add(new RawParameter() { Name = "CouponId", Type = System.Data.DbType.Int32, Value = coupon.CouponId });
            parameters.Add(new RawParameter() { Name = "AdvertiserId", Type = System.Data.DbType.Int32, Value = coupon.AdvertiserId });
            parameters.Add(new RawParameter() { Name = "Name", Type = System.Data.DbType.String, Value = coupon.Name });
            parameters.Add(new RawParameter() { Name = "Description", Type = System.Data.DbType.String, Value = coupon.Description });
            parameters.Add(new RawParameter() { Name = "Conditions", Type = System.Data.DbType.String, Value = coupon.Conditions });
            parameters.Add(new RawParameter() { Name = "HowToCash", Type = System.Data.DbType.String, Value = coupon.HowToCash });
            parameters.Add(new RawParameter() { Name = "StartDate", Type = System.Data.DbType.Date, Value = coupon.StartDate });
            parameters.Add(new RawParameter() { Name = "National", Type = System.Data.DbType.Int32, Value = coupon.IsNationale ? 1 : 0 });
            parameters.Add(new RawParameter() { Name = "IsClub", Type = System.Data.DbType.Int32, Value = coupon.isClub ? 1 : 0 });

            if (coupon.IsExpirable)
                parameters.Add(new RawParameter() { Name = "EndDate", Type = System.Data.DbType.Date, Value = coupon.EndDate });
            if (coupon.HasPicture)
                parameters.Add(new RawParameter() { Name = "PictureUrl", Type = System.Data.DbType.String, Value = this.CouponUrl(coupon.CouponId) });

            return parameters;
        }

        private List<RawParameter> CreateGalleryParameters(Object item)
        {
            Gallery gallery = item as Gallery;
            List<RawParameter> parameters = new List<RawParameter>();

            parameters.Add(new RawParameter() { Name = "GalleryId", Type = System.Data.DbType.Int32, Value = gallery.GalleryId });
            parameters.Add(new RawParameter() { Name = "AdvertiserId", Type = System.Data.DbType.Int32, Value = gallery.AdvertiserId });
            parameters.Add(new RawParameter() { Name = "Name", Type = System.Data.DbType.String, Value = gallery.Name });

            return parameters;
        }

        private List<RawParameter> CreatePicturesParameters(Object item)
        {
            Picture picture = item as Picture;
            List<RawParameter> parameters = new List<RawParameter>();

            parameters.Add(new RawParameter() { Name = "PictureId", Type = System.Data.DbType.Int32, Value = picture.PictureId });
            parameters.Add(new RawParameter() { Name = "GalleryId", Type = System.Data.DbType.Int32, Value = picture.GalleryId });
            parameters.Add(new RawParameter() { Name = "Description", Type = System.Data.DbType.String, Value = picture.Description });
            parameters.Add(new RawParameter() { Name = "ImageUrl", Type = System.Data.DbType.String, Value = this.PictureUrl(picture.PictureId, true) });
            parameters.Add(new RawParameter() { Name = "ThumbUrl", Type = System.Data.DbType.String, Value = this.PictureUrl(picture.PictureId, false) });

            return parameters;
        }

        private string PictureUrl(int pictureId, bool requestFullPicture)
        {
            return string.Format("{0}?{1}={2}&{3}={4}", this.setup.PictureHandler, QueryKeys.PictureId, pictureId, QueryKeys.IsFullPicture, requestFullPicture);
        }

        private string CouponUrl(int couponId)
        {
            return string.Format("{0}?{1}={2}&{3}={4}", this.setup.CouponHandler, QueryKeys.CouponId, couponId, QueryKeys.CouponSize, Coupon.Sizes.Large);
        }

        private string LogoUrl(int advertiserId)
        {
            return string.Format("{0}?{1}={2}", this.setup.LogoHandler, QueryKeys.AdvertiserId, advertiserId);
        }

        private List<RawParameter> CreateAdvertiserParameters(Object item)
        {
            Advertiser adv = item as Advertiser;
            List<RawParameter> parameters = new List<RawParameter>();

            string filename = string.Empty;
            string[] entries = Directory.GetFiles(this.setup.LogoPath, string.Format("{0}.*", Advertiser.LogoThumbFileNameMask(adv.AdvertiserId)));
            filename = entries.Length > 0 ? entries[0] : string.Empty;

            parameters.Add(new RawParameter() { Name = "AdvertiserId", Type = System.Data.DbType.Int32, Value = adv.AdvertiserId });
            parameters.Add(new RawParameter() { Name = "AdvName", Type = System.Data.DbType.String, Value = adv.Name });
            parameters.Add(new RawParameter() { Name = "Description", Type = System.Data.DbType.String, Value = adv.Description });
            parameters.Add(new RawParameter() { Name = "Address", Type = System.Data.DbType.String, Value = adv.Address });
            parameters.Add(new RawParameter() { Name = "Contact", Type = System.Data.DbType.String, Value = adv.Contact });
            parameters.Add(new RawParameter() { Name = "WebPage", Type = System.Data.DbType.String, Value = adv.WebPage });
            parameters.Add(new RawParameter() { Name = "Facebook", Type = System.Data.DbType.String, Value = adv.Facebook });
            parameters.Add(new RawParameter() { Name = "Twitter", Type = System.Data.DbType.String, Value = adv.Twitter });
            parameters.Add(new RawParameter() { Name = "PointX", Type = System.Data.DbType.Decimal, Value = adv.SqlitePointX });
            parameters.Add(new RawParameter() { Name = "PointY", Type = System.Data.DbType.Decimal, Value = adv.SqlitePointY });
            parameters.Add(new RawParameter() { Name = "CityId", Type = System.Data.DbType.Int32, Value = adv.CityId });
            parameters.Add(new RawParameter() { Name = "CityName", Type = System.Data.DbType.String, Value = adv.City.Name });
            parameters.Add(new RawParameter() { Name = "Phones", Type = System.Data.DbType.String, Value = adv.SqlitePhones });
            parameters.Add(new RawParameter() { Name = "Emails", Type = System.Data.DbType.String, Value = adv.SqliteEmails });
            parameters.Add(new RawParameter() { Name = "Categories", Type = System.Data.DbType.String, Value = adv.SqliteCategories });
            parameters.Add(new RawParameter() { Name = "Tags", Type = System.Data.DbType.String, Value = adv.Tags });
            parameters.Add(new RawParameter() { Name = "PublicityUrl", Type = System.Data.DbType.String, Value = adv.MagazineAnounceUrl });

            if (!string.IsNullOrEmpty(adv.YoutubeVideo))
                parameters.Add(new RawParameter() { Name = "YoutubeVideo", Type = System.Data.DbType.String, Value = adv.YoutubeVideo });

            var featured = adv.FetchTotalFor(AccountConceptKeyEnum.ClubElDirectorio);
            parameters.Add(new RawParameter() { Name = "Featured", Type = System.Data.DbType.Int32, Value = adv.CurrentContract.Featured ? 1 : 0 });

            if (!string.IsNullOrEmpty(filename))
                parameters.Add(new RawParameter() { Name = "LogoUrl", Type = System.Data.DbType.String, Value = this.LogoUrl(adv.AdvertiserId) });

            return parameters;
        }

        CategoryController catController = new CategoryController();

        private string CateogryCommand(string tableName, Category cat)
        {
            string columns = string.Format("{0}, {1}, {2}, {3}, {4}", "CategoryId", "CatName", "Letter", "HasCoupons", "Featured");

            int count = catController.FetchCategoryAdvertisersCount(cat.CategoryId);
            return string.Format("Insert into {0} ({1}) values ({2}, '{3}', '{4}', {5}, {6})",
                tableName,
                columns,
                cat.CategoryId,
                cat.Name,
                cat.Letter,
                cat.HasCoupons ? 1 : 0,
                cat.Featured ? 1 : 0);
        }

        private string CityCommand(string tableName, City city)
        {
            string columns = string.Format("{0}, {1}", "CityId", "CityName");
            return string.Format("Insert into {0} ({1}) values ({2}, '{3}')", tableName, columns, city.CityId, city.Name);
        }
    }
}
