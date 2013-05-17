using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class CatPublicityController
    {
        public bool Save(int catPublicityId, int categoryId, string name, string description, string publicityFile, bool available, DateTime fromDate, DateTime? toDate, out int newId)
        {
            bool result = false;
            newId = 0;

            CatPublicity cp = this.FetchById(catPublicityId);
            if (cp == null)
            {
                cp = new CatPublicity();
                this.db.CatPublicities.InsertOnSubmit(cp);
                cp.CategoryId = categoryId;
            }

            cp.Name = name;
            cp.Description = description;
            cp.PublicityFile = publicityFile;
            cp.Available = available;
            cp.FromDate = fromDate;
            cp.ToDate = toDate;

            try
            {
                this.db.SubmitChanges();
                result = true;
                newId = cp.CatPublicityId;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
            }

            return result;
        }
    }
}
