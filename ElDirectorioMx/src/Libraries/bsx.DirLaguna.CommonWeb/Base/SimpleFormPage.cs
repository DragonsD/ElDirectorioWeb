using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Session;

namespace bsx.DirLaguna.CommonWeb.Base
{
    public abstract class SimpleFormPage<T> : FormPage
    {
        public int PersonalId { get { return SessionValues.PersonalId; } }

        public int FranchiseeId { get { return SessionValues.FranchiseeId; } }

        public abstract T Source { get; }

        public abstract string SuccessUrl { get; }

        protected abstract LinkButton PageSaveButton { get; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.PageSaveButton != null)
                this.PageSaveButton.Click += new EventHandler(PageSaveButton_Click);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (!this.IsPostBack && this.Source != null)
                this.LoadViewFromModel(this.Source);
        }

        protected virtual void PageSaveButton_Click(object sender, EventArgs e)
        {
            if (!this.SaveMethod())
            {
                this.ShowMessage(this.Errors, Enum.MessageTypes.Error);
                return;
            }
            this.ShowMessageInPrevious("La operación se ha completado exitosamente", Enum.MessageTypes.Success);
            this.Response.Redirect(this.SuccessUrl);
        }

        public abstract void LoadViewFromModel(T source);

        public abstract bool SaveMethod();
    }
}
