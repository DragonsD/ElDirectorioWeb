using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal.Carrier
{
    [Serializable]
    public class SimpleAccountDetailCarrier
    {
        public DateTime ContractDate { get; set; }
        public DateTime EndDate { get; set; }
        //public int Months { get; set; }
        public Dictionary<int, int> AccountDetils { get; set; }

        public SimpleAccountDetailCarrier()
        {
            this.ContractDate = DateTime.Today;
            this.EndDate = (DateTime.Today).AddYears(1); 
            //this.Months = 0;
            this.AccountDetils = new Dictionary<int, int>();
        }
    }
}
