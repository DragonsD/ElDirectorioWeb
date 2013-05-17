using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class PictureController
    {
        public bool Save(int pictureId, int galleryId, string description, int franchiseeId, int userId, out int newPictureId)
        {
            bool result = false;
                newPictureId= -1;

            Picture picture = this.FetchById(pictureId, franchiseeId);
            if (picture == null)
            {
                picture = new Picture();
                this.db.Pictures.InsertOnSubmit(picture);
            }

            picture.GalleryId = galleryId;
            picture.Description = description;
            picture.FranchiseeId = franchiseeId;
            GalleryController galleryController = new GalleryController();
            Gallery gallery = galleryController.FetchById(galleryId, franchiseeId);

            AdvertiserController controllerAdvertiser = new AdvertiserController(this.db);
            Advertiser advertiser = controllerAdvertiser.FetchById(gallery.AdvertiserId, gallery.FranchiseeId);
            if (advertiser != null)
                advertiser.ModifiedOn = DateTime.Now;

            try
            {
                this.db.SubmitChanges();
                newPictureId = picture.PictureId;
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
                newPictureId= -1;
            }

            return result;
        }

        public bool Delete(int pictureId, int franchiseeId, int userId)
        {
            bool result = false;

            Picture picture = this.FetchById(pictureId, franchiseeId);
            if (picture == null)
            {
                this.Errors.Add("El elemento no existe");
                return false;
            }

            try
            {
                picture.Deleted = true;
                AdvertiserController controllerAdvertiser = new AdvertiserController(this.db);
                Advertiser advertiser = controllerAdvertiser.FetchById(picture.Gallery.AdvertiserId, franchiseeId);
                if (advertiser != null)
                {
                    advertiser.ModifiedOn = DateTime.Now;
                    advertiser.UserModifiedOn = userId;
                }

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
