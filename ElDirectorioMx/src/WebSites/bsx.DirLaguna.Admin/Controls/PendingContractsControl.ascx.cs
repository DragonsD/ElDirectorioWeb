using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb.Session;
using System.Collections;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb;

namespace bsx.DirLaguna.Admin.Controls
{
    public partial class PendingContractsControl : System.Web.UI.UserControl
    {
        public event EventHandler DisplayMessage;

        public List<string> Messages
        {

            get
            {
                if (this.ViewState["_messages"] == null)
                    return new List<string>();
                return this.ViewState["_messages"] as List<string>; 
            }
            set { this.ViewState["_messages"] = value; }
        }

        public bool hasErrors
        {
            get { return this.Messages.Count > 0; }
        }

        public delegate bool ActionMethod(int invoiceId, int personalId);
        
        public string Title { set { this.TitelLabel.Text = value; } }

        public ContractController.PendingContractsType RequestedType
        {
            get
            {
                if (this.ViewState["reqType"] != null)
                    return (ContractController.PendingContractsType)this.ViewState["reqType"];
                return ContractController.PendingContractsType.None;
            }
            set { this.ViewState["reqType"] = value; }
        }

        public string ButtonText
        {
            get
            {
                if (this.ViewState["btnText"] != null)
                    return this.ViewState["btnText"].ToString();
                return "unk";
            }
            set { this.ViewState["btnText"] = value; }
        }

        public string NameAdvertiser
        {
            get { return this.NameAdvertiserTextBox.Text; }
        }

        public int EstadoId
        {
            get
            {
                if (this.StatesDropDownList.SelectedIndex <= 0)
                    return -1;
                return int.Parse(this.StatesDropDownList.SelectedValue.ToString());
            }
        }

        public int MunicipioId
        {
            get
            {
                if (this.CitiesDropDownList.SelectedIndex <= 0)
                    return -1;
                return int.Parse(this.CitiesDropDownList.SelectedValue.ToString());
            }
        }

        public int PageSize
        {
            get
            {
                if (this.ViewState["pagesize"] != null)
                    return (int)this.ViewState["pagesize"];
                return 10;
            }
            set { this.ViewState["pagesize"] = value; }
        }

        public int FranchiseeId
        {
            get
            {
                if (this.ViewState["_franchiseeId"] != null)
                    return (int)this.ViewState["_franchiseeId"];
                return -1;
            }
            set { this.ViewState["_franchiseeId"] = value; }
        }

        public string InvoiceContractForm(int advId, int id) { return string.Format("{0}?{1}={2}&{3}={4}", this.ResolveUrl(Navigation.InvoiceContractForm), QueryKeys.AdvertiserId, advId, QueryKeys.ContractId, id); }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ContractsDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(ContractsDataSource_Selecting);
            this.ContractsGridView.RowDataBound += new GridViewRowEventHandler(ContractsGridView_RowDataBound);
            this.ContractsGridView.RowCommand += new GridViewCommandEventHandler(ContractsGridView_RowCommand);
            this.ContractsGridView.DataBound +=new EventHandler(ContractsGridView_DataBound);

            this.See50LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See100LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See200LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See20LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See10LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);


            this.StatesDropDownList.SelectedIndexChanged += new EventHandler(StatesDropDownList_SelectedIndexChanged);
            this.SearchFranchiseeButton.Click += new EventHandler(SearchFranchiseeButton_Click);
            this.CleanFiltersLinkButton.Click += new EventHandler(CleanFiltersLinkButton_Click);

            if (this.RequestedType == ContractController.PendingContractsType.NotInvoiced)
                this.ContractsGridView.Columns[6].Visible = false;

