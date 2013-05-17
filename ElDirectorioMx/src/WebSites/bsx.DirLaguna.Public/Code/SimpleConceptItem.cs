using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bsx.DirLaguna.Public.Code
{
    public class SimpleConceptItem
    {
        public int Id { get; set; }
        public string ConceptId { get; set; }
        public string Concept { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }

        public decimal FixQuantity
        {
            get
            {
                decimal q = 0;
                decimal.TryParse(this.Quantity, out q);
                return q;
            }
        }
        public decimal FixPrice
        {
            get
            {
                decimal q = 0;
                decimal.TryParse(this.Price, out q);
                return q;
            }
        }

        public bool IsValidItem
        {
            get
            {
                return this.Id > 0 && this.FixQuantity > 0;
            }
        }
    }
}