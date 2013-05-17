using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class BannerController : BaseController<Banner>
    {
        public BannerController() : base() { }

        public BannerController(DirLagunaModelDataContext context) : base(context) { }

        public override Banner FetchById(int id)
        {
            return (from x in this.db.Banners
                    where x.BannerId == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<Banner> FetchAll()
        {
            return from x in this.db.Banners
                   where !x.Deleted
                   orderby x.Priority descending, x.BannerId descending
                   select x;
        }
    }
}
