using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bsx.DirLaguna.Dal.SelectControllers;

namespace bsx.DirLaguna.Dal
{
    public partial class TagController : FranchiseeBaseController<Tag>
    {
        public TagController() : base() { }

        public TagController(DirLagunaModelDataContext context) : base(context) { }

        public override Tag FetchById(int id, int franchiseeId)
        {
            return (from x in this.db.Tags
                    where x.TagId == id && x.FranchiseeId == franchiseeId
                    select x).FirstOrDefault();
        }

        public override IQueryable<Tag> FetchAll(int franchiseeId)
        {
            return from x in this.db.Tags
                   where !x.Deleted
                         && x.FranchiseeId == franchiseeId
                   select x;
        }

        public override Tag FetchById(int id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Tag> FetchAll()
        {
            throw new NotImplementedException();
        }
    }
}
