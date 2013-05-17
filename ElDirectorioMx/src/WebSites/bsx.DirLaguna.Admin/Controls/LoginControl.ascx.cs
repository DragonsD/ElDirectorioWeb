using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using bsx.DirLaguna.CommonWeb.Session;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.Dal.SelectControllers;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb;

namespace bsx.DirLaguna.Admin.Controls
{
    public partial class LoginControl : System.Web.UI.UserControl
    {
        public string DashboardUrl { get { return this.ResolveUrl(Navigation.AdvertiserDisplay); } }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (this.IsPostBack)
            {
                return;
            }
            if (this.Page.User.Identity.IsAuthenticated)
            {
                HyperLink link = (HyperLink)this.LoginView.FindControl("InicioHyperLink");
                link.NavigateUrl = this.ResolveUrl(Navigation.AdvertiserDisplay);

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

            MembershipUser myObject = Membership.GetUser(control.UserName);

            if (myObject == null)
                return;

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
            //TODO: guardar los valores de sesion necesarios para que funcione el sistema

            if (SessionValues.PersonalTypeId == PersonalTypeEnum.UserIndependent)
            {
                FormsAuthentication.SignOut();
                this.Response.Redirect(this.ResolveUrl(Navigation.Logout));
            }

            string returnUrl = this.Request.QueryString["ReturnUrl"];
            if (!string.IsNullOrEmpty(returnUrl) && !returnUrl.ToLower().Contains("aspxautodetectcookie") && returnUrl.Length > 1)
                this.Response.Redirect(this.ResolveUrl(returnUrl));
            if(SessionValues.IsPrimary)
                this.Response.Redirect(this.ResolveUrl(Navigation.FranchiseeDisplay));
            this.Response.Redirect(this.ResolveUrl(Navigation.AdvertiserDisplay));
            this.Response.End();
        }

    }
}
