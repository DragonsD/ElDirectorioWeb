using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class PersonalController : BaseController<Personal>
    {
        public override Personal FetchById(int id)
        {
            return (from x in this.db.Personals
                    where x.PersonalId == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<Personal> FetchAll()
        {
            return from x in this.db.Personals
                   where !x.Deleted
                   select x;
        }
    }
}
