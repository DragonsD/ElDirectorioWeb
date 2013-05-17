using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Mobile.Code;

namespace bsx.DirLaguna.Mobile
{
    public partial class CouponDetail : System.Web.UI.Page
    {
        public int CategoryId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.CategoryId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.CategoryId]);
                return -1;
            }
        }

        public int CouponId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.CouponId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.CouponId]);
                return -1;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string url = string.Format("{0}?{1}={2}", Navigation.CouponDisplay, QueryKeys.CategoryId, this.CategoryId);
            this.BackUpHyperLink.NavigateUrl = this.ResolveUrl(url);
            this.BackBottomHyperLink.NavigateUrl = this.ResolveUrl(url);

            if (!this.IsPostBack && this.CouponId > 0)
            {
                this.LoadData();
            }
        }

        private void LoadData()
        {

            Coupon cp = new CouponController().FetchById(this.CouponId);
            if (cp == null)
                this.Response.Redirect(this.ResolveUrl(Navigation.Default));

            if (cp.Deleted)
            {
                this.Response.Redirect(this.ResolveUrl(Navigation.Default));
            }

            this.Page.Title = string.Format("Cupón : {0}", cp.Name);
            this.NameLabel.Text = cp.Name;
            this.DescriptionLabel.Text = cp.Description;
            this.HowToCashLabel.Text = cp.HowToCash;
            this.ConditionsLabel.Text = cp.Conditions;
            this.StartLabel.Text = cp.StartDate.ToShortDateString();

            if (cp.IsExpirable)
            {
                this.EndDateDiv.Visible = true;
                this.EndLabel.Text = cp.EndDate.ToShortDateString();
            }
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
            this.CouponProviderLinkButton.PostBackUrl = this.ResolveUrl(string.Format("{0}?{1}={2}", Navigation.AdvertiserForm, QueryKeys.AdvertiserId, cp.AdvertiserId));
            //this.CategoryCouponsLabel.Text = "Otros cupones relacionados";
            //this.CategoryRelatedCouponsCtrl.DataSource = cp.RelatedCoupons;
            //this.CategoryRelatedCouponsCtrl.Refresh();

        }

    }
}