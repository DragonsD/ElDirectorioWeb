using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using bsx.DirLaguna.Dal.Enum;

namespace bsx.DirLaguna.Dal
{
    public partial class Publicity
    {
        public static string ImageFileUrl(int cityId) { return string.Format("{0}/", cityId); }
        
        public static string ImageFileName(int cityId, int publicityId) { return string.Format("{0}/{1}", cityId, publicityId); }

        public string FetchPicturePath(string basePath)
        {
            var file = string.Format("{0}\\{1}\\{2}.jpg", basePath, this.CityId, this.PublicityID);
            if (!File.Exists(file))
                return string.Empty;

            return file;
        }

        public string FixedWebPage
        {
            get
            {
                if (this.WebPage.IndexOf("http://") < 0 && this.WebPage.Length > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("http://{0}", this.WebPage);
                    return sb.ToString();
                }
                return this.WebPage;
            }
        }
    }
}
