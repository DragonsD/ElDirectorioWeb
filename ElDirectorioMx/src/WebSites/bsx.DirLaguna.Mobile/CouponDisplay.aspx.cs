using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Mobile.Code;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Mobile
{
    public partial class CouponDisplay : System.Web.UI.Page
    {
        public string Letter
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.CategoryLetter]))
                    return this.Request.QueryString[QueryKeys.CategoryLetter];
                return string.Empty;
            }
        }

        public int AdvertiserId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.AdvertiserId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.AdvertiserId]);
                return -1;
            }
        }

        public int CategoryId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request[QueryKeys.CategoryId]))
                    return int.Parse(this.Request[QueryKeys.CategoryId].ToString());
                return -1;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.AdvertiserId > 0)
            {
                string url = string.Format("{0}?{1}={2}&{3}={4}&{5}={6}", Navigation.AdvertiserForm, QueryKeys.AdvertiserId, this.AdvertiserId, QueryKeys.CategoryLetter, this.Letter, QueryKeys.CategoryId,this.CategoryId);
                this.BackUpHyperLink.NavigateUrl = url;
                this.BackBottomHyperLink.NavigateUrl = url;
            }
            else
            {
                this.BackUpHyperLink.NavigateUrl = this.ResolveUrl(Navigation.CouponCategory);
                this.BackBottomHyperLink.NavigateUrl = this.ResolveUrl(Navigation.CouponCategory);
            }

            if (!IsPostBack)
            {
                this.CouponsCtrl1.CategoryId = this.CategoryId;
                CategoryController controller = new CategoryController();
                Category cat = controller.FetchById(this.CategoryId);
                string title = "ElDirectorio.mx - Categorias";

                if (cat != null)
                {
                    title = string.Format("ElDirectorio.mx - Categoria - {0}", cat.Name);
                    this.CategoryNameLabel.Text = cat.Name;
                }

                this.Page.Title = title;

            }
        }
    }
}