using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Public.Code;
using bsx.DirLaguna.CommonWeb.Base;

namespace bsx.DirLaguna.Public
{
    public partial class UserAlreadyExist : PublicBasePage
    {
        public string Message
        {
            get
            {
                if (this.Request.QueryString[QueryKeys.MSG] == null)
                    return "El usuario Ya Existe";
                return this.Request.QueryString[QueryKeys.MSG].ToString();
            }
       }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.BackButton.PostBackUrl = this.ResolveUrl(Navigation.RegisterForm);
            }
        }
    }
}