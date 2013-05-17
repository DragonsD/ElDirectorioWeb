using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bsx.DirLaguna.Dal.Enum;

namespace bsx.DirLaguna.Dal
{
    public partial class Franchisee
    {
        public DateTime LastHire
        {
            get
            {
                AdvertiserController controller = new AdvertiserController();
                return controller.LastHireFor(this.FranchiseeId);
            }
        }

        public int AdvertiserCount { get { return this.Advertiser.Where(x => !x.Deleted).Count(); } }

        public int CurrentAdvertiserCount
        {
            get
            {
                ContractController controller = new ContractController();
                return controller.FetchMonthAdvertisers(this.FranchiseeId);
            }
        }
    }
}
