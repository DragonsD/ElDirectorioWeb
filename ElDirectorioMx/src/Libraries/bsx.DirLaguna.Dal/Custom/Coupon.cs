using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace bsx.DirLaguna.Dal
{
    public partial class Coupon
    {
        public static string ImageFileUrl(int advertiserId, int couponSetId) { return string.Format("{0}/{1}/", advertiserId, couponSetId); }

        public static string ImageFileNameSmall(int advertiserId, int couponSetId, int id) { return string.Format("{0}/{1}/{2}_{3}", advertiserId, couponSetId, id, Coupon.Sizes.Small); }

        public static string ImageFileNameMedium(int advertiserId, int couponSetId, int id) { return string.Format("{0}/{1}/{2}_{3}", advertiserId, couponSetId, id, Coupon.Sizes.Medium); }

        public static string ImageFileNameLarge(int advertiserId, int couponSetId, int id) { return string.Format("{0}/{1}/{2}_{3}", advertiserId, couponSetId, id, Coupon.Sizes.Large); }

        public string FetchPicturePath(string basePath, string size)
        {
            var file = string.Format("{0}\\{1}\\{2}\\{3}_{4}.jpg", basePath, this.AdvertiserId, this.CouponSetId, this.CouponId, size);
            if (!File.Exists(file))
                return string.Empty;

            return file;
        }

        public struct Sizes
        {
            public const string Small = "small";

            public const string Medium = "medium";

            public const string Large = "large";
        }

        public List<Coupon> OtherAdvertiserCoupons
        {
            get
            {
                CouponController controller = new CouponController();
                return controller.FetchAdvertiserCoupons(this.AdvertiserId, this.isClub).ToList();
            }
        }

        public List<Coupon> RelatedCoupons
        {
            get
            {
                CouponController controller = new CouponController();
                return controller.FetchSimilarCoupons(this.CouponId).ToList();
            }
        }
    }
}
