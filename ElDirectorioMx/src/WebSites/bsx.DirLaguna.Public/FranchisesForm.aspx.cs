using System;
using System.Configuration;
using System.Net.Configuration;
using System.Net.Mail;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Public.Code;
using NLog;
using bsx.DirLaguna.Dal;
using System.Web.Configuration;

namespace bsx.DirLaguna.Public
{
    public partial class FranchisesForm : PublicBasePage
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.SendLinkButton.Click += new EventHandler(SendLinkButton_Click);

            GeneralSetUpController con = new GeneralSetUpController();
            GeneralSetUp data = con.FetchFirst();
            string url = WebConfigurationManager.AppSettings["UrlSiteAdmin"];
            this.XLiteral.Text = data.FixPageMarkup(url, data.FranchiseeMarkup);
        }

        void SendLinkButton_Click(object sender, EventArgs e)
        {
            //if (!SendEmail(Properties.Settings.Default.Destinataries, this.EmailTextBox.Text, this.MessageTextBox.Text, "Contacto para franquiciar"))
            //{
            //    this.Response.Redirect(string.Format("{0}?success=0&name={1}", this.ResolveUrl(Navigation.MessageSentForm), this.NameTextBox.Text));
            //}

            //this.Response.Redirect(string.Format("{0}?success=1&name={1}", this.ResolveUrl(Navigation.MessageSentForm), this.NameTextBox.Text));
        }

        public static bool SendEmail(string toEmails, string fromEmail, string mailBody, string subject)
        {
            try
            {
                SmtpSection smtpSec = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                bool enableSsl = true;
                //Boolean.TryParse(ConfigurationManager.AppSettings["SmtpEnableSsl"], out enableSsl);
                SmtpClient smtp = new SmtpClient();
                smtp.EnableSsl = true;

                smtp.Host = smtpSec.Network.Host;
                smtp.Port = smtpSec.Network.Port;
                smtp.Credentials = new System.Net.NetworkCredential(smtpSec.Network.UserName, smtpSec.Network.Password);

                Logger.Info(smtpSec.Network.UserName);
                Logger.Info(smtpSec.Network.Password);
                Logger.Info(smtp.EnableSsl);

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                MailAddress from = new MailAddress(fromEmail);

                MailMessage message = new MailMessage();
                message.From = new MailAddress(fromEmail);
                message.Body = mailBody;
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.ReplyTo = new MailAddress(fromEmail);

                string email = toEmails;

                string[] toAddress = toEmails.Split(',');
                foreach (var item in toAddress)
                {
                    message.To.Add(new MailAddress(item));
                }

                smtp.Send(message);
            }
            catch (Exception ex)
            {
                Logger.Error("No se pudo enviar el correo");
                Logger.Error(ex.Message);
                return false;
            }
            return true;
        }
    }
}