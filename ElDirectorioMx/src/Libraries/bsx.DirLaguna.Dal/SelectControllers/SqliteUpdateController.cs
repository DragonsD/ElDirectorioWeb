using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class SqliteUpdateController : BaseController<SqliteUpdate>
    {
        public override SqliteUpdate FetchById(int id)
        {
            return (from x in this.db.SqliteUpdates
                    where x.SqliteUpdateId == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<SqliteUpdate> FetchAll()
        {
            return from x in this.db.SqliteUpdates
                   select x;
        }

        public SqliteUpdate FetchLastUpdate()
        {
            return (from x in this.db.SqliteUpdates
                    orderby x.UpdateDate descending
                    select x).FirstOrDefault();
        }

        public int FetchNextVersion()
        {
            return (from x in this.db.SqliteUpdates
                    orderby x.UpdateDate descending
                    select x.SqliteUpdateId).FirstOrDefault() + 1;
        }

        public DateTime FetchLastUpdateDate()
        {
            return (from x in this.db.SqliteUpdates
                    orderby x.UpdateDate descending
                    select x.UpdateDate).FirstOrDefault();
        }
    }
}
