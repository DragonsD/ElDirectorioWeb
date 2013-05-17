using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bsx.DirLaguna.Dal.Enum;

namespace bsx.DirLaguna.Dal
{
    public partial class Contract
    {
        public int FetchSpec(AccountConceptKeyEnum key)
        {
            ContractController controller = new ContractController();
            int quantity = controller.FetchSpec(this.ContractId, key);

            if (key == AccountConceptKeyEnum.Sucursales)
                quantity++;

            return quantity;
        }

        public bool IsCurrentSetup
        {
            get { return DateTime.Now > this.ContractDate && DateTime.Now < this.EndDate && this.IsActive && !this.Deleted; }
        }

        public string PurchaseDescription
        {
            get
            {
                var items = from x in this.AccountDetails where x.Quantity > 0 && x.Deleted == false select x;

                if (items.Count() == 0)
                    return string.Empty;

                StringBuilder builder = new StringBuilder();
                foreach (var item in items)
                {
                    if (item.AccountConcept.TotalMax == 1)
                        builder.AppendLine(item.AccountConcept.ConceptKey);

                    if (item.AccountConcept.TotalMax != 1)
                        builder.AppendLine(string.Format("{0} ({1})", item.AccountConcept.ConceptKey, item.Quantity));
                }
                return builder.ToString();
            }
        }
    }
}
