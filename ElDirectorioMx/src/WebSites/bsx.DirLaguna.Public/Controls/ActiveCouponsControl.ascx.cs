using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Public.Code;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Public.Controls
{
    public partial class ActiveCouponsControl : System.Web.UI.UserControl
    {
        private const int PageSize = 18;

        public int StartIndex
        {
            get
            {
                if (this.ViewState["startIndex"] != null)
                    return (int)this.ViewState["startIndex"];
                return 0;
            }
            set { this.ViewState["startIndex"] = value; }
        }

        public int CategoryId
        {
            get
            {
                if (this.ViewState["categoryId"] != null)
                    return (int)this.ViewState["categoryId"];
                return -1;
            }
            set { this.ViewState["categoryId"] = value; }
        }

        public int AdvertiserId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.AdvertiserId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.AdvertiserId]);
                return -1;
            }
        }

        public int CityId
        {
            get
            {
                if (this.ViewState["CityId"] != null)
                    return (int)this.ViewState["CityId"];
                else
                    return -1;
            }
            set { this.ViewState["CityId"] = value; }
        }
        public string CouponUrl(int couponId)
        {
            return string.Format(this.AdvertiserId > 0 ? "{0}?{1}={2}&{3}={4}" : "{0}?{1}={2}", this.ResolveUrl(Navigation.CouponDetail), QueryKeys.CouponId, couponId, QueryKeys.AdvertiserId, this.AdvertiserId);
        }

        public string CouponUrlClub(int couponId)
        {
            return string.Format(this.AdvertiserId > 0 ? "{0}?{1}={2}&{3}={4}" : "{0}?{1}={2}", this.ResolveUrl(Navigation.CouponDetailClub), QueryKeys.CouponId, couponId, QueryKeys.AdvertiserId, this.AdvertiserId);
        }

        public bool IsClub
        {
            get
            {
                if (this.ViewState["ISCLub"] != null)
                    return (bool)this.ViewState["ISCLub"];
                return false;
            }
            set { this.ViewState["ISCLub"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CouponsObjectDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(CouponsObjectDataSource_Selecting);
            this.PagerDataList.ItemCommand += new DataListCommandEventHandler(PagerDataList_ItemCommand);
            

            if (!this.IsPostBack)
            {
                this.StartIndex = 0;
                this.SetupPager();
                this.CouponsDataList.DataBind();
            }



        }

        public string CouponPictureUrl(int couponId, string size)
        {
            return CouponHelper.CouponPictureUrl(couponId, size);
        }

        void CouponsObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["categoryId"] = this.CategoryId;
            e.InputParameters["advertiserId"] = this.AdvertiserId;
            e.InputParameters["cityId"] = this.CityId;
            e.InputParameters["startRowIndex"] = this.StartIndex;
            e.InputParameters["maximumRows"] = PageSize;
            e.InputParameters["isClub"] = this.IsClub;
        }

        void PagerDataList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            this.StartIndex = int.Parse(e.CommandArgument.ToString());

            this.RefreshData();
        }

        private void SetupPager()
        {
            int totalCount = new CouponController().fetchAvaibleCouponClub(this.IsClub, this.CategoryId, this.AdvertiserId, this.CityId).Count();

            PageCounter counter = new PageCounter(totalCount, PageSize);
            this.PagerDataList.DataSource = counter.Items;
            this.PagerDataList.DataBind();
            this.PagerDataList.Visible = counter.Items.Count > 1;
            //this.TitleLabel.Visible = totalCount > 0;
        }

        public void RefreshData()
        {
            this.SetupPager();
            this.CouponsDataList.DataBind();
        }
    }
}