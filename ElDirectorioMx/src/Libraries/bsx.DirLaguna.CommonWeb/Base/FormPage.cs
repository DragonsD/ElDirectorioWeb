using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.CommonWeb.Base
{
    public abstract class FormPage : BasePage
    {
        protected List<string> Errors = new List<string>();

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.FillCatalogues();
            this.SetMaxLenght();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public abstract void FillCatalogues();

        public abstract void SetMaxLenght();
    }
}
