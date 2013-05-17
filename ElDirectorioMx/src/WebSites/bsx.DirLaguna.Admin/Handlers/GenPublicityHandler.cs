using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Admin.Handlers
{
    public class GenPublicityHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string swfName = FileHelper.GetFile(context.Server.MapPath(Navigation.Config.GenPublicityPath), string.Format("{0}.*", this.MainFlashName));

            if (string.IsNullOrEmpty(swfName))
                swfName = "default_thumb.jpg";

            context.Response.ContentType = "application/x-shockwave-flash";
            //context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", swfName));

            string FullLogoName = string.Format("{0}\\{1}", context.Server.MapPath(Navigation.Config.GenPublicityPath), swfName);
            context.Response.WriteFile(FullLogoName);
        }

        public string MainFlashName { get { return "MainFlash.swf"; } }

    }
}