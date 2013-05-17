using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal.Carrier
{
    public class SimpleFranchiseeCarrier
    {
        public int? ExternalKey { get; set; }

        public int FranchiseeId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string CellPhone { get; set; }

        public string BankReference { get; set; }

        public int MunicipioId { get; set; }

        public int ShareNivelId { get; set; }

        public string DV { get; set; }
    }
}
