using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Public.Code;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb.Base;
using System.Web.Configuration;
using bsx.DirLaguna.CommonWeb;

namespace bsx.DirLaguna.Public
{
    public partial class HomeForm : PublicBasePage
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
                if (this.Request.UrlReferrer != null)
                {
                    if (!this.Request.UrlReferrer.AbsoluteUri.ToLower().StartsWith(WebConfigurationManager.AppSettings["UrlSitePublicDomain"].ToLower()))
                    {
                        this.Response.Redirect(WebConfigurationManager.AppSettings["UrlSiteDesktop"]);
                    }
                }

                this.LetterCategoriesControl1.CityId = this.SelectedCityId;
                this.AdvertiserDisplay1.CityId = this.SelectedCityId;
                //this.AdvertiserDisplay2.CityId = this.SelectedCityId;
                //this.MapCtrl1.CityId = this.SelectedCityId;

                if (!string.IsNullOrEmpty(this.RequestedLetter))
                    this.RequestedCategoryHidden.Value = this.RequestedLetter;
                else
                {
                    if (!string.IsNullOrEmpty(this.RequestedCategory))
                        this.RequestedCategoryHidden.Value = this.RequestedCategory;
                }
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
            this.AdvertiserDisplay1.StartIndex = 0;
            this.AdvertiserDisplay1.RefreshData(this.RequestedCategoryHidden.Value);
            //this.AdvertiserDisplay2.StartIndex = 0;
            //this.AdvertiserDisplay2.RefreshData(this.RequestedCategoryHidden.Value);
            //this.MapCtrl1.RefreshData(this.RequestedCategoryHidden.Value);
        }
    }
}
