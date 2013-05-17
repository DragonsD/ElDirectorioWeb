using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using bsx.DirLaguna.Public.Code;
using bsx.DirLaguna.Dal;
using System.Web.Security;
using bsx.DirLaguna.CommonWeb;
using System.Configuration;
using bsx.DirLaguna.Dal.Carrier;
using System.Collections;
using System.Text;

namespace bsx.DirLaguna.Public.Admin
{
    public partial class SignupForm : System.Web.UI.Page
    {

        public List<string> Errors
        {
            get
            {
                if (this.ViewState["_errors"] == null)
                    return new List<string>();
                return (List<string>)this.ViewState["_errors"];
            }
            set
            {
                this.ViewState["_errors"] = value;
            }
        }

        public string AdvertiserName
        {
            get
            {
                return this.AdvertiserNameTextBox.Text;
            }
        }

        public string Description
        {
            get
            {
                return this.DescriptionTextBox.Text;
            }
        }

        public string Address
        {
            get
            {
                return this.AddressTextBox.Text;
            }
        }

        public string Contact
        {
            get
            {
                return this.ContactTextBox.Text;
            }
        }

        public string EmailAddress
        {
            get
            {
                return this.EmailTextBox.Text;
            }
        }

        public string Password
        {
            get
            {
                return this.PasswordTextBox.Text;
            }
        }

        public int EstadoId
        {
            get
            {
                return int.Parse(this.EstadoDropDownList.SelectedValue);
            }
        }

        public int MunicipioId
        {
            get
            {
                return int.Parse(this.MunicipioDropDownList.SelectedValue);
            }
        }

        public int FranchiseeId
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["FranchiseePrimary"].ToString());
            }
        }

        private SimpleAccountDetailCarrier Detail
        {
            get
            {
                return this.GenerateDetail();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SaveAndPaymentButton.Click += new EventHandler(SaveAndPaymentButton_Click);
            this.ConceptGridView.RowDataBound += new GridViewRowEventHandler(ConceptGridView_RowDataBound);
            this.EstadoDropDownList.SelectedIndexChanged += new EventHandler(EstadoDropDownList_SelectedIndexChanged);

            if (!IsPostBack)
            {
                this.SetMaxLenght();
                this.Errors = new List<string>();
                this.FillComboBox(this.EstadoDropDownList, new EstadoController().FetchAll(),
                        Estado.ColumnNames.EstadoId,
                        Estado.ColumnNames.Name);
            }

        }

        void EstadoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cities = new MunicipioController().FetchAllByEstadoId(this.EstadoId);
            this.FillComboBox(this.MunicipioDropDownList,
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

            Label GorilaIdLabel = e.Row.FindControl("GorilaIdLabel") as Label;
            Label UnitPriceLessSymbolLabel = e.Row.FindControl("UnitPriceLessSymbolLabel") as Label;

            if (AccountConceptIdLabel == null || UnitPriceLabel == null || GorilaIdLabel == null || UnitPriceLessSymbolLabel == null)
                return;

            int gorilaId = int.Parse(GorilaIdLabel.Text);
            GorilaService.GorilaService servicio = new GorilaService.GorilaService();
            decimal unitPrice = 0;
            string[] errors = new string[10];
            servicio.FetchPriceByGorilaId(gorilaId, out unitPrice, out errors);
            UnitPriceLabel.Text = string.Format("$ {0}", unitPrice.ToString());
            UnitPriceLessSymbolLabel.Text = unitPrice.ToString();
        }

        private void SetMaxLenght()
        {
            this.AdvertiserNameTextBox.MaxLength = Advertiser.Columns.NameColumn.MaxLength;
            this.DescriptionTextBox.MaxLength = Advertiser.Columns.DescriptionColumn.MaxLength;
            this.AddressTextBox.MaxLength = Advertiser.Columns.AddressColumn.MaxLength;
            this.ContactTextBox.MaxLength = Advertiser.Columns.ContactColumn.MaxLength;
            this.EmailTextBox.MaxLength = Email.Columns.AddressColumn.MaxLength;
        }

        private bool SaveMethod()
        {
            PersonalUser personal = new PersonalUser();
            Guid newUserId;
            int newPersonalId = -1;

            if (!personal.CreateUserAdminAndPersonal(this.AdvertiserName, this.Password, this.EmailAddress, this.FranchiseeId, false, PersonalTypeEnum.UserAdmin, out newPersonalId, out newUserId))
            {
                foreach (string item in personal.Errors)
                {
                    this.Errors.Add(item);
                }

                return false;
            }

            int newAdvId=-1;
            int newContractId = -1;
            bool isNew = false;
            AdvertiserController controller = new AdvertiserController();
            if (!controller.SavePublic(newUserId, -1, this.AdvertiserName, this.Description, this.Address, this.FranchiseeId, newPersonalId, this.EstadoId, this.MunicipioId, this.Detail, null, null, out newAdvId, out newContractId, out isNew))
            {
                foreach (string item in controller.Errors)
                {
                    this.Errors.Add(item);
                }
                return false;
            }

            return true;
        }

        void SaveAndPaymentButton_Click(object sender, EventArgs e)
        {
            if (this.SaveMethod())
                this.Response.Redirect(this.ResolveUrl(Navigation.RegisterForm));

            StringBuilder sb = new StringBuilder();
            foreach (string item in this.Errors)
            {
                sb.Append(item);
            }
            this.Msg.Text = sb.ToString();

        }

        private SimpleAccountDetailCarrier GenerateDetail()
        {
            SimpleAccountDetailCarrier carrier = new SimpleAccountDetailCarrier();

            foreach (GridViewRow item in this.ConceptGridView.Rows)
            {
                if (item.RowType != DataControlRowType.DataRow)
                    continue;

                TextBox textBox = item.FindControl("TextBox2") as TextBox;
                Label AccountConceptIdLabel = item.FindControl("AccountConceptIdLabel") as Label;
                Label UnitPriceLabel = item.FindControl("UnitPriceLabel") as Label;

                Label GorilaIdLabel = item.FindControl("GorilaIdLabel") as Label;
                Label UnitPriceLessSymbolLabel = item.FindControl("UnitPriceLessSymbolLabel") as Label;

                carrier.AccountDetils.Add(int.Parse(AccountConceptIdLabel.Text), int.Parse(textBox.Text));
            }

            return carrier;
        }
    }
}