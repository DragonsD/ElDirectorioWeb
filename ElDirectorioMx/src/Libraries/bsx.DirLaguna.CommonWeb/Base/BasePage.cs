using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bsx.DirLaguna.CommonWeb.Enum;
using System.Web.UI;
using bsx.DirLaguna.CommonWeb.Session;

namespace bsx.DirLaguna.CommonWeb.Base
{
    public class BasePage : PageTools
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (SessionValues.FranchiseeId < 0 || SessionValues.PersonalId < 0 || string.IsNullOrEmpty(SessionValues.UserName))
                this.Response.Redirect(this.ResolveUrl("~/Logout.aspx"));
        }

        #region Metdoso para Mensajes

        public void ShowMessage(IList<string> messages, MessageTypes messageType)
        {
            UserControl messageControl =
               PageHelpers.FindControl<UserControl>(this.Controls, "MessagePanel");

            if (messageControl == null)
                return;

            var method = messageControl.GetType().GetMethod("Show", new Type[] { typeof(MessageTypes), typeof(string[]) });
            method.Invoke(messageControl, new object[] { messageType, messages.ToArray() });
        }

        public void ShowMessage(string message, MessageTypes messageType)
        {
            this.ShowMessage(new List<string>() { message }, messageType);
        }

        public void ShowMessageInPrevious(string message, MessageTypes messageType)
        {
            this.ShowMessageInPrevious(new List<string>() { message }, messageType);
        }

        public void ShowMessageInPrevious(IList<string> messages, MessageTypes messageType)
        {
            SessionValues.LastMessages = messages;
            SessionValues.LastMessageType = messageType;
        }

        #endregion
    }
}
