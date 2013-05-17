using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NLog;
using System.Net;
using System.Text;
using System.IO;
using System.Configuration;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Dal.Carrier;
using System.Collections.Specialized;

namespace bsx.DirLaguna.Admin
{
    public partial class PaymentPaypal : System.Web.UI.Page
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        string StrResponseQuery
        {
            get
            {
                return this.ViewState["_these_argies"].ToString();
            }
            set
            {
                this.ViewState["_these_argies"] = value;
            }
        }

        public string PaymentStatus
        {
            get
            {
                if (string.IsNullOrEmpty(StrResponseQuery))
                    return string.Empty;
                NameValueCollection argies = HttpUtility.ParseQueryString(StrResponseQuery);
                return argies["payment_status"];
            }
        }

        public string UrlPaymentPaypal
        {
            get
            {
                return ConfigurationManager.AppSettings["UrlPaymentPaypal"].ToString(); ;
            }
        }

        public string PrimaryPaypalEmail
        {
            get
            {
                return ConfigurationManager.AppSettings["PrimaryPaypalEmail"].ToString(); ;
            }
        }

        public int Invoice
        {
            get
            {
                if (string.IsNullOrEmpty(StrResponseQuery))
                    return -1;
                NameValueCollection argies = HttpUtility.ParseQueryString(StrResponseQuery);
                if (string.IsNullOrEmpty(argies["invoice"]))
                    return -1;
                return int.Parse(argies["invoice"]);
            }
        }

        public string Txn_Id
        {
            get
            {
                if (string.IsNullOrEmpty(StrResponseQuery))
                    return string.Empty;
                NameValueCollection argies = HttpUtility.ParseQueryString(StrResponseQuery);
                return argies["txn_id"];
            }
        }

        public string Receiver_Email
        {
            get
            {
                if (string.IsNullOrEmpty(StrResponseQuery))
                    return string.Empty;
                NameValueCollection argies = HttpUtility.ParseQueryString(StrResponseQuery);
                return argies["receiver_email"];
            }
        }

        public decimal Payment_Amount
        {
            get
            {
                if (string.IsNullOrEmpty(StrResponseQuery))
                    return 0;
                NameValueCollection argies = HttpUtility.ParseQueryString(StrResponseQuery);
                if (string.IsNullOrEmpty(argies["mc_gross"]))
                    return 0;
                return decimal.Parse(argies["mc_gross"]);
            }
        }

        public string Payment_Currency
        {
            get
            {
                if (string.IsNullOrEmpty(StrResponseQuery))
                    return string.Empty;
                NameValueCollection argies = HttpUtility.ParseQueryString(StrResponseQuery);
                return argies["payment_currency"];
            }
        }

        //process payment


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Logger.Debug("No fue Postaback");
                this.ShowPostVariables();
            }

            //Post back to either sandbox or live
            //string strSandbox = "https://www.sandbox.paypal.com/cgi-bin/webscr";
            //string strLive = "https://www.paypal.com/cgi-bin/webscr";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(UrlPaymentPaypal);

            //Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
            string strRequest = Encoding.ASCII.GetString(param);
            this.StrResponseQuery = strRequest;

            strRequest += "&cmd=_notify-validate";
            req.ContentLength = strRequest.Length;

            //for proxy
            //WebProxy proxy = new WebProxy(new Uri("http://url:port#"));
            //req.Proxy = proxy;

            //Send the request to PayPal and get the response
            StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            streamOut.Write(strRequest);
            streamOut.Close();
            StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
            string strResponse = streamIn.ReadToEnd();
            streamIn.Close();

            Logger.Debug("strResponse -> " + strResponse);
            if (strResponse.Equals("VERIFIED", StringComparison.CurrentCultureIgnoreCase))
            {
                Logger.Debug("Pasa primera comparacion");
                //check the payment_status is Completed
                if (!PaymentStatus.ToLower().Equals("Completed".ToLower(), StringComparison.CurrentCultureIgnoreCase))
                {
                    Logger.Debug("Error al comparar el PaymentStatus");
                    return;
                }

                Logger.Debug("Paso despues comparacion PaymentStatus");
                ContractController controller = new ContractController();

                Logger.Debug("Paso antes de validacion de TransactionId");
                //check that txn_id has not been previously processed
                if (controller.ValidateProccesedTransactionId(this.Txn_Id))
                {
                    Logger.Debug(string.Format("La Transaccion {0} ya ha sido procesada", this.Txn_Id));
                    return;
                }

                Logger.Debug("Paso validacion de TransactionId");
                SimpleContractTransactionCarrier carrier = controller.FetchDataTransaction(this.Invoice);
                carrier.TransactionId = this.Txn_Id;

                if (carrier.ContractId == -1)
                {
                    Logger.Debug(string.Format("No se encontro el contrato {0} ", this.Invoice));
                    return;
                }

                Logger.Debug("Antes de comparar Receiver_Email");
                //check that receiver_email is your Primary PayPal email
                if (!Receiver_Email.ToLower().Equals(PrimaryPaypalEmail.ToLower(), StringComparison.CurrentCultureIgnoreCase))
                {
                    Logger.Debug("Error al comparar el Receiver_Email");
                    return;
                }

                Logger.Debug("Antes de comparar Payment_Amount");
                //check that payment_amount/payment_currency are correct
                if (this.Payment_Amount != carrier.PaymentAmount)
                {
                    Logger.Debug(string.Format("Error al comparar el Payment_Amount -> {0} = {1}", this.Payment_Amount, carrier.PaymentAmount));
                    return;
                }

                //if (this.Payment_Currency != paymentCurrency)
                //    return;

                Logger.Debug("Antes de UpdateContractDataTransaction");

                //process payment
                if (!controller.UpdateContractDataTransaction(carrier.ContractId, carrier.TransactionId))
                {
                    Logger.Debug("controller.Errors.Count " + controller.Errors.Count);
                    foreach (string item in controller.Errors)
                    {
                        Logger.Debug(item);
                    }
                }
                else
                {
                    Logger.Debug("No se generaron errores. Checamos los mensajes");
                    Logger.Debug("controller.Errors.Count " + controller.Errors.Count);
                    foreach (string item in controller.Errors)
                    {
                        Logger.Debug(item);
                    }


                }
                Logger.Debug("Termino ejecucion");
            }
            else if (strResponse == "INVALID")
            {
                //log for manual investigation
                Logger.Debug("Fue INVALID");
            }
            else
            {
                //log response/ipn data for manual investigation
                Logger.Debug("NO Fue INVALID");
            }
            Logger.Debug("Termina todo el proceso");
        }

        private void ShowPostVariables()
        {
            Logger.Debug("---------------------------------------------------------");
            Logger.Debug("Loggin Details {0}", Environment.NewLine);
            foreach (string postKey in this.Request.Form.AllKeys)
            {
                string message = string.Format("Key: {0} , Value {1}", postKey, this.Request.Form.Get(postKey));
                //this.Response.Write(message);
                Logger.Debug(message);
            }
            Logger.Debug("----------------------------------------------------------------------------------------------{0}", Environment.NewLine);
        }

    }
}