using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class UserController
    {
        public bool SaveUser(string name, int franchiseeId, string userMemebership, PersonalTypeEnum personalTypeId, out int newPersonalId)
        {
            bool bResult = true;
            Personal personal = this.FetchByUserId(new Guid(userMemebership));
            if (personal == null)
            {
                personal = new Personal();
                this.db.Personals.InsertOnSubmit(personal);
            }
            try
            {
                personal.Name = name;
                personal.FranchiseeId = franchiseeId;
                personal.UserId = new Guid(userMemebership);
                personal.PersonalTypeId = (int)personalTypeId;
                this.db.SubmitChanges();
                newPersonalId = personal.PersonalId;

            }
            catch (Exception ex)
            {
                bResult = false;
                newPersonalId = -1;
                this.Errors.Add(ex.Message);
            }

            return bResult;
        }
    }
}
