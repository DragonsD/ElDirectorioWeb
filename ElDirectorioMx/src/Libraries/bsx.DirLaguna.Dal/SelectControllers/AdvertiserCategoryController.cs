using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using bsx.DirLaguna.Dal.Enum;

namespace bsx.DirLaguna.Dal
{
    public partial class AdvertiserCategoryController : FranchiseeBaseController<AdvertiserCategory>
    {
        public AdvertiserCategoryController() : base() { }

        public AdvertiserCategoryController(DirLagunaModelDataContext context) : base(context) { }

        public override AdvertiserCategory FetchById(int id, int franchiseeId)
        {
            return (from x in this.db.AdvertiserCategories
                    where x.AdvertiserCategoryId == id
                    && x.FranchiseeId == franchiseeId

                    select x).FirstOrDefault();
        }

        public override IQueryable<AdvertiserCategory> FetchAll(int franchiseeId)
        {
            return from x in this.db.AdvertiserCategories
                   where x.FranchiseeId == franchiseeId

                   select x;
        }

        public IQueryable<Advertiser> FetchMapAdvertiser(int advertiserId)
        {
            return from x in this.db.Advertiser
                   where !x.Deleted
                   && x.AdvertiserId == advertiserId
                   select x;
        }

        public override AdvertiserCategory FetchById(int id)
        {
            return this.db.AdvertiserCategories.FirstOrDefault(x => x.AdvertiserCategoryId == id);
        }

        public override IQueryable<AdvertiserCategory> FetchAll()
        {
            throw new NotImplementedException();
        }
    }
}
