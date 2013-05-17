using System;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.CommonWeb.Session;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class PrintInvoiceForm : BasePage
    {
        public int InvoiceId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.InvoiceId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.InvoiceId]);
                return -1;
            }
        }

        public bool IsPdf
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.IsPdf]))
                    return bool.Parse(this.Request.QueryString[QueryKeys.IsPdf]);
                return true;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var franchisee = new FranchiseeController().FetchById(SessionValues.FranchiseeId);

            if (!this.IsPostBack && this.InvoiceId > 0 && franchisee != null)
            {
                if (!franchisee.IsPrimary)
                    return;

                GorilaService.GorilaService service = new GorilaService.GorilaService();
                if (this.IsPdf)
                {
                    var invoice = service.FetchInvoicePdf(franchisee.Rfc, franchisee.GorilaKey, this.InvoiceId, this.Request.UserHostAddress);
                    this.DownloadFile(invoice.Content, invoice.FileName);
                }
                else
                {
                    var xml = service.FetchInvoiceXml(franchisee.Rfc, franchisee.GorilaKey, this.InvoiceId, this.Request.UserHostAddress);
                    this.DownloadXmlFile(xml.Content, xml.FileName);
                }

            }
        }

        /// <summary>
        /// Descarga un archivo a partir de un stream de memoria
        /// </summary>
        /// <param name="fileContent">byte[] con el conteido del archivo a descargar</param>
        /// <param name="fileName">nombre del archivo a descargar</param>
        protected void DownloadFile(byte[] fileContent, string fileName)
        {
            this.Response.AddHeader("content-disposition", string.Format("attachment; filename=\"{0}.pdf\"", fileName));
            this.Response.AddHeader("content-length", fileContent.Length.ToString());
            this.Response.ContentType = "application/pdf";

            this.Response.BinaryWrite(fileContent);
            this.Response.End();
        }

        /// <summary>
        /// Descarga un archivo a partir de un stream de memoria
        /// </summary>
        /// <param name="fileContent">byte[] con el conteido del archivo a descargar</param>
        /// <param name="fileName">nombre del archivo a descargar</param>
        protected void DownloadXmlFile(byte[] fileContent, string fileName)
        {
            this.Response.AddHeader("content-disposition", string.Format("attachment; filename=\"{0}.xml\"", fileName));
            this.Response.AddHeader("content-length", fileContent.Length.ToString());
            this.Response.ContentType = "text/xml";

            this.Response.BinaryWrite(fileContent);
            this.Response.End();
        }
    }
}