using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Mobile.Code;

namespace bsx.DirLaguna.Mobile
{
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Page.Title = "ElDirectorio.mx - Categorias";
                this.BackUpHyperLink.NavigateUrl = this.ResolveUrl(Navigation.Default);
                this.BackBottomHyperLink.NavigateUrl = this.ResolveUrl(Navigation.Default); ;
            }
        }
    }
}