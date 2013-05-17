using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Dal.SelectControllers;

namespace bsx.DirLaguna.Admin.Handlers
{
    public class PublicityHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var publicity = new PublicityController().FetchById(int.Parse(context.Request.QueryString[QueryKeys.PublicityId]));
            if (publicity == null)
                return;

            string fullPictureName = publicity.FetchPicturePath(context.Server.MapPath(Navigation.Config.PublicityImagesPath));
            if (string.IsNullOrEmpty(fullPictureName))
                context.Response.End();

            context.Response.ContentType = "image/jpeg";
            context.Response.TransmitFile(fullPictureName);
        }
    }
}