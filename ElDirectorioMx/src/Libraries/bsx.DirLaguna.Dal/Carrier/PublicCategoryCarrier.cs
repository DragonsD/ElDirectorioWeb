using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal.Carrier
{
    public class PublicCategoryCarrier
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public PublicCategoryCarrier()
        {
            this.CreatedOn = DateTime.Now;
        }
    }
}
