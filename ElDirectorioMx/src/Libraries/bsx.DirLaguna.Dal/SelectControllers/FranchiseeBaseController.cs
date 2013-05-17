using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public abstract class FranchiseeBaseController<T> : BaseController<T>
    {
        public FranchiseeBaseController()
            : base()
        { }

        public FranchiseeBaseController(DirLagunaModelDataContext db)
            : base(db)
        { }

        public abstract T FetchById(int franchiseeId, int id);

        public abstract IQueryable<T> FetchAll(int franchiseeId);

    }
}
