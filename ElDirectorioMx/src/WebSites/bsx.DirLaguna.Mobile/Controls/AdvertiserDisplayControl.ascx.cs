using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Mobile.Code;
using bsx.DirLaguna.Dal;
using System.Configuration;
using System.Text;

namespace bsx.DirLaguna.Mobile.Controls
{
    public partial class AdvertiserDisplayControl : System.Web.UI.UserControl
    {
        public string StyleDestacados(bool featured)
        {
            StringBuilder style = new StringBuilder();
            if (featured)
                style.Append("linkContainer2");
            else
                style.Append("linkContainer");

            return style.ToString();
        }

        private const int PageSize = 30;
        private string urlImageBase
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("UrlLogoHandler"); ;
            }
        }

        public string ImageUrl(int advertiserId)
        {
            return ResolveUrl(string.Format("{0}?{1}={2}", urlImageBase, QueryKeys.AdvertiserId, advertiserId));
        }

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

        public bool DisplayFeatured
        {
            get
            {
                if (this.ViewState["displayFeautured"] != null)
                    return (bool)this.ViewState["displayFeautured"];
                return false;
            }
            set
            {
                this.ViewState["displayFeautured"] = value;
            }
        }

        private string CategoryId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request[QueryKeys.CategoryId]))
                    return this.Request[QueryKeys.CategoryId].ToString();
                return string.Empty;
            }

        }

        public string Keywords
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request[QueryKeys.Keywords]))
                    return this.Request[QueryKeys.Keywords].ToString();
                return string.Empty;
            }
        }

        public int CityId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request[QueryKeys.CityId]))
                    return int.Parse(this.Request[QueryKeys.CityId].ToString());
                return -1;
            }
        }

        public string AdvertiserUrl(int advertiserId)
        {
            if (!string.IsNullOrEmpty(this.RequestedLetter))
                return string.Format("{0}?{1}={2}&{3}={4}&{5}={6}", this.ResolveUrl(Navigation.AdvertiserForm), QueryKeys.AdvertiserId, advertiserId, QueryKeys.CategoryLetter, this.RequestedLetter, QueryKeys.CategoryId, this.CategoryId);
            return string.Format("{0}?{1}={2}&{3}={4}&{5}={6}", this.ResolveUrl(Navigation.AdvertiserForm), QueryKeys.AdvertiserId, advertiserId, QueryKeys.CityId, this.CityId, QueryKeys.Keywords, this.Keywords);
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
                //this.SetupTitleLabel();
            }
        }

        void PagerDataList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            this.StartIndex = int.Parse(e.CommandArgument.ToString());
            this.RefreshData(this.CategoryId);
        }

        private void SetupPager()
        {
            PageCounter counter = new PageCounter(new VwAdvertiserController().FetchCategoryAdvertisersCount(this.CategoryId, this.Keywords, this.CityId), PageSize);
            this.PagerDataList.DataSource = counter.Items;
            this.PagerDataList.DataBind();
            this.PagerDataList.Visible = counter.Items.Count > 1;
        }

        void AdvertisersObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["requestedCategory"] = this.CategoryId;
            //e.InputParameters["displayFeatured"] = this.DisplayFeatured;
            e.InputParameters["startRowIndex"] = this.StartIndex;
            e.InputParameters["maximumRows"] = PageSize;
            e.InputParameters["cityId"] = this.CityId;
            e.InputParameters["keywords"] = this.Keywords;
        }

        public void RefreshData(string value)
        {
            //this.CategoryId = value;
            this.SetupPager();
            this.AdvertisersDataList.DataBind();
            //this.SetupTitleLabel();
        }

    }
}