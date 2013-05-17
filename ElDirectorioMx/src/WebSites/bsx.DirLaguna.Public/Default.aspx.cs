using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;

namespace bsx.DirLaguna.Public
{
    public partial class Default : PublicBasePage
    {
        public string UrlSiteDesktop
        {
            get
            {
                System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
                return ((string)(configurationAppSettings.GetValue("UrlSiteDesktop", typeof(string)))); 
            }
        }

        public string UrlSiteMovil
        {
            get
            {
                System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
                return ((string)(configurationAppSettings.GetValue("UrlSiteMovil", typeof(string))));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}