using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using System.Configuration;
using bsx.DirLaguna.Public.Code;

namespace bsx.DirLaguna.Public.Controls
{
    public partial class AdvertiserHeaderControl : System.Web.UI.UserControl
    {

        public string Name
        {
            set
            {
                this.NameLabel.Text = value;
            }
        }


        public string LogoUrl
        {
            set
            {
                this.LogoImage.ImageUrl = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}