using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Public.Code;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb;
using System.Configuration;

namespace bsx.DirLaguna.Public.Controls
{
    public partial class GalleryControl : System.Web.UI.UserControl
    {
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

        public int PictureId
        {
            get
            {
                if (this.ViewState["_pictureId"] == null)
                    return -1;
                return int.Parse(this.ViewState["_pictureId"].ToString());
            }
            set { this.ViewState["_pictureId"] = value; }
        }

        public int GalleryId
        {
            get
            {
                if (this.ViewState["_galleryId"] == null)
                    return -1;
                return int.Parse(this.ViewState["_galleryId"].ToString());
            }
            set
            {
                Gallery pct = new GalleryController().FetchById(value);
                this.GalleryNameLabel.Text = (pct == null ? string.Empty : pct.Name);

                this.ViewState["_galleryId"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.PictureObjectDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(PictureObjectDataSource_Selecting);

        }

        void PictureObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["galleryId"] = this.GalleryId;
        }
    }
}