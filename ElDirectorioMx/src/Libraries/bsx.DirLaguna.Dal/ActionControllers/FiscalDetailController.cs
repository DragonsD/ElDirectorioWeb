using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bsx.DirLaguna.Dal.Carrier;

namespace bsx.DirLaguna.Dal
{
    public partial class FiscalDetailController
    {
        public bool Save(SimpleFiscalDetailCarrier carrier)
        {
            bool bResult = true;

            FiscalDetail detail = this.FetchById(carrier.FiscalDetailId);
            if (detail == null)
            {
                detail = new FiscalDetail();
                this.db.FiscalDetails.InsertOnSubmit(detail);
            }

            detail.Name = carrier.FiscalName;
            detail.RFC = carrier.RFC;
            detail.IsMoralPerson  = carrier.RFC.Length == 12 ? true : false;
            detail.EstadoId = carrier.EstadoId;
            detail.MunicipioId = carrier.MunicipioId;
            detail.Poblacion = carrier.Poblacion;
            detail.Street = carrier.Street;
            detail.ExteriorNumber = carrier.ExteriorNumber;
            detail.InteriorNumber = carrier.InteriorNumber;
            detail.Colony = carrier.Colony;
            detail.ZipCode = carrier.Colony;

            try
            {
                this.db.SubmitChanges();
            }
            catch (Exception ex)
            {
                bResult = false;
                this.Errors.Add("No se pudo salvar los datos fiscales."+ ex.Message);
            }


            return bResult;
        }
    }
}
