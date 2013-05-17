using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb;

namespace bsx.DirLaguna.Admin.Handlers
{
    public class CatPublicityHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string swfName = FileHelper.GetFile(context.Server.MapPath(Navigation.Config.CatPublicityPath), string.Format("{0}.*", context.Request.QueryString[QueryKeys.CategoryId]));
            string directory = Navigation.Config.CatPublicityPath;

            if (string.IsNullOrEmpty(swfName))
            {
                swfName = SwfNames.DefaultCatPublicityName;
                directory = Navigation.Config.GenPublicityPath;
            }

            context.Response.ContentType = "application/x-shockwave-flash";
            string FullLogoName = string.Format("{0}\\{1}", context.Server.MapPath(directory), swfName);
            context.Response.WriteFile(FullLogoName);

        }
    }
}