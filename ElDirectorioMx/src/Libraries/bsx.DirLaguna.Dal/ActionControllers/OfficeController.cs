using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class OfficeController
    {
        public bool Delete(int advertiserId, int officeId, int franchiseeId, int personalId)
        {
            bool result = false;

            Office office = this.FetchById(officeId, franchiseeId);
            if (office == null || office.AdvertiserId != advertiserId)
            {
                this.Errors.Add("El elemento NO Existe");
                return false;
            }

            try
            {
                office.Deleted = true;
                office.Advertiser.ModifiedOn = DateTime.Now;
                office.Advertiser.UserModifiedOn = personalId;
                this.db.SubmitChanges();
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
            }

            return result;
        }

        public bool Save(int officeId, int advertiserId, int municipioId, string name, string address, string number, string zipCode, string neighnornhod, decimal? mapX, decimal? mapY, int franchiseeId, int userId)
        {
            bool result = false;

            Office office = this.FetchById(officeId, franchiseeId);
            if (office == null)
            {
                office = new Office();
                this.db.Offices.InsertOnSubmit(office);
            }

            office.AdvertiserId = advertiserId;

            var municipio = new MunicipioController().FetchById(municipioId);
            string mixName = string.Format("{0}, {1}", municipio.Name, municipio.Estado.Name);

            City ct = new CityController(this.db).FetchByName(mixName);
            if (ct == null)
            {
                ct = new City();
                this.db.City.InsertOnSubmit(ct);
                ct.Name = mixName;
            }

            office.City = ct;
            //office.CityId = cityId;
            office.MunicipioId = municipioId;
            office.Name = name;
            office.Address = address;
            office.Number = number;
            office.ZipCode = zipCode;
            office.Neibornhod = neighnornhod;
            office.Featured = false;

            if (mapX.HasValue)
                office.MapReferenceX = (double)mapX;
            if (mapY.HasValue)
                office.MapReferenceY = (double)mapY;

            office.Deleted = false;
            office.FranchiseeId = franchiseeId;

            Advertiser adv = new AdvertiserController(this.db).FetchById(advertiserId, franchiseeId);
            adv.ModifiedOn = DateTime.Now;
            adv.UserModifiedOn = userId;
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
