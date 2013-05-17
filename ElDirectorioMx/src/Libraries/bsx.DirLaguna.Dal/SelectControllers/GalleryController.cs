using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class GalleryController : FranchiseeBaseController<Gallery>
    {
        public override Gallery FetchById(int id)
        {
            //throw new NotImplementedException();
            return (from x in this.db.Galleries
                    where x.GalleryId == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<Gallery> FetchAll(int franchiseeId)
        {
            return (from x in this.db.Galleries where x.FranchiseeId == franchiseeId select x);
        }

        public IQueryable<Gallery> FetchAllByAdvertiserId(int advertiserId, int franchiseeId)
        {
            int allowedItems = new AccountDetailController().FetchTotalFor(advertiserId, Enum.AccountConceptKeyEnum.Galerias);
            if (allowedItems == 0)
                return from x in this.db.Galleries
                       where x.GalleryId < 0
                       select x;

            var galleries=from x in this.db.Galleries
                    where !x.Deleted
                    && x.AdvertiserId == advertiserId
                    && x.FranchiseeId == franchiseeId
                    orderby x.GalleryId ascending
                    select x;

            return galleries.Take(allowedItems);
        }

        public override Gallery FetchById(int id, int franchiseeId)
        {
            return (from x in this.db.Galleries
                    where x.GalleryId == id && x.FranchiseeId == franchiseeId
                    select x).FirstOrDefault();
        }

        public IQueryable<Gallery> FetchAllByAdvertiserId(int advertiserId)
        {
            return (from x in this.db.Galleries
                    where !x.Deleted
                    && x.AdvertiserId == advertiserId
                    select x);
        }

        public override IQueryable<Gallery> FetchAll()
        {
            throw new NotImplementedException();
        }
    }

}
