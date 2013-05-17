using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Advertiser.Code;
using bsx.DirLaguna.CommonWeb;
using System.Web.Security;
using bsx.DirLaguna.CommonWeb.Session;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Advertiser.Controls
{
    public partial class LoginControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                return;
            }
            if (this.Page.User.Identity.IsAuthenticated)
            {
                HyperLink link = (HyperLink)this.LoginView.FindControl("InicioHyperLink");
                link.NavigateUrl = this.ResolveUrl(Navigation.AccountForm);

            }
            MembershipUser currentUser = Membership.GetUser();
            if (currentUser == null || string.IsNullOrEmpty(currentUser.UserName))
                FormsAuthentication.SignOut();
            
        }

        protected void Login_LoggingIn(object sender, LoginCancelEventArgs e)
        {
            this.Session.Clear();//limpieza del usuario que inicio sesion con anterioridad
        }

        protected void Login_LoginError(object sender, EventArgs e)
        {
            Panel errorPanel = this.LoginView.FindControl("Login").FindControl("FailurePanel") as Panel;
            if (errorPanel != null)
                errorPanel.Visible = true;
        }

        protected void Login_LoggedIn(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.Login control = sender as System.Web.UI.WebControls.Login;

            MembershipUser myObject = Membership.Providers[MembershipProviders.MembershipAdmin].GetUser(control.UserName, true);

            if (myObject == null)
            {
                myObject = Membership.Providers[MembershipProviders.MembershipAdmin].GetUser(control.UserName, false);
                if (myObject == null)
                    return;
            }

            //TODO: guardar los valores de sesion necesarios para que funcione el sistema 
            SessionValues.UserId = new Guid(myObject.ProviderUserKey.ToString());
            SessionValues.UserName = control.UserName;

            UserController controller = new UserController();
            Personal personal = controller.FetchByUserId(SessionValues.UserId);
            if (personal == null)
                return;
            SessionValues.PersonalId = personal.PersonalId;
            SessionValues.FranchiseeId = personal.FranchiseeId;
            SessionValues.IsPrimary = new FranchiseeController().FetchById(personal.FranchiseeId).IsPrimary;
            SessionValues.PersonalTypeId = new PersonalUser().GetUserType(personal.PersonalTypeId);

            bsx.DirLaguna.Dal.Advertiser adv = personal.Advertiser.FirstOrDefault();
            if (adv == null)
                this.Response.Redirect(this.ResolveUrl(Navigation.PageError));

            if (SessionValues.PersonalTypeId != PersonalTypeEnum.UserIndependent)
            {
                FormsAuthentication.SignOut();
                this.Response.Redirect(this.ResolveUrl(Navigation.PageError));
            }

            SessionValues.AdvertiserId = adv.AdvertiserId;

            string returnUrl = this.Request.QueryString["ReturnUrl"];
            if (!string.IsNullOrEmpty(returnUrl) && !returnUrl.ToLower().Contains("aspxautodetectcookie") && returnUrl.Length > 1)
                this.Response.Redirect(this.ResolveUrl(returnUrl));
            this.Response.Redirect(this.ResolveUrl(Navigation.AccountForm));
            this.Response.End();
        }

    }
}