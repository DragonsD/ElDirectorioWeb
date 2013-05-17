using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using bsx.DirLaguna.Dal.Carrier;

namespace bsx.DirLaguna.Dal
{
    public class VwAdvertiserController : BaseController<VwAdvertiser>
    {
        public VwAdvertiserController() : base() { }

        public VwAdvertiserController(DirLagunaModelDataContext context) : base(context) { }

        public override VwAdvertiser FetchById(int id)
        {
            return (from x in this.db.VwAdvertiser
                    where x.AdvertiserId == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<VwAdvertiser> FetchAll()
        {
            return from x in this.db.VwAdvertiser
                   select x;
        }

        /// <summary>
        /// Obtiene los advertisers dependiendo de lo que se haya solicitado
        /// Si llega una letra saca todos los anunciantes que tengan una categoria que comienza con la letra especificada
        /// Si llega un numero saca todos los anunciantes que pertenescan a la categoria indicada con el identificador llegado
        /// </summary>
        /// <param name="requestedCategory">numero o letra. Depende de lo que se quiera obtener</param>
        /// <returns>Anunciantes que cumplan con el criterio</returns>
        /// 

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<PublicAdvertiserCarrier> fetchAll()
        {
            var advCat = from x in this.db.VwAdvertiser
                                select x;

            var advs = (from x in advCat
                        orderby x.Name ascending
                        select new PublicAdvertiserCarrier()
                        {
                            Address = x.Address,
                            AdvertiserId = x.AdvertiserId,
                            CityName = x.CityName,
                            Description = x.Description,
                            Name = x.Name,
                            WebPage = x.WebPage,
                            Featured = x.Featured
                        }).Distinct();
            return from x in advs orderby x.Name ascending select x;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<PublicAdvertiserCarrier> FetchCategoryAdvertisers(string requestedCategory, string keywords, int cityId)
        {
            var advertiserCat = from x in this.db.VwAdvertiser
                                select x;

            if (!string.IsNullOrEmpty(requestedCategory) && char.IsLetter(requestedCategory, 0))
            {
                string letter = requestedCategory[0].ToString();

                advertiserCat = from x in advertiserCat
                                where x.Letter.Equals(letter)
                                select x;
            }

            if (!string.IsNullOrEmpty(requestedCategory) && char.IsNumber(requestedCategory, 0))
                advertiserCat = from x in advertiserCat
                                where x.CategoryId == int.Parse(requestedCategory)
                                select x;

            if (cityId > 0)
                advertiserCat = from x in advertiserCat
                                where x.CityId == cityId
                                select x;

            if (!string.IsNullOrEmpty(keywords))
                advertiserCat = from x in advertiserCat
                                where (x.Name.Contains(keywords)
                                || x.Description.Contains(keywords)
                                || x.Tags.Contains(keywords))
                                select x;

            advertiserCat = (from x in advertiserCat select x).Distinct();

            var advs=  (from x in advertiserCat
                    orderby x.Name ascending
                    select new PublicAdvertiserCarrier()
                    {
                        Address = x.Address,
                        AdvertiserId = x.AdvertiserId,
                        CityName = x.CityName,
                        Description = x.Description,
                        Name = x.Name,
                        WebPage = x.WebPage,
                        Featured = x.Featured,
                        PromocionesClub = x.PromocionesClub
                    }).Distinct();

            return from x in advs orderby x.Name ascending select x;
        }

        public int FetchCategoryAdvertisersCount(string requestedCategory, string keywords, int cityId)
        {
            return this.FetchCategoryAdvertisers(requestedCategory, keywords, cityId).Count();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<PublicAdvertiserCarrier> FetchCategoryAdvertisers(string requestedCategory, string keywords, int startRowIndex, int maximumRows, int cityId)
        {
            var advertisers = this.FetchCategoryAdvertisers(requestedCategory, keywords, cityId);
            return advertisers.Skip(startRowIndex).Take(maximumRows);
        }
    }
}
