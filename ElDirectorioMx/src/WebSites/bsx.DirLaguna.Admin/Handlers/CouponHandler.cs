using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Admin.Code;

namespace bsx.DirLaguna.Admin.Handlers
{
    public class CouponHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var coupon = new CouponController().FetchById(int.Parse(context.Request.QueryString[QueryKeys.CouponId]));
            if (coupon == null)
                return;

            string fullPictureName = coupon.FetchPicturePath(context.Server.MapPath(Navigation.Config.CouponImagesPath), context.Request.QueryString[QueryKeys.CouponSize]);
            if (string.IsNullOrEmpty(fullPictureName))
                context.Response.End();

            context.Response.ContentType = "image/jpeg";
            context.Response.TransmitFile(fullPictureName);
        }
    }
}