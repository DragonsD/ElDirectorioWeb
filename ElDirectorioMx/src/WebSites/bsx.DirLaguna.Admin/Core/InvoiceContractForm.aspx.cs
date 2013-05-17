using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb.Session;
using bsx.DirLaguna.CommonWeb.Base;
using System.Configuration;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class InvoiceContractForm : SimpleFormPage<Contract>
    {
        public int ContractId
        {
            get
            {
                if (this.Request.QueryString[QueryKeys.ContractId] != null)
                    return int.Parse(this.Request.QueryString[QueryKeys.ContractId].ToString());
                return -1;
            }
        }

        public int AdvertiserId
        {
            get
            {
                if (this.Request.QueryString[QueryKeys.AdvertiserId] != null)
                    return int.Parse(this.Request.QueryString[QueryKeys.AdvertiserId].ToString());
                return -1;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DetailObjectDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(DetailObjectDataSource_Selecting);
            this.InvoiceButton.Click += new EventHandler(InvoiceButton_Click);
            if (!Page.IsPostBack)
            {
                this.BackButton.PostBackUrl = this.ResolveUrl(Navigation.FranchiseeDisplay);
                AdvertiserController controller = new AdvertiserController();
                Advertiser adv = controller.FetchById(this.AdvertiserId);
                if (adv != null)
                {
                    this.FiscalDetailReadOnlyControl.FiscalDetailId = adv.FiscalDetailId;
                    this.FiscalDetailReadOnlyControl.LoadData();
                }
            }
        }

        void InvoiceButton_Click(object sender, EventArgs e)
        {
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
                contractController.UpdateInvoiceByContract(this.ContractId, invoiceId, this.PersonalId, folioSerie);
                this.ShowMessageInPrevious("La factura se genero correctamente", CommonWeb.Enum.MessageTypes.Error);
                this.Response.Redirect(this.ResolveUrl(this.SuccessUrl));
            }
        }


        public override Contract Source
        {
            get 
            {
                ContractController contractController = new ContractController();
                return contractController.FetchById(this.ContractId);                
            }
        }

        public override string SuccessUrl
        {
            get { return this.ResolveUrl(Navigation.FranchiseeDisplay); }
        }

        protected override LinkButton PageSaveButton
        {
            get { return null; }
        }

        public override void LoadViewFromModel(Contract source)
        {

        }

        public override bool SaveMethod()
        {
            return true;
        }

        public override void FillCatalogues()
        {
            
        }

        public override void SetMaxLenght()
        {
            
        }

        void DetailObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["contractId"] = this.ContractId;
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

            carrier.PaymentMethod = "Tarjeta de Crédito";
            carrier.PaymentCondition = "Pago en una sola exhibicion";

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
            if (!string.IsNullOrEmpty(adv.DV))
            {
                string notes = string.Format("Cuenta a depositar:\n{0}\n Nuestra Cuenta es:\n {1}", adv.BankKey(bankAccount), notesConfig);

                carrier.NotesClient = notes;
            }
            return carrier;
        }

        private GorilaService.ConceptCarrier[] FillConcepts()
        {
            AccountDetailController controller = new AccountDetailController();
            AccountConceptController controllerConcept = new AccountConceptController();
            List<AccountDetail> detailList = controller.FetchAllByContractId(this.ContractId);

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

    }
}