using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Public.Code;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Public.Controls
{
    public partial class RelatedCouponsControl : System.Web.UI.UserControl
    {
        public List<Coupon> DataSource { set { this.CouponsDataList.DataSource = value; } }

        public void Refresh() { this.CouponsDataList.DataBind(); }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string CouponPictureUrl(int couponId, string size)
        {
            return CouponHelper.CouponPictureUrl(couponId, size);
        }

    }
}