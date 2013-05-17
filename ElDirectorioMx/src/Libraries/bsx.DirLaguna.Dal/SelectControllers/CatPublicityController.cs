using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace bsx.DirLaguna.Dal
{
    public partial class CatPublicityController : BaseController<CatPublicity>
    {
        public CatPublicityController() : base() { }

        public CatPublicityController(DirLagunaModelDataContext context) : base(context) { }

        public override CatPublicity FetchById(int id)
        {
            return (from x in this.db.CatPublicities
                    where x.CatPublicityId == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<CatPublicity> FetchAll()
        {
            return from x in this.db.CatPublicities
                   where !x.Deleted
                   select x;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<CatPublicity> FetchForCategory(int categoryId)
        {
            return from x in this.db.CatPublicities
                   where !x.Deleted
                   && x.CategoryId == categoryId
                   select x;
        }

        //public IQueryable<AvailableItem> FetchClientItems(int clientId, int startRowIndex, int maximumRows, string sort)

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<CatPublicity> FetchForCategory(int categoryId, int startRowIndex, int maximumRows, string sort)
        {
            var catPublicities = from x in this.db.CatPublicities
                                 where !x.Deleted
                                 && x.CategoryId == categoryId
                                 select x;

            if (!string.IsNullOrEmpty(sort))
            {
                //if (sort.Contains(AvailableItem.ColumnNames.ItemTypeId))
                //{
                //    if (sort.Contains("ASC"))
                //        items = items.OrderBy(d => d.ItemTypeId);
                //    else
                //        items = items.OrderByDescending(d => d.ItemTypeId);
                //}
                //else
                //{
                //    if (sort.Contains(AvailableItem.ColumnNames.Description))
                //    {
                //        if (sort.Contains("ASC"))
                //            items = items.OrderBy(d => d.Description);
                //        else
                //            items = items.OrderByDescending(d => d.Description);
                //    }
                //}

                //if (sort.Contains(AvailableItem.ColumnNames.NoId))
                //{
                //    if (sort.Contains("ASC"))
                //        items = items.OrderBy(d => d.NoId);
                //    else
                //        items = items.OrderByDescending(d => d.NoId);
                //}
            }

            return catPublicities.Skip(startRowIndex).Take(maximumRows).ToList();
        }
    }
}
