using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using bsx.DirLaguna.Dal.PublicContent;
using bsx.DirLaguna.Public.Code;
using bsx.DirLaguna.CommonWeb.Base;

namespace bsx.DirLaguna.Public
{
    public partial class RegisterClub : PublicBasePage
    {
        public long CardId
        {
            get { return long.Parse(this.tbTArjeta.Text); }
        }
        
        MembershipUser currentUser = Membership.GetUser();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnEnviar.Click += new EventHandler(btnEnviar_Click);
        }


        void btnEnviar_Click(object sender, EventArgs e)
        {
            UserPublicController controller = new UserPublicController();
            controller.RegisterClubCard(currentUser.UserName, this.CardId);
            Response.Redirect(Navigation.CouponDisplayDirectorio);

        }
    }
}