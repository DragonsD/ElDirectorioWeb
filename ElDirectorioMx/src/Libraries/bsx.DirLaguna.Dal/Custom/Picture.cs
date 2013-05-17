using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class Picture
    {
        public string Url(string handlerUrl)
        {
            //return string.Format("{0}/{1}_thumb", handlerUrl, this.PictureId);
            return "http://1.bp.blogspot.com/_MCb9cuHKMT0/Sk9MeY7SE7I/AAAAAAAANiI/VuuFzrvnFgk/s400/AnaColombianas.jpg";
        }

        public string PathGalleriesLocation(string pathBase)
        {
            return string.Format("{0}\\{1}\\{2}", pathBase, this.Gallery.AdvertiserId, this.GalleryId);
        }

        /// <summary>
        /// Obtener el nombre de la imagen a partir de la raiz
        /// </summary>
        /// <returns></returns>
        public static string FullPicture(int pictureId, bool IsFullPicture)
        {
            // 103/12/105.jpg -> IsFullPicture == true
            // 103/12/105_thumb.jpg  -> IsFullPicture == false
            Picture pct = new PictureController().FetchById(pictureId);
            if (IsFullPicture)
                return string.Format("{0}/{1}/{2}.jpg", pct.Gallery.AdvertiserId, pct.GalleryId, pct.PictureId);

            return string.Format("{0}/{1}/{2}_thumb.jpg", pct.Gallery.AdvertiserId, pct.GalleryId, pct.PictureId);
        }
    }
}
