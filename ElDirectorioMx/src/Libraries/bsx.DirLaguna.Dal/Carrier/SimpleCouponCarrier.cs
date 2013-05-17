using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal.Carrier
{
    [Serializable]
    public class SimpleCouponCarrier
    {
        public int CouponId { get; set;}

        public int FranchiseeId { get; set; }

        public int AdvertiserId { get; set; }

        public int CouponSetId { get; set; }

        public int CouponStatusId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Conditions { get; set; }

        public string HowToCash { get; set; }

        public DateTime StartDate { get; set; }

        public bool isClub { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsExpirable { get; set; }

        public bool IsNational { get; set; }

        public int PersonalId { get; set; }

        public List<SimpleCouponCategoryCarrier> Categories { get; set; }

        public SimpleCouponCarrier()
        {
            this.Categories = new List<SimpleCouponCategoryCarrier>();
        }
    }
}
