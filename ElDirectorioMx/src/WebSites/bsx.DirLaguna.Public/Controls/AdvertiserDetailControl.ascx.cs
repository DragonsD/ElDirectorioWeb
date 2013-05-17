using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Public.Code;
using System.Configuration;

namespace bsx.DirLaguna.Public.Controls
{
    public partial class AdvertiserDetailControl : PublicDetailFormControl<Advertiser>
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

        public string Letter
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.CategoryLetter]))
                    return this.Request.QueryString[QueryKeys.CategoryLetter];
                return string.Empty;
            }
        }

        public override Advertiser Source
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
                MapHelper helper = new MapHelper(ConfigurationManager.AppSettings["UrlSitePublicDomain"], this.ResolveUrl(Navigation.DetailForm));
                helper.AdvetiserId = this.AdvertiserId;
                helper.ZoomLevel = (int)bsx.DirLaguna.CommonWeb.MapHelper.ZoomLevelEnum.Near;
                return helper.MapScript;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.EmailObjectDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(EmailObjectDataSource_Selecting);
            this.OfficeDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(OfficeDataSource_Selecting);
            this.GalleriesObjectDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(GalleriesObjectDataSource_Selecting);
            if (!IsPostBack)
            {
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



        public override void LoadViewFromModel(Advertiser source)
        {
            if (source == null)
                this.Response.Redirect(this.ResolveUrl(Navigation.HomeForm));

            this.Page.Title = source.Name;            
            this.QrImage.ImageUrl = string.Format("https://chart.googleapis.com/chart?cht=qr&chs=250x250&chl=http://m.eldirectorio.mx/AdvertiserForm.aspx?AdvertiserId={0}", this.AdvertiserId);

            this.DescriptionLabel.Text = "\"" + source.Description + "\"";
            this.AditionalLiteral.Text = source.AditionalInfo;
            this.AditionalPlaceHolder.Visible = !string.IsNullOrEmpty(source.AditionalInfo);

            //this.AdvertiserImage.ImageUrl = string.Format("{1}?AdvertiserId={0}", this.AdvertiserId, ConfigurationManager.AppSettings["UrlLogoHandler"]);
            //this.AdvertiserImage.AlternateText = "[ni]";
            //this.NameLabel.Text = source.Name;
            //this.AddressLabel.Text = string.Format("{0}. {1}", source.Address, source.City.Name);

            this.TagsLabel.Text = string.Format(string.IsNullOrEmpty(source.Tags) ? "- sin etiquetas -" : "Etiqutas: {0}", source.Tags);

            var phones = source.Phone.Where(x => !x.Deleted);
            this.PhonesDiv.Visible = phones.Count() > 0;
            this.OfficesDiv.Visible = source.ActiveOfficesCount > 0;
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
            this.WebPageHyperLink.Text = source.FixedWebPage;
            
            this.SetHyperlinkProperties(this.TwitterHyperLink, source.Twitter);
            this.SetHyperlinkProperties(this.FacebookHyperLink, source.Facebook);

            this.ConnectSocialPlaceHolder.Visible = this.TwitterHyperLink.Visible || this.FacebookHyperLink.Visible;

            var categories = source.AdvertiserCategory.Where(x => !x.Deleted);
            this.CategoriesDiv.Visible = categories.Count() > 0;
            if (this.CategoriesDiv.Visible)
            {
                foreach (var item in categories)
                {
                    string url = string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.HomeForm), QueryKeys.CategoryId, item.CategoryId);
                    this.CategoriesBulletedList.Items.Add(new ListItem(item.Category.Name, url));
                }
            }

            var announces = source.Announce.Where(x => !x.Deleted);
            this.AnnouncesDiv.Visible = announces.Count() > 0;

            var galleries = source.ActiveGalleries.Where(x => !x.Deleted);
            this.galleryDiv.Visible = galleries.Count() > 0;

            var pages = new PageController().FetchAllByAdvertiserId(source.AdvertiserId);
            this.PagesPlaceHolder.Visible = pages.Count() > 0;
            if (this.PagesPlaceHolder.Visible)
            {
                foreach (var item in pages)
                {
                    string url = string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.Magazine), QueryKeys.Pag, item.SyncNumber);
                    this.PagesBulletedList.Items.Add(new ListItem(string.Format("Page #{0}", item.Number), url));
                }
            }

            var emails = source.Email.Where(x => !x.Deleted);
            this.EmailDiv.Visible = emails.Count() > 0;

            var coupons = source.Coupon.Where(x => !x.Deleted);
            this.CouponLinkButton.PostBackUrl = string.Format("{0}?{1}={2}", Navigation.CouponDisplay, QueryKeys.AdvertiserId, source.AdvertiserId);
            this.CouponDiv.Visible = coupons.Count() > 0;


        }

        private void SetHyperlinkProperties(HyperLink hyperlink, string address)
        {
            hyperlink.NavigateUrl = address;
            hyperlink.Visible = !string.IsNullOrEmpty(address);
        }
    }
}