using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal.Carrier
{
    [Serializable]
    public class SimpleContractTransactionCarrier
    {
        public int ContractId { get; set; }
        public string TransactionId { get; set; }
        public decimal PaymentAmount { get; set; }

        public SimpleContractTransactionCarrier()
        {
            this.ContractId = -1;
            this.TransactionId = "-1"; 
            this.PaymentAmount = 0;
        }

    }
}
