using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class AccountConceptController : BaseController<AccountConcept>
    {
        public AccountConceptController() : base() { }

        public AccountConceptController(DirLagunaModelDataContext context) : base(context) { }

        public override AccountConcept FetchById(int id)
        {
            return (from x in this.db.AccountConcepts
                    where !x.Deleted && x.AccountConceptId == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<AccountConcept> FetchAll()
        {
            return (from x in this.db.AccountConcepts
                    where !x.Deleted
                    select x);
        }

        public List<AccountConcept> FetchListAllByConfiguration()
        {
            return (from x in this.db.AccountConcepts
                    where !x.Deleted && x.GorilaId != null
                    orderby x.ConceptKey ascending
                    select x).ToList();
        }

        public List<AccountConcept> FetchListAll()
        {
            return (from x in this.db.AccountConcepts
                    where !x.Deleted
                    select x).ToList();
        }

    }
}
