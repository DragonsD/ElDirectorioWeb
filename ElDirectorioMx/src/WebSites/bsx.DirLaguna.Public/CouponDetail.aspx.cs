using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Public.Code;
using System.Configuration;

namespace bsx.DirLaguna.Public
{
    public partial class CouponDetail : PublicBasePage
    {
        public int CouponId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.CouponId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.CouponId]);
                return -1;
            }
        }

        public string PrintUrl
        {
            get
            {
                return string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.CouponPrint), QueryKeys.CouponId, this.CouponId);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.IsPostBack && this.CouponId > 0)
                this.LoadData();
        }

        private void LoadData()
        {
            Coupon cp = new CouponController().FetchById(this.CouponId);
            if (cp == null)
                this.Response.Redirect(this.ResolveUrl(Navigation.HomeForm));

            this.Page.Title = cp.Name;
            //this.NameLabel.Text = cp.Name;
            this.DescriptionLabel.Text = cp.Description;
            this.HowToCashLabel.Text = cp.HowToCash;
            this.ConditionsLabel.Text = cp.Conditions;
            this.ConditionsDiv.Visible = !string.IsNullOrEmpty(cp.Conditions);
            this.HowToCashDiv.Visible = !string.IsNullOrEmpty(cp.HowToCash);

            if (cp.HasPicture)
                this.couponImage.ImageUrl = CouponHelper.CouponPictureUrl(this.CouponId, Coupon.Sizes.Large);

            var otherCoupons = cp.OtherAdvertiserCoupons;
            if (otherCoupons.Count > 1)
            {
                this.OtherCouponsParagraph.Visible = true;
                this.AdvertiserCouponsLabel.Text = string.Format("Más cupones de {0}", cp.Advertiser.Name);
                this.AdvertiserRelatedCouponsCtrl.DataSource = otherCoupons;
                this.AdvertiserRelatedCouponsCtrl.Refresh();
            }

            this.CouponProviderLinkButton.Text = cp.Advertiser.Name;
            this.CouponProviderLinkButton.PostBackUrl = this.ResolveUrl(string.Format("{0}?{1}={2}", Navigation.DetailForm, QueryKeys.AdvertiserId, cp.AdvertiserId));

        }
    }
}