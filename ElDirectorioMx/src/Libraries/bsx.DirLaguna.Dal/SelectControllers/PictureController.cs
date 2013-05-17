using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class PictureController : FranchiseeBaseController<Picture>
    {
        public override Picture FetchById(int id, int franchiseeId)
        {
            return (from x in this.db.Pictures
                    where x.PictureId == id && x.FranchiseeId == franchiseeId
                    select x).FirstOrDefault();
        }

        public override IQueryable<Picture> FetchAll(int franchiseeId)
        {
            return (from x in this.db.Pictures where x.FranchiseeId == franchiseeId select x);
        }

        public IQueryable<Picture> FetchAllByGalleryId(int galleryId, int franchiseeId)
        {
            return (from x in this.db.Pictures
                    where x.GalleryId == galleryId 
                    && x.FranchiseeId == franchiseeId
                    && !x.Deleted

                    select x);
        }

        public int GetTotalPictureByGalleryId(int galleryId, int franchiseeId)
        {
            return (from x in this.db.Pictures
                    where x.GalleryId == galleryId
                    && x.FranchiseeId == franchiseeId
                    && !x.Deleted
                    select x).Count();
        }


        public override Picture FetchById(int id)
        {
            return (from x in this.db.Pictures
                    where x.PictureId == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<Picture> FetchAll()
        {
            return from x in this.db.Pictures
                   where !x.Deleted
                   select x;
        }

        public IQueryable<Picture> FetchAllByGalleryId(int galleryId)
        {
            return (from x in this.db.Pictures
                    where x.GalleryId == galleryId
                    && !x.Deleted

                    select x);
        }

        public int GetTotalPictureByGalleryId(int galleryId)
        {
            return (from x in this.db.Pictures
                    where x.GalleryId == galleryId
                    && !x.Deleted
                    select x).Count();
        }

    }
}
