using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb;

namespace bsx.DirLaguna.Admin.Handlers
{
    public class FullPictureHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string virtualName = Picture.FullPicture(int.Parse(context.Request[QueryKeys.PictureId]), bool.Parse(context.Request[QueryKeys.IsFullPicture]));

            string pictureName = FileHelper.GetFile(
                context.Server.MapPath(Navigation.Config.GalleryPath),
                virtualName);

            if (string.IsNullOrEmpty(pictureName))
                pictureName = "default_thumb.jpg";

            context.Response.ContentType = "image/jpeg";
            //context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", pictureName));

            string FullPictureName = string.Format("{0}\\{1}", context.Server.MapPath(Navigation.Config.GalleryPath), virtualName);
            context.Response.TransmitFile(FullPictureName);
        }
    }
}