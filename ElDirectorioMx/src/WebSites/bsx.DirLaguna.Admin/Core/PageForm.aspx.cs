using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Admin.Code;
using System.IO;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class PageForm : SimpleFormPage<bsx.DirLaguna.Dal.Page>
    {
        public int PageId
        {
            get
            {
                if (this.Request.QueryString[QueryKeys.PageId] != null)
                    return int.Parse(this.Request.QueryString[QueryKeys.PageId]);
                return -1;
            }
        }

        public int PageNumber
        {
            get { return int.Parse(this.PageNumberTextBox.Text); }
            set
            {
                this.PageNumberTextBox.Text = value.ToString();
            }
        }

        public int NewPageId
        {
            get
            {
                if (this.ViewState["pageid"] != null)
                    return (int)this.ViewState["pageid"];
                return -1;
            }
            set { this.ViewState["pageid"] = value; }
        }

        public string PathImage
        {
            get
            {
                return string.Format("{0}\\page_{1}.jpg", Navigation.Config.MagazinePath, this.PageId);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.SaveAndAddAnnounceButton.Click += new EventHandler(SaveAndAddAnnounceButton_Click);
            this.PageNumberTextBox.Attributes.Add("onkeypress", "javascript:return solonumeros(event)");

            if (!IsPostBack)
            {
                this.PageNumber = new PageController().FetchNumberMax();
                this.BackButton.PostBackUrl = this.ResolveUrl(Navigation.PageDisplay);
                this.PageImage.ImageUrl = this.PathImage;
            }
        }

        void SaveAndAddAnnounceButton_Click(object sender, EventArgs e)
        {
            if (!SaveMethod())
            {
                this.ShowMessage(this.Errors, CommonWeb.Enum.MessageTypes.Error);
                return;
            }
 
            this.ShowMessageInPrevious("La operación se ha completado exitosamente", CommonWeb.Enum.MessageTypes.Success);
            this.Response.Redirect(string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.AnnounceForm), QueryKeys.PageId, this.NewPageId));
        }

        public override bsx.DirLaguna.Dal.Page Source
        {
            get { return new PageController().FetchById(this.PageId); }
        }

        public override string SuccessUrl
        {
            get { return this.ResolveUrl(Navigation.PageDisplay); }
        }

        protected override LinkButton PageSaveButton
        {
            get { return this.SaveButton; }
        }

        public override void LoadViewFromModel(bsx.DirLaguna.Dal.Page source)
        {
            this.TitleLabel.Text = string.Format("Editando Pagina {0}", source.Number);
            this.PageNumber = source.Number;
        }

        public override bool SaveMethod()
        {
            PageController controller = new PageController();
            int newPageId = -1;
            bool bResult = false;

            if (string.IsNullOrEmpty(this.PictureUpload.FileName))
            {
                this.ShowMessage("Debe proporcionar una imagen.", CommonWeb.Enum.MessageTypes.Error);
                return bResult;
            }

            string fn = System.IO.Path.GetFileName(this.PictureUpload.PostedFile.FileName);
            string[] parts = fn.Split('.');
            string extension = parts[parts.Length - 1];

            if (extension != "jpg" && extension != "jpeg")
            {
                this.ShowMessage("La extension debe ser jpg o jpeg.", CommonWeb.Enum.MessageTypes.Error);
                return bResult;
            }

            try
            {
                if (!controller.Save(this.PageId, this.PageNumber, out newPageId))
                {
                    foreach (string item in controller.Errors)
                    {
                        this.Errors.Add(item);
                    }

                    return false;
                }

                string pathFileSave = string.Format("{0}\\page_{1}.{2}", this.Server.MapPath(Navigation.Config.MagazinePath), newPageId, "jpg");
                this.NewPageId = newPageId;

                this.PictureUpload.SaveAs(pathFileSave);
                this.ShowMessage("El registro se ha guardado satisfactoriamente.", CommonWeb.Enum.MessageTypes.Success);
                bResult = true;

            }
            catch (Exception ex)
            {
                Logger.ErrorException(string.Format("Error al subir el archivo. {0}", ex.Message), ex);
                this.Errors.Add("Error al subir el archivo.");
                bResult = false;
            }

            return bResult;
        }

        public override void FillCatalogues() { }

        public override void SetMaxLenght() { }


    }
}