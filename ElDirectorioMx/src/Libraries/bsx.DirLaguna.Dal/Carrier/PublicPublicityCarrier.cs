using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal.Carrier
{
    public class PublicPublicityCarrier
    {
        public int PublicityId { get; set; }

        public int CityId { get; set; }

        public int Prioridad { get; set; }

        public string Picture { get; set; }

        string webpage;

        public string WebPage
        {
            get
            {
                if (this.webpage.IndexOf("http://") < 0 && this.webpage.Length > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("http://{0}", this.webpage);
                    return sb.ToString();
                }
                return this.webpage;
            }
            set { this.webpage = value; }
        }
    }
}
