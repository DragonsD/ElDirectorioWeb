using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class AnnounceController : FranchiseeBaseController<Announce>
    {
        public override Announce FetchById(int id, int franchiseeId)
        {
            return (from x in this.db.Announces
                    where x.AnnounceId == id
                          && x.FranchiseeId == franchiseeId
                    select x).FirstOrDefault();
        }

        public override IQueryable<Announce> FetchAll(int franchiseeId)
        {
            return from x in this.db.Announces
                   where !x.Deleted
                         && x.FranchiseeId == franchiseeId
                   select x;
        }

        public IQueryable<Announce> FetchAllByPageId(int pageId, int franchiseeId)
        {
            return from x in this.db.Announces
                   where !x.Deleted &&
                   x.PageId == pageId
                   && x.FranchiseeId == franchiseeId
                   select x;
        }

        public IQueryable<Announce> FetchAllByAdvertiserId(int advertiserId, int franchiseeId)
        {
            return from x in this.db.Announces
                   where !x.Deleted &&
                   x.AdvertiserId == advertiserId
                   && x.FranchiseeId == franchiseeId
                   select x;
        }


        public override Announce FetchById(int id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Announce> FetchAll()
        {
            throw new NotImplementedException();
        }
    }
}
