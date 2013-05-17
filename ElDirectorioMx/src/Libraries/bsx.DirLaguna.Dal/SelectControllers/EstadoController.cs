using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class EstadoController : BaseController<Estado>
    {
        public EstadoController()
            : base()
        {

        }

        public EstadoController(DirLagunaModelDataContext context) :
            base(context)
        {

        }

        public override Estado FetchById(int id)
        {
            return (from x in this.db.Estados
                    where !x.Deleted && x.EstadoId == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<Estado> FetchAll()
        {
            return (from x in this.db.Estados
                    where !x.Deleted
                    orderby x.Name ascending
                    select x);
        }
    }
}
