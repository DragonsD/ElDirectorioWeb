using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb;
using System.Collections;
using System.Configuration;
using bsx.DirLaguna.Dal.Carrier;
using bsx.DirLaguna.Advertiser.Code;
using System.Text;
using NLog;

namespace bsx.DirLaguna.Advertiser
{
    public partial class SignupForm : System.Web.UI.Page
    {
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

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

        public string UserName
        {
            get
            {
                return this.UserNameTextBox.Text;
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

        private string StrPaypal
        {
            get
            {
                if (this.ViewState["_strPaypal"] == null)
                    return string.Empty;

                return this.ViewState["_strPaypal"].ToString();
            }
            set
            {
                this.ViewState["_strPaypal"] = value;
            }
        }

        private decimal TotalAmount
        {
            get
            {
                HiddenField totalLbl = this.TotalHiddenField;
                if (string.IsNullOrEmpty(this.TotalHiddenField.Value))
                    return 0;
                return decimal.Parse(this.TotalHiddenField.Value);
            }
        }

        public SimpleFiscalDetailCarrier FiscalCarrier
        {
            get
            {
                if (this.FiscalDetailPlaceHolder.Visible)
                    return this.FiscalDetailControl.Carrier;
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SaveAndPaymentButton.Click += new EventHandler(SaveAndPaymentButton_Click);
            this.ConceptGridView.RowDataBound += new GridViewRowEventHandler(ConceptGridView_RowDataBound);
            this.EstadoDropDownList.SelectedIndexChanged += new EventHandler(EstadoDropDownList_SelectedIndexChanged);
            Logger.Debug("Cargando la pagina SignupForm.aspx");
            this.RequiredInvoiceCheckBox.CheckedChanged += new EventHandler(RequiredInvoiceCheckBox_CheckedChanged);
            if (!IsPostBack)
            {
                this.FiscalDetailPlaceHolder.Visible = false;
                this.SetMaxLenght();
                this.Errors = new List<string>();
                this.FillComboBox(this.EstadoDropDownList, new EstadoController().FetchAll(),
                        Estado.ColumnNames.EstadoId,
                        Estado.ColumnNames.Name);
            }

        }

        
        void RequiredInvoiceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.FiscalDetailPlaceHolder.Visible = this.RequiredInvoiceCheckBox.Checked;
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
            this.AdvertiserNameTextBox.MaxLength = bsx.DirLaguna.Dal.Advertiser.Columns.NameColumn.MaxLength;
            this.DescriptionTextBox.MaxLength = bsx.DirLaguna.Dal.Advertiser.Columns.DescriptionColumn.MaxLength;
            this.AddressTextBox.MaxLength = bsx.DirLaguna.Dal.Advertiser.Columns.AddressColumn.MaxLength;
            this.ContactTextBox.MaxLength = bsx.DirLaguna.Dal.Advertiser.Columns.ContactColumn.MaxLength;
            this.EmailTextBox.MaxLength = Email.Columns.AddressColumn.MaxLength;
        }

        private bool SaveMethod()
        {
            PersonalUser personal = new PersonalUser();
            Guid newUserId;
            int newPersonalId = -1;

            if (!personal.CreateUserAdminAndPersonal(this.UserName, this.Password, this.EmailAddress, this.FranchiseeId, true, PersonalTypeEnum.UserIndependent, out newPersonalId, out newUserId))
            {
                Logger.Debug(string.Format("personal.Errors.Count = {0} en CreateUserAdminAndPersonal", personal.Errors.Count));
                foreach (string item in personal.Errors)
                {
                    this.Errors.Add(item);
                }

                return false;
            }

            Logger.Debug("Paso CreateUserAdminAndPersonal");
            int newUsedId = -1;
            int newContractId = -1;
            bool isNewAdv = false;
            AdvertiserController controller = new AdvertiserController();
            if (!controller.SavePublic(newUserId, -1, this.AdvertiserName, this.Description, this.Address, this.FranchiseeId, newPersonalId, this.EstadoId, this.MunicipioId, this.Detail, TotalAmount, this.FiscalDetailControl.Carrier, out newUsedId, out newContractId, out isNewAdv))
            {
                Logger.Debug(string.Format("controller.Errors.Count = {0} en SavePublic", controller.Errors.Count));
                foreach (string item in controller.Errors)
                {
                    this.Errors.Add(item);
                }
                return false;
            }

            Logger.Debug("Paso SavePublic");
            if (!isNewAdv)
            {
                this.Errors.Add("Ha ocurrido un error al guardar el anunciante.");
                return false;
            }

            Logger.Debug("Entrando a GetStringPaypal");
            Logger.Debug("newContractId :" + newContractId);
            this.StrPaypal = GetStringPaypal(newContractId);
            Logger.Debug("StrPaypal : " + this.StrPaypal);

            return true;
        }

        private string GetStringItemsPaypal()
        {
            StringBuilder sb = new StringBuilder();
            int index = 1;
            foreach (GridViewRow item in this.ConceptGridView.Rows)
            {
                if (item.RowType != DataControlRowType.DataRow)
                    continue;

                TextBox quantityTextBox = item.FindControl("TextBox2") as TextBox;
                Label accountConceptIdLabel = item.FindControl("AccountConceptIdLabel") as Label;
                Label conceptKeyLabel = item.FindControl("ConceptKeyLabel") as Label;
                Label unitPriceLessSymbolLabel = item.FindControl("UnitPriceLessSymbolLabel") as Label;

                if (accountConceptIdLabel == null || unitPriceLessSymbolLabel == null || quantityTextBox == null || conceptKeyLabel == null)
                    continue;

                if (int.Parse(quantityTextBox.Text) == 0)
                    continue;

                sb.Append(string.Format("item_number_{0}={1}&item_name_{0}={2}&quantity_{0}={3}&amount_{0}={4}&", index, index, System.Web.HttpUtility.UrlEncode(conceptKeyLabel.Text, Encoding.UTF8), quantityTextBox.Text, unitPriceLessSymbolLabel.Text));
                index++;
            }
            return sb.ToString();
        }

        private string GetReturnUrl(string page)
        {
            if (Request.IsSecureConnection)
                return string.Format("https://{0}{1}/{2}", Request.Url.Host, Request.Url.Port == 80 ? "" : ":" + Request.Url.Port.ToString(), page);
             else
                return string.Format("http://{0}{1}/{2}", Request.Url.Host, Request.Url.Port == 80 ? "" : ":" + Request.Url.Port.ToString(), page);
        }

        private string GetStringPaypal(int contractId)
        {
            string urlPaymentPaypal = ConfigurationManager.AppSettings["UrlPaymentPaypal"].ToString();
            string urlNotityIPN = ConfigurationManager.AppSettings["UrlNotityIPN"].ToString();
            string emailBussiness = ConfigurationManager.AppSettings["EmailBussiness"].ToString();
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("{0}?", urlPaymentPaypal));
            sb.Append(string.Format("cmd={0}&", "_cart"));
            sb.Append(string.Format("upload={0}&", "1"));
            sb.Append(string.Format("business={0}&", emailBussiness));
            sb.Append(string.Format("invoice={0}&", contractId));
            sb.Append(this.GetStringItemsPaypal());
            sb.Append(string.Format("return={0}&", GetReturnUrl("Login.aspx")));
            sb.Append("rm=0&");
            sb.Append(string.Format("cancel_return={0}&", GetReturnUrl("SignupForm.aspx")));
            sb.Append(string.Format("notify_url={0}&", urlNotityIPN));
            //sb.Append(string.Format("amount={0}&", this.TotalAmount));
            sb.Append("currency_code=MXN");

            //return System.Web.HttpUtility.UrlEncode(sb.ToString(), Encoding.Default);
            return sb.ToString();

        }


        void SaveAndPaymentButton_Click(object sender, EventArgs e)
        {
            this.Msg.Text = string.Empty;
            //this.Errors = new List<string>();
            this.Errors.Clear();
            Logger.Debug(string.Format("Empezando a Guardar -> {0}", this.AdvertiserName));
            if (this.SaveMethod())
            {
                Logger.Debug("Se guardo satisfactoriamente");
                Logger.Debug(string.Format("Se redireccionara a la siguiente direccion {0}", this.StrPaypal));
                this.Response.Redirect(this.StrPaypal);
            }

            Logger.Debug("Se generaron errores en el Guardado de Datos");
            Logger.Debug("Errors.Count {0} -> ", Errors.Count);
            StringBuilder sb = new StringBuilder();
            foreach (string item in this.Errors)
            {
                sb.Append(item);
                Logger.Debug(item);
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
                TextBox quantityTextBox = item.FindControl("TextBox2") as TextBox;

                if (int.Parse(quantityTextBox.Text) > 0)
                    carrier.AccountDetils.Add(int.Parse(AccountConceptIdLabel.Text), int.Parse(textBox.Text));
            }

            return carrier;
        }
    }
}