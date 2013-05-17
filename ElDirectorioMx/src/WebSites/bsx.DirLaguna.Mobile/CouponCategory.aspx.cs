using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Mobile.Code;

namespace bsx.DirLaguna.Mobile
{
    public partial class CouponCategory : PublicBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BackUpHyperLink.NavigateUrl = this.ResolveUrl(Navigation.Default);
            this.BackBottomHyperLink.NavigateUrl = this.ResolveUrl(Navigation.Default);

            if (!IsPostBack)
            {
                this.Page.Title = "ElDirectorio.mx - Categorias";

                PublicBasePage p = this.Page as PublicBasePage;
                if (p != null)
                {
                    this.CatCtrl1.CityId = p.SelectedCityId;
                }
                else
                {
                    this.CatCtrl1.CityId = -1;
                }
                this.CatCtrl1.Letter = string.Empty;
            }

        }
    }
}