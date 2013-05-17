using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Advertiser.Code;
using bsx.DirLaguna.CommonWeb.Session;

namespace bsx.DirLaguna.Advertiser
{
    public partial class CouponSetForm : SimpleFormPage<CouponSet>
    {
        public int AdvertiserId
        {
            get
            {
                return SessionValues.AdvertiserId;
            }
        }

        public int CouponSetId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.CouponSetId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.CouponSetId]);
                return -1;
            }
        }

        public override CouponSet Source
        {
            get
            {
                CouponSetController controller = new CouponSetController();
                return controller.FetchById(this.CouponSetId);
            }
        }

        public override string SuccessUrl
        {
            get { return this.ResolveUrl(Navigation.CouponSetDisplay); }
        }

        protected override LinkButton PageSaveButton
        {
            get { return this.SaveButton; }
        }

        public override void LoadViewFromModel(CouponSet source)
        {
            this.NameTextBox.Text = source.Name;
            this.DescriptionTextBox.Text = source.Description;
        }

        public override bool SaveMethod()
        {
            CouponSetController controller = new CouponSetController();
            return controller.Save(SessionValues.FranchiseeId, this.AdvertiserId, this.CouponSetId, this.NameTextBox.Text, this.DescriptionTextBox.Text, SessionValues.PersonalId);
        }

        public override void FillCatalogues()
        {

        }

        public override void SetMaxLenght()
        {
            this.NameTextBox.MaxLength = CouponSet.Columns.NameColumn.MaxLength;
            this.DescriptionTextBox.MaxLength = CouponSet.Columns.DescriptionColumn.MaxLength;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.IsPostBack)
            {
                this.BackButton.PostBackUrl = this.ResolveUrl(Navigation.CouponSetDisplay);
            }
        }
    }
}