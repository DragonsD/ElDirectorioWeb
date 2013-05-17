using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Advertiser.Code;
using bsx.DirLaguna.CommonWeb.Session;

namespace bsx.DirLaguna.Advertiser.Shared
{
    public partial class Base : System.Web.UI.MasterPage
    {
        public string ClassBody
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                    this.BodyItem.Attributes.Add("class", value);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
                this.ShowPreviousMessages();
        }

        public void ShowPreviousMessages()
        {
            IList<string> messages = SessionValues.LastMessages;
            if (messages.Count <= 0)
                return;

            this.MessagePanel.Show(SessionValues.LastMessageType, messages.ToArray());
            messages.Clear();
        }

    }
}