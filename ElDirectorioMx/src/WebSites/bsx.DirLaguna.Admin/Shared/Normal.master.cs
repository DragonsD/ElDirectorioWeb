using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb.Session;
using bsx.DirLaguna.Admin.Controls;

namespace bsx.DirLaguna.Admin.Shared
{
    public partial class Normal : System.Web.UI.MasterPage
    {
        public string LogoutUrl { get { return this.ResolveUrl(Navigation.Logout); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoginStatus1.LoggedOut += new EventHandler(LoginStatus1_LoggedOut);
            this.Master.ClassBody = "normal";

            if (!this.IsPostBack)
            {
                this.LogoImage.AlternateText = Resources.Resource.TextNameDirectoryLaguna;
                this.LogoImage.ToolTip = Resources.Resource.TextNameDirectoryLaguna;
                this.LoggedUserMenu.Visible = this.Page.User.Identity.IsAuthenticated;
                this.FooterPlaceHolder.Visible = this.Page.User.Identity.IsAuthenticated;

                //if (SessionValues.ClientId > 0)
                //{
                //    Client cte = new ClientController().FetchById(SessionValues.ClientId);
                //    this.availableInvoicesLabel.Text = cte.IsInForce ? string.Format("Te quedan {0} facturas", cte.AvailableHiredInvoices) : "NA";
                //}
                //else this.availableInvoicesLabel.Text = "NA";

                if (this.Page.User.Identity.IsAuthenticated)
                {
                    // operacion que sean necesarias una vez que se autentifique el usuario
                }
            }
            this.ShowPreviousMessages();
        }

        void LoginStatus1_LoggedOut(object sender, EventArgs e)
        {
            this.Session.Abandon();
            this.Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
            this.Response.Redirect(Navigation.Default);
        }

        public void ShowPreviousMessages()
        {
            IList<string> messages = SessionValues.LastMessages;
            if (messages.Count <= 0)
                return;

            WebMessageBox message = this.Master.FindControl("MessagePanel") as WebMessageBox;
            if(message != null)
                message.Show(SessionValues.LastMessageType, messages.ToArray());
            messages.Clear();
        }

        public string GetHome()
        {
            string targetUrl = Properties.Settings.Default.SiteUrl;

            targetUrl = this.ResolveUrl(Navigation.AdvertiserDisplay);

            return targetUrl;
        }
    }
}