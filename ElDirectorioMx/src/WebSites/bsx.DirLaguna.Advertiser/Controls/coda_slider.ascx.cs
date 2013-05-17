using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Advertiser.Code;

namespace bsx.DirLaguna.Advertiser.Controls
{
    public partial class coda_slider : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.LoadData();
            }
        }

        public int BannerHeight
        {
            get
            {
                if (this.ViewState["BannerHeight"] == null)
                    this.ViewState["BannerHeight"] = 0;
                return (int)this.ViewState["BannerHeight"];
            }
            set
            {
                this.ViewState["BannerHeight"] = value;
            }

        }

        public int BannerWidth
        {
            get
            {
                if (this.ViewState["BannerWidth"] == null)
                    this.ViewState["BannerWidth"] = 0;
                return (int)this.ViewState["BannerWidth"];
            }
            set
            {
                this.ViewState["BannerWidth"] = value;
            }
        }

        public int AutoSlideInterval
        {
            get
            {
                if (this.ViewState["AutoSlideInterval"] == null)
                    this.ViewState["AutoSlideInterval"] = 0;
                return (int)this.ViewState["AutoSlideInterval"];
            }
            set
            {
                this.ViewState["AutoSlideInterval"] = value;
            }
        }

        public bool AutoSlide
        {
            get
            {
                if (this.ViewState["AutoSlide"] == null)
                    this.ViewState["AutoSlide"] = false;
                return (bool)this.ViewState["AutoSlide"];
            }
            set
            {
                this.ViewState["AutoSlide"] = value;
            }
        }

        public bool AutoSlideStopWhenClicked
        {
            get
            {
                if (this.ViewState["AutoSlideStopWhenClicked"] == null)
                    this.ViewState["AutoSlideStopWhenClicked"] = false;
                return (bool)this.ViewState["AutoSlideStopWhenClicked"];
            }
            set
            {
                this.ViewState["AutoSlideStopWhenClicked"] = value;
            }
        }

        public string LeftImage
        {
            get
            {
                return this.Page.ResolveClientUrl("~/jquery/plugin/coda/anterior.png");
            }
        }

        public string RightImage
        {
            get
            {
                return this.Page.ResolveClientUrl("~/jquery/plugin/coda/siguiente.png");
            }
        }

        public void LoadData()
        {
            BannerController con = new BannerController();
            this.LoadOptions();
            IQueryable<Banner> q = con.FetchAll();
            List<Banner> data = q.ToList();
            List<BannerItem> list = new List<BannerItem>();
            foreach (var item in data)
            {
                list.Add(new BannerItem()
                {
                    image = string.Format("{0}{1}", WebConfigurationManager.AppSettings["UrlSiteAdmin"], item.Picture),
                    link = item.Link,
                    //content = (string)item.Descendants("content").First(),
                    //image = (string)item.Descendants("image").First(),
                    //video = (string)item.Descendants("video").First(),
                    //link = (string)item.Descendants("link").First(),
                    Height = this.BannerHeight,
                    Width = this.BannerWidth
                });
            }
            this.XRepeater.DataSource = list;
            this.XRepeater.DataBind();
        }


        private void LoadOptions() //XElement xml)
        {
            this.BannerHeight = int.Parse(WebConfigurationManager.AppSettings["BannerHeight"]);
            this.BannerWidth = int.Parse(WebConfigurationManager.AppSettings["BannerWidth"]);
            this.AutoSlideInterval = int.Parse(WebConfigurationManager.AppSettings["BannerAutoSlideInterval"]);
            this.AutoSlide = bool.Parse(WebConfigurationManager.AppSettings["BannerAutoSlide"]);
            this.AutoSlideStopWhenClicked = bool.Parse(WebConfigurationManager.AppSettings["BannerAutoSlideStopWhenClicked"]);
        }

    }
}