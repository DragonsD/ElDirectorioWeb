using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Mobile.Code;

namespace bsx.DirLaguna.Mobile.Controls
{
    public partial class CategoriesControl : System.Web.UI.UserControl
    {
        public string CategoryDisplayUrl(int letter)
        {
            this.Page.Title = string.Format(!string.IsNullOrEmpty(letter.ToString()) ? "Negocios con Categoria que comienza con {0}" : "Directorio",
                                                letter.ToString());


            return string.Format("{0}?{1}={2}", Navigation.CategoryDisplay, QueryKeys.CategoryLetter, letter);
        }

        public int ColumnsNumber
        {
            get
            {
                if(this.ViewState["_columnsNumber"] == null)
                    return 4;
                return int.Parse(this.ViewState["_columnsNumber"].ToString());
            }
            set
            {
                this.ViewState["_columnsNumber"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}