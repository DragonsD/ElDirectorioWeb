using System;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.CommonWeb.Session;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class CouponDisplay : SimpleDisplayPage
    {
        public int MaxCouponsCurrentCouponSet
        {
            get
            {
                CouponController controller = new CouponController();
                return controller.FetchActiveCouponsBycouponSet(this.CouponSetId);
            }

        }

        public int MaxCoupons
        {
            get
            {
                return CouponSet.MaxCoupons;
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

        public int CouponSetId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.CouponSetId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.CouponSetId]);
                return -1;
            }
        }

        public string CouponFormUrl(int id) { return string.Format(id <= 0 ? "{0}?{1}={2}&{3}={4}" : "{0}?{1}={2}&{3}={4}&{5}={6}", this.ResolveUrl(Navigation.CouponForm), QueryKeys.AdvertiserId, this.AdvertiserId, QueryKeys.CouponSetId, this.CouponSetId, QueryKeys.CouponId, id); }

        public override ObjectDataSource MainDataSource { get { return this.CouponDataSource; } }

        public override GridView MainGridView { get { return this.CouponsGridView; } }

        public override LinkButton MainNewButton { get { return this.NewCouponButton; } }

        public override LinkButton MainSearchButton { get { return null; } }

        public override LinkButton MainCleanButton { get { return null; } }

        public override string ElementFormUrl { get { return this.CouponFormUrl(0); } }

        public override void MainGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (!e.CommandName.Equals("delCoupon"))
                return;

            CouponController controller = new CouponController();
            if (!controller.Delete(int.Parse(e.CommandArgument.ToString()), this.PersonalId))
            {
                this.ShowMessage(controller.Errors, CommonWeb.Enum.MessageTypes.Error);
                return;
            }

            this.MainNewButton.Visible = !(this.MaxCouponsCurrentCouponSet >= this.MaxCoupons);

            this.ShowMessage("El cupon ha sido eliminado exitosamente", CommonWeb.Enum.MessageTypes.Success);
            this.CouponsGridView.DataBind();
        

        }

        public override void MainDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["franchiseeId"] = SessionValues.FranchiseeId;
            e.InputParameters["advertiserId"] = this.AdvertiserId;
            e.InputParameters["couponSetId"] = this.CouponSetId;
        }

        public override void CleanFilterControls() { }

        public override void MainGridView_DataBound(object sender, EventArgs e) { }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsPostBack)
            {
                CouponSet cs = new CouponSetController().FetchById(this.CouponSetId);
                if(cs != null)
                    this.CouponSetLabel.Text = cs.Name;

                this.MainNewButton.Visible = !(this.MaxCouponsCurrentCouponSet >= this.MaxCoupons);

                this.BackButton.PostBackUrl = this.ResolveUrl(string.Format("{0}?AdvertiserId={1}", Navigation.CouponSetDisplay, this.AdvertiserId));
            }
        }

    }
}