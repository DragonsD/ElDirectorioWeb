using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web.Configuration;

namespace bsx.DirLaguna.Admin
{
    public partial class Rememberme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.EmailPasswordButton.Click += new EventHandler(EmailPasswordButton_Click);
            this.EmailPasswordButton.Click+=new EventHandler(EmailPasswordButton_Click);
            if (!IsPostBack)
            {
                Msg.Text = "Por favor proporciona el Nombre de Usuario.";
            }
        }

        public void EmailPasswordButton_Click(object sender, EventArgs args)
        {
            // Note: Returning a password in clear text using e-mail is not recommended for
            // sites that require a high level of security.

            MembershipUser user = Membership.GetUser(UsernameTextBox.Text, false);

            if (user == null)
                Msg.Text = "El usuario " + Server.HtmlEncode(UsernameTextBox.Text) + " no Fue Encontrado. Checa el valor y vuelvelo a proporcionar.";
            else
            {
                try
                {
                    MembershipUser u = Membership.GetUser(UsernameTextBox.Text);
                    string password = u.GetPassword();
                    if (EmailPassword(u.Email, password))
                        Msg.Text = "Tu contraseña se ha enviado a tu email.";
                }
                catch (MembershipPasswordException e)
                {
                    Msg.Text = "La respuesta a la pregunta secreta es incorrecta. Valida el valor y trata nuevamente.";
                }
                catch (System.Configuration.Provider.ProviderException e)
                {
                    Msg.Text = "Ha ocurrido un error al extraer la contraseña. Por favor checa los valores e intenta nuevamente.";
                }

            }
        }


        private bool EmailPassword(string email, string password)
        {
            try
            {
                Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
                MailSettingsSectionGroup settings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

                MailMessage Message = new MailMessage(settings.Smtp.From, email);
                Message.Subject = "Contraseña";
                Message.Body = "Tu contraseña es: " + Server.HtmlEncode(password);

                SmtpClient SmtpMail = new SmtpClient(settings.Smtp.Network.Host, settings.Smtp.Network.Port);
                bool enableSsl = false;
                Boolean.TryParse(ConfigurationManager.AppSettings["SmtpEnableSsl"], out enableSsl);
                SmtpMail.EnableSsl = enableSsl;

                SmtpMail.Send(Message);
                return true;
            }
            catch
            {
                Msg.Text = "Error al enviar el correo. Por favor intenta otra vez.";
                return false;
            }
        }
    }
}