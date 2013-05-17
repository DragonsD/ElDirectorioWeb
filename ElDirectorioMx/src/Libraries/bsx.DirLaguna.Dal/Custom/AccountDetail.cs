using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class AccountDetail
    {
        public string DisplayText { get { return string.Format(this.Quantity > 1 ? "{0} ({1})" : "{0}", this.AccountConcept.ConceptKey, this.Quantity); } }
    }
}
