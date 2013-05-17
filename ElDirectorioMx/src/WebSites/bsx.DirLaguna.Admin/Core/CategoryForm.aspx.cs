using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Admin.Code;
using System.IO;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class CategoryForm : SimpleFormPage<Category>
    {
        public bool HasImage
        {
            get
            {
                if (CategoryId < 0)
                    return false;

                string pathFile = string.Format("{0}/{1}.png", this.ResolveUrl(Navigation.CategoryFiles), CategoryId);

                return File.Exists(this.Server.MapPath(pathFile));
            }
        }

        public string UrlImage
        {
            get
            {
                if (CategoryId < 0)
                    return string.Empty;

                string pathFile = string.Format("{0}/{1}.png", this.ResolveUrl(Navigation.CategoryFiles), CategoryId);

                if (File.Exists(Server.MapPath(pathFile)))
                    return this.ResolveUrl(pathFile);

                return string.Empty;
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

        public override Category Source
        {
            get { return new CategoryController().FetchById(this.CategoryId); }
        }

        public override string SuccessUrl
        {
            get { return this.ResolveUrl(Navigation.CategoriesDisplay); }
        }

        protected override LinkButton PageSaveButton
        {
            get { return this.SaveButton; }
        }

        public override void LoadViewFromModel(Category source)
        {
            this.NameTextBox.Text = source.Name;

            this.Title = string.Format("Editando a {0}", source.Name);
            this.FeaturedCheckbox.Checked = source.Featured;
        }

        public override bool SaveMethod()
        {
            CategoryController controller = new CategoryController();
            bool result = false;
            bool bSaveCategory = false;
            bool bSaveImage = false;
            int newCategoryId = -1;

            try
            {
                if (!controller.Save(this.CategoryId, this.NameTextBox.Text, this.FeaturedCheckbox.Checked, out newCategoryId))
                {
                    this.Errors = controller.Errors;
                }
                bSaveCategory = true;

                if (newCategoryId != -1 && this.CategoryImageFileUpload.HasFile)
                {
                    string pathFile = string.Format("{0}/{1}.png", this.ResolveUrl(Navigation.CategoryFiles), newCategoryId);
                    if (!Directory.Exists(this.Server.MapPath(Navigation.CategoryFiles)))
                        Directory.CreateDirectory(this.Server.MapPath(Navigation.CategoryFiles));

                    //FileHelper.DeleteExistingFiles(this.Server.MapPath(pathFile), "*");

                    this.CategoryImageFileUpload.SaveAs(this.Server.MapPath(pathFile));
                    bSaveImage = true;
                }
                result = true;
            }
            catch (Exception ex)
            {
                Logger.ErrorException("Error al guardar la categoria", ex);
                if (!bSaveCategory)
                    this.Errors.Add("Error al guardar la categoria.");
                else
                {
                    if (!bSaveImage)
                        this.Errors.Add("La categoria se guardo correctamente, pero fallo el guardar la imagen.");
                }
            }
            return result;
        }

        public override void FillCatalogues() { }

        public override void SetMaxLenght()
        {
            this.NameTextBox.MaxLength = Category.Columns.NameColumn.MaxLength;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!this.IsPostBack)
            {
                this.BackButton.PostBackUrl = this.ResolveUrl(Navigation.CategoriesDisplay);
                if (this.CategoryId < 0)
                    this.ImagePlaceHolder.Visible = false;
                else
                {
                    if (!this.HasImage)
                        this.ImagePlaceHolder.Visible = false;
                }

            }
        }
    }
}