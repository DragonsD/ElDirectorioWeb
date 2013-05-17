using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal.Carrier
{
    [Serializable]
    public class SimpleFiscalDetailCarrier
    {
        public bool IsValid { get { return !string.IsNullOrEmpty(this.RFC); } }

        public int FiscalDetailId { get; set; }
        public string FiscalName { get; set; }
        public string RFC { get; set; }
        public int EstadoId { get; set; }
        public int MunicipioId { get; set; }
        public string Poblacion { get; set; }
        public string Street { get; set; }
        public string ExteriorNumber { get; set; }
        public string InteriorNumber { get; set; }
        public string Colony { get; set; }
        public string ZipCode { get; set; }
        public string ContactEmail { get; set; }

        public SimpleFiscalDetailCarrier()
        {
             this.FiscalDetailId= -1;
             this.FiscalName= string.Empty;
             this.RFC= string.Empty;
             this.EstadoId= -1;
             this.MunicipioId= -1;
             this.Poblacion= string.Empty;
             this.Street= string.Empty;
             this.ExteriorNumber= string.Empty;
             this.InteriorNumber= string.Empty;
             this.Colony= string.Empty;
             this.ZipCode= string.Empty;
             this.ContactEmail = string.Empty;
        }
    }
}
