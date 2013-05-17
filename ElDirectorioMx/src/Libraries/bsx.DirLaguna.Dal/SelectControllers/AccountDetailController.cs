using System;
using System.Collections.Generic;
using System.Linq;
using bsx.DirLaguna.Dal.Enum;

namespace bsx.DirLaguna.Dal
{
    public partial class AccountDetailController : BaseController<AccountDetail>
    {
        public AccountDetailController()
            : base()
        {

        }

        public AccountDetailController(DirLagunaModelDataContext context) :
            base(context)
        {

        }

        public override AccountDetail FetchById(int id)
        {
            return (from x in this.db.AccountDetails
                    where !x.Deleted && x.AccountDetailId == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<AccountDetail> FetchAll()
        {
            return (from x in this.db.AccountDetails
                    where !x.Deleted
                    select x);
        }

        public List<AccountDetail> FetchAllByContractId(int contractId)
        {
            return (from x in this.db.AccountDetails
                    where !x.Deleted && x.ContractId == contractId
                    select x).ToList();
        }

        public AccountDetail FetchByContractIdAndAccountConceptId(int contractId, int accountConceptId)
        {
            return (from x in this.db.AccountDetails
                    where !x.Deleted && x.ContractId == contractId
                    && x.AccountConceptId == accountConceptId
                    select x).FirstOrDefault();
        }

        public AccountDetail FetchCurrentSpec(int advertiserId, AccountConceptKeyEnum key)
        {
            return (from x in this.db.AccountDetails
                    where x.Contract.AdvertiserId == advertiserId
                    && x.AccountConceptId == (int)key
                    && x.Contract.ContractDate < DateTime.Now
                    && x.Contract.EndDate > DateTime.Now
                    && x.Contract.IsActive == true
                    orderby x.AccountDetailId descending
                    select x).FirstOrDefault();
        }

        public List<AccountDetail> FetchAllQuantityMoreCeroByContractId(int contractId)
        {
            return (from x in this.db.AccountDetails
                    where !x.Deleted && x.ContractId == contractId && x.Quantity > 0
                    select x).ToList();
        }

        public int FetchTotalFor(int advertiserId, AccountConceptKeyEnum key)
        {
            var query = from x in this.db.AccountDetails
                        where x.AdvertiserId == advertiserId
                        && x.AccountConceptId == (int)key
                        && x.Deleted == false
                        && x.Contract.IsActive
                        select x.Quantity;

            if (query.Count() > 0)
                return query.Sum();

            return 0;
        }

        public bool FetchAnyDetail(int advertiserId)
        {
            var query = from x in this.db.AccountDetails
                        where x.AdvertiserId == advertiserId
                        && x.Deleted == false
                        && x.Contract.IsActive
                        select x;

            return query.FirstOrDefault() != null;
        }
    }
}
