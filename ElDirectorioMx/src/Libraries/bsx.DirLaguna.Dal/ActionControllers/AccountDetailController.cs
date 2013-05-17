using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bsx.DirLaguna.Dal.Enum;

namespace bsx.DirLaguna.Dal
{
    public partial class AccountDetailController
    {
        public bool Save(int accountDetailId, int quantity, int accountConceptId, int? advertiserId, int? contractId, int personalId, DateTime contractDate, int months, bool isPaid)
        {
            bool bResult = true;

            AccountDetail detail = this.FetchById(accountDetailId);
            if (detail == null)
            {
                detail = new AccountDetail();
                this.db.AccountDetails.InsertOnSubmit(detail);
            }
            detail.Quantity = quantity;
            detail.ContractId = (int)contractId;
            detail.AccountConceptId = accountConceptId;

            try
            {
                this.db.SubmitChanges();
            }
            catch (Exception ex)
            {
                bResult = false;
                this.Errors.Add("Ha ocurrido un error al guardar el registro." + ex.Message);

            }

            return bResult;
        }

        public bool UpdateAccountDetail(int contractId, int accountConceptId, int quantity, int advertiserId)
        {
            bool bResult = true;

            AccountDetail detail = this.FetchByContractIdAndAccountConceptId(contractId, accountConceptId);
            if (detail == null)
            {
                detail = new AccountDetail();
                this.db.AccountDetails.InsertOnSubmit(detail);
            }

            detail.AccountConceptId = accountConceptId;
            detail.ContractId = contractId;
            detail.Quantity = quantity;
            detail.AdvertiserId = advertiserId;

            ContractController controller = new ContractController(this.db);
            var contract = controller.FetchById(contractId);

            switch ((AccountConceptKeyEnum)accountConceptId)
            {
                case AccountConceptKeyEnum.ClubElDirectorio:
                    contract.Featured = quantity > 0;
                    break;
                case AccountConceptKeyEnum.Website:
                    contract.WebSite = quantity > 0;
                    break;
                case AccountConceptKeyEnum.iOsApp:
                    contract.iOs = quantity > 0;
                    break;
                case AccountConceptKeyEnum.AndroidApp:
                    contract.Android = quantity > 0;
                    break;
                default:
                    break;
            }

            try
            {
                this.db.SubmitChanges();
            }
            catch (Exception ex)
            {
                bResult = false;
                this.Errors.Add("Ha ocurrido un error al guardar el registro." + ex.Message);
            }

            return bResult;
        }

    }
}
