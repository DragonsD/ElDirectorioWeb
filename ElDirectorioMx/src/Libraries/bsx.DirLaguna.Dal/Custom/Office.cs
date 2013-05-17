using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class Office
    {
        public const string MatrizName = "Matriz";

        public string HtmlAddress { get { return TextHelper.HtmlCleaner(this.CompleteAddress); } }

        public string CompleteAddress
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(this.Address);
                if (!string.IsNullOrEmpty(this.Number))
                    builder.AppendFormat(" No. {0}", this.Number);
                if (!string.IsNullOrEmpty(this.Neibornhod))
                    builder.AppendFormat(" {0}.", this.Neibornhod);
                if (!string.IsNullOrEmpty(this.ZipCode))
                    builder.AppendFormat(" CP. {0}", this.ZipCode);

                return builder.ToString();
            }
        }
    }
}
