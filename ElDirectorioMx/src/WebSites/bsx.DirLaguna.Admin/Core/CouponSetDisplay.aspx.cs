using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.CommonWeb.Session;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class CouponSetDisplay : SimpleDisplayPage
    {
        public int AdvertiserId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.AdvertiserId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.AdvertiserId]);
                return -1;
            }
        }

        public string CouponSetFormUrl(int id) { return string.Format(id <= 0 ? "{0}?{1}={2}" : "{0}?{1}={2}&{3}={4}", this.ResolveUrl(Navigation.CouponSetForm), QueryKeys.AdvertiserId, this.AdvertiserId, QueryKeys.CouponSetId, id); }

        public string CouponDisplayUrl(int couponSetId) { return string.Format("{0}?{1}={2}&{3}={4}", this.ResolveUrl(Navigation.CouponDisplay), QueryKeys.AdvertiserId, this.AdvertiserId, QueryKeys.CouponSetId, couponSetId); }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.IsPostBack)
            {
                this.NewCouponSetButton.PostBackUrl = this.CouponSetFormUrl(0);
                this.BackButton.PostBackUrl = this.ResolveUrl(Navigation.AdvertiserDisplay);
                var advertiser = new AdvertiserController().FetchById(this.AdvertiserId);
                this.MainNewButton.Visible = advertiser.AllowNewCouponSet;
            }
        }

        public override ObjectDataSource MainDataSource { get { return this.CouponSetDataSource; } }

        public override GridView MainGridView { get { return this.CouponSetGridView; } }

        public override LinkButton MainNewButton
        {
            get { return this.NewCouponSetButton; }
        }

        public override LinkButton MainSearchButton { get { return null; } }

        public override LinkButton MainCleanButton { get { return null; } }

        public override string ElementFormUrl { get { return this.CouponSetFormUrl(0); } }

        public override void MainGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (!e.CommandName.Equals("delCouponSet"))
                return;

            CouponSetController controller = new CouponSetController();
            if (!controller.Delete(int.Parse(e.CommandArgument.ToString()), this.PersonalId))
            {
                this.ShowMessage(controller.Errors, CommonWeb.Enum.MessageTypes.Error);
                return;
            }

            var advertiser = new AdvertiserController().FetchById(this.AdvertiserId);
            this.MainNewButton.Visible = advertiser.AllowNewCouponSet;

            this.ShowMessage("El cuponera ha sido eliminada exitosamente", CommonWeb.Enum.MessageTypes.Success);
            this.CouponSetGridView.DataBind();
        
        }

        public override void MainDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["franchiseeId"] = SessionValues.FranchiseeId;
            e.InputParameters["advertiserId"] = this.AdvertiserId;
        }

        public override void CleanFilterControls() { }

        public override void MainGridView_DataBound(object sender, EventArgs e) { }
    }
}