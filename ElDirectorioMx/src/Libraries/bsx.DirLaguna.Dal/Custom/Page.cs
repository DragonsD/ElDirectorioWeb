using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class Page
    {
        public string MagazinePageName { get { return string.Format("page_{0}.jpg", this.PageId); } }
    }
}
