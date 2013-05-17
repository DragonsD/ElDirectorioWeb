using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bsx.DirLaguna.Dal.Carrier;

namespace bsx.DirLaguna.Dal.SelectControllers
{
    public partial class ClubCardController : BaseController<ClubCard>
    {
        public ClubCardController() : base() { }

        public ClubCardController(DirLagunaModelDataContext context) : base(context) { }

        public override ClubCard FetchById(int id)
        {
            return (from x in this.db.ClubCard
                    where x.CardID == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<ClubCard> FetchAll()
        {
            return from x in this.db.ClubCard
                   select x;
        }

        public int FetchAllCount()
        {
            return (from x in this.db.ClubCard
                    select x).Count();
        }

        public ClubCard FetchByFolio(long folio)
        {
            ClubCard clubcard = (from u in this.db.ClubCard
                                where u.Folio == folio
                                select u).FirstOrDefault();


            return clubcard;
        }

        public IQueryable<ClubCard> FetchByAdvertiser(int Advertiserid)
        {
            return (from x in db.ClubCard
                    join y in db.Advertiser on x.AdvertiserId equals y.AdvertiserId
                    where x.AdvertiserId == Advertiserid
                    select x);
        }


        public IQueryable<ClubCard> FetchByGuestFolio(int Advertiserid, int guestId)
        {
            return from x in this.db.ClubCard
                   join y in this.db.Advertiser on x.AdvertiserId equals y.AdvertiserId
                   where x.AdvertiserId == Advertiserid && x.GuestId == guestId

                   select x;
        }

        public bool SaveGuestId(long folio, int guestid) 
        {
            bool result = false;
            ClubCard cc = this.FetchByFolio(folio);
            if (cc != null) 
            {
                cc.GuestId = guestid;
                this.db.SubmitChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public bool Save(SimpleCardClubCarrier carrier)
        {
            bool result = false;
            ClubCard cc = this.FetchByFolio(carrier.Folio);

            if (cc != null) 
            {
                this.Errors.Add("Este Folio ya existe teclee otro folio, Por Favor");
                return result;
            }

            cc = new ClubCard();
            this.db.ClubCard.InsertOnSubmit(cc);

            cc.Folio = carrier.Folio;
            cc.FechaExpedicion = carrier.FechaExpedicion;
            cc.AdvertiserId = carrier.AdvertiserId;

            try
            {
                this.db.SubmitChanges();
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
            }

            return result;
        }
    }
}
