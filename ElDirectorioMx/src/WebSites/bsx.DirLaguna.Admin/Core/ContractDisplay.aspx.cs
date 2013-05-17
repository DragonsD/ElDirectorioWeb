using System;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.CommonWeb.Session;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class ContractDisplay : SimpleDisplayPage
    {
        public int AdvertiserId
        {
            get
            {
                if (this.Request.QueryString[QueryKeys.AdvertiserId] != null)
                    return int.Parse(this.Request.QueryString[QueryKeys.AdvertiserId].ToString());
                return -1;
            }
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

        private void LoadViewDataFromModel(Contract source) { }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //this.SaveButton.Click += new ImageClickEventHandler(SaveButton_Click);
            this.See50LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See100LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See200LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See20LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.BackHyperLink.NavigateUrl = this.ResolveUrl(Navigation.AdvertiserDisplay);
            this.ContractGridView.RowDataBound += new GridViewRowEventHandler(ContractGridView_RowDataBound);

            if (!this.IsPostBack)
            {
                var franchisee = new FranchiseeController().FetchById(SessionValues.FranchiseeId);
                if (!franchisee.IsPrimary)
                {
                    int columns = this.MainGridView.Columns.Count;
                    this.MainGridView.Columns[columns - 3].Visible = false;
                    this.MainGridView.Columns[columns - 4].Visible = false;
                }
            }
        }

        void ContractGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            ImageButton deleteBtn = e.Row.FindControl("DeleteImageButton") as ImageButton;
            if (deleteBtn != null)
            {
                Label invoiceIdLabel = e.Row.FindControl("InvoiceIdLabel") as Label;
                deleteBtn.Visible = string.IsNullOrEmpty(invoiceIdLabel.Text);
            }

            BulletedList specs = e.Row.FindControl("SpecsBulletedList") as BulletedList;
            Contract ct = e.Row.DataItem as Contract;
            if (specs != null && ct != null)
            {
                specs.DataSource = from x in ct.AccountDetails where x.Quantity > 0 orderby x.AccountConcept.ConceptKey ascending select x;
                specs.DataTextField = "DisplayText";
                specs.DataBind();
                specs.ForeColor = ct.IsCurrentSetup ? Color.Black : Color.LightGray;
            }
        }

        void SeePageSizeLinkButton_Command(object sender, CommandEventArgs e)
        {
            this.PageSize = int.Parse(e.CommandArgument.ToString());
            this.ContractGridView.DataBind();
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.MainGridView.DataBind();
        }

        public override ObjectDataSource MainDataSource { get { return this.ContractObjectDataSource; } }

        public override GridView MainGridView { get { return this.ContractGridView; } }

        public override LinkButton MainNewButton { get { return this.NewContractButton; } }

        public override LinkButton MainSearchButton { get { return null; } }

        public override LinkButton MainCleanButton { get { return null; } }

        public override string ElementFormUrl { get { return string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.ContractForm), QueryKeys.AdvertiserId, this.AdvertiserId); } }

        public override void MainGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ContractController controller = new ContractController();
            if (e.CommandName.Equals("delContract"))
            {
                if (!controller.Delete(int.Parse(e.CommandArgument.ToString()), this.PersonalId))
                {
                    this.ShowMessage(controller.Errors, CommonWeb.Enum.MessageTypes.Error);
                    return;
                }

                this.ShowMessage("La contratacion ha sido eliminada exitosamente", CommonWeb.Enum.MessageTypes.Success);
                this.MainGridView.DataBind();
            }
            else
            {
                Contract contract = controller.FetchById(int.Parse(e.CommandArgument.ToString()));
                this.LoadViewDataFromModel(contract);
            }
        }

        public override void MainDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["advertiserId"] = this.AdvertiserId;
        }

        public override void CleanFilterControls()
        {
            //this.ContractDateTextBox.Text = string.Empty;
            //this.MonthsTextBox.Text = string.Empty;
            //this.ContractId = -1;
        }

        public override void MainGridView_DataBound(object sender, EventArgs e)
        {

        }

        public string ContractForm(int id) { return string.Format(id > 0 ? "{0}?{1}={2}&{3}={4}" : "{0}", this.ResolveUrl(Navigation.ContractForm), QueryKeys.ContractId, id, QueryKeys.AdvertiserId, this.AdvertiserId); }

        public string PrintDocumentUrl(object invoiceId, bool pdf)
        {
            if (invoiceId == null)
                invoiceId = "-1";

            int value = 0;

            int.TryParse(invoiceId.ToString(), out value);
            return string.Format("{0}?{1}={2}&{3}={4}", this.ResolveUrl(Navigation.PrintDocumentForm), QueryKeys.InvoiceId, value, QueryKeys.IsPdf, pdf);
        }
    }
}