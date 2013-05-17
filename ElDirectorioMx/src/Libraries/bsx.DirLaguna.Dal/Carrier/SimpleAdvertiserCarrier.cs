using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal.Carrier
{
 public  class SimpleAdvertiserCarrier
    {
     public Guid UserId { get; set; }

     public int FranchiseeId { get; set; }

     public int AdvertiserId { get; set; }

     public int PersonalId { get; set; }

     public string Name { get; set; }

     public string Description { get; set; }

     public string PromocionesClub { get; set; }

     public string Street { get; set; }

     public string Number { get; set; }

     public string ZipCode { get; set; }

     public string Neighbornhod { get; set; }

     public int EstadoId { get; set; }

     public int MunicipioId { get; set; }

     public string WebPage { get; set; }

     public string Facebook { get; set; }

     public string Twitter { get; set; }

     public string YouTubeVideo { get; set; }

     public decimal? mapX { get; set; }

     public decimal? mapY { get; set; }

     public List<SimpleTableCarrier> Phones { get; set; }

     public List<SimpleTableCarrier> Emails { get; set; }

     public List<SimpleTableCarrier> Categories { get; set; }

     public List<SimpleTableCarrier> Tags { get; set; }

     public string AditionalInfo { get; set; }

     public SimpleFiscalDetailCarrier FiscalCarrier { get; set; }

     public SimpleAccountDetailCarrier AccountCarrier { get; set; }
    }
}
