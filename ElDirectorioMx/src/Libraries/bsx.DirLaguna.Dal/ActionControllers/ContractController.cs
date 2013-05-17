using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bsx.DirLaguna.Dal.Carrier;

namespace bsx.DirLaguna.Dal
{
    public partial class ContractController
    {
        public delegate bool UpdatePaidInvoiceEventHandler(string invoiceId);
        public event UpdatePaidInvoiceEventHandler UpdatePaidInvoiceFG;

        public bool Save(int contractId, int advertiserId, int personalId, bool isPaid, DateTime? compromiseDate, bool isActive, SimpleAccountDetailCarrier accountDetailCarrier, decimal? paymentAmount, string invoiceId, out int newContractId)
        {
            bool bResult = false;
            int newId = -1;
            bool isNew = false;

            Advertiser adv = new AdvertiserController(this.db).FetchById(advertiserId);
            if (adv == null)
            {
                this.Errors.Add("No se encontro al Anunciante.");
                newContractId = newId;
                return false;
            }

            Contract contract = this.FetchById(contractId);
            if (contract == null)
            {
                isNew = true;
                contract = new Contract();
                contract.CreationDate = DateTime.Now;
                contract.Deleted = false;
                this.db.Contracts.InsertOnSubmit(contract);
            }

            contract.ContractDate = accountDetailCarrier.ContractDate;
            contract.AdvertiserId = advertiserId;
            if (compromiseDate.HasValue)
                contract.PromiseDate = compromiseDate.Value;
            contract.PersonalId = personalId;
            contract.PaymentAmount = paymentAmount;
            contract.PayPalTransactionId = null;

            if (!string.IsNullOrEmpty(invoiceId))
            {
                contract.Folio = invoiceId;
                contract.InvoiceCreation = DateTime.Now;
                contract.InvoiceCreator = personalId;
            }
              

            int retVal = accountDetailCarrier.EndDate.Month - accountDetailCarrier.ContractDate.Month + (accountDetailCarrier.EndDate.Year - accountDetailCarrier.ContractDate.Year) * 12;
            contract.Months = retVal;
            contract.EndDate = accountDetailCarrier.EndDate; // contract.ContractDate.AddMonths(accountDetailCarrier.Months);
            contract.IsPaid = isPaid;
            contract.IsActive = isActive;

            adv.ModifiedOn = DateTime.Now;
            adv.UserModifiedOn = personalId;

            if (adv.StartDate == null && adv.EndDate == null)
            {
                adv.StartDate = accountDetailCarrier.ContractDate;
                adv.EndDate = accountDetailCarrier.ContractDate.AddMonths(retVal);
            }
            else
            {
                if (isNew)
                {
                    DateTime dateCurrent = (DateTime)adv.EndDate;
                    adv.EndDate = dateCurrent.AddMonths(retVal);
                }
            }

            try
            {
                this.db.SubmitChanges();
                foreach (var item in accountDetailCarrier.AccountDetils)
                {
                    AccountDetailController conceptcontroller = new AccountDetailController();
                    if (!conceptcontroller.UpdateAccountDetail(contract.ContractId, item.Key, item.Value, contract.AdvertiserId))
                    {
                        bResult = false;
                        this.Errors.AddRange(conceptcontroller.Errors);
                        break;
                    }
                }
                newId = contract.ContractId;
                bResult = true;
            }
            catch (Exception ex)
            {
                newId = -1;
                this.Errors.Add("Ha ocurrido un error al guardar la contratacion." + ex.Message);
            }

            newContractId = newId;
            return bResult;
        }

        public bool Delete(int contractId, int personalId)
        {
            bool bResult = true;

            Contract contract = this.FetchById(contractId);
            try
            {
                if (contract != null)
                {
                    contract.Deleted = true;
                    contract.Advertiser.ModifiedOn = DateTime.Now;
                    contract.Advertiser.UserModifiedOn = personalId;
                    this.db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                bResult = false;
                this.Errors.Add("Ha ocurrido un error al guardar la contratacion." + ex.Message);
            }

            return bResult;
        }

        public bool UpdateInvoiceByContract(int contractId, int invoiceId, int personalId, string folioSerie)
        {
            bool bResult = true;

            Contract contract = this.FetchById(contractId);
            if (contract == null)
            {
                this.Errors.Add("No se encontro el contrato.");
                return false;
            }

            contract.InvoiceId = invoiceId;
            contract.Advertiser.UserModifiedOn = personalId;
            contract.Advertiser.ModifiedOn = DateTime.Now;
            contract.InvoiceCreation = DateTime.Now;
            contract.InvoiceCreator = personalId;
            contract.Folio = folioSerie;

            try
            {
                this.db.SubmitChanges();
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
                bResult = false;

            }

            return bResult;
        }

        public bool UpdateContractDataTransaction(int contractId, string transactionId)
        {
            bool bResult = true;

            this.Errors.Add("Buscando el contractId " + contractId);
            Contract contract = this.FetchById(contractId);
            if (contract == null)
            {
                this.Errors.Add("No se encontro el contrato.");
                return false;
            }

            this.Errors.Add("Actualizando transactionId " + transactionId);
            contract.PayPalTransactionId = transactionId;
            contract.IsPaid = true;
            contract.IsActive = true;
            Personal per = new PersonalController().FetchById(contract.PersonalId);
            if (per != null)
            {
                aspnet_Membership member = new UserController(this.db).FetchByUser(per.Name);
                member.IsApproved = true;
                this.Errors.Add("Se aprobo el usuario");
            }

            //contract.Advertiser.UserModifiedOn = personalId;
            //contract.Advertiser.ModifiedOn = DateTime.Now;

            try
            {
                this.db.SubmitChanges();
                this.Errors.Add("Se guardaron los cambios sin error.");
            }
            catch (Exception ex)
            {
                this.Errors.Add("Se genero un error");
                this.Errors.Add(ex.Message);
                bResult = false;

            }

            return bResult;
        }

        public bool PayContract(int contractId, int personalId)
        {
            var contract = (from x in this.db.Contracts
                            where x.ContractId == contractId
                            select x).FirstOrDefault();

            if (contract == null)
            {
                this.Errors.Add("No se ha encontrado el contrato");
                return false;
            }

            contract.IsPaid = true;
            contract.Advertiser.UserModifiedOn = personalId;
            contract.Advertiser.ModifiedOn = DateTime.Now;
            contract.PaymentUser = personalId;
            contract.PaymentDate = DateTime.Now;

            bool result = false;
            try
            {
                this.db.SubmitChanges();
                if (this.UpdatePaidInvoiceFG != null)
                    if (this.UpdatePaidInvoiceFG(contract.InvoiceId.ToString()))
                        this.Errors.Add("Se ha generado un error al actualizar el status de pagado en Factura Gorila.");

                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
            }
            return result;
        }

        public bool ActivateContract(int contractId, int personalId)
        {
            var contract = (from x in this.db.Contracts
                            where x.ContractId == contractId
                            select x).FirstOrDefault();

            if (contract == null)
            {
                this.Errors.Add("No se ha encontrado el contrato");
                return false;
            }

            contract.IsActive = true;

            contract.Advertiser.ModifiedOn = DateTime.Now;
            contract.Advertiser.UserModifiedOn = personalId;

            bool result = false;
            try
            {
                this.db.SubmitChanges();
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
            }
            return result;
        }
    }
}

