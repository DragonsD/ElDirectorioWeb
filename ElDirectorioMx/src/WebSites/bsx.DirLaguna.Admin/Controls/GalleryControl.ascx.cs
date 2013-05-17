using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb.Session;

namespace bsx.DirLaguna.Admin.Controls
{
    public partial class GalleryControl : System.Web.UI.UserControl
    {
        public event EventHandler Refresh;
        public event EventHandler Save;

        public int PersonalId { get { return SessionValues.PersonalId; } }

        public bool IsEdit
        {
            set
            {
                if (value)
                {
                    this.SaveButton.Visible = true;
                    this.CleanButton.Visible = false;
                }
                else
                {
                    this.SaveButton.Visible = true;
                    this.CleanButton.Visible = true;
                }
            }
        }

        public int AdvertiserId
        {
            get
            {
                if (this.ViewState["_advertiserId"] != null)
                    return int.Parse(this.ViewState["_advertiserId"].ToString());

                return -1;
            }
            set { this.ViewState["_advertiserId"] = value; }
        }

        public int GalleryId
        {
            get 
            {
                if(this.ViewState["_galleryId"] != null)
                    return int.Parse(this.ViewState["_galleryId"].ToString());

                return -1;
            }
            set { this.ViewState["_galleryId"] = value;}
        }

        public int FranchiseeId
        {
            get
            {
                if (this.ViewState["_franchiseeId"] != null)
                    return int.Parse(this.ViewState["_franchiseeId"].ToString());

                return -1;
            }
            set { this.ViewState["_franchiseeId"] = value; }
        }

        public string GalleryName
        {
            get { return this.GalleryNameTextBox.Text; }
            set { this.GalleryNameTextBox.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SaveButton.Click += new EventHandler(SaveButton_Click);
            this.CleanButton.Click += new EventHandler(CleanButton_Click);

            this.GalleryNameTextBox.MaxLength = Gallery.Columns.NameColumn.MaxLength;
        }

        void CleanButton_Click(object sender, EventArgs e)
        {
            this.CleanControls();
        }

        void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.Save != null)
                this.Save(this, EventArgs.Empty);

            if (this.Refresh != null)
                this.Refresh(this, EventArgs.Empty);
        }

        public void LoadGallery()
        {
            GalleryController controller = new GalleryController();
            Gallery gallery = controller.FetchById(this.GalleryId, this.FranchiseeId);
            if (gallery != null)
                this.GalleryName = gallery.Name;
            else
                this.GalleryName = string.Empty;
        }

        public bool SaveMethod()
        {
            GalleryController controller = new GalleryController();

            return controller.Save(this.GalleryId, this.GalleryName, this.AdvertiserId, this.FranchiseeId, this.PersonalId);
        }

        public void CleanControls()
        {
            this.GalleryName = string.Empty;
            this.ViewState.Remove("_galleryId");
            //this.ViewState.Remove("_franchiseeId");
        }
    }
}