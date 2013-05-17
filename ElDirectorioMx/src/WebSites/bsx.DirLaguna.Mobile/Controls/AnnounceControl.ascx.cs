using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using bsx.DirLaguna.CommonWeb;

namespace bsx.DirLaguna.Mobile.Controls
{
    public partial class AnnounceControl : System.Web.UI.UserControl
    {
        public int AdvertiserId
        {
            get
            {
                if (this.ViewState["_advertiserId"] == null)
                    return -1;
                return int.Parse(this.ViewState["_advertiserId"].ToString());
            }
            set
            {
                this.ViewState["_advertiserId"] = value;
            }
        }

        private string urlImageBase
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("UrlGalleriesHandler"); ;
            }
        }

        public string ImageUrl(int pictureId)
        {
            return ResolveUrl(string.Format("{0}?{1}={2}&{3}={4}", urlImageBase, QueryKeys.PictureId, pictureId, QueryKeys.IsFullPicture, true));
        }

        public string ImageUrlThumb(int pictureId)
        {
            return ResolveUrl(string.Format("{0}?{1}={2}&{3}={4}", urlImageBase, QueryKeys.PictureId, pictureId, QueryKeys.IsFullPicture, false));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.AnnounceObjectDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(AnnounceObjectDataSource_Selecting);
        }

        void AnnounceObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["advertiserId"] = this.AdvertiserId;
        }
    }
}