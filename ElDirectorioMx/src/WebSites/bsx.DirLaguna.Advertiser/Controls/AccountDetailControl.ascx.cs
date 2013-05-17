using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.CommonWeb.Session;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Dal.Carrier;
using bsx.DirLaguna.Dal.Enum;

namespace bsx.DirLaguna.Advertiser.Controls
{
    public partial class AccountDetailControl : System.Web.UI.UserControl
    {
        public SimpleAccountDetailCarrier Carrier
        {
            get
            {
                SimpleAccountDetailCarrier temp = new SimpleAccountDetailCarrier();

                temp.ContractDate = DateTime.Now;
                temp.EndDate = DateTime.Now.AddYears(1);
                //temp.Months = string.IsNullOrEmpty(this.MonthsTextBox.Text) ? 0 : int.Parse(this.MonthsTextBox.Text);
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

        public GridView GridViewConcepts
        {
            get { return this.ConceptGridView; }
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

        private int? AdvertiserId { get { return SessionValues.AdvertiserId; } }

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
            this.ConceptGridView.RowDataBound += new GridViewRowEventHandler(ConceptGridView_RowDataBound);

            if (!IsPostBack)
            {
                this.LoadData();
            }

        }

        private void LoadData() { }

        void AccountDetailObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e) { }

        void ConceptGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = e.Row as GridViewRow;
            if (row == null)
                return;

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

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