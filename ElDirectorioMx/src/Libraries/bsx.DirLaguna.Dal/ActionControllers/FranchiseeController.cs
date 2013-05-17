using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bsx.DirLaguna.Dal.Carrier;

namespace bsx.DirLaguna.Dal
{
    public partial class FranchiseeController
    {
        public bool Insert(string name, bool isPrimary, string guidUserId, out int newFranchiseeId)
        {
            bool bResult = true;
            Franchisee fran = new Franchisee();
            fran.Deleted = false;
            this.db.Franchisees.InsertOnSubmit(fran);

            fran.Name = name;
            fran.IsPrimary = isPrimary;
            newFranchiseeId = -1;
            try
            {
                this.db.SubmitChanges();
                newFranchiseeId = fran.FranchiseeId;
            }
            catch (Exception ex)
            {
                bResult = false;
                this.Errors.Add(ex.Message);
            }

            return bResult;
        }

        public bool Save(SimpleFranchiseeCarrier franchiseeCarrier, SimpleFiscalDetailCarrier fiscalDetailCarrier, out int newFranchiseeId)
        {
            bool bResult = true;
            newFranchiseeId = -1;

            Franchisee fran = franchiseeCarrier.ExternalKey.HasValue ?
                                this.FetchByExternalId(franchiseeCarrier.ExternalKey.Value) :
                                this.FetchById(franchiseeCarrier.FranchiseeId);

            if (fran == null)
            {
                fran = new Franchisee();
                fran.IsPrimary = false;
                this.db.Franchisees.InsertOnSubmit(fran);
            }


            fran.Name = franchiseeCarrier.Name;
            fran.Address = franchiseeCarrier.Address;
            fran.Phone = franchiseeCarrier.Phone;
            fran.CellPhone = franchiseeCarrier.CellPhone;
            fran.Email = franchiseeCarrier.Email;
            fran.MunicipioId = franchiseeCarrier.MunicipioId;
            fran.ShareLevelId = franchiseeCarrier.ShareNivelId;
            fran.ExternalKey = franchiseeCarrier.ExternalKey;
            fran.BankReference = franchiseeCarrier.BankReference;
            fran.DV = !string.IsNullOrEmpty(franchiseeCarrier.DV) ? franchiseeCarrier.DV : "-";

            if (fiscalDetailCarrier.IsValid)
            {
                var fiscalDetail = new FiscalDetailController(this.db).FetchById(fran.FiscalDetailId.HasValue ? fran.FiscalDetailId.Value : 0);
                if (fiscalDetail == null)
                {
                    fiscalDetail = new FiscalDetail();
                    this.db.FiscalDetails.InsertOnSubmit(fiscalDetail);
                }

                fiscalDetail.Name = fiscalDetailCarrier.FiscalName;
                fiscalDetail.RFC = fiscalDetailCarrier.RFC;
                fiscalDetail.IsMoralPerson = fiscalDetailCarrier.RFC.Length == 12 ? false : true;
                fiscalDetail.EstadoId = fiscalDetailCarrier.EstadoId;
                fiscalDetail.MunicipioId = fiscalDetailCarrier.MunicipioId;
                fiscalDetail.Poblacion = fiscalDetailCarrier.Poblacion;
                fiscalDetail.Street = fiscalDetailCarrier.Street;
                fiscalDetail.ExteriorNumber = fiscalDetailCarrier.ExteriorNumber;
                fiscalDetail.InteriorNumber = fiscalDetailCarrier.InteriorNumber;
                fiscalDetail.Colony = fiscalDetailCarrier.Colony;
                fiscalDetail.ZipCode = fiscalDetailCarrier.ZipCode;
                fiscalDetail.ContactEmail = fiscalDetailCarrier.ContactEmail;
                fiscalDetail.Id = fran.FranchiseeId;

                fran.FiscalDetail = fiscalDetail;
            }
            else
                fran.FiscalDetailId = null;

            try
            {
                this.db.SubmitChanges();
                newFranchiseeId = fran.FranchiseeId;
            }
            catch (Exception ex)
            {
                bResult = false;
                this.Errors.Add(ex.Message);
            }

            return bResult;
        }


        public bool Delete(int franchiseeId)
        {
            bool result = false;

            Franchisee fran = this.FetchById(franchiseeId);
            if (fran == null)
            {
                this.Errors.Add("El elemento no existe");
                return false;
            }

            try
            {
                fran.Deleted = true;
                this.db.SubmitChanges();
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
            }

            return result;
        }

        public bool UpdateOfficeFranchisee(int franchiseeId, int? gorilaOfficeId, int? gorilaBankAccountId)
        {
            bool result = false;

            Franchisee fran = this.FetchById(franchiseeId);
            if (fran == null)
            {
                this.Errors.Add("La franquicia no Existe.");
                return false;
            }

            try
            {
                fran.GorilaOfficeId = gorilaOfficeId;
                fran.GorilaBankId = gorilaBankAccountId;
                this.db.SubmitChanges();
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
            }

            return result;
        }

        public bool UpdateDV(int franchiseeId, string dv)
        {
            bool result = false;

            Franchisee fran = this.FetchById(franchiseeId);
            if (fran == null)
            {
                this.Errors.Add("La franquicia no Existe.");
                return false;
            }

            try
            {
                fran.DV = dv;
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
