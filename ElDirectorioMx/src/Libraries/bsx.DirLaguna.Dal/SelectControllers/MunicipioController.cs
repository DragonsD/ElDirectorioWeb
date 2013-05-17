using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class MunicipioController : BaseController<Municipio>
    {
        public MunicipioController()
            : base()
        {

        }

        public MunicipioController(DirLagunaModelDataContext context) :
            base(context)
        {

        }

        public override Municipio FetchById(int id)
        {
            return (from x in this.db.Municipios
                    where !x.Deleted && x.MunicipioId == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<Municipio> FetchAll()
        {
            return (from x in this.db.Municipios
                    where !x.Deleted
                    select x);
        }

        public IQueryable<Municipio> FetchAllByEstadoId(int estadoId)
        {
            return (from x in this.db.Municipios
                    where !x.Deleted && x.EstadoId== estadoId
                        select x);
        }
    
    }
}
