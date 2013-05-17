using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Mobile.Code;
using bsx.DirLaguna.CommonWeb;

namespace bsx.DirLaguna.Mobile.Controls
{
    public partial class CouponCategoriesControl : System.Web.UI.UserControl
    {
        public string Letter
        {
            get
            {
                if (this.ViewState["_letter"] == null)
                    return string.Empty;
                return this.ViewState["_letter"].ToString();
            }
            set
            {
                this.ViewState["_letter"] = value;
            }
        }

        public int CityId
        {
            get
            {
                if (this.ViewState["_cityId"] == null)
                    return -1;
                return int.Parse(this.ViewState["_cityId"].ToString());
            }
            set
            {
                this.ViewState["_cityId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CategoriesDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(CategoriesDataSource_Selecting);
            this.CategoriesDataList.ItemCommand += new DataListCommandEventHandler(CategoriesDataList_ItemCommand);
        }

        void CategoriesDataList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName != "SeeCategory")
                return;

            this.Response.Redirect(string.Format("{0}?{1}={2}", Navigation.CouponDisplay, QueryKeys.CategoryId, e.CommandArgument));
        }

        void CategoriesDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["letter"] = this.Letter;
            e.InputParameters["cityId"] = this.CityId;
        }
    }
}