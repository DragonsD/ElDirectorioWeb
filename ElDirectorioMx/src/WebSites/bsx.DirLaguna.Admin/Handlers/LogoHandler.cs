using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Admin.Code;
using System.IO;

namespace bsx.DirLaguna.Admin.Handlers
{
    public class LogoHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string logoName = FileHelper.GetFile(context.Server.MapPath(Navigation.Config.LogoPath), string.Format("{0}.*", Advertiser.LogoThumbFileNameMask(int.Parse(context.Request[QueryKeys.AdvertiserId]))));

            if (string.IsNullOrEmpty(logoName))
                logoName = "default_thumb.jpg";

            context.Response.ContentType = "image/jpeg";
            context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", logoName));

            string FullLogoName = string.Format("{0}\\{1}", context.Server.MapPath(Navigation.Config.LogoPath), logoName);
            context.Response.TransmitFile(FullLogoName);
        }
    }
}