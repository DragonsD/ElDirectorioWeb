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
    public partial class PictureControl : System.Web.UI.UserControl
    {
        public event EventHandler Refresh;
        public event EventHandler Save;

        public int PictureId
        {
            get
            {
                //if (this.ViewState["_pictureId"] != null)
                //    return int.Parse(this.ViewState["_pictureId"].ToString());
                // para que s
                return -1;
            }
            //set { this.ViewState["_pictureId"] = value; }
        }

        public int GalleryId
        {
            get
            {
                if (this.ViewState["_galleryId"] != null)
                    return int.Parse(this.ViewState["_galleryId"].ToString());

                return -1;
            }
            set { this.ViewState["_galleryId"] = value; }
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

        //public int TotalPictureGallery
        //{
        //    get
        //    {
        //        if (this.ViewState["_totalPictureGallery"] != null)
        //            return int.Parse(this.ViewState["_totalPictureGallery"].ToString());

        //        return -1;
        //    }
        //    set { this.ViewState["_totalPictureGallery"] = value; }
        //}

        public FileUpload FilePictureUpload
        {
            get
            {
                return this.PictureUpload;
            }
        }

        public string PictureDescription
        {
            get { return this.DescriptionTextBox.Text; }
            set { this.DescriptionTextBox.Text = value; }
        }

        //public int PictureLimit
        //{
        //    get
        //    {
        //        return 5;
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SaveButton.Click += new EventHandler(SaveButton_Click);
            this.CleanButton.Click += new EventHandler(CleanButton_Click);

            this.DescriptionTextBox.MaxLength = Picture.Columns.DescriptionColumn.MaxLength;
            //if (this.IsPostBack)
            //{
            //    PictureController controller = new PictureController();
            //    this.TotalPictureGallery = controller.GetTotalPictureByGalleryId(this.GalleryId);
            //}
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

        public bool SaveMethod(out int newPictureId)
        {
            PictureController controller = new PictureController();

            return controller.Save(this.PictureId, this.GalleryId, this.PictureDescription, this.FranchiseeId, SessionValues.PersonalId, out newPictureId);
        }

        public void CleanControls()
        {
            this.PictureDescription = string.Empty;
        }
    }
}