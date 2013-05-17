using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Session;

namespace bsx.DirLaguna.CommonWeb.Base
{
    public abstract class SimpleDisplayPage : BasePage
    {
        public int PersonalId { get { return SessionValues.PersonalId; } }

        public int FranchiseeId { get { return SessionValues.FranchiseeId; } }

        public abstract ObjectDataSource MainDataSource { get; }

        public abstract GridView MainGridView { get; }

        public abstract LinkButton MainNewButton { get; }

        public abstract LinkButton MainSearchButton { get; }

        public abstract LinkButton MainCleanButton { get; }

        public abstract string ElementFormUrl { get; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!this.IsPostBack)
            {
                this.LoadFilterDropDowns();
            }
        }

        public virtual void LoadFilterDropDowns() { }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if(this.MainNewButton != null)
                this.MainNewButton.Click += new EventHandler(MainNewButton_Click);
                //this.MainNewButton.Click += new System.Web.UI.ImageClickEventHandler(MainNewButton_Click);

            //this.MainNewButton.PostBackUrl = string.IsNullOrEmpty(this.ElementFormUrl) ? string.Empty :  this.ResolveUrl(this.ElementFormUrl);
            if(this.MainDataSource != null)
                this.MainDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(MainDataSource_Selecting);
            
            if (this.MainGridView != null)
            {
                this.MainGridView.RowDataBound += new GridViewRowEventHandler(MainGridView_RowDataBound);
                this.MainGridView.RowCommand += new GridViewCommandEventHandler(MainGridView_RowCommand);
                this.MainGridView.DataBound += new EventHandler(MainGridView_DataBound);
            }

            if (this.MainCleanButton != null)
                this.MainCleanButton.Click += new EventHandler(MainCleanButton_Click);
            if (this.MainSearchButton != null)
                this.MainSearchButton.Click += new EventHandler(MainSearchButton_Click);
        }

        void MainNewButton_Click(object sender, EventArgs e)
        {
            this.Response.Redirect(this.ResolveUrl(this.ElementFormUrl));
        }

        void MainSearchButton_Click(object sender, EventArgs e)
        {
            this.MainGridView.DataBind();
        }

        void MainCleanButton_Click(object sender, EventArgs e)
        {
            this.CleanFilterControls();
            this.MainGridView.DataBind();
        }

        public abstract void MainGridView_RowCommand(object sender, GridViewCommandEventArgs e);

        public virtual void MainGridView_RowDataBound(object sender, GridViewRowEventArgs e) { }

        public abstract void MainDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e);

        public abstract void CleanFilterControls();

        public abstract void MainGridView_DataBound(object sender, EventArgs e);

    }
}
