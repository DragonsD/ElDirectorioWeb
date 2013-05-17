using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class OfficeController : FranchiseeBaseController<Office>
    {
        public OfficeController() : base() { }

        public OfficeController(DirLagunaModelDataContext context) : base(context) { }

        public override Office FetchById(int id, int franchiseeId)
        {
            return (from x in this.db.Offices
                    where x.OfficeId == id
                    && x.FranchiseeId == franchiseeId

                    select x).FirstOrDefault();
        }

        public override IQueryable<Office> FetchAll(int franchiseeId)
        {
            return from x in this.db.Offices
                   where !x.Deleted
                         && x.FranchiseeId == franchiseeId

                   select x;
        }

        public IQueryable<Office> FetchAdvertiserOffices(int advertiserId, int franchiseeId)
        {
            return from x in this.db.Offices
                   where x.AdvertiserId == advertiserId
                   && !x.Deleted
                   && !x.Advertiser.Deleted
                   && x.FranchiseeId == franchiseeId

                   select x;
        }

        public IQueryable<Office> FetchAdvertiserOffices(int advertiserId)
        {
            int allowedOffices = new AccountDetailController().FetchTotalFor(advertiserId, Enum.AccountConceptKeyEnum.Sucursales);

            var query = from x in this.db.Offices
                        where x.AdvertiserId == advertiserId
                        && !x.Deleted
                        && !x.Advertiser.Deleted
                        orderby x.AdvertiserId descending
                        select x;

            return query.Take(allowedOffices + 1);
        }

        public override Office FetchById(int id)
        {
            return (from x in this.db.Offices
                    where x.OfficeId == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<Office> FetchAll()
        {
            return from x in this.db.Offices
                   where !x.Deleted
                   select x;
        }

        public Office FetchMatriz(int advertiserId)
        {
            return (from x in this.db.Offices
                    where !x.Deleted
                    && x.AdvertiserId == advertiserId
                    && x.Name.Equals(Office.MatrizName)
                    orderby x.OfficeId ascending
                    select x).FirstOrDefault();
        }
    }
}
