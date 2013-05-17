using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal.Arguments;

namespace bsx.DirLaguna.Public.Controls
{
    public partial class LetterCategoriesControl : System.Web.UI.UserControl
    {
        public bool FilterFeatured
        {
            get
            {
                if (this.ViewState["filterFeatured"] != null)
                    return (bool)this.ViewState["filterFeatured"];
                return false;
            }
            set { this.ViewState["filterFeatured"] = value; }
        }

        public string Keywords
        {
            get
            {
                if (this.ViewState["keywords"] != null)
                    return this.ViewState["keywords"].ToString();
                return string.Empty;
            }
            set { this.ViewState["keywords"] = value; }
        }

        public int CityId
        {
            get
            {
                if (this.ViewState["cityId"] != null)
                    return (int)this.ViewState["cityId"];
                return -1;
            }
            set { this.ViewState["cityId"] = value; }
        }

        public event EventHandler<IntEventArgs> CategorySelected;

        public string RequestedLetter
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.CategoryLetter]))
                    return this.Request.QueryString[QueryKeys.CategoryLetter];
                return string.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CategoriesDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(CategoriesDataSource_Selecting);
            this.CategoriesDataList.ItemCommand += new DataListCommandEventHandler(CategoriesDataList_ItemCommand);

            if (!this.IsPostBack)
            {
                this.CategoriesDataList.DataBind();
            }
        }

        void CategoriesDataList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("SeeCategory"))
                return;

            if (this.CategorySelected != null)
                this.CategorySelected(this, new IntEventArgs() { Value = int.Parse(e.CommandArgument.ToString()) });
        }

        void CategoriesDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["letter"] = this.RequestedLetter;
            e.InputParameters["keywords"] = this.Keywords;
            e.InputParameters["filterFeatured"] = this.FilterFeatured;
            e.InputParameters["cityId"] = this.CityId;
        }

        public void RefreshData()
        {
            this.CategoriesDataList.DataBind();
        }
    }
}