using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class FiscalDetailController : BaseController<FiscalDetail>
    {
        public FiscalDetailController()
            : base()
        {

        }

        public FiscalDetailController(DirLagunaModelDataContext context) :
            base(context)
        {

        }

        public override FiscalDetail FetchById(int id)
        {
            return (from x in this.db.FiscalDetails
                        where !x.Deleted && x.FiscalDetailId == id
                        select x).FirstOrDefault();
        }

        public override IQueryable<FiscalDetail> FetchAll()
        {
            return (from x in this.db.FiscalDetails
                    where !x.Deleted 
                    select x);
        }

    }
}
