using System;
using NLog;

namespace bsx.DirLaguna.Admin.Code
{
    public class WriterBase : System.Web.UI.Page
    {
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void FlushOnResponse()
        {
            this.Response.Write("----------------------------------------------------------------------------------------------");
            this.Response.Write("Loggin Details {0}");
            this.Response.Write("<br/>");

            foreach (string key in this.Request.Form.AllKeys)
            {
                string message = string.Format("Key: {0} , Value {1}", key, this.Request.Form.Get(key));
                //this.Response.Write(message);
                this.Response.Write(message);
                this.Response.Write("<br/>");
            }
            this.Response.Write("----------------------------------------------------------------------------------------------");
            this.Response.Write("<br/>");
        }

        public void FlushOnLog()
        {
            Logger.Debug("----------------------------------------------------------------------------------------------");
            Logger.Debug("Loggin Details {0}", Environment.NewLine);
            foreach (string key in this.Request.Form.AllKeys)
            {
                string message = string.Format("Key: {0} , Value {1}", key, this.Request.Form.Get(key));
                Logger.Debug(message);
            }
            Logger.Debug("{0}----------------------------------------------------------------------------------------------{0}", Environment.NewLine);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            

            if (!this.IsPostBack)
            {
                Logger.Debug("Peticion recibida");
                this.FlushOnLog();
                this.FlushOnResponse();
            }
        }

        protected void ReturnResult(bool success)
        {
            this.Response.Write(string.Format("Result={0}", success));
            this.Response.ContentType = "text/html";
            this.Response.End();
        }
    }
}