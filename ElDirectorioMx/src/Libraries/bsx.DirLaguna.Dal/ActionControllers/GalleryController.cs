using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class GalleryController
    {
        public bool Save(int galleryId, string name, int advertiserId, int franchiseeId, int personalId)
        {
            bool result = false;

            Gallery gallery = this.FetchById(galleryId, franchiseeId);
            if (gallery == null)
            {
                gallery = new Gallery();
                this.db.Galleries.InsertOnSubmit(gallery);
            }

            gallery.AdvertiserId = advertiserId;
            gallery.Name = name;
            gallery.FranchiseeId = franchiseeId;
            Advertiser adv = new AdvertiserController(this.db).FetchById(advertiserId, franchiseeId);
            if (adv != null)
            {
                adv.ModifiedOn = DateTime.Now;
                adv.UserModifiedOn = personalId;
            }

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

        public bool Delete(int galleryId, int franchiseeId, int personalId)
        {
            bool result = false;

            Gallery gal = this.FetchById(galleryId, franchiseeId);
            if (gal == null)
            {
                this.Errors.Add("El elemento no existe");
                return false;
            }

            gal.Advertiser.ModifiedOn = DateTime.Now;
            gal.Advertiser.UserModifiedOn = personalId;

            try
            {
                gal.Deleted = true;
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
