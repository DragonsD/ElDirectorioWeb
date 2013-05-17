using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Enum;

namespace bsx.DirLaguna.Admin.Controls
{
    public partial class WebMessageBox : System.Web.UI.UserControl
    {
        private bool showMessageCalled = false;
        #region Properties
        public bool ShowCloseButton { get; set; }

        #endregion

        #region Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.showMessageCalled)
            {
                this.MessageBoxPanel.Style.Clear();
                this.MessageBoxPanel.Style.Add("display", "none");
            }

            if (this.ShowCloseButton)
            {
                string onClickEvent =
                    string.Format("document.getElementById('{0}').style.display = 'none'", MessageBoxPanel.ClientID);
                this.CloseButtonLink.Attributes.Add("onclick",
                    onClickEvent);
            }
        }
        #endregion

        #region Wrapper methods
        public void ShowErrors(string message)
        {
            Show(MessageTypes.Error, message);
        }

        public void ShowInfo(string message)
        {
            Show(MessageTypes.Notice, message);
        }

        public void ShowSuccess(string message)
        {
            Show(MessageTypes.Success, message);
        }

        #endregion

        #region Show control

        public void Show(MessageTypes messageType, string message)
        {
            this.Show(messageType, new string[] { message });
        }

        public void Show(MessageTypes messageType, string[] messages)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("<ul class='{0}'>", messageType.ToString());
            foreach (string item in messages)
                sb.AppendFormat("<li>{0}</li>", item);
            sb.Append("</ul>");
            this.CloseButtonLink.Visible = ShowCloseButton;
            this.MessageLiteral.Text = sb.ToString();
            this.Visible = true;
            this.MessageBoxPanel.Style.Clear();
            this.MessageBoxPanel.Style.Add("display", "block");
            this.showMessageCalled = true;
        }
        #endregion
 
    }
}