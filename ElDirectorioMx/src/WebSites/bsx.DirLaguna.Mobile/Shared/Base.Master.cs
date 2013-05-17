using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;

namespace bsx.DirLaguna.Mobile.Shared
{
    public partial class Base : System.Web.UI.MasterPage
    {
        public string TextIos
        {
            get
            {
                if (this.Request.QueryString[QueryKeys.ParamAdicional] == null)
                    return string.Empty;

                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.ParamAdicional].ToString()))
                    return this.Request.QueryString[QueryKeys.ParamAdicional].ToString();
                return string.Empty;
            }
        }

        public string BodyClass
        {
            set
            {
                BodyTag.Attributes.Add("class", value);
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (this.TextIos == "1")
                {
                    this.BodyClass = "noHeader";
                }
            }
        }
    }
}