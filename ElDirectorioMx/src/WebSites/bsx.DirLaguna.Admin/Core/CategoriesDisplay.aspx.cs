using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal;
using System.Web.UI.HtmlControls;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class CategoriesDisplay : SimpleDisplayPage
    {
        public string AdvertiserForm(int id) { return string.Format(id > 0 ? "{0}?{1}={2}" : "{0}", this.ResolveUrl(Navigation.CategoryForm), QueryKeys.CategoryId, id); }

        public string CatPublicityDisplay(int id) { return string.Format(id > 0 ? "{0}?{1}={2}" : "{0}", this.ResolveUrl(Navigation.CatPublicityDisplay), QueryKeys.CategoryId, id); }

        public override ObjectDataSource MainDataSource { get { return this.CategoriesDataSource; } }

        public override GridView MainGridView { get { return this.CategoriesGridView; } }

        public override LinkButton MainNewButton { get { return this.NewCategoryButton; } }

        public override LinkButton MainSearchButton { get { return this.SearchCategoryButton; } }

        public override LinkButton MainCleanButton { get { return this.CleanFiltersLinkButton; } }

        public override string ElementFormUrl { get { return this.ResolveUrl(Navigation.CategoryForm); } }

        public override void MainGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (!e.CommandName.Equals("delCategory"))
                return;

            CategoryController controller = new CategoryController();
            if (!controller.Delete(int.Parse(e.CommandArgument.ToString())))
            {
                this.ShowMessage(controller.Errors, CommonWeb.Enum.MessageTypes.Error);
                return;
            }
            this.ShowMessage("La categoria se ha eliminado exitosamente", CommonWeb.Enum.MessageTypes.Success);
            this.CategoriesGridView.DataBind();
        }

        public override void MainDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["name"] = this.NameTextBox.Text;
            e.InputParameters["letter"] = this.LetterTextBox.Text;
            e.InputParameters["highlighted"] = null;
            e.InputParameters["maximumRows"] = 10;
        }

        public override void CleanFilterControls()
        {
            this.NameTextBox.Text = string.Empty;
            this.LetterTextBox.Text = string.Empty;
        }

        protected void PageDropDownList_SelectedIndexChanged(Object sender, EventArgs e)
        {
            GridViewRow pagerRow = MainGridView.BottomPagerRow;

            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

            MainGridView.PageIndex = pageList.SelectedIndex;
        }

        public override void MainGridView_DataBound(object sender, EventArgs e)
        {
            GridViewRow pagerRow = MainGridView.BottomPagerRow;

            if (pagerRow == null)
                return;

            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

            if (pageList != null)
            {
                for (int i = 0; i < MainGridView.PageCount; i++)
                {
                    int pageNumber = i + 1;
                    ListItem item = new ListItem(pageNumber.ToString());

                    if (i == MainGridView.PageIndex)
                    {
                        item.Selected = true;
                    }

                    pageList.Items.Add(item);
                }
            }
        }
    }
}
