using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Dal;
using System.Web.Configuration;
using bsx.DirLaguna.Public.Code;

namespace bsx.DirLaguna.Public
{
    public partial class Portada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GeneralSetUpController con = new GeneralSetUpController();
            GeneralSetUp data = con.FetchFirst();
            string url = WebConfigurationManager.AppSettings["UrlSiteAdmin"];
            this.XLiteral.Text = data.FixFrontPageMarkup(url);
        }

        public string HomeUrl
        {
            get
            {
                return this.ResolveUrl(Navigation.HomeForm);
            }
        }
    }
}