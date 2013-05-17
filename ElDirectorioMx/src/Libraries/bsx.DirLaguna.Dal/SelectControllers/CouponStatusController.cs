using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class CouponStatusController : BaseController<CouponStatus>
    {
        public override CouponStatus FetchById(int id)
        {
            return (from x in this.db.CouponStatus
                    where !x.Deleted
                    && x.CouponStatusId == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<CouponStatus> FetchAll()
        {
            return from x in this.db.CouponStatus
                   where !x.Deleted
                   select x;
        }
    }
}
