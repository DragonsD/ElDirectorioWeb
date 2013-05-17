using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using bsx.DirLaguna.Dal;
using NLog;

namespace bsx.DirLaguna.Admin.Code
{
    public class ProspectationHelper
    {
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void SendToProspectacion(int contractId, out List<string> messages)
        {
            Logger.Info(">>>> Tratando de enviar una peticion a prospectacion");

            messages = new List<string>();
            Contract ct = new ContractController().FetchById(contractId);

            if (!ct.Advertiser.ExternalKey.HasValue && !ct.Advertiser.Franchisee.ExternalKey.HasValue)
            {
                Logger.Error("El anunciante no tiene llave externa  o el anunciante no tiene información completa");
                return;
            }

            StringBuilder parametros = new StringBuilder();
            List<RequestParam> aux = this.FillParameters(ct);

            int count = 0;
            foreach (var item in aux)
            {
                if (item.Value == null)
                    continue;

                if (count++ > 0)
                    parametros.Append("&");

                parametros.AppendFormat("{0}={1}", item.Key, item.Value.ToString());
            }

            string sURL;
            sURL = Properties.Settings.Default.AccountingSystemUrl + "?" + parametros.ToString();
            Logger.Info(">> PROS: {0}", sURL);
            WebRequest wrGETURL;

            wrGETURL = WebRequest.Create(sURL);
            Stream objStream;
            StreamReader objReader = null;

            try
            {
                objStream = wrGETURL.GetResponse().GetResponseStream();
                objReader = new StreamReader(objStream);
            }
            catch (System.Exception ex)
            {
                Logger.ErrorException(ex.Message, ex);
            }

            string sLine = "";
            int i = 0;

            while (sLine != null)
            {
                i++;
                sLine = objReader.ReadLine();
                if (sLine != null)
                {
                    messages.Add(sLine);
                    Logger.Info(sLine);
                }
            }

            if ((from x in messages where x.ToLower().Contains("error") select x).Count() > 0 || messages.Count == 0)
                this.SendErrorMessage();
        }

        public void SendErrorMessage()
        {
            Logger.Error("Ha ocurrido un error");
        }

        public List<RequestParam> FillParameters(Contract ct)
        {
            List<RequestParam> aux = new List<RequestParam>();

            // contrato
            aux.Add(new RequestParam() { Key = "ve_id", Value = ct.ContractId });
            aux.Add(new RequestParam() { Key = "cl_id", Value = ct.Advertiser.ExternalKey });
            aux.Add(new RequestParam() { Key = "ft_id", Value = ct.Advertiser.Franchisee.ExternalKey });
            aux.Add(new RequestParam() { Key = "ve_desc", Value = ct.PurchaseDescription });
            aux.Add(new RequestParam() { Key = "ve_fecha", Value = ct.ContractDate });
            aux.Add(new RequestParam() { Key = "ve_monto", Value = ct.PaymentAmount.HasValue ? ct.PaymentAmount : 0 });
            aux.Add(new RequestParam() { Key = "ve_tipo", Value = "F" });
            aux.Add(new RequestParam() { Key = "isPayed", Value = ct.IsPaid ? 1 : 0 });

            aux.Add(new RequestParam() { Key = "needInvoice", Value = ct.Advertiser.FiscalDetail != null ? 1 : 0 });
            if (ct.Advertiser.FiscalDetail != null)
            {
                aux.Add(new RequestParam() { Key = "ds_calle", Value = ct.Advertiser.FiscalDetail.Street });
                aux.Add(new RequestParam() { Key = "ds_extnum", Value = ct.Advertiser.FiscalDetail.ExteriorNumber });
                //if (!string.IsNullOrEmpty(ct.Advertiser.FiscalDetail.InteriorNumber))
                aux.Add(new RequestParam() { Key = "ds_intnum", Value = ct.Advertiser.FiscalDetail.InteriorNumber });
                aux.Add(new RequestParam() { Key = "ds_colonia", Value = ct.Advertiser.FiscalDetail.Colony });
                aux.Add(new RequestParam() { Key = "ds_ciudad", Value = ct.Advertiser.FiscalDetail.Municipio.Name });
                aux.Add(new RequestParam() { Key = "ds_estado", Value = ct.Advertiser.FiscalDetail.Estado.Name });
                aux.Add(new RequestParam() { Key = "ds_cp", Value = ct.Advertiser.FiscalDetail.ZipCode });
                aux.Add(new RequestParam() { Key = "ds_rfc", Value = ct.Advertiser.FiscalDetail.RFC });
                aux.Add(new RequestParam() { Key = "ds_razonsocial", Value = ct.Advertiser.FiscalDetail.Name });
            }

            if (ct.PromiseDate.HasValue)
                aux.Add(new RequestParam() { Key = "PromiseDate", Value = ct.PromiseDate.Value });

            return aux;
        }

        public class RequestParam
        {
            public string Key { get; set; }
            public object Value { get; set; }
        }
    }
}