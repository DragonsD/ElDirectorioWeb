using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Torreon.Utility.CKEditor
{
    /// <summary>
    /// Summary description for ImageUploaderHandler
    /// </summary>
    public class ImageUploaderHandler : IHttpHandler
    {
        public ImageUploaderHandler()
        {
        }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Files.Count <= 0)
            {
                return;
            }
            HttpPostedFile f = context.Request.Files[0];
            string virtualPath = string.Format("~/content/inblogpost/{0}", this.GenerateNewFileName(f));
            f.SaveAs(HttpContext.Current.Server.MapPath(virtualPath));
            string url = VirtualPathUtility.ToAbsolute(virtualPath);
            string name = context.Request["CKEditorFuncNum"];
            context.Response.Write(string.Format("<script>window.parent.CKEDITOR.tools.callFunction('{0}', '{1}');</script>", name, url));
        }

        protected virtual string GenerateNewFileName(HttpPostedFile file)
        {
            string finalFileName = System.IO.Path.GetFileNameWithoutExtension(file.FileName);
            if (finalFileName.Length > 20)
                finalFileName = finalFileName.Substring(0, 25);
            DateTime now = DateTime.Now;
            finalFileName = string.Format("{0}-{1:00}{2:00}{3:00}{4}{5}", finalFileName, now.Hour, now.Day, now.Month, now.Year,
                System.IO.Path.GetExtension(file.FileName));
            return finalFileName;
        }
    }
}