            if (!Page.IsPostBack)
            {
                var states = new EstadoController().FetchAll();

                this.FillComboBox(this.StatesDropDownList,
                        from x in states orderby x.Name ascending select x,
                        Estado.ColumnNames.EstadoId,
                        Estado.ColumnNames.Name);

                var cities = new MunicipioController().FetchAllByEstadoId(this.EstadoId);
                this.FillComboBox(this.CitiesDropDownList,
                        from x in cities orderby x.Name ascending select x,
                        Municipio.ColumnNames.MunicipioId,
                        Municipio.ColumnNames.Name);
                this.Messages = new List<string>();
            }

        }

        void CleanFiltersLinkButton_Click(object sender, EventArgs e)
        {
            this.NameAdvertiserTextBox.Text = string.Empty;
            this.StatesDropDownList.SelectedIndex = 0;
            this.CitiesDropDownList.SelectedIndex = 0;
            this.ContractsGridView.DataBind();
        }

        void SearchFranchiseeButton_Click(object sender, EventArgs e)
        {
            this.ContractsGridView.DataBind();
        }

        void StatesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cities = new MunicipioController().FetchAllByEstadoId(this.EstadoId);
            this.FillComboBox(this.CitiesDropDownList,
                    from x in cities orderby x.Name ascending select x,
                    Municipio.ColumnNames.MunicipioId,
                    Municipio.ColumnNames.Name);
        }

        protected void FillComboBox(System.Web.UI.WebControls.DropDownList dropdown, IEnumerable collection, string dataValueField, string dataTextField)
        {
            dropdown.DataSource = collection;
            dropdown.DataValueField = dataValueField;
            dropdown.DataTextField = dataTextField;
            dropdown.DataBind();

            dropdown.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", string.Empty));
        }

        void SeePageSizeLinkButton_Command(object sender, CommandEventArgs e)
        {
            this.PageSize = int.Parse(e.CommandArgument.ToString());
            this.ContractsGridView.DataBind();
        }

        void ContractsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (!e.CommandName.Equals("ActionCommand"))
                return;

            int contractId = int.Parse(e.CommandArgument.ToString());

            ContractController controller = new ContractController();
            controller.UpdatePaidInvoiceFG += new ContractController.UpdatePaidInvoiceEventHandler(controller_UpdatePaidInvoiceFG);
            ActionMethod method = null;
            switch (this.RequestedType)
            {
                case ContractController.PendingContractsType.Unpayed:
                    method = controller.PayContract;
                    break;
                case ContractController.PendingContractsType.Inactive:
                    method = controller.ActivateContract;
                    break;
                case ContractController.PendingContractsType.None:
                    break;
                case ContractController.PendingContractsType.NotInvoiced:
                    break;
                default:
                    break;
            }

            if (method != null)
            {
                if (!method(contractId, SessionValues.PersonalId))
                    this.Response.Redirect("mensaje");
                else
                {
                    if (DisplayMessage != null)
                    {
                        this.Messages.Add("La operacion se ha completado con exito.");
                        DisplayMessage(this, new EventArgs());
                    }
                    this.ContractsGridView.DataBind();
                }
            }
        }

        bool controller_UpdatePaidInvoiceFG(string invoiceId)
        {
            List<string> err = new List<string>();

            bool bResult = true;
            if (this.RequestedType == ContractController.PendingContractsType.Unpayed)
            {
                FranchiseeController controller = new FranchiseeController();
                Franchisee fran = controller.FetchById(this.FranchiseeId);
                if (fran == null)
                {
                    this.Messages.Add("No se encontro al franquiciatario.");
                    return false;
                }

                string[] errors = new string[20];
                GorilaService.GorilaService service = new GorilaService.GorilaService();
                if (!service.RegisterPayment(fran.Rfc, fran.GorilaKey, int.Parse(invoiceId), (int)fran.GorilaBankId, out errors))
                {
                    foreach (string item in errors)
                    {
                        err.Add(item);
                    }

                    this.Messages.AddRange(err);

                    if(DisplayMessage != null)
                        DisplayMessage(this, new EventArgs());

                    bResult= false;
                }
            }

            return bResult;
        }

        void ContractsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var hyperlink = e.Row.FindControl("ActionLinkButton") as LinkButton;
            if (hyperlink != null)
                hyperlink.Text = this.ButtonText;

            var advertiserLabel = e.Row.FindControl("AdvertiserLabel") as Label;
            Contract ct = e.Row.DataItem as Contract;

            if (ct != null && advertiserLabel != null)
                advertiserLabel.Text = ct.Advertiser.Name;

            var franchiseeLabel = e.Row.FindControl("FranchiseeLabel") as Label;
            if (ct != null && franchiseeLabel != null)
                franchiseeLabel.Text = ct.Advertiser.Franchisee.Name;

            var invoiceHyperlink = e.Row.FindControl("InvoiceContractLink") as HyperLink;
            if (invoiceHyperlink == null)
                return;

            if (this.RequestedType == ContractController.PendingContractsType.NotInvoiced)
            {
                hyperlink.Visible = false;
                invoiceHyperlink.Visible = true;
            }
            else
            {
                hyperlink.Visible = true;
                invoiceHyperlink.Visible = false;
            }
        }

        public string PrintDocumentUrl(object invoiceId, bool pdf)
        {
            if (invoiceId == null)
                invoiceId = "-1";

            int value = 0;

            int.TryParse(invoiceId.ToString(), out value);
            return string.Format("{0}?{1}={2}&{3}={4}", this.ResolveUrl(Navigation.PrintDocumentForm), QueryKeys.InvoiceId, value, QueryKeys.IsPdf, pdf);
        }


        void ContractsDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            this.ContractsGridView.PageSize = this.PageSize;

            e.InputParameters["requested"] = this.RequestedType;
            e.InputParameters["nameAdvertiser"] = this.NameAdvertiser;
            e.InputParameters["estadoId"] = this.EstadoId;
            e.InputParameters["municipioId"] = this.MunicipioId;
            e.InputParameters["startRowIndex"] = 0;
            e.InputParameters["maximumRows"] = this.PageSize;
            e.InputParameters["sort"] = Franchisee.ColumnNames.Name;
        }

        protected void PageDropDownList_SelectedIndexChanged(Object sender, EventArgs e)
        {
            GridViewRow pagerRow = this.ContractsGridView.BottomPagerRow;
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            this.ContractsGridView.PageIndex = pageList.SelectedIndex;
        }

        public void ContractsGridView_DataBound(object sender, EventArgs e)
        {
            GridViewRow pagerRow = this.ContractsGridView.BottomPagerRow;

            if (pagerRow == null)
                return;

            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

            if (pageList != null)
            {
                for (int i = 0; i < this.ContractsGridView.PageCount; i++)
                {
                    int pageNumber = i + 1;
                    ListItem item = new ListItem(pageNumber.ToString());

                    if (i == this.ContractsGridView.PageIndex)
                    {
                        item.Selected = true;
                    }

                    pageList.Items.Add(item);
                }
            }
        }

    }
}