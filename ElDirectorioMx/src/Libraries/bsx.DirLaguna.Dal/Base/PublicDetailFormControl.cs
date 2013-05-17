using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.CommonWeb.Base
{
    public abstract class PublicDetailFormControl<T> : System.Web.UI.UserControl
    {
        public abstract T Source { get; }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (!this.IsPostBack && this.Source != null)
                this.LoadViewFromModel(this.Source);
        }

        public abstract void LoadViewFromModel(T source);

    }
}
