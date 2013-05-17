using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using NLog;

namespace bsx.DirLaguna.CommonWeb.Base
{
    public class PageTools : System.Web.UI.Page
    {
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        protected void FillComboBox(System.Web.UI.WebControls.DropDownList dropdown, IEnumerable collection, string dataValueField, string dataTextField)
        {
            dropdown.DataSource = collection;
            dropdown.DataValueField = dataValueField;
            dropdown.DataTextField = dataTextField;
            dropdown.DataBind();

            dropdown.Items.Insert(0, new System.Web.UI.WebControls.ListItem( "Seleccione", string.Empty));
        }

        public void FillComboBox1(System.Web.UI.WebControls.DropDownList dropdown, IEnumerable collection, string dataValueField, string dataTextField)
        {
            dropdown.DataSource = collection;
            dropdown.DataValueField = dataValueField;
            dropdown.DataTextField = dataTextField;
            dropdown.DataBind();

            dropdown.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", string.Empty));
        }
    }
}
