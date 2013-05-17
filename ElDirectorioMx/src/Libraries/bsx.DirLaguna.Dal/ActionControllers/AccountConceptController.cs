using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class AccountConceptController
    {
        public bool SaveGorilaId(int accountConceptId, int? gorilaId, string description)
        {
            bool bResult = true;

            AccountConcept concept = this.FetchById(accountConceptId);
            if (concept == null)
            {
                this.Errors.Add("Ha ocurrido un error al buscar el registro.");
                return false;
            }

            concept.GorilaId = gorilaId;
            concept.Description = description;

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
