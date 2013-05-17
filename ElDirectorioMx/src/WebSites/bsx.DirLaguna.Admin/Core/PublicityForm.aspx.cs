using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using bsx.DirLaguna.Admin.Code;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Dal.SelectControllers;
using bsx.DirLaguna.Dal.Carrier;
using bsx.DirLaguna.CommonWeb.Session;
using System.IO;
using bsx.DirLaguna.Dal.Enum;
using NLog;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class PublicityForm : SimpleFormPage<Publicity>
    {

        public int PublicityId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.PublicityId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.PublicityId]);
                return -1;
            }
        }

        public int Prioridad
        {
            get
            {
                int id = 0;
                int.TryParse(this.PrioridadTextBox.Text, out id);
                return id;
            }
            set
            {
                this.PrioridadTextBox.Text = value.ToString();
            }
        }

        public override string SuccessUrl { get { return this.ResolveUrl(Navigation.PublicityDisplay); } }

        protected override LinkButton PageSaveButton { get { return this.SaveButton; } }

        public override Publicity Source
        {
            get
            {
                Publicity cp = new PublicityController().FetchById(this.PublicityId);
                return cp;
            }
        }

        public override void LoadViewFromModel(Publicity source)
        {
            this.CiudadDropDownList.SelectedIndex = this.CiudadDropDownList.Items.IndexOf(this.CiudadDropDownList.Items.FindByValue(source.CityId.ToString()));
            this.LinkTextBox.Text = source.WebPage;
            this.Prioridad = (int)source.Prioridad;
        }

        public override bool SaveMethod()
        {
            PublicityController controller = new PublicityController();
            int publicityId = -1;
            bool result = controller.Save(this.Carrier, out publicityId);

            if (result && !string.IsNullOrEmpty(this.PublicityFileUpload.FileName))
            {
                string fn = System.IO.Path.GetFileName(this.PublicityFileUpload.PostedFile.FileName);
                string[] parts = fn.Split('.');
                string extension = parts[parts.Length - 1];

                if (extension != "jpg" && extension != "jpeg" && extension != "png")
                {
                    this.Errors.Add("El registro se guardo correctamente pero el archivo debe ser de extension JPG, JPEG o PNG.");
                    return false;
                }

                // Content/Publicity/[CityId]/[IdPublicity].jpg
                string ContentPublicityUrl = string.Format("{0}/{1}", this.Server.MapPath(Navigation.Config.PublicityImagesPath), Publicity.ImageFileUrl(Carrier.CityId));
                if (!Directory.Exists(ContentPublicityUrl))
                    Directory.CreateDirectory(ContentPublicityUrl);

                FileHelper.DeleteExistingFiles(this.Server.MapPath(Navigation.Config.PublicityImagesPath), Publicity.ImageFileName(Carrier.CityId,publicityId) + ".*");

                string saveLocation = string.Format("{0}\\{1}.{2}", this.Server.MapPath(Navigation.Config.PublicityImagesPath), Publicity.ImageFileName(Carrier.CityId,publicityId), "jpg");
                string filePath = string.Format("/Content/Publicity/{0}/{1}.jpg", Carrier.CityId, publicityId);
                controller.UpdatePath(publicityId, filePath);

                try
                {
                    this.PublicityFileUpload.PostedFile.SaveAs(saveLocation);
                    result = true;
                }
                catch (Exception ex)
                {
                    Logger.ErrorException("Error al subir el archivo", ex);
                }
            }

            if (!result)
                this.Errors = controller.Errors;

            return result;
        }

        public override void FillCatalogues()
        {
            FillComboBox(this.CiudadDropDownList,
                new CityController().FechAllActive(AccountConceptKeyEnum.Website),
                "CItyId",
                "Name");
        }

       public override void SetMaxLenght()
        {
            string hola = Convert.ToString(Coupon.Columns.NameColumn.MaxLength);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            this.SaveButton.Click += new EventHandler(SaveButton_Click);
        }

        void SaveButton_Click(object sender, EventArgs e)
        {

        }

        public SimplePublicityCarrier Carrier
        {
            get
            {
                SimplePublicityCarrier carrier = new SimplePublicityCarrier()
                {
                    CityId = int.Parse(this.CiudadDropDownList.SelectedValue),
                    WebPage = LinkTextBox.Text,
                    Prioridad = this.Prioridad
                };

                return carrier;
            }
        }
    }
}