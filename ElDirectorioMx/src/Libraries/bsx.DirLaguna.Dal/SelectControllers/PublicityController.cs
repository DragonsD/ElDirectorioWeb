using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bsx.DirLaguna.Dal;
using System.ComponentModel;
using bsx.DirLaguna.Dal.SelectControllers;

namespace bsx.DirLaguna.Dal.SelectControllers
{
    public partial class PublicityController : BaseController<Publicity>
    {
        public PublicityController()
            : base()
        {

        }

        public PublicityController(DirLagunaModelDataContext context) :
            base(context)
        {

        }

        public override Publicity FetchById(int id)
        {
            return (from x in this.db.Publicity
                    where x.PublicityID == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<Publicity> FetchAll()
        {
            return from x in this.db.Publicity
                   select x;
        }

        public IQueryable<Publicity> FetchFromIds(List<int> ids)
        {
            return from x in this.db.Publicity
                   where ids.Contains(x.PublicityID)
                   select x;
        }

        public IQueryable<Publicity> FetchByCityId(int Cityid)
        {
            return (from x in this.db.Publicity
                    where x.CityId == Cityid
                    orderby x.Prioridad descending
                    select x);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<Publicity> FetchbyCity(int cityId, int startRowIndex, int maximumRows)
        {
            var coupons = this.FetchByCityId(cityId);

            return coupons.Skip(startRowIndex).Take(maximumRows);
        }


        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<Publicity> FetchAll(int publicityId, int cityId)
        {
            var publicities = from x in this.db.Publicity
                              select x;

            if (cityId > 0)
                publicities = from x in publicities
                              where x.PublicityID == publicityId
                              select x;
            return publicities;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IQueryable<Publicity> fetchbyCityId(int cityId)
        {
            var publicities = from x in this.db.Publicity
                              select x;

            if (cityId > 0)
                publicities = from x in publicities
                              where x.CityId == cityId
                              select x;
            return publicities;
        }

        public int FetchAllCount(int publicityId, int cityId, int startRowIndex, int maximumRows)
        {
            return this.FetchAll(publicityId, cityId).Count();
        }
    }
}
