using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Public.Code;
using bsx.DirLaguna.CommonWeb.Base;

namespace bsx.DirLaguna.Public
{
    public partial class CategoryDisplay : PublicBasePage
    {
        public string RequestedLetter
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.CategoryLetter]))
                    return this.Request.QueryString[QueryKeys.CategoryLetter];
                return string.Empty;
            }
        }

        public string RequestedCategory
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.CategoryId]))
                    return this.Request.QueryString[QueryKeys.CategoryId];
                return string.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            this.LetterCategoriesControl1.CategorySelected += new EventHandler<Dal.Arguments.IntEventArgs>(LetterCategoriesControl1_CategorySelected);

            if (!this.IsPostBack)
            {
                this.LetterCategoriesControl1.CityId = this.SelectedCityId;
                this.AdvertiserDisplay1.CityId = this.SelectedCityId;

                if (!string.IsNullOrEmpty(this.RequestedLetter))
                    this.RequestedCategoryHidden.Value = this.RequestedLetter;
                else
                {
                    if (!string.IsNullOrEmpty(this.RequestedCategory))
                        this.RequestedCategoryHidden.Value = this.RequestedCategory;
                }
                this.Page.Title = string.Format(!string.IsNullOrEmpty(this.RequestedLetter) ? "Negocios con Categoria que comienza con {0}" : "Directorio", 
                                                    this.RequestedLetter);
                this.LetterCategoriesControl1.RefreshData();
                this.RefreshAdvertiserList();
            }

            if (!this.IsPostBack && !string.IsNullOrEmpty(this.RequestedCategory))
                this.RequestedCategoryHidden.Value = this.RequestedCategory;
        }

        void LetterCategoriesControl1_CategorySelected(object sender, Dal.Arguments.IntEventArgs e)
        {
            this.Page.Title = string.Format("{0}", new CategoryController().FetchById(e.Value).Name);

            this.RequestedCategoryHidden.Value = e.Value.ToString();
            this.RefreshAdvertiserList();            
        }

        private void RefreshAdvertiserList()
        {
            this.AdvertiserDisplay1.RefreshData(this.RequestedCategoryHidden.Value);
        }
    }
}