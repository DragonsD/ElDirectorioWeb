using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class Gallery
    {
        public const int MaxPictures = 5;

        public IQueryable<Picture> ActivePictures
        {
            get
            {
                PictureController controller = new PictureController();
                return controller.FetchAllByGalleryId(this.GalleryId, this.FranchiseeId);
            }
        }

        public int ActivePicturesCount
        {
            get
            {
                PictureController controller = new PictureController();
                return controller.FetchAllByGalleryId(this.GalleryId, this.FranchiseeId).Count();
            }
        }
    }
}
