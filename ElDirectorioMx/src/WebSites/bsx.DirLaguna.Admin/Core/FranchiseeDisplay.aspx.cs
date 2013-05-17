using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class FranchiseeDisplay : SimpleDisplayPage
    {
        public string Name
        {
            get { return this.NameTextBox.Text; }
            set { this.NameTextBox.Text = value; }
        }

        public string Email
        {
            get { return this.EmailTextBox.Text; }
            set { this.EmailTextBox.Text = value; }
        }

        public int EstadoId
        {
            get
            {
                if (this.StatesDropDownList.SelectedIndex <= 0)
                    return -1;
                return int.Parse(this.StatesDropDownList.SelectedValue.ToString());
            }
            set
            {
                ListItem item = this.StatesDropDownList.Items.FindByValue(value.ToString());
                if (item == null)
                    this.StatesDropDownList.SelectedIndex = 0;
                else
                    this.StatesDropDownList.SelectedIndex = this.StatesDropDownList.Items.IndexOf(item);
            }
        }

        public int CityId
        {
            get
            {
                if (this.CitiesDropDownList.SelectedIndex <= 0)
                    return -1;
                return int.Parse(this.CitiesDropDownList.SelectedValue.ToString());
            }
            set
            {
                ListItem item = this.CitiesDropDownList.Items.FindByValue(value.ToString());
                if (item == null)
                    this.CitiesDropDownList.SelectedIndex = 0;
                else
                    this.CitiesDropDownList.SelectedIndex = this.CitiesDropDownList.Items.IndexOf(item);
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

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!this.IsPostBack)
            {
                this.UnpayedControl.RequestedType = ContractController.PendingContractsType.Unpayed;
                this.UnpayedControl.Title = "Contrataciones sin pagar";
                this.UnpayedControl.ButtonText = "Pagar";
                this.NoActiveControl.RequestedType = ContractController.PendingContractsType.Inactive;
                this.NoActiveControl.Title = "Contrataciones sin activar";
                this.NoActiveControl.ButtonText = "Activar";
                this.NotInvoicedControl.RequestedType = ContractController.PendingContractsType.NotInvoiced;
                this.NotInvoicedControl.Title = "Contrataciones sin facturar";
                this.NotInvoicedControl.ButtonText = string.Empty;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.See50LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See100LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See200LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See20LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See10LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.StatesDropDownList.SelectedIndexChanged += new EventHandler(StatesDropDownList_SelectedIndexChanged);
            this.UnpayedControl.DisplayMessage += new EventHandler(DisplayMessages);
            this.NoActiveControl.DisplayMessage += new EventHandler(DisplayMessages);

            if (!Page.IsPostBack)
            {
                this.FillComboBox(this.StatesDropDownList,
                    new EstadoController().FetchAll(),
                    Estado.ColumnNames.EstadoId,
                    Estado.ColumnNames.Name);

                var cities = new MunicipioController().FetchAllByEstadoId(this.EstadoId);
                this.FillComboBox(this.CitiesDropDownList,
                        from x in cities orderby x.Name ascending select x,
                        Municipio.ColumnNames.MunicipioId,
                        Municipio.ColumnNames.Name);

                this.UnpayedControl.RequestedType = ContractController.PendingContractsType.Unpayed;
                this.NoActiveControl.RequestedType = ContractController.PendingContractsType.Inactive;

                this.UnpayedControl.FranchiseeId = this.FranchiseeId;

            }


        }

        void DisplayMessages(object sender, EventArgs e)
        {
            if (this.UnpayedControl.Messages.Count > 0)
                this.ShowMessage(this.UnpayedControl.Messages, CommonWeb.Enum.MessageTypes.Error);

            if (this.NoActiveControl.Messages.Count > 0)
                this.ShowMessage(this.NoActiveControl.Messages, CommonWeb.Enum.MessageTypes.Error);
        }

        void StatesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cities = new MunicipioController().FetchAllByEstadoId(this.EstadoId);
            this.FillComboBox(this.CitiesDropDownList,
                    from x in cities orderby x.Name ascending select x,
                    Municipio.ColumnNames.MunicipioId,
                    Municipio.ColumnNames.Name);
        }

        void SeePageSizeLinkButton_Command(object sender, CommandEventArgs e)
        {
            this.PageSize = int.Parse(e.CommandArgument.ToString());
            this.FranchiseesGridView.DataBind();
        }

        public string FranchiseeForm(int id) { return string.Format(id > 0 ? "{0}?{1}={2}" : "{0}", this.ResolveUrl(Navigation.FranchiseeForm), QueryKeys.FranchiseeId, id); }

        public string FranchiseeDisplayUrl(int id) { return string.Format(id > 0 ? "{0}?{1}={2}" : "{0}", this.ResolveUrl(Navigation.AdvertiserPrimaryDisplay), QueryKeys.FranchiseeId, id); }

        public override ObjectDataSource MainDataSource { get { return this.FranchiseeDataSource; } }

        public override GridView MainGridView { get { return this.FranchiseesGridView; } }

        public override LinkButton MainNewButton { get { return this.NewFranchiseeButton; } }

        public override LinkButton MainSearchButton { get { return this.SearchFranchiseeButton; } }

        public override LinkButton MainCleanButton { get { return this.CleanFiltersLinkButton; } }

        public override string ElementFormUrl { get { return this.ResolveUrl(Navigation.FranchiseeForm); } }

        public override void MainGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (!e.CommandName.Equals("delFranchisee"))
                return;

            FranchiseeController controller = new FranchiseeController();
            if (!controller.Delete(int.Parse(e.CommandArgument.ToString())))
            {
                this.ShowMessage(controller.Errors, CommonWeb.Enum.MessageTypes.Error);
                return;
            }

            this.ShowMessage("El franquiciatario ha sido eliminado exitosamente", CommonWeb.Enum.MessageTypes.Success);
            this.FranchiseesGridView.DataBind();
        }

        public override void MainDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            this.FranchiseesGridView.PageSize = this.PageSize;
            e.InputParameters["name"] = this.Name;
            e.InputParameters["email"] = this.Email;
            e.InputParameters["estadoId"] = this.EstadoId;
            e.InputParameters["cityId"] = this.CityId;
        }

        public override void CleanFilterControls()
        {
            this.NameTextBox.Text = string.Empty;
            this.EmailTextBox.Text = string.Empty;
            this.StatesDropDownList.SelectedIndex = 0;
            var cities = new MunicipioController().FetchAllByEstadoId(this.EstadoId);
            this.FillComboBox(this.CitiesDropDownList,
                    from x in cities orderby x.Name ascending select x,
                    Municipio.ColumnNames.MunicipioId,
                    Municipio.ColumnNames.Name);
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