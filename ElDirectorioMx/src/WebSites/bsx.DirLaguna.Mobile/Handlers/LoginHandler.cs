using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using bsx.DirLaguna.Dal.PublicContent;

namespace bsx.DirLaguna.Mobile.Handlers
{
    public class LoginHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if(context.Request[QueryKeys.UserName] == null)
            {
                context.Response.StatusCode = 403;
                context.Response.End();
                return ;
            }

            if(context.Request[QueryKeys.MD5] == null)
            {
                context.Response.StatusCode = 403;
                context.Response.End();
                return ;
            }

            MembershipUser memUser;
            memUser = Membership.GetUser(context.Request[QueryKeys.UserName].ToString());

            if (memUser == null)
            {
                context.Response.StatusCode = 403;
                context.Response.End();
                return ;
            }

            string passDb =memUser.GetPassword();

            MD5 md5;
            md5 = new MD5CryptoServiceProvider();

            string passMD5 = Crypto.EncryptMD5(passDb);
            passMD5 = passMD5.Replace("-", "").ToLower();
            string password = context.Request[QueryKeys.MD5].ToString();
            if (passMD5.Equals(password))
            {
                context.Response.StatusCode = 200;
                UserPublicController controller = new UserPublicController();
                bsx.DirLaguna.Dal.PublicContent.aspnet_Membership membership = controller.FetchByUserName(memUser.UserName);
                Guest guest = controller.FetchGuestByUserId(membership.UserId);
                if (guest.Folio != null)
                {
                    context.Response.Write("1");
                }
                else
                {
                    context.Response.Write("0");
                }
                context.Response.End();
                return ;
            }
            else
            {
                context.Response.StatusCode = 403;
                context.Response.End();
                return;
            }

        }
    }
}