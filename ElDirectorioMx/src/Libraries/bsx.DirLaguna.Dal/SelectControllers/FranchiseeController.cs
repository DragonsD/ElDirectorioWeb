using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace bsx.DirLaguna.Dal
{
    public partial class FranchiseeController : BaseController<Franchisee>
    {
        public FranchiseeController()
            : base()
        {

        }

        public FranchiseeController(DirLagunaModelDataContext context) :
            base(context)
        {

        }

        public override Franchisee FetchById(int id)
        {
            return (from x in this.db.Franchisees where x.FranchiseeId == id select x).FirstOrDefault();
        }

        public Franchisee FetchByExternalId(int id)
        {
            return (from x in this.db.Franchisees where x.ExternalKey == id select x).FirstOrDefault();
        }

        public override IQueryable<Franchisee> FetchAll()
        {
            return from x in this.db.Franchisees where !x.Deleted orderby x.Name ascending select x;
        }

        public IQueryable<Franchisee> FetchAll(string name)
        {
            if(!string.IsNullOrEmpty(name))
                return from x in this.db.Franchisees where !x.Deleted && x.Name.Contains(name) orderby x.Name ascending select x;

            return from x in this.db.Franchisees where !x.Deleted orderby x.Name ascending select x;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Franchisee> FetchAll(string name, int startRowIndex, int maximumRows, string sort)
        {
            var franchiseers = this.FetchAll(name);

            if (!string.IsNullOrEmpty(sort))
            {
                if (sort.Contains(Franchisee.ColumnNames.Name))
                {
                    franchiseers = franchiseers.OrderBy(d => d.Name);
                }
            }

            return franchiseers.Skip(startRowIndex).Take(maximumRows).ToList();
        }

        public int FetchAllCount(string name, int startRowIndex, int maximumRows, string sort)
        {
            return this.FetchAll(name).Count();
        }

        public IQueryable<Franchisee> FetchAll(string name, string email, int estadoId, int cityId)
        {
            var franchisees = from x in this.db.Franchisees where !x.Deleted select x;
            
            if (!string.IsNullOrEmpty(email))
                franchisees = from x in franchisees where x.Email.Contains(email) select x;

            if (estadoId > 0)
                franchisees = from x in franchisees where x.Municipio.EstadoId == estadoId select x;

            if (cityId > 0)
                franchisees = from x in franchisees where x.Municipio.MunicipioId == cityId select x;

            if (!string.IsNullOrEmpty(name))
                franchisees = from x in franchisees where x.Name.Contains(name) select x;

            return from x in franchisees orderby x.Name ascending select x;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Franchisee> FetchAll(string name, string email, int estadoId, int cityId, int startRowIndex, int maximumRows, string sort)
        {
            var franchiseers = this.FetchAll(name, email, estadoId, cityId);

            if (!string.IsNullOrEmpty(sort))
            {
                if (sort.Contains(Franchisee.ColumnNames.Name))
                {
                    franchiseers = franchiseers.OrderBy(d => d.Name);
                }
            }

            return franchiseers.Skip(startRowIndex).Take(maximumRows).ToList();
        }

        public int FetchAllCount(string name, string email, int estadoId, int cityId, int startRowIndex, int maximumRows, string sort)
        {
            return this.FetchAll(name, email, estadoId, cityId).Count();
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Franchisee> FetchAllLessDV(int startRowIndex, int maximumRows, string sort)
        {
            var franchiseers = this.FetchAllDV(false);

            if (!string.IsNullOrEmpty(sort))
            {
                if (sort.Contains(Franchisee.ColumnNames.Name))
                {
                    franchiseers = franchiseers.OrderBy(d => d.Name);
                }
            }

            return franchiseers.Skip(startRowIndex).Take(maximumRows).ToList();
        }

        public int FetchAllLessDVCount(int startRowIndex, int maximumRows, string sort)
        {
            return this.FetchAllDV(false).Count();
        }

        private IQueryable<Franchisee> FetchAllDV(bool hasDV)
        {
           if(hasDV)
                return from x in this.db.Franchisees where !x.Deleted && (x.DV != null || x.DV != "") orderby x.Name ascending select x;

           return from x in this.db.Franchisees where !x.Deleted && (x.DV == null || x.DV == "") orderby x.Name ascending select x;
        }


    }
}
