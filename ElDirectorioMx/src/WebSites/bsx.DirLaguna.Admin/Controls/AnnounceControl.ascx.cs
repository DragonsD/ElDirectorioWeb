using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb.Session;

namespace bsx.DirLaguna.Admin.Controls
{
    public partial class AnnounceControl : System.Web.UI.UserControl
    {
        public event EventHandler Refresh;
        public event EventHandler Save;

        public string PathImage
        {
            get
            {
                return string.Format("{0}\\page_{1}.jpg", Navigation.Config.MagazinePath, this.PageId);
            }
        }

        public int AnnounceId
        {
            get
            {
                return -1;
            }
        }

        public int PageId
        {
            get
            {
                if (this.Request.QueryString[QueryKeys.PageId] != null)
                    return int.Parse(this.Request.QueryString[QueryKeys.PageId].ToString());

                return -1;
            }
        }

        public int AdvertiserId
        {
            get { return int.Parse(this.AdvertisersDropDownList.SelectedValue); }
            set
            {
                this.AdvertisersDropDownList.SelectedIndex = this.AdvertisersDropDownList.Items.IndexOf(this.AdvertisersDropDownList.Items.FindByValue(value.ToString())); ;
            }
        }

        public FileUpload FilePictureUpload
        {
            get
            {
                return this.PictureUpload;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SaveButton.Click += new EventHandler(SaveButton_Click);
            this.CleanButton.Click += new EventHandler(CleanButton_Click);

            if (!this.IsPostBack)
            {
                this.PageImage.ImageUrl = this.PathImage;

                AdvertiserController controller = new AdvertiserController();
                this.AdvertisersDropDownList.DataSource = controller.FetchAll(SessionValues.FranchiseeId);
                this.AdvertisersDropDownList.DataTextField = Advertiser.Columns.NameColumn.ColumnName;
                this.AdvertisersDropDownList.DataValueField = Advertiser.Columns.AdvertiserIdColumn.ColumnName;
                this.AdvertisersDropDownList.DataBind();
            }
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

        public bool SaveMethod(out int newAnnounceId)
        {
            AnnounceController controller = new AnnounceController();

            return controller.Save(this.AnnounceId, this.AdvertiserId, this.PageId, SessionValues.FranchiseeId, out newAnnounceId);
        }

        public void CleanControls()
        {
            this.AdvertisersDropDownList.SelectedIndex =0;
        }

    }
}