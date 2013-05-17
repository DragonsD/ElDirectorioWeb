using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using System.Web.Security;

namespace bsx.DirLaguna.Mobile
{
    public partial class RegisterIos : System.Web.UI.Page
    {
        protected List<string> Errors = new List<string>();

        public string UserName
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.UserName].ToString()))
                    return this.Request.QueryString[QueryKeys.UserName].ToString();
                return string.Empty;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if(!string.IsNullOrEmpty(this.UserName))
                {
                    MembershipUser memUser;
                    memUser = Membership.GetUser(this.UserName);
                    if (memUser == null)
                    {
                        this.Errors.Add("El usuario No Existe");
                        return ;
                    }
                    string passEncryp = Crypto.EncryptMD5(memUser.GetPassword());
                    passEncryp = passEncryp.Replace("-", "").ToLower();
                    this.InfoHiddenField.Value = passEncryp;
                }
            }
        }
    }
}