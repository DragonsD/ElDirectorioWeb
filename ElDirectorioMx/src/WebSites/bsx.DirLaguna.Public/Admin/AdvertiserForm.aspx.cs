using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Public.Code;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Public.Admin
{
    public partial class AdvertiserForm : SimpleFormPage<Advertiser>
    {
        public override Advertiser Source
        {
            get { throw new NotImplementedException(); }
        }

        public override string SuccessUrl
        {
            get { throw new NotImplementedException(); }
        }

        protected override LinkButton PageSaveButton
        {
            get { throw new NotImplementedException(); }
        }

        public override void LoadViewFromModel(Advertiser source)
        {
            throw new NotImplementedException();
        }

        public override bool SaveMethod()
        {
            throw new NotImplementedException();
        }

        public override void FillCatalogues()
        {
            throw new NotImplementedException();
        }

        public override void SetMaxLenght()
        {
            throw new NotImplementedException();
        }
    }
}