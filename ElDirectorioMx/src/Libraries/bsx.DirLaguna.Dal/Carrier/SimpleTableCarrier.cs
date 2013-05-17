using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal.Carrier
{
    [Serializable]
    public class SimpleTableCarrier
    {
        public SimpleTableCarrier()
        {
            this.UiId = Guid.NewGuid();
            this.Id = 0;
            this.TypeId = 0;
            this.ExternalId = 0;
            this.Deleted = false;
            this.CreatedOn = DateTime.Now;
        }

        public Guid UiId { get; set; }

        public int Id { get; set; }

        public string Description { get; set; }

        public int TypeId { get; set; }

        public string TypeDescription { get; set; }

        public int ExternalId { get; set; }

        public bool Deleted { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
