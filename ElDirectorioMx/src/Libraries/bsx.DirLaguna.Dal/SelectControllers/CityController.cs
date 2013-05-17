using System.Collections.Generic;
using System.Linq;
using bsx.DirLaguna.Dal.Enum;
using System;

namespace bsx.DirLaguna.Dal
{
    public partial class CityController : BaseController<City>
    {
        public CityController() : base() { }

        public CityController(DirLagunaModelDataContext context) : base(context) { }

        public override City FetchById(int id)
        {
            return (from x in this.db.City
                    where x.CityId == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<City> FetchAll()
        {
            return from x in this.db.City
                   where !x.Deleted
                   orderby x.Name
                   select x;
        }

        public City FetchByName(string name)
        {
            return (from x in this.db.City
                    where x.Name == name
                    select x).FirstOrDefault();
        }

        public IQueryable<City> FechAllActive(AccountConceptKeyEnum device)
        {
            return from x in this.db.City
                   where !x.Deleted
                   && this.FetchActiveCitiesId(device).Contains(x.CityId)
                   orderby x.Name
                   select x;
        }

        public int FetchAdvertisersCount(int cityId)
        {
            return (from x in this.db.Advertiser
                    where x.CityId == cityId
                    && !x.Deleted
                    && x.AccountDetail.Where(y => y.Quantity > 0
                                            && y.AccountConceptId == (int)AccountConceptKeyEnum.Website
                                            && y.Contract.ContractDate < DateTime.Now
                                            && y.Contract.EndDate > DateTime.Now).Count() > 0
                    select x).Count();
        }

        public List<int> FetchActiveCitiesId(AccountConceptKeyEnum device)
        {
            int[] devices = new[] { (int)AccountConceptKeyEnum.Website, (int)AccountConceptKeyEnum.iOsApp, (int)AccountConceptKeyEnum.AndroidApp };

            var cities = (from x in this.db.Offices
                         join y in this.db.Advertiser on x.AdvertiserId equals y.AdvertiserId
                         join z in this.db.Contracts on y.AdvertiserId equals z.AdvertiserId
                         join a in this.db.AccountDetails on z.ContractId equals a.ContractId
                         where x.Deleted == false
                         && y.Deleted == false
                         && z.Deleted == false
                         && z.IsActive == true
                         && z.ContractDate < DateTime.Now
                         && z.EndDate > DateTime.Now
                         && a.Quantity > 0
                         && a.AccountConceptId == (int)device
                         select x.CityId).Distinct(); 

            return cities.ToList();
        }
    }
}
