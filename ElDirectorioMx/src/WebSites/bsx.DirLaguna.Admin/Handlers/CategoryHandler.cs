using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb;

namespace bsx.DirLaguna.Admin.Handlers
{
    public class CategoryHandler : IHttpHandler
    {
        public bool IsReusable { get { return false; } }

        public void ProcessRequest(HttpContext context)
        {
            string logoName = FileHelper.GetFile(context.Server.MapPath(Navigation.Config.CategoryPath), string.Format("{0}.*", context.Request[QueryKeys.CategoryId]));

            if (string.IsNullOrEmpty(logoName))
                logoName = "default_thumb.png";

            context.Response.ContentType = "image/png";
            context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", logoName));

            string FullLogoName = string.Format("{0}\\{1}", context.Server.MapPath(Navigation.Config.CategoryPath), logoName);
            context.Response.TransmitFile(FullLogoName);

        }
    }
}