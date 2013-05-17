using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class PublicityDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreRender += new EventHandler(PublicityDisplay_PreRender);
        }

        void PublicityDisplay_PreRender(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                CityController cities = new CityController();
                this.ddlCity.DataSource = cities.FechAllActive(Dal.Enum.AccountConceptKeyEnum.Website);
                this.ddlCity.DataBind();
            }
        }
    }
}