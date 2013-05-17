using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class StatusController : BaseController<Status>
    {
        public StatusController() : base() { }

        public StatusController(DirLagunaModelDataContext context) : base(context) { }

        public override Status FetchById(int id)
        {
            return (from x in this.db.Status where x.StatusId == id select x).FirstOrDefault();
        }

        public override IQueryable<Status> FetchAll()
        {
            return from x in this.db.Status where !x.Deleted select x;
        }
    }
}
