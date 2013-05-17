using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Mobile.Code;
using System.Configuration;

namespace bsx.DirLaguna.Mobile.Controls
{
    public partial class AdvertiserDetailControl : System.Web.UI.UserControl
    {
        private string UrlLogoHandler
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("UrlLogoHandler");
            }
        }

        public int CategoryId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.CategoryId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.CategoryId]);
                return -1;
            }
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

        public string Letter
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.CategoryLetter]))
                    return this.Request.QueryString[QueryKeys.CategoryLetter];
                return string.Empty;
            }
        }

        public Advertiser Source
        {
            get
            {
                if (this.AdvertiserId > 0)
                    return new AdvertiserController().FetchById(this.AdvertiserId);
                return null;
            }
        }

        public string MapScript
        {
            get
            {
                MapHelper helper = new MapHelper(ConfigurationManager.AppSettings["UrlSitePublicDomain"], this.ResolveUrl(Navigation.AdvertiserForm));
                helper.AdvetiserId = this.AdvertiserId;
                helper.ZoomLevel = (int)bsx.DirLaguna.CommonWeb.MapHelper.ZoomLevelEnum.Near;
                return helper.MapScript;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.EmailObjectDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(EmailObjectDataSource_Selecting);
            this.OfficeDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(OfficeDataSource_Selecting);
            this.GalleriesObjectDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(GalleriesObjectDataSource_Selecting);
            if (!Page.IsPostBack)
            {
                this.LoadViewFromModel(this.Source);
                this.AnnounceControl1.AdvertiserId = this.AdvertiserId;
            }
        }

        void GalleriesObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["advertiserId"] = this.AdvertiserId;
        }

        void OfficeDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["advertiserId"] = this.AdvertiserId;
        }

        void EmailObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["advertiserId"] = this.AdvertiserId;
        }

        private void LoadViewFromModel(Advertiser source)
        {
            if (source != null)
            {
                this.Page.Title = string.Format("ElDirectorio.mx - {0}", source.Name);

                this.DescriptionLabel.Text = "\"" + source.Description + "\"";
                this.AditionalLiteral.Text = source.AditionalInfo;
                this.AditionalPlaceHolder.Visible = !string.IsNullOrEmpty(source.AditionalInfo);

                this.AdvertiserImage.ImageUrl = string.Format("{0}?AdvertiserId={1}", this.UrlLogoHandler, this.AdvertiserId);
                this.AdvertiserImage.AlternateText = "[ni]";
                this.NameLabel.Text = source.Name;
                this.AddressLabel.Text = string.Format("{0}. {1}", source.Address, source.City.Name);

                //this.TagsLabel.Text = string.Format(string.IsNullOrEmpty(source.Tags) ? "- sin etiquetas -" : "Etiqutas: {0}", source.Tags);

                var phones = source.Phone.Where(x => !x.Deleted);
                this.PhonesDiv.Visible = phones.Count() > 0;
                this.divMapa.Visible = source.MapReferenceX != null;

                if (this.PhonesDiv.Visible)
                {
                    foreach (var item in phones)
                    {
                        this.PhoneBulletedList.Items.Add(string.Format("{0}: {1}", item.PhoneType.Name, item.PhoneNumber));
                    }
                }

                //this.MediaDiv.Visible = !string.IsNullOrEmpty(source.WebPage) || !string.IsNullOrEmpty(source.Twitter) || !string.IsNullOrEmpty(source.Facebook);
                this.SetHyperlinkProperties(this.WebPageHyperLink, source.FixedWebPage);
                //this.WebPageHyperLink.Text = source.WebPage;
                this.SetHyperlinkProperties(this.TwitterHyperLink, source.Twitter);
                this.SetHyperlinkProperties(this.FacebookHyperLink, source.Facebook);

                var categories = source.AdvertiserCategory.Where(x => !x.Deleted);
                this.CategoriesDiv.Visible = categories.Count() > 0;
                if (this.CategoriesDiv.Visible)
                {
                    foreach (var item in categories)
                    {
                        string url = string.Format("{0}?{1}={2}&{3}={4}", this.ResolveUrl(Navigation.AdvertiserDisplay), QueryKeys.CategoryId, item.CategoryId, QueryKeys.CategoryLetter, item.Category.Letter);
                        this.CategoriesBulletedList.Items.Add(new ListItem(item.Category.Name, url));
                    }
                }

                var announces = source.Announce.Where(x => !x.Deleted);
                this.AnnounceDiv.Visible = announces.Count() > 0;

                var galleries = source.Gallery.Where(x => !x.Deleted);
                this.galleryDiv.Visible = galleries.Count() > 0;

                var oficces = source.Office.Where(x => !x.Deleted);
                this.OfficesDiv.Visible = oficces.Count() > 0;

                var emails = source.Email.Where(x => !x.Deleted);
                this.EmailDiv.Visible = emails.Count() > 0;

                var coupons = source.Coupon.Where(x => !x.Deleted);
                this.CouponLinkButton.PostBackUrl = string.Format("{0}?{1}={2}&{3}={4}&{5}={6}", Navigation.CouponDisplay, QueryKeys.AdvertiserId, source.AdvertiserId, QueryKeys.CategoryLetter, this.Letter, QueryKeys.CategoryId, this.CategoryId);
                this.CouponDiv.Visible = coupons.Count() > 0;
            }
        }

        private void SetHyperlinkProperties(HyperLink hyperlink, string address)
        {
            hyperlink.NavigateUrl = address;
            hyperlink.Visible = !string.IsNullOrEmpty(address);
        }

    }
}