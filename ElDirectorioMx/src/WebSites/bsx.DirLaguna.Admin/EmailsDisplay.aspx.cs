using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using System.IO;
using System.Text;
using System.Data;
using bsx.DirLaguna.Dal.PublicContent;

namespace bsx.DirLaguna.Admin
{
    public partial class EmailsDisplay : SimpleDisplayPage
    {
        private DataTable data
        {
            get
            {
                return this.ViewState["_data"] as DataTable;
            }
            set { this.ViewState["_data"] = value; }
        }

        public override ObjectDataSource MainDataSource { get { return null; } } // this.EmailDataSource; } }

        public override GridView MainGridView { get { return this.EmailGridView; } }

        public override LinkButton MainNewButton { get { return null; } }

        public override LinkButton MainSearchButton { get { return null; } }

        public override LinkButton MainCleanButton { get { return null; } }

        public override string ElementFormUrl { get { return string.Empty; } }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.See50LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See100LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See200LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See20LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.ExportToLinkButton.Click += new EventHandler(ExportToLinkButton_Click);

            //this.EmailGridView.RowDataBound += new GridViewRowEventHandler(EmailGridView_RowDataBound);
            if (!IsPostBack)
                this.data = this.GetData();

            this.EmailGridView.DataSource = data;
            this.EmailGridView.DataBind();

        }

        //void EmailGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        //{

        //}



        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        void ExportToLinkButton_Click(object sender, EventArgs e)
        {
            this.Export("GuestEmails.xls", this.EmailGridView);
        }

        void SeePageSizeLinkButton_Command(object sender, CommandEventArgs e)
        {
            this.PageSize = int.Parse(e.CommandArgument.ToString());
            this.EmailGridView.DataBind();
        }

        public override void MainGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        public int PageSize
        {
            get
            {
                if (this.ViewState["pagesize"] != null)
                    return (int)this.ViewState["pagesize"];
                return 20;
            }
            set { this.ViewState["pagesize"] = value; }
        }

        public override void MainDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            this.EmailGridView.PageSize = this.PageSize;

            e.InputParameters["startRowIndex"] = 0;
            e.InputParameters["maximumRows"] = this.PageSize;
            e.InputParameters["sort"] = string.Empty;
        }

        public override void LoadFilterDropDowns()
        {

        }

        public override void MainGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

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

        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.MainGridView.DataBind();
        }

        public object Adveriser { get; set; }

        private DataTable GetData()
        {
            UserPublicController controller = new UserPublicController();
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("Age", typeof(String));
            dt.Columns.Add("City", typeof(String));
            dt.Columns.Add("UserName", typeof(String));
            dt.Columns.Add("Email", typeof(String));
            dt.Columns.Add("SendPublicity", typeof(String));

            var list = controller.FetchAllForExport();
            foreach (var item in list)
            {
                DataRow row = dt.NewRow();
                row["Name"] = item.Name;
                row["Age"] = item.Age;
                row["City"] = item.City;
                row["UserName"] = item.aspnet_Membership.aspnet_User.UserName;
                row["Email"] = item.aspnet_Membership.Email;
                row["SendPublicity"] = item.SendPublicity.ToString();
                dt.Rows.Add(row);
            }

            return dt;
        }

        public void Export(string fileName, GridView gv)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
            HttpContext.Current.Response.ContentType = "application/ms-excel";

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    //  Create a table to contain the grid
                    Table table = new Table();

                    //  include the gridline settings
                    table.GridLines = gv.GridLines;

                    //  add the header row to the table
                    if (gv.HeaderRow != null)
                    {
                        this.PrepareControlForExport(gv.HeaderRow);
                        table.Rows.Add(gv.HeaderRow);
                    }

                    //  add each of the data rows to the table
                    foreach (GridViewRow row in gv.Rows)
                    {
                        this.PrepareControlForExport(row);
                        table.Rows.Add(row);
                    }

                    //  add the footer row to the table
                    if (gv.FooterRow != null)
                    {
                        this.PrepareControlForExport(gv.FooterRow);
                        table.Rows.Add(gv.FooterRow);
                    }

                    //  render the table into the htmlwriter
                    table.RenderControl(htw);

                    //  render the htmlwriter into the response
                    HttpContext.Current.Response.Write(sw.ToString());
                    HttpContext.Current.Response.End();
                }
            }
        }

        private void PrepareControlForExport(Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                Control current = control.Controls[i];
                if (current is LinkButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
                }
                else if (current is ImageButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
                }
                else if (current is HyperLink)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
                }
                else if (current is DropDownList)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
                }
                else if (current is CheckBox)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
                }

                if (current.HasControls())
                {
                    this.PrepareControlForExport(current);
                }
            }
        }
    }
}