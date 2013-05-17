using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Public.Code;
using bsx.DirLaguna.Dal.PublicContent;
using System.Web.Security;

namespace bsx.DirLaguna.Public
{
    public partial class CouponDisplay : PublicBasePage
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

        public string CityId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.CityId]))
                    return this.Request.QueryString[QueryKeys.CityId];
                return string.Empty;
            }
        }

        private MembershipUser currentUser = Membership.GetUser();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.CatCtrl1.CategorySelected += new EventHandler<Dal.Arguments.IntEventArgs>(CatCtrl1_CategorySelected);
            this.ddlCityCouponFilter.DataBound += new EventHandler(ddlddlCityCouponFilter_DataBound);
            this.PreRender += new EventHandler(CouponDisplay_PreRender);
            this.CouponsCtrl1.CityId = this.SelectedCouponCityId;
            if (!this.IsPostBack&& this.AdvertiserId > 0)
            {
                Advertiser adv = new AdvertiserController().FetchById(this.AdvertiserId);
                this.Title = string.Format("Cupones de {0}", adv.Name);
                this.ddlCityCouponFilter.Visible = false;
                this.btnFilterCityCoupon.Visible = false;
                this.CouponsCtrl1.CityId = 0;
            }
            //this.CheckMemberCouponClub(currentUser.UserName);
        }

        void ddlddlCityCouponFilter_DataBound(object sender, EventArgs e)
        {
            this.ddlCityCouponFilter.Items.Insert(0, new ListItem("Todas las ciudades", "0"));
        }

        void CouponDisplay_PreRender(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                PublicBasePage p = this.Page as PublicBasePage;
                if (p != null)
                {
                    CityController cities = new CityController();
                    this.ddlCityCouponFilter.DataSource = cities.FechAllActive(Dal.Enum.AccountConceptKeyEnum.Website);
                    this.ddlCityCouponFilter.DataBind();

                    this.ddlCityCouponFilter.SelectedIndex =
                        this.ddlCityCouponFilter.Items.IndexOf(this.ddlCityCouponFilter.Items.FindByValue(p.SelectedCouponCityId.ToString()));
                }
            }
        }

        void CatCtrl1_CategorySelected(object sender, Dal.Arguments.IntEventArgs e)
        {
            this.CouponsCtrl1.CategoryId = e.Value;
            this.CouponsCtrl1.DataBind();
        }

        void CheckMemberCouponClub(string userName) 
        {
            UserPublicController controller = new UserPublicController();
            bsx.DirLaguna.Dal.PublicContent.aspnet_Membership membership = controller.FetchByUserName(userName);
            Guest guest = controller.FetchGuestByUserId(membership.UserId);
            if (guest.Folio != null)
            {
                this.CouponsCtrl1.IsClub = true;
            }
            else
            {
                this.CouponsCtrl1.IsClub = false;
                this.CouponsCtrl1.Visible = false;
            }
        }

        protected void btnFilterCityCoupon_Click(object sender, EventArgs e)
        {
            PublicBasePage p = this.Page as PublicBasePage;
            if (p != null)
            {
                p.SelectedCouponCityId = int.Parse(this.ddlCityCouponFilter.SelectedValue);
            }
            this.Response.Redirect(string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.CouponDisplay), QueryKeys.CityId, this.ddlCityCouponFilter.SelectedValue));
        }
    }
}