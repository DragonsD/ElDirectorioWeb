﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NLog;
using bsx.DirLaguna.Admin.Code;

namespace bsx.DirLaguna.Admin
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Session.Abandon();
            this.Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
            this.Response.Redirect(this.ResolveUrl(Navigation.Default));
        }
    }
}