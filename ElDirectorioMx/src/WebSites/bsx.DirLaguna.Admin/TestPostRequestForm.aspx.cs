using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace bsx.DirLaguna.Admin
{
    public partial class TestPostRequestForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.MakeRequest();
            }
        }

        private void MakeRequest()
        {
            string pathSite = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority;
            string path = "http://localhost:3628/FranchiseeWriter.aspx";
            //string path = "http://71.6.150.179:8079/FranchiseeWriter.aspx";
            //string path = string.Format("{0}{1}", pathSite, this.ResolveUrl("AdvertiserWriter.aspx"));
            //string path = string.Format("{0}{1}", pathSite, this.ResolveUrl("FranchiseeWriter.aspx"));
            WebRequest wr = (HttpWebRequest)WebRequest.Create(path);
            wr.Method = "POST";
            UTF8Encoding encoding = new UTF8Encoding();
            StringBuilder parametros = new StringBuilder();

            List<RequestParam> aux = this.FillParameters();

            int count = 0;
            foreach (var item in aux)
            {
                if (count++ > 0)
                    parametros.Append("&");

                parametros.AppendFormat("{0}={1}", item.Key, item.Value.ToString());
            }

            byte[] byte1 = encoding.GetBytes(parametros.ToString());
            wr.ContentType = "application/x-www-form-urlencoded";
            wr.ContentLength = byte1.Length;

            Stream newStream = wr.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);
            newStream.Close();

            this.Response.Write(System.Text.Encoding.UTF8.GetString(byte1));
        }

        public List<RequestParam> FillParameters()
        {
            List<RequestParam> aux = new List<RequestParam>();

            // franquiciatario
            aux.Add(new RequestParam() { Key = "MunicipioId", Value = 75 });
            aux.Add(new RequestParam() { Key = "Name", Value = "Pacheco" });
            aux.Add(new RequestParam() { Key = "Email", Value = "prjesushector@hotmail.com" });
            aux.Add(new RequestParam() { Key = "Phone", Value = "871 123123" });
            aux.Add(new RequestParam() { Key = "CellPhone", Value = "2343523423" });
            aux.Add(new RequestParam() { Key = "ShareLevelId", Value = 2 });
            aux.Add(new RequestParam() { Key = "Address", Value = "Centro #512 Col. Amp. Los Angeles" });
            aux.Add(new RequestParam() { Key = "FiscalDetail.Rfc", Value = "BTE1005079N9" });
            aux.Add(new RequestParam() { Key = "FiscalDetail.Name", Value = "Motors" });
            aux.Add(new RequestParam() { Key = "Reference", Value = 12345789 });
            aux.Add(new RequestParam() { Key = "FiscalDetail.Street", Value = "Tiro al blanco" });
            aux.Add(new RequestParam() { Key = "FiscalDetail.ExtNumber", Value = "240" });
            aux.Add(new RequestParam() { Key = "FiscalDetail.IntNumber", Value = "A" });
            aux.Add(new RequestParam() { Key = "FiscalDetail.Colony", Value = "Centro" });
            aux.Add(new RequestParam() { Key = "FiscalDetail.Poblacion", Value = "Torreon" });
            aux.Add(new RequestParam() { Key = "FiscalDetail.MunicipioId", Value = 75 });
            aux.Add(new RequestParam() { Key = "FiscalDetail.ZipCode", Value = 27100 });
            aux.Add(new RequestParam() { Key = "FiscalDetail.ContactEmail", Value = "jhpachecordz@gmail.com" });
            aux.Add(new RequestParam() { Key = "ExternalKey", Value = 8 });
            aux.Add(new RequestParam() { Key = "UserName", Value = "Advertiser102" });
            aux.Add(new RequestParam() { Key = "Password", Value = "bisimplex" });

            // anunciante
            //aux.Add(new RequestParam() { Key = "Name", Value = "George's store" });
            //aux.Add(new RequestParam() { Key = "Address", Value = "Tiro al blanco" });
            //aux.Add(new RequestParam() { Key = "Matriz.Colony", Value = "Centro" });
            //aux.Add(new RequestParam() { Key = "Matriz.ZipCode", Value = 27100 });
            //aux.Add(new RequestParam() { Key = "EstadoId", Value = 1 });
            //aux.Add(new RequestParam() { Key = "MunicipioId", Value = 75 });
            //aux.Add(new RequestParam() { Key = "Contact", Value = "George Rodriguez" });
            //aux.Add(new RequestParam() { Key = "Franchisee.ExternalKey", Value = 8 });
            //aux.Add(new RequestParam() { Key = "EsternalKey", Value = 1 });

            return aux;
        }


        public class RequestParam
        {
            public string Key { get; set; }
            public object Value { get; set; }
        }
    }
}