using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Advertiser.Code;
using bsx.DirLaguna.CommonWeb;
using System.IO;
using bsx.DirLaguna.Dal.Carrier;
using bsx.DirLaguna.CommonWeb.Session;
using System.Configuration;

namespace bsx.DirLaguna.Advertiser
{
    public partial class CouponForm : SimpleFormPage<Coupon>
    {
        private string urlImageBase
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("UrlCouponHandler"); ;
            }
        }

        public string ImageUrl
        {
            get
            {
                return ResolveUrl(string.Format("{0}?{1}={2}&{3}={4}", urlImageBase, QueryKeys.CouponId, this.CouponId, "size", "medium"));
                //return string.Format("{0}{1}.jpg", this.ResolveUrl(Navigation.Config.CouponImagesPath), Coupon.ImageFileNameMedium(this.AdvertiserId, this.CouponSetId, this.CouponId));
            }
        }

        public int AdvertiserId
        {
            get
            {
                return SessionValues.AdvertiserId;
            }
        }

        public int CouponSetId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.CouponSetId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.CouponSetId]);
                return -1;
            }
        }

        public int CouponId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.CouponId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.CouponId]);
                return -1;
            }
        }

        public string ExtensionBase { get { return "jpg"; } }

        public override Coupon Source
        {
            get
            {
                Coupon cp = new CouponController().FetchById(this.CouponId);
                return cp;
            }
        }

        public List<SimpleCouponCategoryCarrier> CouponCategories
        {
            get
            {
                if (this.ViewState["Categories"] != null)
                    return (List<SimpleCouponCategoryCarrier>)this.ViewState["Categories"];
                return new List<SimpleCouponCategoryCarrier>();
            }
            set { this.ViewState["Categories"] = value; }
        }


        public override string SuccessUrl { get { return string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.CouponDisplay), QueryKeys.CouponSetId, this.CouponSetId); } }

        protected override LinkButton PageSaveButton { get { return this.SaveButton; } }

        public override void LoadViewFromModel(Coupon source)
        {
            this.StatusDropDownList.SelectedIndex = this.StatusDropDownList.Items.IndexOf(this.StatusDropDownList.Items.FindByValue(source.CouponStatusId.ToString()));
            this.NameTextBox.Text = source.Name;
            this.DescriptionTextBox.Text = source.Description;
            this.ConditionsTextBox.Text = source.Conditions;
            this.HowToCashTextBox.Text = source.HowToCash;
            this.StartDateTextBox.Text = source.StartDate.ToShortDateString();
            this.EndDateTextBox.Text = source.EndDate.ToShortDateString();
            this.ExpirableCheckBox.Checked = source.IsExpirable;
            this.ImagePlaceHolder.Visible = source.HasPicture;

            foreach (var item in source.CouponCategory.Where(x => x.Deleted == false))
            {
                SimpleCouponCategoryCarrier carrier = new SimpleCouponCategoryCarrier()
                {
                    CouponCategoryId = item.CouponCategoryId,
                    CouponId = item.CouponId,
                    CategoryId = item.CategoryId,
                    Name = item.Category.Name,
                    Id = Guid.NewGuid().ToString(),
                    Deleted = false
                };

                this.CouponCategories.Add(carrier);
            }

            this.RefreshCategories();
        }

        public override bool SaveMethod()
        {
            CouponController controller = new CouponController();
            int usedId = -1;
            bool result = controller.Save(this.Carrier, out usedId);

            if (result && !string.IsNullOrEmpty(this.ImageFileUpload.FileName))
            {
                string fn = System.IO.Path.GetFileName(this.ImageFileUpload.PostedFile.FileName);
                string[] parts = fn.Split('.');
                string extension = parts[parts.Length - 1];

                if (extension != "jpg" && extension != "jpeg" && extension != "png")
                {
                    this.Errors.Add("El registro se guardo correctamente pero el archivo debe ser de extension JPG, JPEG o PNG.");
                    return false;
                }

                //// Content/CouponSets/[AdvertiserId]/[CouponSetId]/[IdCoupon]_[small | medium | large].jpg
                //string ContentCouponSetsUrl = string.Format("{0}/{1}", this.Server.MapPath(Navigation.Config.CouponImagesPath), Coupon.ImageFileUrl(this.AdvertiserId, this.CouponSetId));
                //if (!Directory.Exists(ContentCouponSetsUrl))
                //    Directory.CreateDirectory(ContentCouponSetsUrl);

                //FileHelper.DeleteExistingFiles(this.Server.MapPath(Navigation.Config.CouponImagesPath), Coupon.ImageFileNameSmall(this.AdvertiserId, this.CouponSetId, usedId) + ".*");
                //FileHelper.DeleteExistingFiles(this.Server.MapPath(Navigation.Config.CouponImagesPath), Coupon.ImageFileNameMedium(this.AdvertiserId, this.CouponSetId, usedId) + ".*");
                //FileHelper.DeleteExistingFiles(this.Server.MapPath(Navigation.Config.CouponImagesPath), Coupon.ImageFileNameLarge(this.AdvertiserId, this.CouponSetId, usedId) + ".*");

                //string saveLocationSmall = string.Format("{0}\\{1}.{2}", this.Server.MapPath(Navigation.Config.CouponImagesPath), Coupon.ImageFileNameSmall(this.AdvertiserId, this.CouponSetId, usedId), "jpg");
                //string saveLocationMedium = string.Format("{0}\\{1}.{2}", this.Server.MapPath(Navigation.Config.CouponImagesPath), Coupon.ImageFileNameMedium(this.AdvertiserId, this.CouponSetId, usedId), "jpg");
                //string saveLocationLarge = string.Format("{0}\\{1}.{2}", this.Server.MapPath(Navigation.Config.CouponImagesPath), Coupon.ImageFileNameLarge(this.AdvertiserId, this.CouponSetId, usedId), "jpg");

                ////string thumbLocation = string.Format("{0}\\{1}.{2}", this.Server.MapPath(Navigation.Config.LogoPath), bsx.DirLaguna.Dal.Advertiser.LogoThumbFileNameMask(usedId), extension.ToLower());
                ////Server.MapPath("Data") + "\\" + fn;
                //try
                //{
                //    //this.LogoUpload.PostedFile.SaveAs(saveLocationSmall);

                //    ThumbnailHelper thumb = new ThumbnailHelper(70, 70);
                //    thumb.ProcessNewImage(this.ImageFileUpload.PostedFile.InputStream, saveLocationSmall, 150m);
                //    thumb.ProcessNewImage(this.ImageFileUpload.PostedFile.InputStream, saveLocationMedium, 195m);
                //    thumb.ProcessNewImage(this.ImageFileUpload.PostedFile.InputStream, saveLocationLarge, 600m);
                //    result = controller.UpdateHasImage(usedId);
                //}
                //catch (Exception ex)
                //{
                //    Logger.ErrorException("Error al subir el archivo", ex);
                //}

                ImageServicie.ImageService service = new ImageServicie.ImageService();
                string[] errors = new string[10];

                if (!service.SaveCouponSet(this.AdvertiserId, this.CouponSetId, usedId, this.ImageFileUpload.FileBytes, ExtensionBase, out errors))
                {
                    this.ShowMessage(errors, CommonWeb.Enum.MessageTypes.Error);
                }

            }

            if (!result)
                this.Errors = controller.Errors;

            return result;
        }

        public override void FillCatalogues()
        {
            FillComboBox(this.StatusDropDownList,
                new CouponStatusController().FetchAll().OrderBy(x => x.Description),
                "CouponStatusId",
                "Description");

            FillComboBox(this.CategoryDropDownList,
                new CategoryController().FetchAdvertiserCategories(this.AdvertiserId).OrderBy(x => x.Name),
                Category.ColumnNames.CategoryId,
                Category.ColumnNames.Name);

        }

        public override void SetMaxLenght()
        {
            this.NameTextBox.MaxLength = Coupon.Columns.NameColumn.MaxLength;

        }

        public SimpleCouponCarrier Carrier
        {
            get
            {
                SimpleCouponCarrier carrier = new SimpleCouponCarrier()
                {
                    CouponId = this.CouponId,
                    FranchiseeId = SessionValues.FranchiseeId,
                    AdvertiserId = this.AdvertiserId,
                    CouponSetId = this.CouponSetId,
                    CouponStatusId = int.Parse(this.StatusDropDownList.SelectedValue),
                    Name = this.NameTextBox.Text,
                    Description = this.DescriptionTextBox.Text,
                    Conditions = this.ConditionsTextBox.Text,
                    HowToCash = this.HowToCashTextBox.Text,
                    StartDate = DateTime.Parse(this.StartDateTextBox.Text),
                    EndDate = DateTime.Parse(this.EndDateTextBox.Text),
                    IsExpirable = this.ExpirableCheckBox.Checked,
                    PersonalId = SessionValues.PersonalId
                };
                carrier.Categories = this.CouponCategories;

                return carrier;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.CategoryButton.Click += new EventHandler(CategoryButton_Click);
            this.CategoryGridView.RowCommand += new GridViewCommandEventHandler(CategoryGridView_RowCommand);

            if (!IsPostBack)
            {
                Coupon cupon = new CouponController().FetchById(this.CouponId);
                this.CouponNameLabel.Text = cupon == null ? string.Empty : cupon.Name;

                this.BackButton.PostBackUrl = this.Request.UrlReferrer != null ? this.Request.UrlReferrer.ToString() : string.Format("{0}?&CouponSetId={1}", Navigation.CouponDisplay, this.CouponSetId);
            }
        }
        
        void CategoryGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (!e.CommandName.Equals("DelItem"))
                return;

            var uid = e.CommandArgument.ToString();
            var index = this.CouponCategories.FindIndex(x => x.Id == uid);
            if (index < 0)
                return;
            this.CouponCategories[index].Deleted = true;

            this.RefreshCategories();
        }

        public void RefreshCategories()
        {
            this.CategoryGridView.DataSource = from x in this.CouponCategories where x.Deleted == false select x;
            this.CategoryGridView.DataBind();
        }

        void CategoryButton_Click(object sender, EventArgs e)
        {
            var catId = int.Parse(this.CategoryDropDownList.SelectedValue);
            Category ct = new CategoryController().FetchById(catId);

            SimpleCouponCategoryCarrier carrier = new SimpleCouponCategoryCarrier()
            {
                CouponId = this.CouponId,
                CategoryId = catId,
                Name = ct.Name,
                Id = Guid.NewGuid().ToString(),
                Deleted = false
            };

            this.CouponCategories.Add(carrier);
            this.RefreshCategories();
            this.CategoryDropDownList.SelectedIndex = 0;
        }
    }
}