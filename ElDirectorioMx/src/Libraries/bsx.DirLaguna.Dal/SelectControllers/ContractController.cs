using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bsx.DirLaguna.Dal.Enum;
using bsx.DirLaguna.Dal.Carrier;

namespace bsx.DirLaguna.Dal
{
    public partial class ContractController : BaseController<Contract>
    {
        public ContractController()
            : base() { }

        public ContractController(DirLagunaModelDataContext context) :
            base(context) { }


        public override Contract FetchById(int id)
        {
            return (from x in this.db.Contracts
                    where !x.Deleted
                    && x.ContractId == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<Contract> FetchAll()
        {
            return (from x in this.db.Contracts
                    where !x.Deleted
                    select x);
        }

        public IQueryable<Contract> FetchAllByAdvertiserId(int advertiserId)
        {
            return (from x in this.db.Contracts
                    where !x.Deleted
                    && x.AdvertiserId == advertiserId
                    select x);
        }

        public Contract FetchCurrentContractFor(int advertiserId)
        {
            var currentContract = from x in this.db.Contracts
                                  where !x.Deleted
                                  && x.AdvertiserId == advertiserId
                                  && x.ContractDate < DateTime.Now
                                  && x.EndDate > DateTime.Now
                                  orderby x.EndDate descending
                                  select x;

            return (currentContract).ToList().FirstOrDefault();
        }

        public int FetchSpec(int contractId, AccountConceptKeyEnum key)
        {
            var specs = from x in this.db.AccountDetails
                        where x.ContractId == contractId
                        && x.AccountConceptId == (int)key
                        select x.Quantity;

            return (specs).FirstOrDefault();
        }

        public int FetchMonthAdvertisers(int franchiseeId)
        {
            var advs = from x in this.db.Contracts
                       where x.Advertiser.FranchiseeId == franchiseeId
                       && !x.Advertiser.Deleted
                       && x.AccountDetails.Where(y => !y.Deleted && y.Quantity > 0).Count() > 0
                       && x.ContractDate.Date > new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
                       select x.AdvertiserId;

            return advs.Distinct().Count();
        }

        public bool ValidateProccesedTransactionId(string transactionId)
        {
            Contract con = (from x in this.db.Contracts
                            where x.PayPalTransactionId == transactionId
                            select x).FirstOrDefault();
            return con != null;
        }

        public SimpleContractTransactionCarrier FetchDataTransaction(int contractId)
        {
            Contract con = (from x in this.db.Contracts
                            where x.ContractId == contractId
                            select x).FirstOrDefault();
            SimpleContractTransactionCarrier carrier = new SimpleContractTransactionCarrier();
            if (con != null)
            {
                carrier.ContractId = contractId;
                carrier.PaymentAmount = (decimal)con.PaymentAmount;
                carrier.TransactionId = con.PayPalTransactionId;
            }

            return carrier;
        }

        public IQueryable<Contract> FetchPendingContracts(PendingContractsType requested, string nameAdvertiser, int estadoId, int municipioId)
        {
            var contracts = from x in this.db.Contracts
                            where !x.Deleted
                            && !x.Advertiser.Deleted
                            select x;

            switch (requested)
            {
                case PendingContractsType.Unpayed:
                    contracts = from x in contracts
                                where !x.IsPaid
                                && x.InvoiceId != null && !x.IsPaid
                                select x;
                    break;
                case PendingContractsType.Inactive:
                    contracts = from x in contracts
                                where !x.IsActive
                                select x;
                    break;
                case PendingContractsType.NotInvoiced:
                    contracts = from x in contracts
                                where x.InvoiceId == null && x.Advertiser.FiscalDetailId != null
                                select x;
                    break;
                default:
                    break;
            }

            if (!string.IsNullOrEmpty(nameAdvertiser))
            {
                contracts = from x in contracts
                            where x.Advertiser.Name.Contains(nameAdvertiser)
                            select x;
            }

            if (estadoId > 0)
            {
                contracts = from x in contracts
                            where x.Advertiser.Municipio.EstadoId == estadoId
                            select x;

                if (municipioId > 0)
                {
                    contracts = from x in contracts
                                where x.Advertiser.MunicipioId == municipioId
                                select x;

                }
            }

            return contracts;
        }

        public IQueryable<Contract> FetchPendingContracts(PendingContractsType requested, string nameAdvertiser, int estadoId, int municipioId, int startRowIndex, int maximumRows, string sort)
        {
            var contracts = this.FetchPendingContracts(requested, nameAdvertiser, estadoId, municipioId);

            if (!string.IsNullOrEmpty(sort))
            {
                //if (sort.Contains(AvailableItem.ColumnNames.ItemTypeId))
                //{
                //    if (sort.Contains("ASC"))
                //        items = items.OrderBy(d => d.ItemTypeId);
                //    else
                //        items = items.OrderByDescending(d => d.ItemTypeId);
                //}
            }

            return contracts.Skip(startRowIndex).Take(maximumRows);
        }

        public int FetchPendingContractsCount(PendingContractsType requested, string nameAdvertiser, int estadoId, int municipioId, int startRowIndex, int maximumRows, string sort)
        {
            var contracts = this.FetchPendingContracts(requested, nameAdvertiser, estadoId, municipioId).Count();
            return contracts;
        }

        public enum PendingContractsType
        {
            Unpayed,
            Inactive,
            None,
            NotInvoiced
        }

        public Contract MinCurrentContractFor(int advertiserId)
        {
            var contract = (from x in this.db.Contracts
                            where x.AdvertiserId == advertiserId
                            && x.IsActive
                            && x.ContractDate < DateTime.Now
                            && x.EndDate > DateTime.Now
                            orderby x.ContractDate ascending
                            select x).FirstOrDefault();

            return contract;
        }

        public Contract MaxCurrentContractFor(int advertiserId)
        {
            var contract = (from x in this.db.Contracts
                            where x.AdvertiserId == advertiserId
                            && x.IsActive
                            && x.ContractDate < DateTime.Now
                            && x.EndDate > DateTime.Now
                            orderby x.EndDate descending
                            select x).FirstOrDefault();

            return contract;
        }
    }
}
