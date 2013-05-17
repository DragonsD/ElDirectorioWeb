using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb.Session;

namespace bsx.DirLaguna.Advertiser.Controls
{
    public partial class AdvertiserInfoControl : System.Web.UI.UserControl
    {
        public int AdvertiserId
        {
            get
            {
                return SessionValues.AdvertiserId;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack && this.AdvertiserId > 0)
            {
                bsx.DirLaguna.Dal.Advertiser adv = new AdvertiserController().FetchById(this.AdvertiserId);

                this.NameLabel.Text = adv.Name;
                this.FranchiseeLabel.Text = adv.Franchisee.Name;
                this.VigencyLabel.Text = adv.CurrentContract != null ? String.Format("Del {0:d} al {1:d}", adv.CurrentContract.ContractDate, adv.CurrentContract.EndDate) : "-";
            }
        }
    }
}