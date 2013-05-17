using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class PhoneController : FranchiseeBaseController<Phone>
    {
        public PhoneController() : base() { }

        public PhoneController(DirLagunaModelDataContext context) : base(context) { }

        public override Phone FetchById(int id, int franchiseeId)
        {
            return (from x in this.db.Phones
                    where x.PhoneId == id
                          && x.FranchiseeId == franchiseeId

                    select x).FirstOrDefault();
        }

        public override IQueryable<Phone> FetchAll(int franchiseeId)
        {
            return from x in this.db.Phones
                   where !x.Deleted
                         && x.FranchiseeId == franchiseeId
                   select x;
        }

        public override Phone FetchById(int id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Phone> FetchAll()
        {
            throw new NotImplementedException();
        }
    }
}
