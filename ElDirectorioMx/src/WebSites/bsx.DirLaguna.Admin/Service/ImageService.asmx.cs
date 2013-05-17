using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb;
using System.IO;
using System.Drawing;


namespace bsx.DirLaguna.Admin.Service
{
    /// <summary>
    /// Summary description for ImageService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ImageService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public bool SaveLogo(int advertiserId, byte[] contentImg, string extension, out List<string> errors)
        {
            bool bResult = true;
            List<string> err = new List<string>();
            try
            {
                Advertiser adv = new AdvertiserController().FetchById(advertiserId);

                if (adv == null)
                {
                    err.Add("No se encontro el Anunciante");
                    errors = err;
                    return false;
                }

                FileHelper.DeleteExistingFiles(this.Server.MapPath(Navigation.Config.LogoPath), bsx.DirLaguna.Dal.Advertiser.LogoFileNameMask(advertiserId) + ".*");
                FileHelper.DeleteExistingFiles(this.Server.MapPath(Navigation.Config.LogoPath), bsx.DirLaguna.Dal.Advertiser.LogoFileNameMask(advertiserId) + ".*");

                string saveLocation = string.Format("{0}\\{1}.{2}", this.Server.MapPath(Navigation.Config.LogoPath), Advertiser.LogoFileNameMask(advertiserId), extension.ToLower());
                string thumbLocation = string.Format("{0}\\{1}.{2}", this.Server.MapPath(Navigation.Config.LogoPath), bsx.DirLaguna.Dal.Advertiser.LogoThumbFileNameMask(advertiserId), extension.ToLower());

                Stream stream = new MemoryStream(contentImg);
                Image img = Image.FromStream(stream);
                img.Save(saveLocation);
                ThumbnailHelper thumb = new ThumbnailHelper(70, 70);
                thumb.ProcessNewImage(stream, thumbLocation, 180m);

            }
            catch (Exception ex)
            {
                bResult = false;
                err.Add("Error al subir el archivo");
                //err.Add(ex.Message);
            }

            errors = err;
            return bResult;
        }

        [WebMethod]
        public bool SavePicture(int advertiserId, int galleryId, int newPictureId, byte[] contentImg, string extension, out List<string> errors)
        {
            bool bResult = true;
            List<string> err = new List<string>();
            try
            {
                Advertiser adv = new AdvertiserController().FetchById(advertiserId);

                if (adv == null)
                {
                    err.Add("No se encontro el Anunciante");
                    errors = err;
                    return false;
                }

                string pathBase = string.Format("{0}\\{1}\\{2}\\", this.Server.MapPath(Navigation.Config.GalleryPath), advertiserId, galleryId); ; ;
                if (!Directory.Exists(pathBase))
                    Directory.CreateDirectory(pathBase);

                string saveLocation = string.Format("{0}\\{1}.{2}", pathBase, Advertiser.PictureFileNameMask(newPictureId), extension.ToLower());

                Stream stream = new MemoryStream(contentImg);
                ThumbnailHelper picture = new ThumbnailHelper(97, 97);
                picture.ProcessNewImage(stream, saveLocation, 600m);

                string thumbLocation = string.Format("{0}\\{1}.{2}", pathBase, Advertiser.PictureThumbFileNameMask(newPictureId), extension.ToLower());
                ThumbnailHelper thumb = new ThumbnailHelper(70, 70);
                thumb.ProcessNewImage(stream, thumbLocation, 180m);

            }
            catch (Exception ex)
            {
                bResult = false;
                err.Add("Error al subir el archivo");
                //err.Add(ex.Message);
            }

            errors = err;
            return bResult;
        }

        [WebMethod]
        public bool SaveCouponSet(int advertiserId, int couponSetId, int newPictureId, byte[] contentImg, string extension, out List<string> errors)
        {
            bool bResult = true;
            List<string> err = new List<string>();
            try
            {
                Advertiser adv = new AdvertiserController().FetchById(advertiserId);

                if (adv == null)
                {
                    err.Add("No se encontro el Anunciante");
                    errors = err;
                    return false;
                }

                // Content/CouponSets/[AdvertiserId]/[CouponSetId]/[IdCoupon]_[small | medium | large].jpg
                string ContentCouponSetsUrl = string.Format("{0}/{1}", this.Server.MapPath(Navigation.Config.CouponImagesPath), Coupon.ImageFileUrl(advertiserId, couponSetId));
                if (!Directory.Exists(ContentCouponSetsUrl))
                    Directory.CreateDirectory(ContentCouponSetsUrl);

                FileHelper.DeleteExistingFiles(this.Server.MapPath(Navigation.Config.CouponImagesPath), Coupon.ImageFileNameSmall(advertiserId, couponSetId, newPictureId) + ".*");
                FileHelper.DeleteExistingFiles(this.Server.MapPath(Navigation.Config.CouponImagesPath), Coupon.ImageFileNameMedium(advertiserId, couponSetId, newPictureId) + ".*");
                FileHelper.DeleteExistingFiles(this.Server.MapPath(Navigation.Config.CouponImagesPath), Coupon.ImageFileNameLarge(advertiserId, couponSetId, newPictureId) + ".*");

                string saveLocationSmall = string.Format("{0}\\{1}.{2}", this.Server.MapPath(Navigation.Config.CouponImagesPath), Coupon.ImageFileNameSmall(advertiserId, couponSetId, newPictureId), "jpg");
                string saveLocationMedium = string.Format("{0}\\{1}.{2}", this.Server.MapPath(Navigation.Config.CouponImagesPath), Coupon.ImageFileNameMedium(advertiserId, couponSetId, newPictureId), "jpg");
                string saveLocationLarge = string.Format("{0}\\{1}.{2}", this.Server.MapPath(Navigation.Config.CouponImagesPath), Coupon.ImageFileNameLarge(advertiserId, couponSetId, newPictureId), "jpg");

                string thumbLocation = string.Format("{0}\\{1}.{2}", this.Server.MapPath(Navigation.Config.LogoPath), bsx.DirLaguna.Dal.Advertiser.LogoThumbFileNameMask(newPictureId), extension.ToLower());
                //Server.MapPath("Data") + "\\" + fn;
                try
                {
                    //this.LogoUpload.PostedFile.SaveAs(saveLocationSmall);

                    
                    Stream stream = new MemoryStream(contentImg);
                    ThumbnailHelper picture = new ThumbnailHelper(97, 97);


                    picture.ProcessNewImage(stream, saveLocationSmall, 150m);
                    picture.ProcessNewImage(stream, saveLocationMedium, 195m);
                    picture.ProcessNewImage(stream, saveLocationLarge, 600m);
                }
                catch (Exception ex)
                {
                    bResult = false;
                    err.Add("Error al subir el archivo");
                }


            }
            catch (Exception ex)
            {
                bResult = false;
                err.Add("Error al subir el archivo");
                //err.Add(ex.Message);
            }

            errors = err;
            return bResult;
        }


    }
}
