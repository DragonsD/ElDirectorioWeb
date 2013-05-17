using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Admin.Code;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class DvUpdaterForm : SimpleFormPage<Advertiser>
    {
        public int AdvertiserId
        {
            get
            {
                if (this.Request.QueryString[QueryKeys.AdvertiserId] != null)
                    return int.Parse(this.Request.QueryString[QueryKeys.AdvertiserId]);
                return -1;
            }
        }

        public string DV
        {
            get
            {
                return this.DvTextBox.Text;
            }
            set
            {
                this.DvTextBox.Text = value;
            }

        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.BackButton.PostBackUrl = this.ResolveUrl(Navigation.FranchiseeDisplay);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.IsPostBack)
            {

            }
        }

        public override Advertiser Source
        {
            get { return new AdvertiserController().FetchById(this.AdvertiserId); }
        }

        public override string SuccessUrl
        {
            get { return this.ResolveUrl(Navigation.FranchiseeDisplay); }
        }

        protected override LinkButton PageSaveButton
        {
            get { return this.SaveButton; }
        }

        public override void LoadViewFromModel(Advertiser source)
        {
            this.DV = !string.IsNullOrEmpty(source.DV) ? source.DV : string.Empty; 
        }

        public override bool SaveMethod()
        {
            AdvertiserController controller = new AdvertiserController();

            if (!controller.UpdateDV(this.AdvertiserId, this.DV, this.PersonalId))
            {
                this.Errors.AddRange(controller.Errors);
                return false;
            }

            return true;
        }

        public override void FillCatalogues()
        {

        }

        public override void SetMaxLenght()
        {
            this.DvTextBox.MaxLength = Advertiser.Columns.DVColumn.MaxLength;

        }
    }
}