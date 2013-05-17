using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb.Session;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class CouponSetForm : SimpleFormPage<CouponSet>
    {
        public int AdvertiserId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.AdvertiserId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.AdvertiserId]);
                return -1;
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
            get { return string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.CouponSetDisplay), QueryKeys.AdvertiserId, this.AdvertiserId); }
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
            Advertiser adv = new AdvertiserController().FetchById(this.AdvertiserId);
            if (!adv.AllowNewCouponSet)
            {
                this.Errors.Add("Ya ha llegado al máximo numero de cuponeras permitidas por su cuenta");
                return false;
            }

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
                this.BackButton.PostBackUrl = this.ResolveUrl(string.Format("{0}?{1}={2}", Navigation.CouponSetDisplay, QueryKeys.AdvertiserId, this.AdvertiserId));
            }
        }

    }
}