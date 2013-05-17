using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using bsx.DirLaguna.CommonWeb;

namespace bsx.DirLaguna.Mobile.Code
{
    public class CouponHelper
    {
        public static string CouponPictureUrl(int couponId, string size)
        {
            return string.Format("{0}?{1}={2}&{3}={4}", ConfigurationManager.AppSettings["UrlCouponHandler"], QueryKeys.CouponId, couponId, QueryKeys.CouponSize, size);
        }
    }
}