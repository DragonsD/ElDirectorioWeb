using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Advertiser.Code;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.CommonWeb.Session;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb.Base;
using System.Configuration;
using System.Text;

namespace bsx.DirLaguna.Advertiser
{
    public partial class ContractForm : BasePage
    {
        List<string> Errors = new List<string>();

        public int AdvertiserId { get { return SessionValues.AdvertiserId; } }

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

        public Contract Source
        {
            get
            {
                Contract ct = new ContractController().FetchById(this.ContractId);
                return ct;
            }
        }

        public string SuccessUrl
        {
            get
            {
                return string.Format("{0}?{1}={2}",
                    this.ResolveUrl(Navigation.MyAccountForm),
                    QueryKeys.AdvertiserId,
                    this.AdvertiserId);
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

        protected LinkButton PageSaveButton { get { return this.SaveButton; } }

        public void LoadViewFromModel(Contract source) { }

        public bool SaveMethod()
        {
            int newContractId = -1;

            ContractController controllerContract = new ContractController();
            bool bResult = controllerContract.Save(
                                    this.ContractId,
                                    this.AdvertiserId,
                                    SessionValues.PersonalId,
                                    false,
                                    null,
                                    false,
                                    this.AccountDetailControl1.Carrier,
                                    this.AccountDetailControl1.PaymentAccount,
                                    null,
                                    out newContractId);

            this.NewContractId = newContractId;
            List<string> messages = new List<string>();
            if (!bResult)
                this.Errors = controllerContract.Errors;

            return bResult;
        }

        public void FillCatalogues() { }

        public void SetMaxLenght() { }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            string urlBack = string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.MyAccountForm), QueryKeys.AdvertiserId, this.AdvertiserId);
            this.BackLinkButton.PostBackUrl = this.Request.UrlReferrer == null ? urlBack : this.Request.UrlReferrer.ToString();

            //this.InvoiceAndSaveButton.Click += new EventHandler(InvoiceAndSaveButton_Click);
            this.SaveButton.Click += new EventHandler(SaveButton_Click);
            if (!Page.IsPostBack)
            {
                AdvertiserController controller = new AdvertiserController();
                Dal.Advertiser adv = controller.FetchById(this.AdvertiserId);

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

        void SaveButton_Click(object sender, EventArgs e)
        {
            if (!SaveMethod())
            {
                this.ShowMessage(this.Errors, CommonWeb.Enum.MessageTypes.Error);
                return;
            }


            Logger.Debug("Entrando a GetStringPaypal");
            Logger.Debug("newContractId :" + this.NewContractId);
            this.StrPaypal = GetStringPaypal(this.NewContractId);
            Logger.Debug("StrPaypal : " + this.StrPaypal);
            this.Response.Redirect(this.StrPaypal);
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
            sb.Append(string.Format("return={0}&", GetReturnUrl("ContractForm.aspx")));
            sb.Append("rm=0&");
            sb.Append(string.Format("cancel_return={0}&", GetReturnUrl("ContractForm.aspx")));
            sb.Append(string.Format("notify_url={0}&", urlNotityIPN));
            //sb.Append(string.Format("amount={0}&", this.TotalAmount));
            sb.Append("currency_code=MXN");

            //return System.Web.HttpUtility.UrlEncode(sb.ToString(), Encoding.Default);
            return sb.ToString();

        }

        private string GetStringItemsPaypal()
        {
            StringBuilder sb = new StringBuilder();
            int index = 1;
            foreach (GridViewRow item in this.AccountDetailControl1.GridViewConcepts.Rows)
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

    }
}