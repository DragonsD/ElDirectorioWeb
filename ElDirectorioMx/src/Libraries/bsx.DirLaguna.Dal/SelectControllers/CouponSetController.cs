using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class CouponSetController : BaseController<CouponSet>
    {
        public override CouponSet FetchById(int id)
        {
            return (from x in this.db.CouponSets where x.CouponSetId == id select x).FirstOrDefault();
        }

        public override IQueryable<CouponSet> FetchAll()
        {
            return from x in this.db.CouponSets where !x.Deleted select x;
        }

        public IQueryable<CouponSet> FetchAdvertiserCouponSets(int franchiseeId, int advertiserId)
        {
            return from x in this.db.CouponSets
                   where !x.Deleted
                   && x.FranchiseeId == franchiseeId
                   && x.AdvertiserId == advertiserId
                   select x;
        }

        public IQueryable<CouponSet> FetchActiveCouponSets(int advertiserId)
        {
            return from x in this.db.CouponSets
                   where !x.Deleted
                   && x.AdvertiserId == advertiserId
                   select x;
        }

        public CouponSet fetchActiveCouponSets(int advertiserId)
        {
            return (from x in this.db.CouponSets
                   where !x.Deleted
                   && x.AdvertiserId == advertiserId
                   select x).FirstOrDefault();
        }

    }
}
