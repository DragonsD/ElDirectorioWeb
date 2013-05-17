using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class UserController : BaseController<aspnet_Membership>
    {
        public UserController() : base() { }

        public UserController(DirLagunaModelDataContext context) : base(context) { }

        public override aspnet_Membership FetchById(int id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<aspnet_Membership> FetchAll()
        {
            throw new NotImplementedException();
            //return (from x in this.db.aspnet_Memberships
            //        select x);
        }

        public IQueryable<aspnet_Membership> FetchAll(int franchiseeId)
        {
            return (from x in this.db.aspnet_Memberships
                    join u in this.db.Personals on x.UserId equals u.UserId
                    where u.FranchiseeId == franchiseeId
                    select x);
        }

        public bool BlockUser(string userName)
        {
            aspnet_User user = (from c in db.aspnet_Users
                                where c.UserName == userName
                                select c).FirstOrDefault();

            bool bResult = false;

            if (user != null)
            {
                aspnet_Membership member = (from m in db.aspnet_Memberships
                                            where m.UserId == user.UserId
                                            select m).FirstOrDefault();

                member.IsLockedOut = true;
                try
                {
                    this.db.SubmitChanges();
                    bResult = true;
                }
                catch (Exception ex)
                {
                    this.Errors.Add(ex.Message);
                }

            }

            return bResult;
        }

        public int FetchAllCount()
        {
            return (from x in this.db.aspnet_Memberships
                    where x.IsApproved
                    select x).Count();
        }

        public aspnet_Membership FetchByUser(string userName)
        {
            aspnet_User user = (from u in this.db.aspnet_Users
                                where u.UserName == userName
                                select u).FirstOrDefault();

            aspnet_Membership membership;
            if (user != null)
            {
                membership = (from u in this.db.aspnet_Memberships
                              where u.UserId == user.UserId
                              select u).FirstOrDefault();
            }
            else
                membership = new aspnet_Membership();

            return membership;
        }

        public Personal FetchByUserId(Guid userId)
        {
            return (from u in this.db.Personals
                              where u.UserId == userId
                              select u).FirstOrDefault();
        }

    }
}
