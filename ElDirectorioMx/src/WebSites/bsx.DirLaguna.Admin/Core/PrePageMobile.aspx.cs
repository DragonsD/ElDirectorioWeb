using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Admin.Code;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class PrePageMobile : SimpleFormPage<GeneralSetUp>
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override GeneralSetUp Source
        {
            get
            {
                GeneralSetUpController con = new GeneralSetUpController();
                return con.FetchFirst();
            }
        }

        public string PreContent
        {
            get
            {
                return this.XCKEditorControl.Text;
            }
            set
            {
                this.XCKEditorControl.Text = value;
            }
        }

        public override string SuccessUrl
        {
            get { return Navigation.PrePageiOs; }
        }

        protected override LinkButton PageSaveButton
        {
            get
            {
                return this.SaveButton;
            }
        }

        public override void LoadViewFromModel(GeneralSetUp source)
        {
            this.PreContent = source.FrontPageMarkupIphone;
        }

        public override bool SaveMethod()
        {
            GeneralSetUpController con = new GeneralSetUpController();
            return con.SaveFrontPageMarkupIphone(this.PreContent);
        }

        public override void FillCatalogues()
        {

        }

        public override void SetMaxLenght()
        {

        }

    }
}