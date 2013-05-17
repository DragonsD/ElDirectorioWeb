using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using bsx.DirLaguna.Dal.Enum;

namespace bsx.DirLaguna.Dal
{
    public partial class AdvertiserController : FranchiseeBaseController<Advertiser>
    {
        public AdvertiserController()
            : base()
        {

        }

        public AdvertiserController(DirLagunaModelDataContext context) :
            base(context)
        {

        }

        public IQueryable<Advertiser> FetchFromIds(List<int> ids)
        {
            return from x in this.db.Advertiser
                   where ids.Contains(x.AdvertiserId)
                   select x;
        }

        public override Advertiser FetchById(int id, int franchiseeId)
        {
            return (from x in this.db.Advertiser where x.AdvertiserId == id && x.FranchiseeId == franchiseeId select x).FirstOrDefault();
        }

        public Advertiser FetchByExternalId(int advertiserExtId, int franchiseeExtId)
        {
            return (from x in this.db.Advertiser where x.ExternalKey == advertiserExtId && x.Franchisee.ExternalKey == franchiseeExtId select x).FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public override IQueryable<Advertiser> FetchAll(int franchiseeId)
        {
            return from x in this.db.Advertiser where !x.Deleted && x.FranchiseeId == franchiseeId orderby x.Name ascending select x;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<Advertiser> FetchAllFeatured()
        {
            return from x in this.db.Advertiser where !x.Deleted && x.Featured orderby x.Name ascending select x;
        }

        public IQueryable<Advertiser> FetchAllAlive()//int franchiseeId)
        {
            int[] importantAccounts = new[] { (int)AccountConceptKeyEnum.iOsApp, (int)AccountConceptKeyEnum.AndroidApp, (int)AccountConceptKeyEnum.Website };
            return from x in this.db.Advertiser
                   where !x.Deleted
                   && x.AccountDetail.Where(y => !y.Deleted && y.Quantity > 0 && importantAccounts.Contains(y.AccountConceptId) && y.Contract.ContractDate < DateTime.Now && y.Contract.EndDate > DateTime.Now).Count() > 0
                   //&& x.FranchiseeId == franchiseeId 
                   select x;
        }

        public IQueryable<Advertiser> FetchAllAliveFor(AccountConceptKeyEnum device)//int franchiseeId)
        {
            switch (device)
            {
                case AccountConceptKeyEnum.iOsApp:
                    return (from x in this.db.Advertiser
                           join z in this.db.Contracts on x.AdvertiserId equals z.AdvertiserId
                           where !x.Deleted
                           && z.iOs == true
                           && z.ContractDate < DateTime.Now
                           && z.EndDate > DateTime.Now
                           && z.IsPaid == true
                           && z.Deleted == false
                           select x).Distinct();

                case AccountConceptKeyEnum.AndroidApp:
                    return (from x in this.db.Advertiser
                           join z in this.db.Contracts on x.AdvertiserId equals z.AdvertiserId
                           where !x.Deleted
                           && z.Android == true
                           && z.ContractDate < DateTime.Now
                           && z.EndDate > DateTime.Now
                           && z.IsPaid == true
                           && z.Deleted == false
                           select x).Distinct();

                default:
                    break;
            }

            return from x in this.db.Advertiser
                   where x.AdvertiserId < 0
                   select x;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<Advertiser> FetchAll(string name, string description, int cityId, int statusId, int franchiseeId)
        {
            var advertisers = from x in this.db.Advertiser
                              where !x.Deleted
                              select x;

            if (franchiseeId > 0)
                advertisers = from x in advertisers
                              where x.FranchiseeId == franchiseeId
                              select x;

            if (!string.IsNullOrEmpty(name))
                advertisers = from x in advertisers
                              where x.Name.Contains(name)
                              select x;

            if (!string.IsNullOrEmpty(description))
                advertisers = from x in advertisers
                              where x.Description.Contains(description)
                              select x;

            if (cityId > 0)
                advertisers = from x in advertisers
                              where x.CityId == cityId
                              select x;

            //if (statusId > 0)
            //    advertisers = from x in advertisers
            //                  where x.StatusId == statusId
            //                  select x;


            return advertisers;
        }

        public int FetchAllCount(string name, string description, int cityId, int statusId, int franchiseeId, int startRowIndex, int maximumRows, string sort)
        {
            return this.FetchAll(name, description, cityId, statusId, franchiseeId).Count();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Advertiser> FetchAll(string name, string description, int cityId, int statusId, int franchiseeId, int startRowIndex, int maximumRows, string sort)
        {
            var advertisers = this.FetchAll(name, description, cityId, statusId, franchiseeId);

            if (!string.IsNullOrEmpty(sort))
            {
                if (sort.Contains(Advertiser.ColumnNames.Name))
                {
                    advertisers = advertisers.OrderBy(d => d.Name);
                    //if (sort.Contains("ASC"))
                    //    advertisers = advertisers.OrderBy(d => d.Name);
                    //else
                    //    advertisers = advertisers.OrderByDescending(d => d.Name);
                }
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

            return advertisers.Skip(startRowIndex).Take(maximumRows).ToList();
        }

        /// <summary>
        /// Obtiene la cantidad de modificaciones que han sucedido desde una fecha determinada al momento de la ejecucíón de la función
        /// </summary>
        /// <param name="date">fecha a partir de la cual se cuentan los cambios</param>
        /// <returns>Cantidad de cambios</returns>
        public int FetchChangesSince(DateTime date)//, int franchiseeId)
        {
            return (from x in this.db.Advertiser
                    where x.ModifiedOn >= date
                    //&& x.FranchiseeId == franchiseeId 
                    select x).Count();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<Advertiser> FetchFullTextSearchResult(string keywords, int franchiseeId)
        {
            return from x in this.db.Advertiser
                   where !x.Deleted
                   && x.Name.Contains(keywords)
                   && x.FranchiseeId == franchiseeId
                   orderby x.Name
                   select x;
        }


        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<KeyValuePair<int, string>> FetchMagazineItemsByName(string filter, int franchiseeId)
        {
            /*List<Advertiser> data = from x in this.db.Advertisers
                                    where !x.Deleted
                                    && x.Name.Contains(filter)
                                    orderby x.Name
                                    select x;
            return data;*/
            //KeyValuePair<int,string> a = new KeyValuePair<int,string>();
            if (string.IsNullOrEmpty(filter))
            {
                var data = from x in this.db.Advertiser
                           join y in this.db.Announces on x.AdvertiserId equals y.AdvertiserId
                           join z in this.db.Pages on y.PageId equals z.PageId
                           where !x.Deleted
                                 && x.FranchiseeId == franchiseeId
                           orderby x.Name
                           select new KeyValuePair<int, string>(z.SyncNumber, x.Name);
                return data.ToList();
            }
            else
            {
                var data = from x in this.db.Advertiser
                           join y in this.db.Announces on x.AdvertiserId equals y.AdvertiserId
                           join z in this.db.Pages on y.PageId equals z.PageId
                           where !x.Deleted && x.Name.Contains(filter)
                                 && x.FranchiseeId == franchiseeId
                           orderby x.Name
                           select new KeyValuePair<int, string>(z.SyncNumber, x.Name);
                return data.ToList();
            }

        }

        public override Advertiser FetchById(int id)
        {
            return (from x in this.db.Advertiser where x.AdvertiserId == id select x).FirstOrDefault();
        }

        public IQueryable<Advertiser> FetchByQueryableId(int id)
        {
            return from x in this.db.Advertiser where x.AdvertiserId == id select x;
        }

        public override IQueryable<Advertiser> FetchAll()
        {
            throw new NotImplementedException();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<Advertiser> FetchAll(string name, string description, int cityId, int statusId)
        {
            var advertisers = from x in this.db.Advertiser
                              where !x.Deleted
                              select x;

            if (!string.IsNullOrEmpty(name))
                advertisers = from x in advertisers
                              where x.Name.Contains(name)
                              select x;

            if (!string.IsNullOrEmpty(description))
                advertisers = from x in advertisers
                              where x.Description.Contains(description)
                              select x;

            if (cityId > 0)
                advertisers = from x in advertisers
                              where x.CityId == cityId
                              select x;

            //if (statusId > 0)
            //    advertisers = from x in advertisers
            //                  where x.StatusId == statusId
            //                  select x;


            return advertisers;
        }

        //public int FetchAllCount(string name, string description, int cityId, int statusId, int publishedIn, int startRowIndex, int maximumRows, string sort)
        //{
        //    return this.FetchAll(name, description, cityId, statusId).Count();
        //}

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Advertiser> FetchAllForFranchiseePrimary(string name, string description, int cityId, int statusId, int franchiseeId, int publishedIn, DateTime? startDate, DateTime? endDate, int startRowIndex, int maximumRows, string sort)
        {
            var advertisers = this.FetchAllForFranchiseePrimary(name, description, cityId, statusId, franchiseeId, publishedIn, startDate, endDate);

            if (!string.IsNullOrEmpty(sort))
            {
                if (sort.Contains(Advertiser.ColumnNames.Name))
                {
                    advertisers = advertisers.OrderBy(d => d.Name);
                }
            }

            return advertisers.Skip(startRowIndex).Take(maximumRows).ToList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<Advertiser> FetchAllForFranchiseePrimary(string name, string description, int cityId, int statusId, int franchiseeId, int publishedIn, DateTime? startDate, DateTime? endDate)
        {
            var advertisers = from x in this.db.Advertiser
                              where !x.Deleted
                              select x;

            if (startDate.HasValue)
            {
                advertisers = from x in advertisers
                              where x.EndDate.Value.Date >= startDate.Value.Date
                              select x;
            }

            if (endDate.HasValue)
            {
                advertisers = from x in advertisers
                              where x.EndDate.Value.Date <= endDate.Value.Date
                              select x;
            }

            if (startDate.HasValue || endDate.HasValue)
            {
                var minValue = (from x in this.db.Contracts
                                select x.EndDate).Min();
                var maxValue = (from x in this.db.Contracts
                                select x.EndDate).Max();

                var expiringAdvertisers = (from x in this.db.Contracts
                                           where
                                           x.EndDate > (startDate.HasValue ? startDate.Value : minValue)
                                           && x.EndDate < (endDate.HasValue ? endDate.Value : maxValue)
                                           select x.AdvertiserId).Distinct();

                advertisers = from x in advertisers
                              where expiringAdvertisers.Contains(x.AdvertiserId)
                              select x;
            }

            if (franchiseeId > 0)
            {
                advertisers = from x in advertisers
                              where x.FranchiseeId == franchiseeId
                              select x;
            }

            var contracts = (from x in this.db.Contracts select x.AdvertiserId).ToList();
            if ((int)PublishedStatusEnum.SinFiltro != publishedIn)
            {
                switch (publishedIn)
                {
                    case (int)PublishedStatusEnum.SinPublicar:
                        int[] devices = new[] { (int)AccountConceptKeyEnum.AndroidApp, (int)AccountConceptKeyEnum.iOsApp, (int)AccountConceptKeyEnum.Website };
                        advertisers = from x in advertisers
                                      join y in this.db.Contracts on x.AdvertiserId equals y.AdvertiserId
                                      where !x.Deleted
                                      && y.ContractDate < DateTime.Now
                                      && y.EndDate > DateTime.Now
                                      && y.AccountDetails.Where(z => !z.Deleted && z.Quantity == 0 && devices.Contains(z.AccountConceptId)).Count() > 0
                                      select x;
                        break;
                    //case (int)PublishedStatusEnum.Web:
                    //    advertisers = from x in advertisers
                    //                  where x.ShowInWebsite
                    //                  select x;
                    //    break;
                    //case (int)PublishedStatusEnum.IOS:
                    //    advertisers = from x in advertisers
                    //                  where x.ShowInIOs
                    //                  select x;
                    //    break;
                    //case (int)PublishedStatusEnum.PublishedNotPaid:
                    //    contracts = (from s in this.db.Contracts
                    //                 where !s.Deleted
                    //                 && !s.IsPaid
                    //                 && s.ContractDate < DateTime.Now
                    //                 && s.EndDate > DateTime.Now
                    //                 select s.AdvertiserId).Distinct().ToList();

                    //    advertisers = from x in advertisers
                    //                  where (x.ShowInIOs || x.ShowInWebsite) && contracts.Contains(x.AdvertiserId)
                    //                  select x;
                    //    break;
                    case (int)PublishedStatusEnum.NotPaid:
                        contracts = (from s in this.db.Contracts
                                     where !s.Deleted
                                     && !s.IsPaid
                                     && s.ContractDate < DateTime.Now
                                     && s.EndDate > DateTime.Now
                                     select s.AdvertiserId).Distinct().ToList();

                        advertisers = from x in advertisers
                                      where contracts.Contains(x.AdvertiserId)
                                      select x;
                        break;

                    case (int)PublishedStatusEnum.PaidNotPublished:
                        contracts = (from s in this.db.Contracts
                                     where !s.Deleted
                                     && s.IsPaid
                                     && s.ContractDate < DateTime.Now
                                     && s.EndDate > DateTime.Now
                                     select s.AdvertiserId).Distinct().ToList();

                        //advertisers = from x in advertisers
                        //              where (!x.ShowInIOs && !x.ShowInWebsite) && contracts.Contains(x.AdvertiserId)
                        //              select x;
                        break;

                }
            }

            if (!string.IsNullOrEmpty(name))
                advertisers = from x in advertisers
                              where x.Name.Contains(name)
                              select x;

            if (!string.IsNullOrEmpty(description))
                advertisers = from x in advertisers
                              where x.Description.Contains(description)
                              select x;

            if (cityId > 0)
                advertisers = from x in advertisers
                              where x.CityId == cityId
                              select x;

            //if (statusId > 0)
            //    advertisers = from x in advertisers
            //                  where x.StatusId == statusId
            //                  select x;


            return advertisers;
        }

        public int FetchAllCountForFranchiseePrimary(string name, string description, int cityId, int statusId, int franchiseeId, int publishedIn, DateTime? startDate, DateTime? endDate, int startRowIndex, int maximumRows, string sort)
        {
            return this.FetchAllForFranchiseePrimary(name, description, cityId, statusId, franchiseeId, publishedIn, startDate, endDate).Count();
        }

        public DateTime LastHireFor(int franchisee)
        {
            var lastHire = from x in this.db.Contracts
                           where x.Advertiser.FranchiseeId == franchisee
                           && !x.Deleted
                           && !x.Advertiser.Deleted
                           orderby x.ContractDate descending
                           select x.ContractDate;

            return lastHire.FirstOrDefault();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Advertiser> FetchAllLessDV(string nameAdvertiser, int estadoId, int municipioId, int startRowIndex, int maximumRows, string sort)
        {
            var advertisers = this.FetchAllDV(nameAdvertiser, estadoId, municipioId, false);

            if (!string.IsNullOrEmpty(sort))
            {
                if (sort.Contains(Advertiser.ColumnNames.Name))
                {
                    advertisers = advertisers.OrderBy(d => d.Name);
                }
            }

            return advertisers.Skip(startRowIndex).Take(maximumRows).ToList();
        }

        public int FetchAllLessDVCount(string nameAdvertiser, int estadoId, int municipioId, int startRowIndex, int maximumRows, string sort)
        {
            return this.FetchAllDV(nameAdvertiser, estadoId, municipioId, false).Count();
        }

        private IQueryable<Advertiser> FetchAllDV(string nameAdvertiser, int estadoId, int municipioId, bool hasDV)
        {
            var advertisers = (from x in this.db.Advertiser
                               where !x.Deleted
                               select x);

            if (hasDV)
            {
                advertisers = (from x in advertisers
                               where (x.DV != null || x.DV != "")
                               select x);
            }
            else
            {
                advertisers = (from x in advertisers
                               where (x.DV == null || x.DV == "")
                               select x);
            }

            if (!string.IsNullOrEmpty(nameAdvertiser))
            {
                advertisers = (from x in advertisers
                               where x.Name.Contains(nameAdvertiser)
                               select x);
            }

            if (estadoId > 0)
            {
                advertisers = (from x in advertisers
                               where x.Municipio.EstadoId == estadoId
                               select x);

                if (municipioId > 0)
                {
                    advertisers = (from x in advertisers
                                   where x.MunicipioId == municipioId
                                   select x);
                }
            }

            advertisers = (from x in advertisers
                           orderby x.Name ascending
                           select x);

            return advertisers;
        }

    }
}
