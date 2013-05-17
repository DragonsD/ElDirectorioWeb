using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Advertiser.Code;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb.Session;

namespace bsx.DirLaguna.Advertiser
{
    public partial class CouponSetDisplay : SimpleDisplayPage
    {
        public int AdvertiserId
        {
            get
            {
                return SessionValues.AdvertiserId;
            }
        }

        public string CouponSetFormUrl(int id) { return string.Format(id <= 0 ? "{0}?{1}={2}" : "{0}?{1}={2}", this.ResolveUrl(Navigation.CouponSetForm), QueryKeys.CouponSetId, id); }

        public string CouponDisplayUrl(int couponSetId) { return string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.CouponDisplay), QueryKeys.CouponSetId, couponSetId); }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.IsPostBack)
            {
                this.NewCouponSetButton.PostBackUrl = this.CouponSetFormUrl(0);
                this.BackButton.PostBackUrl = this.ResolveUrl(Navigation.AccountForm);
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

            var advertiser = new AdvertiserController().FetchById(SessionValues.AdvertiserId);
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