using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal;
using System.Web.Configuration;

namespace bsx.DirLaguna.Public
{
    public partial class ContactForm : PublicBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GeneralSetUpController con = new GeneralSetUpController();
            GeneralSetUp data = con.FetchFirst();
            string url = WebConfigurationManager.AppSettings["UrlSiteAdmin"];
            this.XLiteral.Text = data.FixPageMarkup(url, data.AdvertiserMarkup);
        }
    }
}