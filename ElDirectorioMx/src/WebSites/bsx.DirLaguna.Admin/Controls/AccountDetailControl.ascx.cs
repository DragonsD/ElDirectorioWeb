using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Dal.Carrier;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb.Session;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal.Enum;

namespace bsx.DirLaguna.Admin.Controls
{
    public partial class AccountDetailControl : System.Web.UI.UserControl
    {
        public SimpleAccountDetailCarrier Carrier
        {
            get
            {
                SimpleAccountDetailCarrier temp = new SimpleAccountDetailCarrier();

                temp.ContractDate = string.IsNullOrEmpty(this.ContractDateTextBox.Text) ? DateTime.Today : DateTime.Parse(this.ContractDateTextBox.Text);
                temp.EndDate = temp.ContractDate.AddYears(1);
                temp.AccountDetils = this.AccountDetils;
                return temp;
            }
        }

        public decimal PaymentAccount
        {
            get
            {
                HiddenField totalLbl = this.TotalHiddenField;
                if (string.IsNullOrEmpty(this.TotalHiddenField.Value))
                    return 0;
                return decimal.Parse(this.TotalHiddenField.Value);
            }
        }

        private Dictionary<int, int> AccountDetils
        {
            get
            {
                Dictionary<int, int> temp = new Dictionary<int, int>();
                foreach (GridViewRow item in this.ConceptGridView.Rows)
                {
                    Label lblAccountconceptId = item.FindControl("AccountConceptIdLabel") as Label;
                    TextBox txtQuantity = item.FindControl("TextBox2") as TextBox;
                    temp.Add(int.Parse(lblAccountconceptId.Text), int.Parse(txtQuantity.Text));
                }

                return temp;
            }
        }

        private int? AdvertiserId
        {
            get
            {
                if (this.Request.QueryString[QueryKeys.AdvertiserId] != null)
                    return int.Parse(this.Request.QueryString[QueryKeys.AdvertiserId]);
                return -1;
            }
        }

        private int? ContractId
        {
            get
            {
                if (this.Request.QueryString[QueryKeys.ContractId] != null)
                    return int.Parse(this.Request.QueryString[QueryKeys.ContractId]);
                return -1;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            this.AccountDetailObjectDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(AccountDetailObjectDataSource_Selecting);
            //this.ConceptsDataList.ItemDataBound += new DataListItemEventHandler(ConceptsDataList_ItemDataBound);
            this.ConceptGridView.RowDataBound += new GridViewRowEventHandler(ConceptGridView_RowDataBound);

            if (!IsPostBack)
            {
                this.LoadData();
            }

        }

        private void LoadData()
        {
            ContractController controller = new ContractController();
            Contract contract = controller.FetchById((int)this.ContractId);
            SimpleAccountDetailCarrier carrier = new SimpleAccountDetailCarrier();
            if (contract != null)
            {
                this.ContractDateTextBox.Text = string.Format("{0:dd/MM/yyyy}", contract.ContractDate);
            }
        }

        void AccountDetailObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        void ConceptGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = e.Row as GridViewRow;
            if (row == null)
                return;


            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            // add the UnitPrice and QuantityTotal to the running total variables
            //priceTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "UnitPrice"));
            //quantityTotal += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Quantity"));

            Label AccountConceptIdLabel = e.Row.FindControl("AccountConceptIdLabel") as Label;
            Label UnitPriceLabel = e.Row.FindControl("UnitPriceLabel") as Label;
            TextBox txtQuantity = e.Row.FindControl("TextBox2") as TextBox;

            Label GorilaIdLabel = e.Row.FindControl("GorilaIdLabel") as Label;
            Label UnitPriceLessSymbolLabel = e.Row.FindControl("UnitPriceLessSymbolLabel") as Label;

            if (AccountConceptIdLabel == null || UnitPriceLabel == null || GorilaIdLabel == null || UnitPriceLessSymbolLabel == null)
                return;

            int AccountConceptId = int.Parse(AccountConceptIdLabel.Text);
            AccountDetailController controller = new AccountDetailController();
            AccountDetail accountDet = controller.FetchByContractIdAndAccountConceptId((int)this.ContractId, AccountConceptId);
            if (accountDet != null)
            {
                if (AccountConceptId == (int)AccountConceptKeyEnum.ClubElDirectorio)
                    txtQuantity.Text = accountDet.Quantity > 1 ? "1" : accountDet.Quantity.ToString();
                else
                    txtQuantity.Text = accountDet.Quantity.ToString();
            }
            else
                txtQuantity.Text = "0";

            int gorilaId = int.Parse(GorilaIdLabel.Text);
            GorilaService.GorilaService servicio = new GorilaService.GorilaService();
            decimal unitPrice = 0;
            string[] errors = new string[10];
            try
            {
                servicio.FetchPriceByGorilaId(gorilaId, out unitPrice, out errors);

            }
            catch (Exception)
            {
                unitPrice = 0;
            }
            UnitPriceLabel.Text = string.Format("$ {0}", unitPrice.ToString());
            UnitPriceLessSymbolLabel.Text = unitPrice.ToString();
        }


    }
}