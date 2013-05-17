using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Public.Code;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Public.Controls
{
    public partial class MapControl : System.Web.UI.UserControl
    {
        public string DefaultSwfName { get { return SwfNames.DefaultCatPublicityName; } }

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

        public string RequestedLetter
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request[QueryKeys.CategoryLetter]))
                    return this.Request[QueryKeys.CategoryLetter];
                return string.Empty;
            }
        }

        public string FlashUrl
        {
            get
            {
                if (string.IsNullOrEmpty(this.RequestedCategory))
                    return string.Format("{0}?{1}=0",
                        ConfigurationManager.AppSettings["CatPublicityHandler"],
                        QueryKeys.CategoryId);

                return string.Format("{0}?{1}={2}",
                    ConfigurationManager.AppSettings["CatPublicityHandler"],
                    QueryKeys.CategoryId,
                    this.RequestedCategory);
            }
        }

        public bool FilterFeatured
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
        public string FlashFileName { get { return string.Format("{0}.swf", !string.IsNullOrEmpty(this.RequestedCategory) ? this.RequestedCategory : this.DefaultSwfName); } }

        public string MapScript
        {
            get
            {
                MapHelper helper = new MapHelper(this.FilterFeatured, this.RequestedCategory, this.Keywords, this.CityId, ConfigurationManager.AppSettings["UrlSitePublicDomain"], this.ResolveUrl(Navigation.DetailForm));
                helper.EmptyList += new EventHandler(helper_EmptyList);
                return helper.MapScript;
            }
        }

        void helper_EmptyList(object sender, EventArgs e)
        {
            this.EmptyLabel.Visible = true;
            this.ResultsetDiv.Visible = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack && !string.IsNullOrEmpty(this.Keywords))
                this.TitleLabel.Text = string.Format("Resultados para '{0}'", this.Keywords);
        }

        public void RefreshData(string value)
        {
            this.RequestedCategory = value;
            this.SetupTitleLabel();
        }

        private void SetupTitleLabel()
        {
            this.TitleLabel.Text = string.Empty;
            if (!string.IsNullOrEmpty(this.RequestedLetter) && string.IsNullOrEmpty(this.RequestedCategory))
                this.TitleLabel.Text = this.TitleLabel.Text + string.Format("Letra {0}. ", this.RequestedLetter);

            if (!string.IsNullOrEmpty(this.RequestedCategory))
            {
                CategoryController controller = new CategoryController();
                if (char.IsLetter(this.RequestedCategory[0]))
                    this.TitleLabel.Text = this.TitleLabel.Text + "Letra " + this.RequestedCategory + ". ";
                else
                    this.TitleLabel.Text = this.TitleLabel.Text + string.Format("{0}. ", controller.FetchById(int.Parse(this.RequestedCategory)).Name);
            }

            if (this.CityId > 0)
            {
                CityController controller = new CityController();
                City ct = controller.FetchById(this.CityId);
                this.TitleLabel.Text = TitleLabel.Text + (ct != null ? ct.Name : string.Empty) + ".";
            }
        }
    }
}