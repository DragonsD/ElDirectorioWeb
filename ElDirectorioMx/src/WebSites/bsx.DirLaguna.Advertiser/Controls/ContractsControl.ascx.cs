using System;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Advertiser.Code;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.CommonWeb.Session;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Advertiser.Controls
{
    public partial class ContractsControl : System.Web.UI.UserControl
    {
        public int AdvertiserId { get { return SessionValues.AdvertiserId; } }

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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ContractObjectDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(ContractObjectDataSource_Selecting);

            this.See50LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See100LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See200LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See20LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.BackHyperLink.NavigateUrl = this.ResolveUrl(Navigation.AccountForm);
            this.ContractGridView.RowDataBound += new GridViewRowEventHandler(ContractGridView_RowDataBound);
            this.ContractGridView.RowCommand += new GridViewCommandEventHandler(ContractGridView_RowCommand);

            if (!this.IsPostBack)
                this.NewContractButton.PostBackUrl = this.ResolveUrl(Navigation.ContractForm);
        }

        void ContractGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ContractController controller = new ContractController();
            if (e.CommandName.Equals("delContract"))
            {
                if (!controller.Delete(int.Parse(e.CommandArgument.ToString()), SessionValues.PersonalId))
                {
                    //this.ShowMessage(controller.Errors, CommonWeb.Enum.MessageTypes.Error);
                    return;
                }

                //this.ShowMessage("La contratacion ha sido eliminada exitosamente", CommonWeb.Enum.MessageTypes.Success);
                this.ContractGridView.DataBind();
            }
            else
            {
                Contract contract = controller.FetchById(int.Parse(e.CommandArgument.ToString()));
                this.LoadViewDataFromModel(contract);
            }
        }

        void ContractObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["advertiserId"] = SessionValues.AdvertiserId;
        }

        void ContractGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            ImageButton deleteBtn = e.Row.FindControl("DeleteImageButton") as ImageButton;
            if (deleteBtn != null)
            {
                Label invoiceIdLabel = e.Row.FindControl("InvoiceIdLabel") as Label;
                //deleteBtn.Visible = string.IsNullOrEmpty(invoiceIdLabel.Text);
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
            this.ContractGridView.DataBind();
        }

        public string ContractForm(int id) { return string.Format(id > 0 ? "{0}?{1}={2}" : "{0}", this.ResolveUrl(Navigation.ContractForm), QueryKeys.ContractId, id); }

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