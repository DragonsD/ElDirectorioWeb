using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal.PublicContent
{
    public abstract class BaseController<T>
    {
        public DirLagunaPublicModelDataContext db { get; set; }

        public List<string> Errors { get; set; }

        public BaseController()
        {
            this.db = new DirLagunaPublicModelDataContext();
            this.Errors = new List<string>();
        }

        public BaseController(DirLagunaPublicModelDataContext db)
        {
            this.db = db;
            this.Errors = new List<string>();
        }

        public abstract T FetchById(int id);

        public abstract IQueryable<T> FetchAll();

    }
}
