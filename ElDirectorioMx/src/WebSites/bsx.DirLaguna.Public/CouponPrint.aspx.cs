using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Public.Code;

namespace bsx.DirLaguna.Public
{
    public partial class CouponPrint : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                this.LoadData();
            }
        }

        private void LoadData()
        {
            Coupon cp = new CouponController().FetchById(this.CouponId);
            if (cp == null)
                this.Response.Redirect(this.ResolveUrl(Navigation.HomeForm));

            this.Page.Title = cp.Name;
            this.TitleLabel.Text = cp.Name;

            this.ConditionsLabel.Text = cp.Conditions;
            this.conditionsDiv.Visible = !string.IsNullOrEmpty(cp.Conditions);

            if (cp.HasPicture)
                this.CouponImage.ImageUrl = CouponHelper.CouponPictureUrl(this.CouponId, Coupon.Sizes.Large);
        }

    }
}