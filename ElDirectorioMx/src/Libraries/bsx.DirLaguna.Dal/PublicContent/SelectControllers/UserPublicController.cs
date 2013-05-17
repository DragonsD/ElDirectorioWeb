using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace bsx.DirLaguna.Dal.PublicContent
{
    public partial class UserPublicController : BaseController<aspnet_Membership>
    {
        public UserPublicController()
            : base()
        {

        }

        public UserPublicController(DirLagunaPublicModelDataContext context) :
            base(context)
        {

        }

        public override aspnet_Membership FetchById(int id)
        {
            return null;
        }

        public override IQueryable<aspnet_Membership> FetchAll()
        {
            return (from x in this.db.aspnet_Memberships
                    select x);
        }

        public aspnet_Membership FetchByUserId(Guid userId)
        {
            return (from x in this.db.aspnet_Memberships
                    where x.UserId == userId
                    select x).FirstOrDefault();
        }

        public Guest FetchGuestByUserId(Guid userId)
        {
            return (from x in this.db.Guest
                    where x.UserId == userId
                    select x).FirstOrDefault();
        }

        public aspnet_Membership FetchByUserName(string userName)
        {
            return (from x in this.db.aspnet_Memberships
                    where x.aspnet_User.UserName == userName
                    select x).FirstOrDefault();
        }

        private IQueryable<Guest> FetchAllGuest()
        {
            return (from x in this.db.Guest
                    where !x.Deleted
                    select x);

        }

        public Guest FetchGuestByUserName(string userName)
        {
            return (from x in this.db.Guest
                        where !x.Deleted && x.Name == userName
                        select x).First();

        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Guest> FetchAllGuest(int startRowIndex, int maximumRows, string sort)
        {
            var emails = this.FetchAllGuest();

            return emails.Skip(startRowIndex).Take(maximumRows).ToList();
        }

        public int FetchAllGuestCount(int startRowIndex, int maximumRows, string sort)
        {
            return this.FetchAllGuest().Count();
        }

        public List<Guest> FetchAllForExport()
        {
            var emails = this.FetchAllGuest();

            return emails.ToList();
        }
    }
}
