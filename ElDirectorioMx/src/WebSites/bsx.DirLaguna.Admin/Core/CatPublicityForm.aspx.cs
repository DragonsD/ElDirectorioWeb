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

namespace bsx.DirLaguna.Admin.Core
{
    public partial class CatPublicityForm : SimpleFormPage<CatPublicity>
    {
        public string FlashUrl
        {
            get
            {
                return string.Format("{2}{0}{1}.swf",
                    this.ResolveUrl(Navigation.Config.CatPublicityPath),
                    this.CatPublicityId,
                    Properties.Settings.Default.SiteUrl);
            }
        }

        public string FlashFileName { get { return string.Format("{0}.swf", this.CatPublicityId); } }

        public int CatPublicityId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.CatPublicityId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.CatPublicityId]);
                return -1;
            }
        }

        public int CategoryId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.CategoryId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.CategoryId]);
                return -1;
            }
        }

        public override CatPublicity Source
        {
            get { return new CatPublicityController().FetchById(this.CatPublicityId); }
        }

        public override string SuccessUrl
        {
            get { return string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.CatPublicityDisplay), QueryKeys.CategoryId, this.CategoryId); }
        }

        protected override LinkButton PageSaveButton
        {
            get { return this.SaveButton; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!this.IsPostBack)
                this.BackButton.PostBackUrl = string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.CatPublicityDisplay), QueryKeys.CategoryId, this.CategoryId);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (CategoryId <= 0)
                return;

            Category cat = new CategoryController().FetchById(this.CategoryId);
            this.HeaderLabel.Text = string.Format("Categoria: {0}", cat.Name);

        }

        public override void LoadViewFromModel(CatPublicity source)
        {
            if (source.Deleted)
                return;

            this.NameTextBox.Text = source.Name;
            this.DescriptionTextBox.Text = source.Description;
            this.AvailableCheckBox.Checked = source.Available;
            this.StartTextBox.Text = source.FromDate.ToShortDateString();
            if (source.ToDate.HasValue)
                this.EndTextBox.Text = source.ToDate.Value.ToShortDateString();
        }

        public override bool SaveMethod()
        {
            DateTime? toDate = null;
            if (!string.IsNullOrEmpty(this.EndTextBox.Text))
                toDate = DateTime.Parse(this.EndTextBox.Text);

            CatPublicityController controller = new CatPublicityController();
            bool result = false;
            int catPublicityId;
            result = controller.Save(
                    this.CatPublicityId,
                    this.CategoryId,
                    this.NameTextBox.Text,
                    this.DescriptionTextBox.Text,
                    string.Empty,
                    this.AvailableCheckBox.Checked,
                    DateTime.Parse(this.StartTextBox.Text),
                    toDate,
                    out catPublicityId);

            if (!result)
                return false;

            if (result && !string.IsNullOrEmpty(this.MediaUpload.FileName))
            {
                string fn = System.IO.Path.GetFileName(this.MediaUpload.PostedFile.FileName);
                string[] parts = fn.Split('.');
                string extension = parts[parts.Length - 1];

                if (!extension.ToLower().Equals("swf"))
                {
                    this.Errors.Add("El archivo de medios no es de un tipo apropiado. Utilice *.swf. Los datos se han guardado bien, solo vuelva a subir el archivo");
                    return false;
                }

                FileHelper.DeleteExistingFiles(this.Server.MapPath(Navigation.Config.CatPublicityPath), CatPublicity.CatPublicityFileName(catPublicityId) + ".*");
                string saveLocation = string.Format("{0}\\{1}", this.Server.MapPath(Navigation.Config.CatPublicityPath), CatPublicity.CatPublicityFileName(catPublicityId));

                try
                {
                    this.MediaUpload.PostedFile.SaveAs(saveLocation);
                }
                catch (Exception ex)
                {
                    this.Errors.Add("Ha ocurrido un error al subir el archivo. " + ex.Message);
                }
            }

            return result;
        }

        public override void FillCatalogues()
        {

        }

        public override void SetMaxLenght()
        {
            this.NameTextBox.MaxLength = CatPublicity.Columns.NameColumn.MaxLength;
            this.DescriptionTextBox.MaxLength = CatPublicity.Columns.DescriptionColumn.MaxLength;
        }
    }
}