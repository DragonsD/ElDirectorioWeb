using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal.Carrier
{
    [Serializable]
    public class SimpleCouponCategoryCarrier
    {
        public int CouponCategoryId { get; set; }

        public int CouponId { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Id { get; set; }

        public bool Deleted { get; set; }

        public bool SelectedRead { get; set; }

        public bool SelectedCurrent { get; set; }

    }
}
