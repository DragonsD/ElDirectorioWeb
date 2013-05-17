using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Public.Code;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal;
using System.Configuration;

namespace bsx.DirLaguna.Public
{
    public partial class DetailForm : PublicBasePage
    {
        //public string RequestedLetter
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.CategoryLetter]))
        //            return this.Request.QueryString[QueryKeys.CategoryLetter];
        //        return string.Empty;
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.LetterCategoriesControl1.CategorySelected += new EventHandler<Dal.Arguments.IntEventArgs>(LetterCategoriesControl1_CategorySelected);
            this.PreRender += new EventHandler(DetailForm_PreRender);
        }

        void DetailForm_PreRender(object sender, EventArgs e)
        {
            Advertiser data = this.AdvertiserDetailControl1.Source;
            this.AdvertiserHeaderControl1.Name = data.Name;
            this.AdvertiserHeaderControl1.LogoUrl = string.Format("{1}?AdvertiserId={0}", data.AdvertiserId, ConfigurationManager.AppSettings["UrlLogoHandler"]);
        }

        //void LetterCategoriesControl1_CategorySelected(object sender, Dal.Arguments.IntEventArgs e)
        //{
        //    this.Response.Redirect(string.Format("{0}?{1}={2}&{3}={4}", this.ResolveUrl(Navigation.CategoryDisplay), QueryKeys.CategoryLetter, this.RequestedLetter, QueryKeys.CategoryId, e.Value));
        //}

    }
}