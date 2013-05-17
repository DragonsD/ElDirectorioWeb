using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Dal.Carrier;
using bsx.DirLaguna.Dal.SelectControllers;
using bsx.DirLaguna.CommonWeb.Session;
using bsx.DirLaguna.Dal.Enum;
using System.IO;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class AdvertiserForm : SimpleFormPage<Advertiser>
    {
        public List<SimpleTableCarrier> Emails
        {
            get
            {
                if (this.ViewState["Emails"] != null)
                    return (List<SimpleTableCarrier>)this.ViewState["Emails"];
                return new List<SimpleTableCarrier>();
            }
            set { this.ViewState["Emails"] = value; }
        }

        public List<SimpleCouponCategoryCarrier> CouponCategories
        {
            get
            {
                if (this.ViewState["couCategories"] != null)
                    return (List<SimpleCouponCategoryCarrier>)this.ViewState["couCategories"];
                return new List<SimpleCouponCategoryCarrier>();
            }
            set { this.ViewState["couCategories"] = value; }
        }

        public List<SimpleTableCarrier> Categories
        {
            get
            {
                if (this.ViewState["Categories"] != null)
                    return (List<SimpleTableCarrier>)this.ViewState["Categories"];
                return new List<SimpleTableCarrier>();
            }
            set { this.ViewState["Categories"] = value; }
        }

        public int NewAdvertiserId
        {
            get
            {
                if (this.ViewState["newAdvertiserId"] != null)
                    return (int)this.ViewState["newAdvertiserId"];
                return -1;
            }
            set { this.ViewState["newAdvertiserId"] = value; }
        }

        public int CouponId
        {
            get
            {
                if (this.ViewState["newCouponId"] != null)
                    return (int)this.ViewState["newCouponId"];
                return -1;
            }
            set { this.ViewState["newCouponId"] = value; }
        }

        public List<SimpleTableCarrier> Phones
        {
            get
            {
                if (this.ViewState["Phones"] != null)
                    return (List<SimpleTableCarrier>)this.ViewState["Phones"];
                return new List<SimpleTableCarrier>();
            }
            set { this.ViewState["Phones"] = value; }
        }

        public List<SimpleTableCarrier> Tags
        {
            get
            {
                if (this.ViewState["Tags"] != null)
                    return (List<SimpleTableCarrier>)this.ViewState["Tags"];
                return new List<SimpleTableCarrier>();
            }
            set { this.ViewState["Tags"] = value; }
        }

        public int AdvertiserId
        {
            get
            {
                if (this.Request.QueryString[QueryKeys.AdvertiserId] != null)
                    return int.Parse(this.Request.QueryString[QueryKeys.AdvertiserId]);
                return -1;
            }
        }

        public int EstadoAdvertiserId
        {
            get
            {
                if (this.EstadoAdvertiserDropDownList.SelectedIndex == 0)
                    return -1;
                return int.Parse(this.EstadoAdvertiserDropDownList.SelectedValue.ToString());
            }
            set
            {
                ListItem item = this.EstadoAdvertiserDropDownList.Items.FindByValue(value.ToString());
                if (item == null)
                    this.EstadoAdvertiserDropDownList.SelectedIndex = 0;
                else
                    this.EstadoAdvertiserDropDownList.SelectedIndex = this.EstadoAdvertiserDropDownList.Items.IndexOf(item);
            }
        }

        public int MunicipioAdvertiserId
        {
            get
            {
                if (this.MunicipioAdvertiserDropDownList.SelectedIndex == 0)
                    return -1;
                return int.Parse(this.MunicipioAdvertiserDropDownList.SelectedValue.ToString());
            }
            set
            {
                ListItem item = this.MunicipioAdvertiserDropDownList.Items.FindByValue(value.ToString());
                if (item == null)
                    this.MunicipioAdvertiserDropDownList.SelectedIndex = 0;
                else
                    this.MunicipioAdvertiserDropDownList.SelectedIndex = this.MunicipioAdvertiserDropDownList.Items.IndexOf(item);
            }
        }

        public string AditionalInfo
        {
            get
            {
                return this.XCKEditorControl.Text;
            }
            set
            {
                this.XCKEditorControl.Text = value;
            }
        }

        public SimpleFiscalDetailCarrier FiscalCarrier
        {
            get
            {
                if (this.FiscalDetailPlaceHolder.Visible)
                    return this.FiscalDetailControl.Carrier;
                return null;
            }
        }

        public int MaxCategories
        {
            get
            {
                if (this.ViewState["maxCategories"] != null)
                    return (int)this.ViewState["maxCategories"];
                return -1;
            }
            set { this.ViewState["maxCategories"] = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.BackButton.PostBackUrl = this.ResolveUrl(Navigation.AdvertiserDisplay);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.RequiredInvoiceCheckBox.CheckedChanged += new EventHandler(RequiredInvoiceCheckBox_CheckedChanged);
            this.AddPhoneButton.Click += new EventHandler(AddPhoneButton_Click);
            this.EmailButton.Click += new EventHandler(EmailButton_Click);
            this.CategoryButton.Click += new EventHandler(CategoryButton_Click);
            this.TagButton.Click += new EventHandler(TagButton_Click);

            this.SavenOfficeButton.Click += new EventHandler(SavenOfficeButton_Click);

            this.PhoneGridView.RowCommand += new GridViewCommandEventHandler(PhoneGridView_RowCommand);
            this.CategoryGridView.RowCommand += new GridViewCommandEventHandler(CategoryGridView_RowCommand);
            this.EmailGridView.RowCommand += new GridViewCommandEventHandler(EmailGridView_RowCommand);
            this.TagsGridView.RowCommand += new GridViewCommandEventHandler(TagsGridView_RowCommand);

            //this.EstadoDropDownList.SelectedIndexChanged += new EventHandler(EstadoDropDownList_SelectedIndexChanged);
            this.EstadoAdvertiserDropDownList.SelectedIndexChanged += new EventHandler(EstadoAdvertiserDropDownList_SelectedIndexChanged);
            if (!this.IsPostBack)
            {
                this.Emails = new List<SimpleTableCarrier>();
                this.Categories = new List<SimpleTableCarrier>();
                this.Tags = new List<SimpleTableCarrier>();
                this.Phones = new List<SimpleTableCarrier>();
                this.CouponCategories = new List<SimpleCouponCategoryCarrier>();
                if (this.AdvertiserId < 0)
                {
                    this.FiscalDetailPlaceHolder.Visible = false;
                    this.PromoClubCheckBox.Visible = false;
                    this.lbPromo.Visible = false;
                }

                this.MaxCategories = new AccountDetailController().FetchTotalFor(this.AdvertiserId, AccountConceptKeyEnum.Categorias) + 1;

                this.AditionalInfoP.Visible = new AccountDetailController().FetchTotalFor(this.AdvertiserId, Dal.Enum.AccountConceptKeyEnum.RichContent) > 0;
            }
        }

        void RequiredInvoiceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.FiscalDetailPlaceHolder.Visible = this.RequiredInvoiceCheckBox.Checked;
            if (!this.RequiredInvoiceCheckBox.Checked)
            {
                this.FiscalDetailControl.FiscalDeailId = -1;
                this.FiscalDetailControl.LoadData();
            }
        }

        void EstadoAdvertiserDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cities = new MunicipioController().FetchAllByEstadoId(this.EstadoAdvertiserId);
            this.FillComboBox(this.MunicipioAdvertiserDropDownList,
                    from x in cities orderby x.Name ascending select x,
                    Municipio.ColumnNames.MunicipioId,
                    Municipio.ColumnNames.Name);
        }



        void SavenOfficeButton_Click(object sender, EventArgs e)
        {

            if (!this.SaveMethod())
            {
                //this.Errors.Add("Ha ocurrido un error al guardar los datos.");
                this.ShowMessage(this.Errors, CommonWeb.Enum.MessageTypes.Error);
                return;
            }
            this.ShowMessageInPrevious("Los datos se han guardado correctamente", CommonWeb.Enum.MessageTypes.Success);
            if (this.AdvertiserId > 0)
                this.Response.Redirect(string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.OfficeDisplay), QueryKeys.AdvertiserId, this.AdvertiserId));
            this.Response.Redirect(string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.OfficeDisplay), QueryKeys.AdvertiserId, this.NewAdvertiserId));
        }

        private void RefreshGrid(GridView grid, List<SimpleTableCarrier> source)
        {
            grid.DataSource = from x in source where !x.Deleted select x;
            grid.DataBind();
        }

        private void DeleteGridItem(Guid guid, List<SimpleTableCarrier> data)
        {
            int index = data.FindIndex(x => x.UiId == guid);
            if (index >= 0)
                data[index].Deleted = true;
        }

        void TagsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            this.DeleteGridItem(new Guid(e.CommandArgument.ToString()), this.Tags);
            this.RefreshGrid(this.TagsGridView, this.Tags);
        }

        void EmailGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            this.DeleteGridItem(new Guid(e.CommandArgument.ToString()), this.Emails);
            this.RefreshGrid(this.EmailGridView, this.Emails);
        }

        void CategoryGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            this.DeleteGridItem(new Guid(e.CommandArgument.ToString()), this.Categories);
            this.RefreshGrid(this.CategoryGridView, this.Categories);
        }

        void PhoneGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            this.DeleteGridItem(new Guid(e.CommandArgument.ToString()), this.Phones);
            this.RefreshGrid(this.PhoneGridView, this.Phones);
        }

        void TagButton_Click(object sender, EventArgs e)
        {
            this.Tags.Add(new SimpleTableCarrier() { Description = this.TagTextBox.Text });
            this.RefreshGrid(this.TagsGridView, this.Tags);
            this.TagTextBox.Text = string.Empty;
        }

        void CategoryButton_Click(object sender, EventArgs e)
        {
            var categories = (from x in this.Categories where x.Deleted == false select x).Count();
            if (categories >= this.MaxCategories)
            {
                this.ShowMessage("Tu cuenta solo contempla " + this.MaxCategories.ToString() + " categorias. No es posible completar la operación", CommonWeb.Enum.MessageTypes.Notice);
                return;
            }

            this.Categories.Add(new SimpleTableCarrier() { ExternalId = int.Parse(this.CategoryDropDownList.SelectedValue), Description = this.CategoryDropDownList.SelectedItem.Text });
            this.RefreshGrid(this.CategoryGridView, this.Categories);
            this.CategoryDropDownList.SelectedIndex = 0;
        }

        void EmailButton_Click(object sender, EventArgs e)
        {
            this.Emails.Add(new SimpleTableCarrier() { Description = this.EmailTextBox.Text });
            this.RefreshGrid(this.EmailGridView, this.Emails);
            this.EmailTextBox.Text = string.Empty;
        }

        void AddPhoneButton_Click(object sender, EventArgs e)
        {
            this.Phones.Add(new SimpleTableCarrier() { Description = this.PhoneTextBox.Text, TypeId = int.Parse(this.PhoneTypeDropDownList.SelectedValue), TypeDescription = this.PhoneTypeDropDownList.SelectedItem.Text });
            this.RefreshGrid(this.PhoneGridView, this.Phones);
            this.PhoneTextBox.Text = string.Empty;
            this.PhoneTypeDropDownList.SelectedIndex = 0;
        }

        public override void FillCatalogues()
        {
            var cities = from x in new CityController().FetchAll()
                         orderby x.Name
                         select x;

            this.FillComboBox(this.PhoneTypeDropDownList,
                    new PhoneTypeController().FetchAll(),
                    PhoneType.ColumnNames.PhoneTypeId,
                    PhoneType.ColumnNames.Name);

            var categories = from x in new CategoryController().FetchAll()
                             orderby x.Name
                             select x;

            this.FillComboBox(this.CategoryDropDownList,
                    categories,
                    Category.ColumnNames.CategoryId,
                    Category.ColumnNames.Name);

            this.FillComboBox(this.EstadoAdvertiserDropDownList,
                    new EstadoController().FetchAll(),
                    Estado.ColumnNames.EstadoId,
                    Estado.ColumnNames.Name);

        }

        public override void SetMaxLenght()
        {
            this.NameTextBox.MaxLength = Advertiser.Columns.NameColumn.MaxLength;
            this.DescriptionTextBox.MaxLength = Advertiser.Columns.DescriptionColumn.MaxLength;
            this.WebPageTextBox.MaxLength = Advertiser.Columns.WebPageColumn.MaxLength;
            this.FacebookTextBox.MaxLength = Advertiser.Columns.FacebookColumn.MaxLength;
            this.TwitterTextBox.MaxLength = Advertiser.Columns.TwitterColumn.MaxLength;
            this.ZipCodeTextBox.MaxLength = Office.Columns.ZipCodeColumn.MaxLength;
        }

        public override Advertiser Source { get { return new AdvertiserController().FetchById(this.AdvertiserId, this.FranchiseeId); } }

        public override string SuccessUrl { get { return this.ResolveUrl(Navigation.AdvertiserDisplay); } }

        protected override LinkButton PageSaveButton { get { return this.SaveButton; } }

        private SimpleAdvertiserCarrier Carrier
        {
            get
            {
                decimal? mapX = null, mapY = null;

                if (!string.IsNullOrEmpty(this.MapReferenceTextBox.Text))
                {
                    string[] items = this.MapReferenceTextBox.Text.Split(',');
                    mapX = decimal.Parse(items[0]);
                    mapY = decimal.Parse(items[1]);
                }

                SimpleAdvertiserCarrier carrier = new SimpleAdvertiserCarrier()
                {
                    UserId = SessionValues.UserId,
                    AdvertiserId = this.AdvertiserId,
                    Name = this.NameTextBox.Text,
                    Description = this.DescriptionTextBox.Text,
                    PromocionesClub = this.PromocionesTextbox.Text,
                    Street = this.StreetTextBox.Text,
                    Number = this.NumberTextBox.Text,
                    ZipCode = this.ZipCodeTextBox.Text,
                    Neighbornhod = this.NeghbornhodTextBox.Text,
                    WebPage = this.WebPageTextBox.Text,
                    Facebook = this.FacebookTextBox.Text,
                    Twitter = this.TwitterTextBox.Text,
                    mapX = mapX,
                    mapY = mapY,
                    Phones = this.Phones,
                    Emails = this.Emails,
                    Categories = this.Categories,
                    Tags = this.Tags,
                    AditionalInfo = this.AditionalInfo,
                    FranchiseeId = this.FranchiseeId,
                    PersonalId = this.PersonalId,
                    FiscalCarrier = this.FiscalCarrier,
                    EstadoId = this.EstadoAdvertiserId,
                    MunicipioId = this.MunicipioAdvertiserId,
                    YouTubeVideo = this.YoutubeTextBox.Text,
                    AccountCarrier = new SimpleAccountDetailCarrier()
                };
                return carrier;
            }
        }

        private SimpleCouponCarrier promo
        {
            get
            {
                if (PromoClubCheckBox.Checked == true && PromoClubCheckBox.Visible == true)
                {
                    SimpleCouponCarrier carrier = new SimpleCouponCarrier()
                    {
                        CouponId = this.CouponId,
                        FranchiseeId = SessionValues.FranchiseeId,
                        AdvertiserId = this.AdvertiserId,
                        CouponSetId = this.Source.ActiveCouponSet.CouponSetId,
                        CouponStatusId = 1,
                        Name = "Promoción del Club",
                        Description = this.Promo1TextBox.Text,
                        Conditions = this.Condition1TextBox.Text,
                        HowToCash = "Presentando este Cupón",
                        StartDate = DateTime.Parse(this.StartDateTextBox.Text),
                        EndDate = DateTime.Parse(this.EndDateTextBox.Text),
                        IsExpirable = true,
                        IsNational = false,
                        PersonalId = SessionValues.PersonalId,
                        isClub = true
                    };

                    var cat = this.Source.AdvertiserCategory.Where(x => x.AdvertiserId == this.AdvertiserId).FirstOrDefault();
                    Category ct = new CategoryController().FetchById(cat.CategoryId);

                    SimpleCouponCategoryCarrier carrierCa = new SimpleCouponCategoryCarrier()
                    {
                        CouponId = this.CouponId,
                        CategoryId = cat.CategoryId,
                        Name = ct.Name,
                        Id = Guid.NewGuid().ToString(),
                        Deleted = false
                    };

                    this.CouponCategories.Add(carrierCa);
                    carrier.Categories = this.CouponCategories;
                    return carrier;
                }
                else
                {
                    return promo;
                }
            }
        }

        public override bool SaveMethod()
        {
            Logger.Info("Tratando de guardar un anuncinate");

            int usedId = -1;
            AdvertiserController controller = new AdvertiserController();
            bool result = false;
            try
            {
                Logger.Info("AdvertiserController.Save()");
                result = controller.Save(this.Carrier, out usedId);
                Logger.Info("AdvertiserController.Save() -> correcto");
            }
            catch (Exception ex)
            {
                this.Errors = controller.Errors;
                Logger.ErrorException("Error al guardar el anunciante", ex);
                this.Errors.Add("Error al guardar el anunciante.");
            }

            this.NewAdvertiserId = usedId;

            if (result && !string.IsNullOrEmpty(this.LogoUpload.FileName))
            {
                Logger.Info("Trabajando con la imagen");

                string fn = System.IO.Path.GetFileName(this.LogoUpload.PostedFile.FileName);
                string[] parts = fn.Split('.');
                string extension = parts[parts.Length - 1];

                FileHelper.DeleteExistingFiles(this.Server.MapPath(Navigation.Config.LogoPath), Advertiser.LogoFileNameMask(usedId) + ".*");
                FileHelper.DeleteExistingFiles(this.Server.MapPath(Navigation.Config.LogoPath), Advertiser.LogoFileNameMask(usedId) + ".*");

                string saveLocation = string.Format("{0}\\{1}.{2}", this.Server.MapPath(Navigation.Config.LogoPath), Advertiser.LogoFileNameMask(usedId), extension.ToLower());
                string thumbLocation = string.Format("{0}\\{1}.{2}", this.Server.MapPath(Navigation.Config.LogoPath), Advertiser.LogoThumbFileNameMask(usedId), extension.ToLower());
                //Server.MapPath("Data") + "\\" + fn;
                try
                {
                    Logger.Info("Por guardar la imagen");
                    this.LogoUpload.PostedFile.SaveAs(saveLocation);

                    Logger.Info("Guardando el thumbnail");
                    ThumbnailHelper thumb = new ThumbnailHelper(70, 70);
                    thumb.ProcessNewImage(this.LogoUpload.PostedFile.InputStream, thumbLocation, 180m);
                    Logger.Info("Procesamiento de la imagen correcto");

                }
                catch (Exception ex)
                {
                    Logger.ErrorException("Error al subir el archivo", ex);
                    Logger.Error(ex.Message);
                }
            }

            if (!result)
                this.Errors = controller.Errors;

            if (result && !string.IsNullOrEmpty(this.Promo1File.FileName) && promo != null)
            {
                CouponController cont = new CouponController();
                int couId = -1;
                result = cont.Save(this.promo, out couId);

                string fn = System.IO.Path.GetFileName(this.Promo1File.PostedFile.FileName);
                string[] parts = fn.Split('.');
                string extension = parts[parts.Length - 1];

                if (extension != "jpg" && extension != "jpeg" && extension != "png")
                {
                    this.Errors.Add("El registro se guardo correctamente pero el archivo debe ser de extension JPG, JPEG o PNG.");
                    return false;
                }

                // Content/CouponSets/[AdvertiserId]/[CouponSetId]/[IdCoupon]_[small | medium | large].jpg
                string ContentCouponSetsUrl = string.Format("{0}/{1}", this.Server.MapPath(Navigation.Config.CouponImagesPath), Coupon.ImageFileUrl(this.AdvertiserId, this.promo.CouponSetId));
                if (!Directory.Exists(ContentCouponSetsUrl))
                    Directory.CreateDirectory(ContentCouponSetsUrl);

                FileHelper.DeleteExistingFiles(this.Server.MapPath(Navigation.Config.CouponImagesPath), Coupon.ImageFileNameSmall(this.AdvertiserId, this.promo.CouponSetId, couId) + ".*");
                FileHelper.DeleteExistingFiles(this.Server.MapPath(Navigation.Config.CouponImagesPath), Coupon.ImageFileNameMedium(this.AdvertiserId, this.promo.CouponSetId, couId) + ".*");
                FileHelper.DeleteExistingFiles(this.Server.MapPath(Navigation.Config.CouponImagesPath), Coupon.ImageFileNameLarge(this.AdvertiserId, this.promo.CouponSetId, couId) + ".*");

                string saveLocationSmall = string.Format("{0}\\{1}.{2}", this.Server.MapPath(Navigation.Config.CouponImagesPath), Coupon.ImageFileNameSmall(this.AdvertiserId, this.promo.CouponSetId, couId), "jpg");
                string saveLocationMedium = string.Format("{0}\\{1}.{2}", this.Server.MapPath(Navigation.Config.CouponImagesPath), Coupon.ImageFileNameMedium(this.AdvertiserId, this.promo.CouponSetId, couId), "jpg");
                string saveLocationLarge = string.Format("{0}\\{1}.{2}", this.Server.MapPath(Navigation.Config.CouponImagesPath), Coupon.ImageFileNameLarge(this.AdvertiserId, this.promo.CouponSetId, couId), "jpg");

                string thumbLocation = string.Format("{0}\\{1}.{2}", this.Server.MapPath(Navigation.Config.LogoPath), Advertiser.LogoThumbFileNameMask(usedId), extension.ToLower());
                //Server.MapPath("Data") + "\\" + fn;
                try
                {
                    //this.LogoUpload.PostedFile.SaveAs(saveLocationSmall);

                    ThumbnailHelper thumb = new ThumbnailHelper(70, 70);
                    thumb.ProcessNewImage(this.Promo1File.PostedFile.InputStream, saveLocationSmall, 150m);
                    thumb.ProcessNewImage(this.Promo1File.PostedFile.InputStream, saveLocationMedium, 195m);
                    thumb.ProcessNewImage(this.Promo1File.PostedFile.InputStream, saveLocationLarge, 600m);
                    result = cont.UpdateHasImage(couId, this.PersonalId);
                }
                catch (Exception ex)
                {
                    Logger.ErrorException("Error al subir el archivo", ex);
                }
            }

            return result;
        }

        public override void LoadViewFromModel(Advertiser source)
        {
            this.EstadoAdvertiserId = source.EstadoId;
            this.FillComboBox(this.MunicipioAdvertiserDropDownList,
                new MunicipioController().FetchAllByEstadoId(this.EstadoAdvertiserId),
                    Municipio.ColumnNames.MunicipioId,
                    Municipio.ColumnNames.Name);

            this.MunicipioAdvertiserId = source.MunicipioId;
            this.NameTextBox.Text = source.Name;
            this.DescriptionTextBox.Text = source.Description;

            var contractToday = source.CurrentContract;
            
            if (contractToday.Featured == false)
            {
                this.PromoClubCheckBox.Visible = false;
                this.PromoClubCheckBox.Checked = false;
                this.lbPromo.Visible = false;
            }
            else 
            {
                this.PromoClubCheckBox.Checked = true;
                this.PromoClubCheckBox.Visible = true;
                this.PromoClubPlaceHolder.Visible = true;
                this.PromocionesTextbox.Text = source.PromocionesClub;
            }

            var matriz = source.Matriz;
            if (matriz != null)
            {
                this.StreetTextBox.Text = matriz.Address;
                this.NumberTextBox.Text = matriz.Number;
                this.ZipCodeTextBox.Text = matriz.ZipCode;
                this.NeghbornhodTextBox.Text = matriz.Neibornhod;
            }

            if (source.CouponClubCount >= 1) 
            {
                this.PromoClubCheckBox.Visible = false;
                this.PromoClubCheckBox.Checked = false;
                this.PromoClubPlaceHolder.Visible = false;
                this.PromocionesTextbox.Visible = false;
                this.lbPromo.Visible = false;
            }

            this.WebPageTextBox.Text = source.WebPage;
            this.FacebookTextBox.Text = source.Facebook;
            this.TwitterTextBox.Text = source.Twitter;
            this.MapReferenceTextBox.Text = (source.MapReferenceX.HasValue && source.MapReferenceY.HasValue) ? string.Format("{0},{1}", source.MapReferenceX.Value, source.MapReferenceY.Value) : string.Empty;
            this.AditionalInfo = source.AditionalInfo;
            this.YoutubeTextBox.Text = source.YoutubeVideo;

            //this.AccountDetailControl1.AccountDetailId = source.AccountDetailId;
            this.FiscalDetailPlaceHolder.Visible = source.FiscalDetailId.HasValue;
            this.RequiredInvoiceCheckBox.Checked = source.FiscalDetailId.HasValue;

            var currentFeaturedCount = (from x in source.Office where x.Deleted == false && x.Featured select x).Count();
            var allowedFeaturedOfcices = new AccountDetailController().FetchTotalFor(this.AdvertiserId, AccountConceptKeyEnum.ClubElDirectorio);

            if (source.FiscalDetail != null)
            {
                this.FiscalDetailControl.FiscalDeailId = (int)source.FiscalDetailId;
                this.FiscalDetailControl.LoadData();
                this.RequiredInvoiceCheckBox.Checked = true;
            }

            foreach (var item in source.Phone.Where(x => !x.Deleted))
                this.Phones.Add(new SimpleTableCarrier() { Id = item.PhoneId, Description = item.PhoneNumber, TypeId = item.PhoneTypeId, TypeDescription = item.PhoneType.Name });
            this.RefreshGrid(this.PhoneGridView, this.Phones);

            foreach (var item in source.Email.Where(x => !x.Deleted))
                this.Emails.Add(new SimpleTableCarrier() { Id = item.EmailId, Description = item.Address });
            this.RefreshGrid(this.EmailGridView, this.Emails);

            foreach (var item in source.AdvertiserCategory.Where(x => !x.Deleted))
                this.Categories.Add(new SimpleTableCarrier() { ExternalId = item.CategoryId, Description = item.Category.Name, Id = item.AdvertiserCategoryId });
            this.RefreshGrid(this.CategoryGridView, this.Categories);

            foreach (var item in source.Tag.Where(x => !x.Deleted))
                this.Tags.Add(new SimpleTableCarrier() { Id = item.TagId, Description = item.Name });
            this.RefreshGrid(this.TagsGridView, this.Tags);

            string logoName = source.GetLogo(this.Server.MapPath(Navigation.Config.LogoPath));
            this.FullSizeLogoImage.ImageUrl = string.Format("{0}{1}", Navigation.Config.LogoPath, logoName);
            if (string.IsNullOrEmpty(logoName))
                this.FullSizeLogoImage.AlternateText = "[Sin logotipo]";

            this.Title = string.Format("Editando a {0}", source.Name);
        }

        protected void PromoClubCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PromoClubPlaceHolder.Visible = PromoClubCheckBox.Checked;
        }


    }
}