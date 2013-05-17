using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bsx.DirLaguna.CommonWeb;
using System.Configuration;

namespace bsx.DirLaguna.Public.Code
{
    public class CouponHelper
    {
        public static string CouponPictureUrl(int couponId, string size)
        {
            return string.Format("{0}?{1}={2}&{3}={4}", ConfigurationManager.AppSettings["UrlCouponHandler"], QueryKeys.CouponId, couponId, QueryKeys.CouponSize, size);
        }
    }
}