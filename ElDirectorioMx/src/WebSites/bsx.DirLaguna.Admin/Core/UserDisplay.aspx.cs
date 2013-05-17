using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using System.Web.Security;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class UserDisplay : SimpleDisplayPage
    {
        public string UserForm(string userName) { return string.Format(!string.IsNullOrEmpty(userName) ? "{0}?{1}={2}" : "{0}", this.ResolveUrl(Navigation.UserForm), QueryKeys.UserName, userName); }

        public string UsersDisplay(int id) { return string.Format(id > 0 ? "{0}?{1}={2}" : "{0}", this.ResolveUrl(Navigation.UserDisplay), QueryKeys.CategoryId, id); }

        public override ObjectDataSource MainDataSource { get { return this.UsersDataSource; } }

        public override GridView MainGridView { get { return this.UsersGridView; } }

        public override LinkButton MainNewButton { get { return this.NewUserButton; } }

        public override LinkButton MainSearchButton { get { return null; } }

        public override LinkButton MainCleanButton { get { return null; } }

        public override string ElementFormUrl { get { return this.ResolveUrl(Navigation.UserForm); } }


        public override void MainGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (!e.CommandName.Equals("delUser"))
                return;


            // Get information about this user

            MembershipUser usr = Membership.GetUser(e.CommandArgument.ToString());
            if (usr == null)
                return;

            usr.IsApproved = false;
            Membership.UpdateUser(usr);

            this.ShowMessage("El usuario se ha eliminado exitosamente", CommonWeb.Enum.MessageTypes.Success);
            this.MainGridView.DataBind();
        }

        public override void MainDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["franchiseeId"] = this.FranchiseeId;            
        }

        public override void CleanFilterControls()
        {
            
        }

        protected void PageDropDownList_SelectedIndexChanged(Object sender, EventArgs e)
        {
            GridViewRow pagerRow = MainGridView.BottomPagerRow;

            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

            MainGridView.PageIndex = pageList.SelectedIndex;
        }

        public override void MainGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = e.Row as GridViewRow;
            if (row == null)
                return;

            CheckBox IsApprovedCheckBox = row.FindControl("IsApprovedCheckBox") as CheckBox;
            Label ApprovedTextLabel = row.FindControl("ApprovedTextLabel") as Label;

            if (IsApprovedCheckBox != null && ApprovedTextLabel != null)
                ApprovedTextLabel.Text = IsApprovedCheckBox.Checked ? "Sí" : "No";

            CheckBox IsLockedOutCheckBox = row.FindControl("IsLockedOutCheckBox") as CheckBox;
            Label IsLockedOutLabel = row.FindControl("IsLockedOutLabel") as Label;

            if (IsApprovedCheckBox != null && ApprovedTextLabel != null)
                IsLockedOutLabel.Text = IsLockedOutCheckBox.Checked ? "Sí" : "No";
        
        }

        public override void MainGridView_DataBound(object sender, EventArgs e)
        {

        }
    }
}