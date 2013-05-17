using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class CatPublicity
    {
        public static string CatPublicityFileName(int id) { return string.Format("{0}.swf", id); }

        public string GetPublicityFileName(string path) { return FileHelper.GetFile(path, string.Format("{0}", CatPublicityFileName(this.CatPublicityId))); }


    }
}
