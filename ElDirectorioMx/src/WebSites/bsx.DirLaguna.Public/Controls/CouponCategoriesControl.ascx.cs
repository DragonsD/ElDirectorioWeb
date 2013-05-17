using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Dal.Arguments;

namespace bsx.DirLaguna.Public.Controls
{
    public partial class CouponCategoriesControl : System.Web.UI.UserControl
    {
        public event EventHandler<IntEventArgs> CategorySelected;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CategoriesDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(CategoriesDataSource_Selecting);
            this.CategoriesDataList.ItemCommand += new DataListCommandEventHandler(CategoriesDataList_ItemCommand);
        }

        void CategoriesDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["cityId"] = this.SelectedCityId;
        }

        void CategoriesDataList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("SeeCategory"))
                return;

            if (this.CategorySelected != null)
                this.CategorySelected(this, new IntEventArgs() { Value = int.Parse(e.CommandArgument.ToString()) });
        }

        public int SelectedCityId
        {
            get
            {
                int id = 0;
                HttpCookie myCookie = this.Request.Cookies["DirLagunaCiudad"];
                if (myCookie != null)
                {
                    int.TryParse(myCookie.Value, out id);
                }
                return id;
            }
        }
    }
}