using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bsx.DirLaguna.Public.Shared
{
    public partial class NestedBaseMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreRender += new EventHandler(NestedBaseMasterPage_PreRender);
        }

        void NestedBaseMasterPage_PreRender(object sender, EventArgs e)
        {
            if(this.TitleLabel!=null)
                this.TitleLabel.Text = this.Page.Title;
        }
    }
}