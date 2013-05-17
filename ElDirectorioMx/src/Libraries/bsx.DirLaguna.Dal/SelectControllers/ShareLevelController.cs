using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class ShareLevelController: BaseController<ShareLevel>
    {
        public ShareLevelController()
            : base()
        {

        }

        public ShareLevelController(DirLagunaModelDataContext context) :
            base(context)
        {

        }

        public override ShareLevel FetchById(int id)
        {
            return (from x in this.db.ShareLevels
                    where !x.Deleted && x.ShareLevelId == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<ShareLevel> FetchAll()
        {
            return (from x in this.db.ShareLevels
                    where !x.Deleted
                    select x);
        }
    }
}
