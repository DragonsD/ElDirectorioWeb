using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal.Carrier
{
    public class SimpleCardClubCarrier
    {
        public int CardID {get; set;}
        public int AdvertiserId { get; set; }
        public long Folio { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public string id { get; set; }
        public int GuestID { get; set; }
    }
}
