using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class Category
    {
        public int LiveAdvertisers
        {
            get
            {
                CategoryController controller = new CategoryController();
                return controller.FetchCategoryAdvertisersCount(this.CategoryId);
            }
        }

        public bool HasCoupons
        {
            get
            {
                CouponController controller = new CouponController();
                return controller.FetchAvailableCoupons(this.CategoryId, -1).Count() > 0;
            }
        }

    }
}
