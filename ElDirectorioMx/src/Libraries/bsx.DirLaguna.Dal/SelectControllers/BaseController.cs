using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public abstract class BaseController<T>
    {
        public DirLagunaModelDataContext db { get; set; }

        public List<string> Errors { get; set; }

        public BaseController()
        {
            this.db = new DirLagunaModelDataContext();
            this.Errors = new List<string>();
        }

        public BaseController(DirLagunaModelDataContext db)
        {
            this.db = db;
            this.Errors = new List<string>();
        }

        public abstract T FetchById(int id);

        public abstract IQueryable<T> FetchAll();
    }
}
