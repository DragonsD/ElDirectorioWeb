using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal.SelectControllers
{
    public partial class PhoneTypeController : BaseController<PhoneType>
    {
        public PhoneTypeController() : base() { }

        public PhoneTypeController(DirLagunaModelDataContext context) : base(context) { }

        public override PhoneType FetchById(int id)
        {
            return (from x in this.db.PhoneTypes where x.PhoneTypeId == id select x).FirstOrDefault();
        }

        public override IQueryable<PhoneType> FetchAll()
        {
            return from x in this.db.PhoneTypes select x;
        }
    }
}
