using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Public.Code;
using bsx.DirLaguna.CommonWeb.Base;

namespace bsx.DirLaguna.Public
{
    public partial class Logout : PublicBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Session.Abandon();
            this.Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
            this.Response.Redirect(this.ResolveUrl(Navigation.HomeForm));
        }
    }
}