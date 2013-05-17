using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Public.Code;
using bsx.DirLaguna.Dal;
using System.Text;
using System.Configuration;

namespace bsx.DirLaguna.Public.Controls
{
    public partial class AdvertiserDisplay : System.Web.UI.UserControl
    {
        private const int PageSize = 30;

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

        public string RequestedLetter
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request[QueryKeys.CategoryLetter]))
                    return this.Request[QueryKeys.CategoryLetter];
                return string.Empty;
            }
        }

        public string RequestedCategory
        {
            get
            {
                if (this.ViewState["reqCategory"] != null)
                    return this.ViewState["reqCategory"].ToString();
                return string.Empty;
            }
            set { this.ViewState["reqCategory"] = value; }
        }

        public bool DisplayFeatured
        {
            get
            {
                if (this.ViewState["filterFeat"] != null)
                    return (bool)this.ViewState["filterFeat"];
                return false;
            }
            set { this.ViewState["filterFeat"] = value; }
        }

        public string Keywords
        {
            get
            {
                if (this.ViewState["keywords"] != null)
                    return this.ViewState["keywords"].ToString();
                return string.Empty;
            }
            set { this.ViewState["keywords"] = value; }
        }

        public int CityId
        {
            get
            {
                if (this.ViewState["_cityId"] != null)
                    return int.Parse(this.ViewState["_cityId"].ToString());
                return -1;
            }
            set { this.ViewState["_cityId"] = value; }
        }

        public string AdvertiserUrl(int advertiserId)
        {
            if (!string.IsNullOrEmpty(this.RequestedLetter))
                return string.Format("{0}?{1}={2}&{3}={4}", this.ResolveUrl(Navigation.DetailForm), QueryKeys.AdvertiserId, advertiserId, QueryKeys.CategoryLetter, this.RequestedLetter);
            return string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.DetailForm), QueryKeys.AdvertiserId, advertiserId);
        }

        public string PromoUrl(int advertiserId)
        {
            return string.Format("{0}?{1}={2}", Navigation.CouponDisplayDirectorio, QueryKeys.AdvertiserId, advertiserId);
        }

        public string CutWebPage(string webpage) 
        {
            string finalWeb = null;
            if (webpage.Length >= 45)
            {
                char[] page = webpage.ToCharArray(0, 44);
                finalWeb = new string(page) + "...";
            }
            else 
            {
                finalWeb = webpage;
            }
            return finalWeb;
        }

        public string LogoUrl(int advertiserId)
        {
            return string.Format("{0}?{1}={2}", ConfigurationManager.AppSettings["UrlLogoHandler"], QueryKeys.AdvertiserId, advertiserId);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdvertisersObjectDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(AdvertisersObjectDataSource_Selecting);

            this.PagerDataList.ItemCommand += new DataListCommandEventHandler(PagerDataList_ItemCommand);

            if (!this.IsPostBack)
            {
                this.StartIndex = 0;
                this.SetupPager();
                this.AdvertisersDataList.DataBind();
            }
        }

        void PagerDataList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            this.StartIndex = int.Parse(e.CommandArgument.ToString());
            this.RefreshData(this.RequestedCategory);
        }

        private void SetupPager()
        {
            int totalCount = new VwAdvertiserController().FetchCategoryAdvertisersCount(
                this.RequestedCategory,
                this.Keywords,
                this.CityId);

            PageCounter counter = new PageCounter(totalCount, PageSize);
            this.PagerDataList.DataSource = counter.Items;
            this.PagerDataList.DataBind();
            this.PagerDataList.Visible = counter.Items.Count > 1;
            this.TitleLabel.Visible = totalCount > 0;
        }

        void AdvertisersObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["requestedCategory"] = this.RequestedCategory;
            //e.InputParameters["displayFeatured"] = this.DisplayFeatured;
            e.InputParameters["startRowIndex"] = this.StartIndex;
            e.InputParameters["maximumRows"] = PageSize;
            e.InputParameters["cityId"] = this.CityId;
            e.InputParameters["keywords"] = this.Keywords;
        }

        public void RefreshData(string value)
        {
            this.RequestedCategory = value;
            this.SetupPager();
            this.AdvertisersDataList.DataBind();
        }
    }
}