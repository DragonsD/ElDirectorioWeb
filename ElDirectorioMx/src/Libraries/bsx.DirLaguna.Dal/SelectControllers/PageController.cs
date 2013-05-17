using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class PageController : BaseController<Page>
    {
        public override Page FetchById(int id)
        {
            return (from x in this.db.Pages
                    where x.PageId == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<Page> FetchAll()
        {
            return from x in this.db.Pages
                   where !x.Deleted
                   select x;
        }

        public int FetchNumberMax()
        {
            int total = (from x in this.db.Pages
                         select x.Number).Count();
            int valMax = 0;

            if (total > 0)
            {
                valMax = (from x in this.db.Pages
                          select x.Number).Max();
            }

            return valMax + 1;
        }

        public IQueryable<Page> FetchAllByAdvertiserId(int advertiserId)
        {
            int[] announces = (from announce in this.db.Announces
                            where !announce.Deleted &&
                            announce.AdvertiserId == advertiserId
                            select announce.PageId).Distinct().ToArray<int>();

            return from x in this.db.Pages
                   where !x.Deleted &&
                   announces.Contains(x.PageId)
                   select x;
        }

    }
}
