using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Advertiser.Code;
using System.Text;
using System.IO;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb.Session;
using System.Net.Mail;
using System.Configuration;

namespace bsx.DirLaguna.Advertiser
{
    public partial class BannerRequestForm : BasePage
    {
        public List<string> errors
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

        public StringBuilder sbContent
        {
            get
            {
                if (this.ViewState["_sbContent"] == null)
                    return new StringBuilder();
                return (StringBuilder)this.ViewState["_sbContent"];
            }
            set
            {
                this.ViewState["_sbContent"] = value;
            }
        }

        protected override void OnLoad(EventArgs e)
        {

            this.SendButton.Click += new EventHandler(SendButton_Click);
            base.OnLoad(e);
            if (!this.IsPostBack)
            {
                this.BackButton.PostBackUrl = this.ResolveUrl(Navigation.AccountForm);
                this.sbContent = new StringBuilder();
                this.errors = new List<string>();
                this.SetData();
            }
        }

        private string BR { get { return "<br />"; } }

        private void AddContent(string title, string url)
        {
            sbContent.Append(BR);
            sbContent.Append(title);
            sbContent.Append(BR);
            if (!string.IsNullOrEmpty(url))
            {
                sbContent.Append(string.Format("Url = {0}", url));
                sbContent.Append(BR);
                sbContent.Append(BR);
            }
        }

        private bool HasErrorsInControls()
        {
            bool hasErrors = false;
            if (this.SendUploadBannerControl1.Visible && this.SendUploadBannerControl1.Validate() == 0)
            {
                foreach (string item in this.SendUploadBannerControl1.Errors)
                {
                    errors.Add(item);
                }
                hasErrors = true;
            }

            if (this.SendUploadBannerControl2.Visible && this.SendUploadBannerControl2.Validate() == 0)
            {
                foreach (string item in this.SendUploadBannerControl2.Errors)
                {
                    errors.Add(item);
                }
                hasErrors = true;
            }

            if (this.SendUploadBannerControl3.Visible && this.SendUploadBannerControl3.Validate() == 0)
            {
                foreach (string item in this.SendUploadBannerControl3.Errors)
                {
                    errors.Add(item);
                }
                hasErrors = true;
            }

            if (this.SendUploadBannerControl4.Visible && this.SendUploadBannerControl4.Validate() == 0)
            {
                foreach (string item in this.SendUploadBannerControl4.Errors)
                {
                    errors.Add(item);
                }
                hasErrors = true;
            }

            return hasErrors;
        }

        private void GetDataControls(out List<Attachment> attachments)
        {
            attachments = new List<Attachment>();
            if (this.SendUploadBannerControl1.Visible && this.SendUploadBannerControl1.Validate() == 1)
            {
                this.AddContent(this.SendUploadBannerControl1.TitleBanner, this.SendUploadBannerControl1.Url);
                attachments.Add(new Attachment(this.SendUploadBannerControl1.FileUpload.FileContent, string.Format("{0}.png", this.SendUploadBannerControl1.TitleBanner)));
            }

            if (this.SendUploadBannerControl2.Visible && this.SendUploadBannerControl2.Validate() == 1)
            {
                this.AddContent(this.SendUploadBannerControl2.TitleBanner, this.SendUploadBannerControl2.Url);
                attachments.Add(new Attachment(this.SendUploadBannerControl2.FileUpload.FileContent, string.Format("{0}.png", this.SendUploadBannerControl2.TitleBanner)));
            }

            if (this.SendUploadBannerControl3.Visible && this.SendUploadBannerControl3.Validate() == 1)
            {
                this.AddContent(this.SendUploadBannerControl3.TitleBanner, this.SendUploadBannerControl3.Url);
                attachments.Add(new Attachment(this.SendUploadBannerControl3.FileUpload.FileContent, string.Format("{0}.png", this.SendUploadBannerControl3.TitleBanner)));
            }

            if (this.SendUploadBannerControl4.Visible && this.SendUploadBannerControl4.Validate() == 1)
            {
                this.AddContent(this.SendUploadBannerControl4.TitleBanner, this.SendUploadBannerControl4.Url);
                attachments.Add(new Attachment(this.SendUploadBannerControl4.FileUpload.FileContent, string.Format("{0}.png", this.SendUploadBannerControl4.TitleBanner)));
            }
        }

        void SendButton_Click(object sender, EventArgs e)
        {
            this.errors = new List<string>();
            List<Attachment> attachments = new List<Attachment>(); ;

            if (this.HasErrorsInControls())
            {
                this.ShowMessage(this.errors, CommonWeb.Enum.MessageTypes.Success);
                return;
            }

            byte[] content = File.ReadAllBytes(Server.MapPath(Navigation.MessageEmailAdvertiserBanner));

            this.sbContent.AppendLine(UTF8Encoding.UTF8.GetString(content));
            this.sbContent.AppendLine("Contenido:");

            this.GetDataControls(out attachments);
            string strRes = string.Empty;
            string toEmail = bsx.DirLaguna.Advertiser.Properties.Settings.Default.EmailDataBanner;
            string fromEmail = bsx.DirLaguna.Advertiser.Properties.Settings.Default.FromEmailBanner;
            if (EmailSender.SendEmail(toEmail, fromEmail, sbContent.ToString(), "Contenido", attachments, out strRes))
                ShowMessage("El correo se ha enviado con exito.", CommonWeb.Enum.MessageTypes.Success);
            else
                ShowMessage(strRes, CommonWeb.Enum.MessageTypes.Error);

        }

        protected void SetData()
        {
            bool hasControls = false;
            AdvertiserController controller = new AdvertiserController();
            bsx.DirLaguna.Dal.Advertiser adv = controller.FetchById(SessionValues.AdvertiserId);
            if (adv != null)
            {
                int acc = 0;
                acc = adv.FetchTotalFor(Dal.Enum.AccountConceptKeyEnum.Banner1);
                this.SendUploadBannerControl1.Visible = acc > 0;
                if (acc > 0)
                {
                    this.SendUploadBannerControl1.ValidationGroup = this.SendButton.ValidationGroup;
                    this.SendUploadBannerControl1.TitleBanner = "Banner tipo 1";
                    hasControls = true;
                }

                acc = 0;
                acc = adv.FetchTotalFor(Dal.Enum.AccountConceptKeyEnum.Banner2);
                this.SendUploadBannerControl2.Visible = acc > 0;
                if (acc > 0)
                {
                    this.SendUploadBannerControl2.ValidationGroup = this.SendButton.ValidationGroup;
                    this.SendUploadBannerControl2.TitleBanner = "Banner tipo 2";
                    hasControls = true;
                }

                acc = 0;
                acc = adv.FetchTotalFor(Dal.Enum.AccountConceptKeyEnum.Banner3);
                this.SendUploadBannerControl3.Visible = acc > 0;
                if (acc > 0)
                {
                    this.SendUploadBannerControl3.ValidationGroup = this.SendButton.ValidationGroup;
                    this.SendUploadBannerControl3.TitleBanner = "Banner tipo 3";
                    hasControls = true;
                }

                acc = 0;
                acc = adv.FetchTotalFor(Dal.Enum.AccountConceptKeyEnum.Banner4);
                this.SendUploadBannerControl4.Visible = acc > 0;
                if (acc > 0)
                {
                    this.SendUploadBannerControl4.ValidationGroup = this.SendButton.ValidationGroup;
                    this.SendUploadBannerControl4.TitleBanner = "Banner tipo 4";
                    hasControls = true;
                }
            }

            this.NotHasControlsPlaceHolder.Visible = !hasControls;

        }

    }
}