using System;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Admin.Controls
{
    public partial class AdvertiserInfoControl : System.Web.UI.UserControl
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack && this.AdvertiserId > 0)
            {
                Advertiser adv = new AdvertiserController().FetchById(this.AdvertiserId);

                this.NameLabel.Text = adv.Name;
                this.FranchiseeLabel.Text = adv.Franchisee.Name;

                var minContract = adv.MinCurrentContract;
                var maxContract = adv.MaxCurrentContract;

                this.VigencyLabel.Text = (minContract != null && maxContract != null) ? String.Format("Del {0:d} al {1:d}", adv.MinCurrentContract.ContractDate, adv.MaxCurrentContract.EndDate) : "-";

            }
        }
    }
}