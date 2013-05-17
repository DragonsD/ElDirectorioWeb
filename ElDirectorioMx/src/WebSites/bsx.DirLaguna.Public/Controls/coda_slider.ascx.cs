using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using bsx.DirLaguna.Dal;
using System.Web.Configuration;

public partial class modules_home_coda_slider : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string script = "<script type=\"text/javascript\" src=\"{0}\"></script>";
        //if (!this.Page.ClientScript.IsClientScriptBlockRegistered("easing"))
        //    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "easing",
        //        string.Format(script, this.Page.ResolveClientUrl("~/scripts/jquery.easing.1.3.js")));
        //if (!this.Page.ClientScript.IsClientScriptBlockRegistered("coda"))
        //    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "coda",
        //        string.Format(script, this.Page.ResolveClientUrl("~/scripts/jquery.coda-slider-2.0.js")));

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
    //public int BannerHeight
    //{
    //    get
    //    {
    //        if (this.ViewState["BannerHeight"] == null)
    //            this.ViewState["BannerHeight"] = 0;
    //        return (int)this.ViewState["BannerHeight"];
    //    }
    //}

    //public int BannerWidth
    //{
    //    get
    //    {
    //        if (this.ViewState["BannerWidth"] == null)
    //            this.ViewState["BannerWidth"] = 0;
    //        return (int)this.ViewState["BannerWidth"];
    //    }
    //}

    //public string XmlSource
    //{
    //    get
    //    {
    //        return this.Page.MapPath("~/content/Banner.xml");
    //    }
    //}

    //public string OtherXmlSource
    //{
    //    get
    //    {
    //        if(this.ViewState["OtherXmlSource"]==null)
    //            return string.Empty;
    //        return this.ViewState["OtherXmlSource"].ToString();
    //    }
    //    set
    //    {
    //        this.ViewState["OtherXmlSource"] = value;
    //    }
    //}

    public void LoadData()
    {
        //string source = this.OtherXmlSource;
        //if (string.IsNullOrEmpty(source))
        //    source = this.XmlSource;
        //if(source.Contains("~"))
        //    source = this.Page.MapPath(source);
        //XElement xml = XElement.Load(source);
        //var data = from x in xml.Descendants("item") select x;
        BannerController con = new BannerController();
        //this.LoadOptions(xml);
        this.LoadOptions();
        IQueryable<Banner> q = con.FetchAll();
        //string qs = q.ToString();
        List<Banner> data = q.ToList();
        List<BannerItem> list = new List<BannerItem>();
        foreach (var item in data)
        {
            list.Add(new BannerItem(){
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


        //this.BannerHeight = int.Parse((string)xml.Attribute("height"));
        //this.BannerWidth = int.Parse((string)xml.Attribute("width"));
        //this.AutoSlideInterval = int.Parse((string)xml.Attribute("autoSlideInterval"));
        //this.AutoSlide = bool.Parse((string)xml.Attribute("autoSlide"));
        //this.AutoSlideStopWhenClicked = bool.Parse((string)xml.Attribute("autoSlideStopWhenClicked"));    

    }

}
