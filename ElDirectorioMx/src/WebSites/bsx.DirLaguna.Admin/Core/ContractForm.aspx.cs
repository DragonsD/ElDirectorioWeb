using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.CommonWeb.Session;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class ContractForm : SimpleFormPage<Contract>
    {
        //public int PersonalId { get { return SessionValues.PersonalId; } }

        public int AdvertiserId
        {
            get
            {
                if (this.Request.QueryString[QueryKeys.AdvertiserId] != null)
                    return int.Parse(this.Request.QueryString[QueryKeys.AdvertiserId].ToString());
                return -1;
            }

        }

        public int ContractId
        {
            get
            {
                if (this.Request.QueryString[QueryKeys.ContractId] != null)
                    return int.Parse(this.Request.QueryString[QueryKeys.ContractId].ToString());
                return -1;
            }

        }

        public int NewContractId
        {
            get
            {
                if (this.ViewState["_newContractId"] == null)
                    return -1;
                return int.Parse(this.ViewState["_newContractId"].ToString());
            }
            set { this.ViewState["_newContractId"] = value; }
        }

        public bool IsPaid
        {
            get { return this.IsPaidCheckBox.Checked; }
            set { this.IsPaidCheckBox.Checked = value; }
        }

        public int? InvoiceFolio
        {
            get
            {
                if (string.IsNullOrEmpty(this.InvoiceTextBox.Text))
                    return null;
                return int.Parse(this.InvoiceTextBox.Text);
            }
            set { this.InvoiceTextBox.Text = value != null ? value.ToString() : string.Empty; }
        }

        public override Contract Source
        {
            get
            {
                Contract ct = new ContractController().FetchById(this.ContractId);
                return ct;
            }
        }

        public override string SuccessUrl
        {
            get
            {
                return string.Format("{0}?{1}={2}",
                    this.ResolveUrl(Navigation.ContractDisplay),
                    QueryKeys.AdvertiserId,
                    this.AdvertiserId);
            }
        }

        protected override LinkButton PageSaveButton { get { return this.SaveButton; } }

        public override void LoadViewFromModel(Contract source)
        {
            this.IsPaid = source.IsPaid;
            this.ActiveCheckBox.Checked = source.IsActive;
            if (source.PromiseDate.HasValue)
                this.CompromiseDate.Text = source.PromiseDate.Value.ToShortDateString();
            if (!string.IsNullOrEmpty(source.Folio))
                this.InvoiceTextBox.Text = source.Folio;

            this.InvoiceFolio = source.InvoiceId;
        }

        public override bool SaveMethod()
        {
            int newContractId = -1;

            DateTime? compromiseDate = null;
            if (!string.IsNullOrEmpty(this.CompromiseDate.Text))
                compromiseDate = DateTime.Parse(this.CompromiseDate.Text);

            ContractController controllerContract = new ContractController();
            bool bResult = controllerContract.Save(
                                    this.ContractId,
                                    this.AdvertiserId,
                                    this.PersonalId,
                                    this.IsPaid,
                                    compromiseDate,
                                    this.ActiveCheckBox.Checked,
                                    this.AccountDetailControl1.Carrier,
                                    this.AccountDetailControl1.PaymentAccount,
                                    this.InvoiceTextBox.Text,
                                    out newContractId);

            this.NewContractId = newContractId;
            List<string> messages = new List<string>();
            if (!bResult)
                this.Errors = controllerContract.Errors;
            else
            {
                ProspectationHelper prospectation = new ProspectationHelper();
                prospectation.SendToProspectacion(this.NewContractId, out messages);
            }                

            return bResult;
        }

        public override void FillCatalogues() { }

        public override void SetMaxLenght() { }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            string urlBack = string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.ContractDisplay), QueryKeys.AdvertiserId, this.AdvertiserId);
            this.BackLinkButton.PostBackUrl = this.Request.UrlReferrer == null ? urlBack : this.Request.UrlReferrer.ToString();

            //this.InvoiceAndSaveButton.Click += new EventHandler(InvoiceAndSaveButton_Click);
            if (!Page.IsPostBack)
            {
                this.IsPrimaryPlaceHolder.Visible = SessionValues.IsPrimary;
                AdvertiserController controller = new AdvertiserController();
                Advertiser adv = controller.FetchById(this.AdvertiserId);

                if (adv == null)
                {
                    this.Response.Redirect(urlBack);
                    return;
                }
                this.AdvertiserNameLabel.Text = adv.Name;
                //if (this.Source != null)
                //    this.AccountDetailControl1.AccountDetailId = this.Source.AccountDetailId;
            }
        }

        private GorilaService.CustomerCarrier FillCarrier()
        {
            AdvertiserController controller = new AdvertiserController();
            Advertiser adv = controller.FetchById(this.AdvertiserId);
            if (adv == null)
                return new GorilaService.CustomerCarrier();

            GorilaService.CustomerCarrier carrier = new GorilaService.CustomerCarrier();
            carrier.InvoiceId = -1;
            carrier.CustomerRFC = adv.FiscalDetail.RFC;
            carrier.FechaDocumento = DateTime.Now;
            carrier.TotalInvoice = 0;
            carrier.TotalImpuestos = 0;
            carrier.SocialReason = adv.Name;
            carrier.Email = adv.FiscalDetail.ContactEmail;

            carrier.PaymentMethod = "Tarjeta de Credito";
            carrier.PaymentCondition = "Pago en una sola exhibicion";
            carrier.NotesClient = "";

            carrier.ZipCode = adv.FiscalDetail.ZipCode;
            carrier.Street = adv.FiscalDetail.Street;
            carrier.Poblacion = adv.FiscalDetail.Poblacion;
            carrier.MunicipioName = new MunicipioController().FetchById(adv.FiscalDetail.MunicipioId).Name;
            carrier.MunicipioId = adv.FiscalDetail.MunicipioId;

            carrier.EstadoName = new EstadoController().FetchById(adv.FiscalDetail.EstadoId).Name;
            carrier.EstadoId = adv.FiscalDetail.EstadoId;
            carrier.ExteriorNumber = adv.FiscalDetail.ExteriorNumber;
            carrier.InteriorNumber = adv.FiscalDetail.InteriorNumber;
            carrier.Colony = adv.FiscalDetail.Colony;

            string[] names = carrier.SocialReason.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            carrier.FirstName = names.Length > 0 ? names[0] : string.Empty;
            carrier.MotherName = names.Length > 1 ? names[1] : string.Empty;
            carrier.LastName = names.Length > 2 ? names[2] : string.Empty;

            carrier.Version = "3.2";
            carrier.OfficeId = adv.Franchisee.GorilaOfficeId;
            carrier.Moneda = "MXN";
            carrier.TipoCambio = 1;
            carrier.CurrencyName = "Pesos";

            string bankAccount = bsx.DirLaguna.Admin.Properties.Settings.Default.BankAccount;
            string notesConfig = bsx.DirLaguna.Admin.Properties.Settings.Default.InvoiceNotes;
            string notes = string.Format("Cuenta a depositar:\n{0}\n Nuestra Cuenta es:\n {1}", adv.BankKey(bankAccount), notesConfig);
            carrier.NotesClient = notes;
            return carrier;
        }

        private GorilaService.ConceptCarrier[] FillConcepts()
        {
            AccountDetailController controller = new AccountDetailController();
            AccountConceptController controllerConcept = new AccountConceptController();
            List<AccountDetail> detailList = controller.FetchAllByContractId(this.NewContractId);

            List<GorilaService.ConceptCarrier> list = new List<GorilaService.ConceptCarrier>();

            foreach (var item in detailList)
            {
                AccountConcept concept = controllerConcept.FetchById(item.AccountConceptId);
                if (concept == null)
                    continue;

                var aux = new GorilaService.ConceptCarrier();

                aux.Id = (int)concept.GorilaId;
                aux.Quantity = item.Quantity;
                aux.Price = -1;
                aux.Description = string.Empty;
                list.Add(aux);

            }

            return list.ToArray();
        }

        void InvoiceAndSaveButton_Click(object sender, EventArgs e)
        {
            if (!SaveMethod())
            {
                this.ShowMessage(this.Errors, CommonWeb.Enum.MessageTypes.Error);
                return;
            }
            var carrier = this.FillCarrier();
            var list = this.FillConcepts();

            FranchiseeController controller = new FranchiseeController();
            Franchisee fran = controller.FetchById(this.FranchiseeId);
            if (fran == null)
            {
                this.ShowMessage("No se encontro al franquiciatario.", CommonWeb.Enum.MessageTypes.Notice);
                return;
            }
            GorilaService.GorilaService servicio = new GorilaService.GorilaService();
            string[] errors = new string[10];

            if (servicio.SignupCustomer(fran.Rfc, fran.GorilaKey, carrier, out errors) <= 0)
            {
                foreach (string item in errors)
                {
                    Logger.Info(item);
                }
                this.ShowMessage(errors, CommonWeb.Enum.MessageTypes.Error);
                return;
            }

            string folioSerie = string.Empty;

            int invoiceId = servicio.InvoiceTo(fran.Rfc, fran.GorilaKey, carrier, list, out errors, out folioSerie);
            if (invoiceId < 0)
            {
                foreach (string item in errors)
                {
                    Logger.Info(item);
                }
                this.ShowMessage(errors, CommonWeb.Enum.MessageTypes.Error);
            }
            else
            {
                ContractController contractController = new ContractController();
                contractController.UpdateInvoiceByContract(this.NewContractId, invoiceId, this.PersonalId, folioSerie);
                this.ShowMessageInPrevious("La factura se genero correctamente", CommonWeb.Enum.MessageTypes.Error);
                this.Response.Redirect(this.ResolveUrl(this.SuccessUrl));
            }
        }
    }
}
