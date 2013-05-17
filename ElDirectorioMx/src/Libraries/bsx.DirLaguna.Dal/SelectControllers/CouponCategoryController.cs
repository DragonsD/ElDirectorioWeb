using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class CouponCategoryController : BaseController<CouponCategory>
    {
        public CouponCategoryController() : base() { }

        public CouponCategoryController(DirLagunaModelDataContext context) : base(context) { }

        public override CouponCategory FetchById(int id) { return this.db.CouponCategories.FirstOrDefault(x => x.CouponCategoryId == id); }

        public override IQueryable<CouponCategory> FetchAll()
        {
            return from x in this.db.CouponCategories
                   where x.Deleted == false
                   select x;
        }

        public CouponCategory FetchRelation(int couponId, int categoryId)
        {
            return this.db.CouponCategories.FirstOrDefault(x => x.Deleted == false && x.CouponId == couponId && x.CategoryId == categoryId);
        }
    }
}
