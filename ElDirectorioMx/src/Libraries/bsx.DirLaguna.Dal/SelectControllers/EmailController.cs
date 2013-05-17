using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class EmailController : BaseController<Email>
    {
        public EmailController() : base() { }

        public EmailController(DirLagunaModelDataContext context) : base(context) { }

        public override Email FetchById(int id)
        {
            return (from x in this.db.Emails
                    where x.EmailId == id
                    select x).FirstOrDefault();
        }

        public override IQueryable<Email> FetchAll()
        {
            return from x in this.db.Emails
                   where !x.Deleted
                   select x;
        }

        public IQueryable<Email> FetchAdvertiserEmails(int advertiserId)
        {
            return from x in this.db.Emails
                   where x.AdvertiserId == advertiserId
                   && !x.Deleted
                   select x;
        }
    }
}
