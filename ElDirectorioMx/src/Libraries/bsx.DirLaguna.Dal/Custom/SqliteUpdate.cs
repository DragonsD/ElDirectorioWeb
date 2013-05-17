using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class SqliteUpdate
    {
        public static SqliteUpdate LastUpdate { get { return new SqliteUpdateController().FetchLastUpdate(); } }
    }
}
