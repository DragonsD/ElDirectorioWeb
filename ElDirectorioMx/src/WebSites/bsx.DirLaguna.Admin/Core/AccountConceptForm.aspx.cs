using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb.Session;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal.SelectControllers;
using bsx.DirLaguna.Dal.Enum;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class AccountConceptForm : BasePage
    {
        public int FranchiseeId
        {
            get
            {
                return SessionValues.FranchiseeId;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SaveButton.Click += new EventHandler(SaveButton_Click);
            this.ConceptsDataList.ItemDataBound += new DataListItemEventHandler(ConceptsDataList_ItemDataBound);
            if (!this.IsPostBack)
            {
                this.LoadData();
            }

        }

        public List<GorilaService.ConceptCarrier> ServiceConcepts
        {
            get
            {
                if (this.ViewState["_serviceConcepts"] == null)
                    return new List<GorilaService.ConceptCarrier>();
                return this.ViewState["_serviceConcepts"] as List<GorilaService.ConceptCarrier>;
            }
            set
            {
                this.ViewState["_serviceConcepts"] = value;
            }
        }

        public int? GorilaOfficeId
        {
            get
            {
                return int.Parse(this.OfficesDropDownList.SelectedValue);
            }
            set
            {
                this.OfficesDropDownList.SelectedIndex = 
                    this.OfficesDropDownList.Items.IndexOf(this.OfficesDropDownList.Items.FindByValue(value.ToString()));
            }
        }

        public int? GorilaBankAccountId
        {
            get
            {
                return int.Parse(this.BankAccountDropDownList.SelectedValue);
            }
            set
            {
                this.BankAccountDropDownList.SelectedIndex =
                    this.BankAccountDropDownList.Items.IndexOf(this.BankAccountDropDownList.Items.FindByValue(value.ToString()));
            }
        }

        public List<GorilaService.OfficeCarrier> ServiceOffices
        {
            get
            {
                if (this.ViewState["_serviceOffices"] == null)
                    return new List<GorilaService.OfficeCarrier>();
                return this.ViewState["_serviceOffices"] as List<GorilaService.OfficeCarrier>;
            }
            set
            {
                this.ViewState["_serviceOffices"] = value;
            }
        }

        public List<GorilaService.BankAccountCarrier> ServiceBankAccounts
        {
            get
            {
                if (this.ViewState["_serviceBankAccounts"] == null)
                    return new List<GorilaService.BankAccountCarrier>();
                return this.ViewState["_serviceBankAccounts"] as List<GorilaService.BankAccountCarrier>;
            }
            set
            {
                this.ViewState["_serviceBankAccounts"] = value;
            }
        }

        void ConceptsDataList_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            DropDownList conceptsList = e.Item.FindControl("ConceptsDropDownList") as DropDownList;
            Label AccountConceptIdLabel = e.Item.FindControl("AccountConceptIdLabel") as Label;
            Label GorilaIdLabel = e.Item.FindControl("GorilaIdLabel") as Label;
            TextBox DescriptionTextBox = e.Item.FindControl("DescriptionTextBox") as TextBox;

            if (conceptsList == null || AccountConceptIdLabel == null || GorilaIdLabel == null || DescriptionTextBox == null)
                return;
            DescriptionTextBox.MaxLength = AccountConcept.Columns.DescriptionColumn.MaxLength;

            this.FillComboBox(conceptsList,
               this.ServiceConcepts,
               "Id",
               "Description");

            int accountConceptId = int.Parse(AccountConceptIdLabel.Text);
            int gorilaId = string.IsNullOrEmpty(GorilaIdLabel.Text) ? -1 : int.Parse(GorilaIdLabel.Text);

            AccountConceptController controller = new AccountConceptController();
            AccountConcept concept = controller.FetchById(accountConceptId);
            if (concept == null)
                return;

            conceptsList.SelectedIndex = conceptsList.Items.IndexOf(conceptsList.Items.FindByValue(gorilaId.ToString()));

        }


        void SaveButton_Click(object sender, EventArgs e)
        {
            AccountConceptController controller = new AccountConceptController();
            List<string> errors = new List<string>();
            bool bHasError = false;

            foreach (DataListItem item in this.ConceptsDataList.Items)
            {
                DropDownList conceptsList = item.FindControl("ConceptsDropDownList") as DropDownList;
                Label AccountConceptIdLabel = item.FindControl("AccountConceptIdLabel") as Label;
                TextBox DescriptionTextBox = item.FindControl("DescriptionTextBox") as TextBox;

                if (conceptsList == null || AccountConceptIdLabel == null || DescriptionTextBox == null)
                    return;

                int accountconceptId = int.Parse(AccountConceptIdLabel.Text);
                int gorilaId = int.Parse(conceptsList.SelectedValue);
                if (!controller.SaveGorilaId(accountconceptId, gorilaId, DescriptionTextBox.Text))
                {
                    bHasError = true;
                    foreach (var error in controller.Errors)
                    {
                        errors.Add(error);
                    }
                }
            }

            FranchiseeController controllerFran = new FranchiseeController();
            if (!controllerFran.UpdateOfficeFranchisee(this.FranchiseeId, this.GorilaOfficeId, this.GorilaBankAccountId))
            {
                errors.AddRange(controllerFran.Errors);
            }

            if (!bHasError)
                this.ShowMessage("Los datos se han guardado correctamente.", CommonWeb.Enum.MessageTypes.Success);
            else
                this.ShowMessage(errors, CommonWeb.Enum.MessageTypes.Error);

        }

        private void LoadData()
        {
            FranchiseeController controller = new FranchiseeController();
            Franchisee fran = controller.FetchById(this.FranchiseeId);
            if (fran == null)
            {
                this.ShowMessage("No se encontro al franquiciatario.", CommonWeb.Enum.MessageTypes.Notice);
                return;
            }

            GorilaService.GorilaService service = new GorilaService.GorilaService();
            GorilaService.ConceptCarrier[] items;
            string[] errors;

            if (!service.FetchClientConcepts(fran.Rfc, fran.GorilaKey, out items, out errors))
            {
                this.ShowMessage(errors, CommonWeb.Enum.MessageTypes.Error);
                return;
            }

            List<GorilaService.ConceptCarrier> list = new List<GorilaService.ConceptCarrier>();

            foreach (var item in items)
            {
                list.Add(item);
            }
            this.ServiceConcepts = list;

            GorilaService.OfficeCarrier[] offices;
            List<GorilaService.OfficeCarrier> listOffices = new List<GorilaService.OfficeCarrier>();

            if (!service.OfficesFranchisee(fran.Rfc, fran.GorilaKey, out offices, out errors))
            {
                this.ShowMessage(errors, CommonWeb.Enum.MessageTypes.Error);
                return;
            }

            foreach (var item in offices)
            {
                listOffices.Add(item);
            }
            this.ServiceOffices = listOffices;

            this.FillComboBox(this.OfficesDropDownList,
                    this.ServiceOffices,
                    "Id",
                    "Name");

            this.GorilaOfficeId = fran.GorilaOfficeId;

            GorilaService.BankAccountCarrier[] bankAccounts;
            List<GorilaService.BankAccountCarrier> listBankAccounts = new List<GorilaService.BankAccountCarrier>();

            if (!service.BankAccountsFranchisee(fran.Rfc, fran.GorilaKey, out bankAccounts, out errors))
            {
                this.ShowMessage(errors, CommonWeb.Enum.MessageTypes.Error);
                return;
            }

            foreach (var item in bankAccounts)
            {
                listBankAccounts.Add(item);
            }
            this.ServiceBankAccounts = listBankAccounts;

            this.FillComboBox(this.BankAccountDropDownList,
                    this.ServiceBankAccounts,
                    "Id",
                    "Name");

            this.GorilaBankAccountId = fran.GorilaBankId;

        }
    }
}