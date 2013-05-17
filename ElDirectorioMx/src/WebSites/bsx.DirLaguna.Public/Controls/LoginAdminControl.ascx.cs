using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using bsx.DirLaguna.Public.Code;
using bsx.DirLaguna.CommonWeb;

namespace bsx.DirLaguna.Public.Controls
{
    public partial class LoginAdminControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                return;
            }
            if (this.Page.User.Identity.IsAuthenticated)
            {
                MembershipUser currentUser = Membership.Providers[MembershipProviders.MembershipAdmin].GetUser(this.Page.User.Identity.Name, true);
                if (currentUser == null || string.IsNullOrEmpty(currentUser.UserName))
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                }

                HyperLink link = (HyperLink)this.LoginView.FindControl("InicioHyperLink");
                link.NavigateUrl = this.ResolveUrl(Navigation.Admin.AccountForm);

            }

            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
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


            string returnUrl = this.Request.QueryString["ReturnUrl"];
            if (!string.IsNullOrEmpty(returnUrl) && !returnUrl.ToLower().Contains("aspxautodetectcookie") && returnUrl.Length > 1)
                this.Response.Redirect(this.ResolveUrl(returnUrl));
            this.Response.Redirect(this.ResolveUrl(Navigation.Admin.AccountForm));
            this.Response.End();
        }

    }
}