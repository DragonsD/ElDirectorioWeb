using System;
using System.Configuration;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Dal.SelectControllers;
using bsx.DirLaguna.Public.Code;
using System.Linq;
using System.Web;

namespace bsx.DirLaguna.Public.Shared
{
    public partial class Base : System.Web.UI.MasterPage
    {
        public string UrlPageFacebook
        {
            get
            {
                if (ConfigurationManager.AppSettings["UrlPageFacebook"] == null)
                    return "http://www.Facebook.com";
                return ConfigurationManager.AppSettings["UrlPageFacebook"].ToString();
            }
        }

        public string UrlPageTwitter
        {
            get
            {
                if (ConfigurationManager.AppSettings["UrlPageTwitter"] == null)
                    return "http://www.twitter.com";
                return ConfigurationManager.AppSettings["UrlPageTwitter"].ToString();
            }
        }

        private const int PageSize = 8;

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

        public string PublicityPictureUrl(int publicityId)
        {
            return PublicityHelper.PublicityPictureUrl(publicityId);
        }

        public int city
        {
            get
            {
                int id = 0;
                HttpCookie myCookie = this.Request.Cookies["DirLagunaCiudad"];
                if (myCookie != null)
                {
                    int.TryParse(myCookie.Value, out id);
                }
                return id;
            }
        }


        //public string UrlPathProspection
        //{
        //    get
        //    {
        //        if (ConfigurationManager.AppSettings["UrlPathProspection"] == null)
        //            return "http://www.twitter.com";
        //        return ConfigurationManager.AppSettings["UrlPathProspection"].ToString();
        //    }
        //}

        //public string UrlPathAdmin
        //{
        //    get
        //    {
        //        if (ConfigurationManager.AppSettings["UrlPathAdmin"] == null)
        //            return "http://www.twitter.com";
        //        return ConfigurationManager.AppSettings["UrlPathAdmin"].ToString();
        //    }
        //}

        public string UrlPathFranchisee
        {
            get
            {
                return this.ResolveUrl(Navigation.FranchiseeProspectationForm);
            }
        }

        public string FlashUrl { get { return ConfigurationManager.AppSettings["GenPublicityHandler"]; } }

        public string FlashFileName { get { return "MainFlash.swf"; } }

        public string Keywords
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.Keywords]))
                    return this.Request.QueryString[QueryKeys.Keywords];
                return string.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.WhereDropDownList.DataBound += new EventHandler(WhereDropDownList_DataBound);
            this.SearchButton.Click += new EventHandler(SearchButton_Click);
            this.PreRender += new EventHandler(Base_PreRender);

            if (!this.IsPostBack && !string.IsNullOrEmpty(Keywords))
            {
                this.SearchTextBox.Text = this.Keywords;
            }
        }

        void WhereDropDownList_DataBound(object sender, EventArgs e)
        {
            this.WhereDropDownList.Items.Insert(0, new ListItem("Todas las ciudades", "0"));
        }

        void Base_PreRender(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                PublicBasePage p = this.Page as PublicBasePage;
                if (p != null)
                {
                    CityController cities = new CityController();
                    this.WhereDropDownList.DataSource = cities.FechAllActive(Dal.Enum.AccountConceptKeyEnum.Website);
                    this.WhereDropDownList.DataBind();

                    this.WhereDropDownList.SelectedIndex =
                        this.WhereDropDownList.Items.IndexOf(this.WhereDropDownList.Items.FindByValue(p.SelectedCityId.ToString()));

                    if (p.SelectedCityId == 0)
                    {
                        this.flashmovie.Visible = true;
                        this.PublicityDataList.Visible = false;
                    }
                    else
                    {
                        this.flashmovie.Visible = false;
                        this.PublicityDataList.Visible = true;
                    }
                }
            }
        }

        void SearchButton_Click(object sender, EventArgs e)
        {
            PublicBasePage p = this.Page as PublicBasePage;
            if (p != null)
            {
                p.SelectedCityId = int.Parse(this.WhereDropDownList.SelectedValue);
            }
            this.Response.Redirect(string.Format("{0}?{1}={2}&{3}={4}", this.ResolveUrl(Navigation.SearchResultForm), QueryKeys.Keywords, this.SearchTextBox.Text, QueryKeys.CityId, this.WhereDropDownList.SelectedValue));
        }

        protected void PublicityDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["cityId"] = this.city;
            e.InputParameters["startRowIndex"] = this.StartIndex;
            e.InputParameters["maximumRows"] = PageSize;
        }

        private void SetupPager()
        {
            int totalCount = new PublicityController().fetchbyCityId(this.CityId).Count();

            PageCounter counter = new PageCounter(totalCount, PageSize);
        }

        public void RefreshData()
        {
            this.SetupPager();
            this.PublicityDataList.DataBind();
        }
    }
}