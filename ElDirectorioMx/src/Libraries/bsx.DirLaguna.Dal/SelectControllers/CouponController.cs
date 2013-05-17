using System;
using System.Linq;
using bsx.DirLaguna.Dal.Enum;
using System.Collections.Generic;

namespace bsx.DirLaguna.Dal
{
    public partial class CouponController : BaseController<Coupon>
    {
        public CouponController() : base() { }

        public CouponController(DirLagunaModelDataContext context) : base(context) { }

        public override Coupon FetchById(int id)
        {
            return (from x in this.db.Coupon
                    where x.CouponId == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<Coupon> FetchAll()
        {
            return from x in this.db.Coupon
                   where !x.Deleted
                   select x;
        }

        /// <summary>
        /// Obtienen las cuponeras de un anunciante. Esta funcion esta pensada para utilizarse 
        /// en el administrador
        /// </summary>
        /// <param name="franchiseeId"></param>
        /// <param name="advertiserId"></param>
        /// <param name="couponSetId"></param>
        /// <returns></returns>
        public IQueryable<Coupon> FetchCouponSetCoupons(int franchiseeId, int advertiserId, int couponSetId)
        {
            return from x in this.db.Coupon
                   where !x.Deleted
                   && x.FranchiseeId == franchiseeId
                   && x.AdvertiserId == advertiserId
                   && x.CouponSetId == couponSetId
                   select x;
        }

        public IQueryable<Coupon> FetchSimilarCoupons(int couponId)
        {
            var coupon = this.FetchById(couponId);

            var coupons = this.ActiveCouponsQuery;

            var advertisers = from x in this.db.AdvertiserCategories
                              where !x.Deleted
                              select x.AdvertiserId;

            coupons = from x in coupons
                      where advertisers.Contains(x.AdvertiserId)
                      select x;

            return coupons;
        }

        /// <summary>
        /// Obtiene la consulta base para sacar cupones activos. Es utilizada por otros metodos.
        /// </summary>
        private IQueryable<Coupon> ActiveCouponsQuery
        {
            get
            {
                var coupons = from x in this.db.Coupon
                              where !x.Deleted
                              && x.CouponStatusId == (int)CouponStatusEnum.Active
                              && x.Advertiser.AccountDetail.Where(y =>
                                    y.AccountConceptId == (int)AccountConceptKeyEnum.Coupons
                                    && y.Quantity > 0
                                    && y.Contract.IsActive
                                    && y.Contract.ContractDate < DateTime.Now
                                    && y.Contract.EndDate > DateTime.Now).Count() > 0
                              && (!x.IsExpirable || (x.IsExpirable && x.EndDate > DateTime.Now))
                              && !x.Advertiser.Deleted
                              select x;

                return coupons;
            }
        }

        public IQueryable<Coupon> fetchAvaibleCouponClub(bool isClub, int categoryId, int advertiserId, int cityId)
        {
            var couponsClub = this.ActiveCouponsQuery;

            couponsClub = from x in couponsClub
                          where x.isClub == isClub
                          select x;
            if (categoryId > 0)
                couponsClub = from x in couponsClub
                          join y in this.db.CouponCategories on x.CouponId equals y.CouponId
                          where y.CategoryId == categoryId
                          select x;

            if (advertiserId > 0)
                couponsClub = from x in couponsClub
                          where x.AdvertiserId == advertiserId
                          select x;

            if (cityId > 0)
                couponsClub = from x in couponsClub
                          join y in this.db.Advertiser on x.AdvertiserId equals y.AdvertiserId
                          join z in this.db.Offices on y.AdvertiserId equals z.AdvertiserId
                          where (z.CityId == cityId
                          || x.IsNationale)
                          select x;

            return couponsClub;
        }

        /// <summary>
        /// Obtiene los cupones actuales y activos de una categoría en particular. No filtra por anunciante.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public IQueryable<Coupon> FetchAvailableCoupons(int categoryId, int advertiserId, int cityId)
        {
            var coupons = this.ActiveCouponsQuery;

            if (categoryId > 0)
                coupons = from x in coupons
                          join y in this.db.CouponCategories on x.CouponId equals y.CouponId
                          where y.CategoryId == categoryId
                          select x;

            if (advertiserId > 0)
                coupons = from x in coupons
                          where x.AdvertiserId == advertiserId
                          select x;

            if (cityId > 0)
                coupons = from x in coupons
                          join y in this.db.Advertiser on x.AdvertiserId equals y.AdvertiserId
                          join z in this.db.Offices on y.AdvertiserId equals z.AdvertiserId
                          where (z.CityId == cityId
                          || x.IsNationale)
                          select x;

            return coupons;
        }

        /// <summary>
        /// Obtiene los cupones actuales y activos de una categoría en particular. No filtra por anunciante.
        /// Enmascara la funcion que toma tambien el id del advertiser
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public IQueryable<Coupon> FetchAvailableCoupons(int categoryId, int cityId) { return this.FetchAvailableCoupons(categoryId, -1, cityId); }

        /// <summary>
        /// Obtienene los cupones activos de un anunciante en particular. Toma en cuenta las restricciones 
        /// necesarias para mostrar un cupon que esta en proceso de ser mostrado
        /// </summary>
        /// <param name="advertiserId"></param>
        /// <returns></returns>
        public IQueryable<Coupon> FetchAdvertiserCoupons(int advertiserId, bool isclub)
        {
            int allowedCouponSets = new AccountDetailController().FetchTotalFor(advertiserId, Enum.AccountConceptKeyEnum.Coupons);
            if (allowedCouponSets == 0)
                return from x in this.db.Coupon
                       where x.CouponId < 0
                       select x;

            var coupons = this.ActiveCouponsQuery;

            coupons = from x in coupons
                      where x.AdvertiserId == advertiserId && x.isClub == isclub
                      orderby x.CouponId
                      select x;

            return coupons.Take(allowedCouponSets * CouponSet.MaxCoupons);
        }

        public IQueryable<Coupon> FetchAdvertiserCoupon(int advertiserId)
        {
            int allowedCouponSets = new AccountDetailController().FetchTotalFor(advertiserId, Enum.AccountConceptKeyEnum.Coupons);
            if (allowedCouponSets == 0)
                return from x in this.db.Coupon
                       where x.CouponId < 0
                       select x;

            var coupons = this.ActiveCouponsQuery;

            coupons = from x in coupons
                      where x.AdvertiserId == advertiserId
                      orderby x.CouponId
                      select x;

            return coupons.Take(allowedCouponSets * CouponSet.MaxCoupons);
        }


        public IQueryable<Coupon> FetchAdvertiserAllCoupons(int advertiserId)
        {
            var coupons = this.ActiveCouponsQuery;

            coupons = from x in coupons
                      where x.AdvertiserId == advertiserId
                      orderby x.CouponId
                      select x;
            
            return coupons;
        }

        public IQueryable<Coupon> FetchAvailableCoupons(int categoryId, int advertiserId, int cityId, int startRowIndex, int maximumRows)
        {
            var coupons = this.FetchAvailableCoupons(categoryId, advertiserId, cityId);

            return coupons.Skip(startRowIndex).Take(maximumRows);
        }

        public IQueryable<Coupon> FetchAvailableCouponsClub(bool isclub ,int categoryId, int advertiserId, int cityId, int startRowIndex, int maximumRows)
        {
            var coupons = this.fetchAvaibleCouponClub(isclub, categoryId, advertiserId, cityId);

            return coupons.Skip(startRowIndex).Take(maximumRows);
        }

        /// <summary>
        /// Obtiene la consulta base para sacar cupones activos. Es utilizada por otros metodos.
        /// </summary>
        public int FetchActiveCouponsBycouponSet(int couponSetId)
        {
            return (from x in this.db.Coupon
                    where !x.Deleted
                    && x.CouponSetId == couponSetId
                    select x).Count();
        }

    }
}
