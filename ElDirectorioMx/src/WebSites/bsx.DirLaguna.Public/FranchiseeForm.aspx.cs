using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using bsx.DirLaguna.CommonWeb.Base;

namespace bsx.DirLaguna.Public
{
    public partial class FranchiseeForm : PublicBasePage
    {
        public string UrlPathProspection
        {
            get
            {
                if (ConfigurationManager.AppSettings["UrlPathProspection"] == null)
                    return "http://www.twitter.com";
                return ConfigurationManager.AppSettings["UrlPathProspection"].ToString();
            }
        }

        public string UrlPathAdmin
        {
            get
            {
                if (ConfigurationManager.AppSettings["UrlPathAdmin"] == null)
                    return "http://www.twitter.com";
                return ConfigurationManager.AppSettings["UrlPathAdmin"].ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.FranchiseeHyperLink.NavigateUrl = this.UrlPathAdmin;
                this.ProspectationHyperLink.NavigateUrl = this.UrlPathProspection;
            }

        }
    }
}