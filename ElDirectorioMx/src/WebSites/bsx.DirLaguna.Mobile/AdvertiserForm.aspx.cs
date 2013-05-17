using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Mobile.Code;
using bsx.DirLaguna.CommonWeb;

namespace bsx.DirLaguna.Mobile
{
    public partial class AdvertiserForm : System.Web.UI.Page
    {
        public string RequestedLetter
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request[QueryKeys.CategoryLetter]))
                    return this.Request[QueryKeys.CategoryLetter];
                return string.Empty;
            }
        }

        public string CityId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request[QueryKeys.CityId]))
                    return this.Request[QueryKeys.CityId];
                return string.Empty;
            }
        }

        public string Keywords
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request[QueryKeys.Keywords]))
                    return this.Request[QueryKeys.Keywords];
                return string.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (this.Request.UrlReferrer != null)
                //    this.BackButton.PostBackUrl = this.Request.UrlReferrer.ToString();
                //else
                if (!string.IsNullOrEmpty(this.RequestedLetter))
                {
                    this.BackUpHyperLink.NavigateUrl = string.Format("{0}?{1}={2}&{3}={4}", this.ResolveUrl(Navigation.AdvertiserDisplay), QueryKeys.CategoryId, this.AdvertiserDetailControl1.CategoryId, QueryKeys.CategoryLetter, this.AdvertiserDetailControl1.Letter);
                    this.BackBottomHyperLink.NavigateUrl = string.Format("{0}?{1}={2}&{3}={4}", this.ResolveUrl(Navigation.AdvertiserDisplay), QueryKeys.CategoryId, this.AdvertiserDetailControl1.CategoryId, QueryKeys.CategoryLetter, this.AdvertiserDetailControl1.Letter);
                }
                else
                {
                    this.BackUpHyperLink.NavigateUrl = string.Format("{0}?{1}={2}&{3}={4}", this.ResolveUrl(Navigation.AdvertiserDisplay), QueryKeys.CityId, this.CityId, QueryKeys.Keywords, this.Keywords);
                    this.BackBottomHyperLink.NavigateUrl = string.Format("{0}?{1}={2}&{3}={4}", this.ResolveUrl(Navigation.AdvertiserDisplay), QueryKeys.CityId, this.CityId, QueryKeys.Keywords, this.Keywords);
                }
            }
        }
    }
}