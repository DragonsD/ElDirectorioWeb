using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal.Carrier
{
    public class PublicAdvertiserCarrier
    {
        public int AdvertiserId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }
        
        public string PromocionesClub { get; set; }

        public string CityName { get; set; }

        public bool Featured { get; set; }

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

        public static AdvertiserController controller;

        public static AdvertiserController Controller
        {
            get
            {
                if (controller == null)
                    controller = new AdvertiserController();

                return controller;
            }
        }

        public string FullAddress
        {
            get
            {
                var office = Controller.FetchById(this.AdvertiserId).ActiveOffices.Where(x => x.Name.Equals(Office.MatrizName)).FirstOrDefault();
                if (office != null)
                    return office.CompleteAddress;
                return string.Empty;
            }
        }
    }
}
