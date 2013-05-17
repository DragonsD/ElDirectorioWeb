using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class ShareLevel
    {
        public string NameComplete
        {
            get { return string.Format("{0} ({1}%)", this.Description, this.Percentage); }
        }
    }
}
