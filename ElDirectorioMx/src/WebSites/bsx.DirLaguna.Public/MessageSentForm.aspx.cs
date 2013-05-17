using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;

namespace bsx.DirLaguna.Public
{
    public partial class MessageSentForm : PublicBasePage
    {
        public string CustomerName
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString["name"]))
                    return this.Request.QueryString["name"];
                return "no recibido";
            }
        }

        public int CurrentView
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString["success"]))
                    return int.Parse(this.Request.QueryString["success"]);
                return 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ResultMultiView.ActiveViewIndex = this.CurrentView;
                this.nameLiteral.Text = this.CustomerName;
                this.Literal1.Text = this.CustomerName;

                this.Title = this.CurrentView == 0 ? "Ha ocurrido un error" : "Hemos enviado tu correo";
                this.TitleLabel.Text = this.Title;
            }
        }
    }
}