using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Advertiser.Code;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb.Session;

namespace bsx.DirLaguna.Advertiser
{
    public partial class AccountForm : BasePage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.IsPostBack)
            {
                bsx.DirLaguna.Dal.Advertiser adv = new AdvertiserController().FetchById(SessionValues.AdvertiserId);
                this.MyAccountHyperLink1.NavigateUrl = this.ResolveUrl(Navigation.MyAccountForm);

                this.AdvertiserHyperlink.NavigateUrl = this.ResolveUrl(Navigation.AdvertiserForm);
                this.BannersPlaceHolder.Visible = false;
                if (adv.FetchTotalFor(Dal.Enum.AccountConceptKeyEnum.Banner1) > 0
                    || adv.FetchTotalFor(Dal.Enum.AccountConceptKeyEnum.Banner2) > 0
                    || adv.FetchTotalFor(Dal.Enum.AccountConceptKeyEnum.Banner3) > 0
                    || adv.FetchTotalFor(Dal.Enum.AccountConceptKeyEnum.Banner4) > 0)
                {
                    this.BannerHyperLink.Visible = true;
                    this.BannerHyperLink.NavigateUrl = this.ResolveUrl(Navigation.BannerRequestForm);
                    this.BannersPlaceHolder.Visible = true;
                }

                this.GalleriesPlaceHolder.Visible = false;
                if (adv.FetchTotalFor(Dal.Enum.AccountConceptKeyEnum.Galerias) > 0)
                {
                    this.GalleriesHyperLink.Visible = true;
                    this.GalleriesHyperLink.NavigateUrl = this.ResolveUrl(Navigation.GalleryDisplay);
                    this.GalleriesPlaceHolder.Visible = true;
                }
                this.CouponsPlaceHolder.Visible = false;
                if (adv.FetchTotalFor(Dal.Enum.AccountConceptKeyEnum.Coupons) > 0)
                {
                    this.CouponSetHyperLink.Visible = true;
                    this.CouponSetHyperLink.NavigateUrl = this.ResolveUrl(Navigation.CouponSetDisplay);
                    this.CouponsPlaceHolder.Visible = true;
                }
                this.OfficesPlaceHolder.Visible = false;
                if (adv.FetchTotalFor(Dal.Enum.AccountConceptKeyEnum.Sucursales) > 0)
                {
                    this.OfficesHyperLink.Visible = true;
                    this.OfficesHyperLink.NavigateUrl = this.ResolveUrl(Navigation.OfficeDisplay);
                    this.OfficesPlaceHolder.Visible = true;
                }

                this.LogoutHyperLink.NavigateUrl = this.ResolveUrl(Navigation.Logout);
            }
        }

    }
}