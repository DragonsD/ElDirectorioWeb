using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Dal.Carrier;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Advertiser.Code;
using bsx.DirLaguna.Dal.SelectControllers;
using bsx.DirLaguna.CommonWeb.Session;
using System.Configuration;
using bsx.DirLaguna.Dal.Enum;

namespace bsx.DirLaguna.Advertiser
{
    public partial class AdvertiserForm : SimpleFormPage<bsx.DirLaguna.Dal.Advertiser>
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
                return SessionValues.AdvertiserId;
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
            get { return this.XCKEditorControl.Text; }
            set { this.XCKEditorControl.Text = value; }
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
            if (!this.IsPostBack)
                this.BackHyperlink.NavigateUrl = this.ResolveUrl(Navigation.AccountForm);
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
                if (this.AdvertiserId < 0)
                    this.FiscalDetailPlaceHolder.Visible = false;

                this.MaxCategories = new AccountDetailController().FetchTotalFor(this.AdvertiserId, AccountConceptKeyEnum.Categorias) + 1;
            }
        }

        void RequiredInvoiceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.FiscalDetailPlaceHolder.Visible = this.RequiredInvoiceCheckBox.Checked;
            if (!this.RequiredInvoiceCheckBox.Checked)
            {
                this.FiscalDetailControl.FiscalDetailId = -1;
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
                this.ShowMessageInPrevious("Ha ocurrido un error al guardar los datos.", CommonWeb.Enum.MessageTypes.Error);
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
            this.NameTextBox.MaxLength = bsx.DirLaguna.Dal.Advertiser.Columns.NameColumn.MaxLength;
            this.DescriptionTextBox.MaxLength = bsx.DirLaguna.Dal.Advertiser.Columns.DescriptionColumn.MaxLength;
            this.WebPageTextBox.MaxLength = bsx.DirLaguna.Dal.Advertiser.Columns.WebPageColumn.MaxLength;
            this.FacebookTextBox.MaxLength = bsx.DirLaguna.Dal.Advertiser.Columns.FacebookColumn.MaxLength;
            this.TwitterTextBox.MaxLength = bsx.DirLaguna.Dal.Advertiser.Columns.TwitterColumn.MaxLength;
            this.ZipCodeTextBox.MaxLength = Office.Columns.ZipCodeColumn.MaxLength;

        }

        public override bsx.DirLaguna.Dal.Advertiser Source { get { return new AdvertiserController().FetchById(this.AdvertiserId, this.FranchiseeId); } }

        public override string SuccessUrl { get { return this.ResolveUrl(Navigation.AccountForm); } }

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
                    AccountCarrier = new SimpleAccountDetailCarrier()
                };

                return carrier;
            }
        }

        public override bool SaveMethod()
        {
            decimal? mapX = null, mapY = null;

            if (!string.IsNullOrEmpty(this.MapReferenceTextBox.Text))
            {
                string[] items = this.MapReferenceTextBox.Text.Split(',');
                mapX = decimal.Parse(items[0]);
                mapY = decimal.Parse(items[1]);
            }

            int usedId = -1;
            AdvertiserController controller = new AdvertiserController();
            bool result = false;
            try
            {
                result = controller.Save(this.Carrier, out usedId);
            }
            catch (Exception ex)
            {
                this.Errors = controller.Errors;
                Logger.ErrorException("Error al guardar el anunciante", ex);
                this.Errors.Add("Error al guardar el anunciante.");
            }

            if (!result)
                this.Errors = controller.Errors;

            this.NewAdvertiserId = usedId;

            if (result && !string.IsNullOrEmpty(this.LogoUpload.FileName))
            {
                string fn = System.IO.Path.GetFileName(this.LogoUpload.PostedFile.FileName);
                string[] parts = fn.Split('.');
                string extension = parts[parts.Length - 1];

                //FileHelper.DeleteExistingFiles(this.Server.MapPath(Navigation.Config.LogoPath), bsx.DirLaguna.Dal.Advertiser.LogoFileNameMask(usedId) + ".*");
                //FileHelper.DeleteExistingFiles(this.Server.MapPath(Navigation.Config.LogoPath), bsx.DirLaguna.Dal.Advertiser.LogoFileNameMask(usedId) + ".*");

                //string saveLocation = string.Format("{0}\\{1}.{2}", this.Server.MapPath(Navigation.Config.LogoPath), bsx.DirLaguna.Dal.Advertiser.LogoFileNameMask(usedId), extension.ToLower());
                //string thumbLocation = string.Format("{0}\\{1}.{2}", this.Server.MapPath(Navigation.Config.LogoPath), bsx.DirLaguna.Dal.Advertiser.LogoThumbFileNameMask(usedId), extension.ToLower());
                ////Server.MapPath("Data") + "\\" + fn;
                //try
                //{
                //    this.LogoUpload.PostedFile.SaveAs(saveLocation);

                //    ThumbnailHelper thumb = new ThumbnailHelper(70, 70);
                //    thumb.ProcessNewImage(this.LogoUpload.PostedFile.InputStream, thumbLocation, 180m);

                //}
                //catch (Exception ex)
                //{
                //    Logger.ErrorException("Error al subir el archivo", ex);
                //}

                try
                {
                    ImageServicie.ImageService service = new ImageServicie.ImageService();
                    string[] errors = new string[10];

                    if (!service.SaveLogo(usedId, this.LogoUpload.FileBytes, extension, out errors))
                    {
                        foreach (string item in errors)
                        {
                            this.Errors.Add(item);
                        }
                        result = false;
                    }
                }
                catch (Exception)
                {
                    this.Errors.Add("¡ No esta funcionando el servicio ImageService. !");
                    result = false;
                }
            }

            return result;
        }

        public override void LoadViewFromModel(bsx.DirLaguna.Dal.Advertiser source)
        {
            this.EstadoAdvertiserId = source.EstadoId;
            this.FillComboBox(this.MunicipioAdvertiserDropDownList,
                new MunicipioController().FetchAllByEstadoId(this.EstadoAdvertiserId),
                    Municipio.ColumnNames.MunicipioId,
                    Municipio.ColumnNames.Name);

            this.MunicipioAdvertiserId = source.MunicipioId;
            this.NameTextBox.Text = source.Name;
            this.DescriptionTextBox.Text = source.Description;

            var matriz = source.Matriz;
            if (matriz != null)
            {
                this.StreetTextBox.Text = matriz.Address;
                this.NumberTextBox.Text = matriz.Number;
                this.ZipCodeTextBox.Text = matriz.ZipCode;
                this.NeghbornhodTextBox.Text = matriz.Neibornhod;
            }

            this.WebPageTextBox.Text = source.WebPage;
            this.FacebookTextBox.Text = source.Facebook;
            this.TwitterTextBox.Text = source.Twitter;
            this.MapReferenceTextBox.Text = (source.MapReferenceX.HasValue && source.MapReferenceY.HasValue) ? string.Format("{0},{1}", source.MapReferenceX.Value, source.MapReferenceY.Value) : string.Empty;
            this.AditionalInfo = source.AditionalInfo;

            //this.AccountDetailControl1.AccountDetailId = source.AccountDetailId;
            this.FiscalDetailPlaceHolder.Visible = source.FiscalDetailId.HasValue;
            this.RequiredInvoiceCheckBox.Checked = source.FiscalDetailId.HasValue;

            if (source.FiscalDetail != null)
            {
                this.FiscalDetailControl.FiscalDetailId = (int)source.FiscalDetailId;
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

            //string logoName = source.GetLogo(this.Server.MapPath(Navigation.Config.LogoPath));
            string logoName = string.Format("{0}?{1}={2}", ConfigurationManager.AppSettings["UrlLogoHandler"], QueryKeys.AdvertiserId, this.AdvertiserId);
            this.FullSizeLogoImage.ImageUrl = string.Format("{0}{1}", Navigation.Config.LogoPath, logoName);
            if (string.IsNullOrEmpty(logoName))
                this.FullSizeLogoImage.AlternateText = "[Sin logotipo]";
        }

    }
}