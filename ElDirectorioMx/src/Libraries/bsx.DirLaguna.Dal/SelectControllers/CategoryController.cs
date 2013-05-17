using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using bsx.DirLaguna.Dal.Enum;
using bsx.DirLaguna.Dal.Carrier;

namespace bsx.DirLaguna.Dal
{
    public partial class CategoryController : BaseController<Category>
    {
        public CategoryController() : base() { }

        public CategoryController(DirLagunaModelDataContext context) : base(context) { }

        public override Category FetchById(int id)
        {
            return (from x in this.db.Categories
                    where x.CategoryId == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<Category> FetchAll()
        {
            return from x in this.db.Categories
                   where !x.Deleted
                   select x;
        }

        public int FetchCategoryAdvertisersCount(int categoryId)
        {
            var aux = (from x in this.db.VwCategories
                       where x.CategoryId == categoryId
                       select x.AdvertiserName).Distinct().Count();
            return aux;
        }

        public IQueryable<Category> FetchAll(string name, string letter, bool? highlighted)
        {
            var categories = from x in this.db.Categories
                             where !x.Deleted
                             select x;

            if (!string.IsNullOrEmpty(name))
                categories = from x in categories
                             where x.Name.Contains(name)
                             select x;

            if (!string.IsNullOrEmpty(letter))
                categories = from x in categories
                             where x.Letter.Equals(letter)
                             select x;

            if (highlighted.HasValue)
                categories = from x in categories
                             where x.Featured == highlighted
                             select x;

            return categories.OrderBy(x => x.Name);
        }

        public int FetchAllCount(string name, string letter, bool? highlighted, int startRowIndex, int maximumRows, string sort)
        {
            return this.FetchAll(name, letter, highlighted).Count();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Category> FetchAll(string name, string letter, bool? highlighted, int startRowIndex, int maximumRows, string sort)
        {
            var categories = this.FetchAll(name, letter, highlighted);

            if (!string.IsNullOrEmpty(sort))
            {
                //if (sort.Contains(AvailableItem.ColumnNames.ItemTypeId))
                //{
                //    if (sort.Contains("ASC"))
                //        items = items.OrderBy(d => d.ItemTypeId);
                //    else
                //        items = items.OrderByDescending(d => d.ItemTypeId);
                //}
            }

            return categories.Skip(startRowIndex).Take(maximumRows).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<string> FetchAllCategoryLetters()
        {
            var catLetters = (from x in this.db.Categories
                              where !x.Deleted
                              select x.Letter).Distinct();
            return catLetters.ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<PublicCategoryCarrier> FetchCategoriesForLetter(string letter, string keywords, int cityId, bool filterFeatured)
        {
            var categories = from x in this.db.VwCategories
                             select x;
            // esta seccion de codigo es para cuando se busca con fulltext
            if (!string.IsNullOrEmpty(keywords))
                categories = from x in categories
                             where
                             x.AdvertiserName.Contains(keywords)
                             || x.Description.Contains(keywords)
                             || x.Tags.Contains(keywords)
                             select x;

            if (!string.IsNullOrEmpty(letter))
                categories = from x in categories
                             where x.letter.Equals(letter)
                             select x;

            if (filterFeatured)
                categories = from x in categories
                             where x.Featured
                             select x;

            if (cityId > 0)
                categories = from x in categories
                             where x.CityId == cityId
                             select x;

            var result = (from x in categories
                          select new PublicCategoryCarrier() { CategoryId = x.CategoryId, Name = x.Name }).Distinct();

            return from x in result orderby x.Name ascending select x;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<Category> FetchFullTextSearchResult(string keywords)
        {
            return (from x in this.db.AdvertiserCategories
                    where x.Advertiser.Name.Contains(keywords)
                    orderby x.Category.Name
                    select x.Category).Distinct();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<Category> FetchCouponsCategories(string letter, int cityId)
        {
            CouponController controller = new CouponController(this.db);
            var coupons = controller.FetchAvailableCoupons(-1, cityId);

            var categories = from x in coupons
                             join y in this.db.CouponCategories on x.CouponId equals y.CouponId
                             where y.Deleted == false
                             select y.Category;

            if (!string.IsNullOrEmpty(letter))
                categories = from x in categories
                             where x.Name.StartsWith(letter)
                             select x;

            return categories.Distinct();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<Category> FetchAdvertiserCategories(int advertiserId)
        {
            int allowedCategories = new AccountDetailController().FetchTotalFor(advertiserId, Enum.AccountConceptKeyEnum.Categorias);

            var query = from x in this.db.AdvertiserCategories
                        where x.AdvertiserId == advertiserId
                        && x.Deleted == false
                        && x.Category.Deleted == false
                        orderby x.CreatedOn descending
                        select x.Category;

            return query.Take(allowedCategories + 1);
        }
    }
}
