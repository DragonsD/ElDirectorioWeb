using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Admin.Code;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class GalleryDisplay : SimpleDisplayPage
    {
        public string PictureDisplay(int galleryId, int advertiserId)
        {
            return string.Format(galleryId > 0 && advertiserId > 0  ? "{0}?{1}={2}&&{3}={4}" : "{0}", this.ResolveUrl(Navigation.PictureDisplay), QueryKeys.GalleryId, galleryId, QueryKeys.AdvertiserId, advertiserId);
        }

        public int AdvertiserId
        {
            get
            {
                if (this.Request.QueryString[QueryKeys.AdvertiserId] != null)
                    return int.Parse(this.Request.QueryString[QueryKeys.AdvertiserId].ToString());
                return -1;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GalleryControl1.Save += new EventHandler(GalleryControl1_Save);

            if (!this.IsPostBack)
            {
                var advertiser = new AdvertiserController().FetchById(this.AdvertiserId);
                this.GalleryControl1.Visible = advertiser.AllowNewGalleries;
                this.GalleryControl1.IsEdit = false;

                this.GalleryControl1.AdvertiserId = this.AdvertiserId;
                this.GalleryControl1.FranchiseeId = this.FranchiseeId;

                this.BackButton.PostBackUrl = string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.AdvertiserDisplay), QueryKeys.AdvertiserId, this.AdvertiserId);
            }
        }

        void GalleryControl1_Save(object sender, EventArgs e)
        {
            Advertiser adv = new AdvertiserController().FetchById(this.AdvertiserId);
            if (!adv.AllowNewGalleries)
            {
                this.ShowMessage("Ya ha llegado al máximo numero de galerías permitidas por su cuenta", CommonWeb.Enum.MessageTypes.Notice);
                return;
            }

            if (this.GalleryControl1.SaveMethod())
            {
                this.ShowMessage("El registro se ha guardado satisfactoriamente.", CommonWeb.Enum.MessageTypes.Success);
                var advertiser = new AdvertiserController().FetchById(this.AdvertiserId);
                this.GalleryControl1.Visible = advertiser.AllowNewGalleries;

                this.GalleryControl1.CleanControls();
                this.MainGridView.DataBind();
            }
            else
                this.ShowMessage("No se pudo guardar el registro.", CommonWeb.Enum.MessageTypes.Error);
        }

        public override ObjectDataSource MainDataSource { get { return this.GalleryObjectDataSource; } }

        public override GridView MainGridView
        {
            get { return this.GalleriesGridView; }
        }

        public override LinkButton MainNewButton
        {
            get { return null; }
        }

        public override LinkButton MainSearchButton
        {
            get { return null; }
        }

        public override LinkButton MainCleanButton
        {
            get { return null; }
        }

        public override string ElementFormUrl
        {
            get { return string.Empty; }
        }

        public override void MainGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("delGallery"))
            {
                GalleryController controller = new GalleryController();
                if (!controller.Delete(int.Parse(e.CommandArgument.ToString()), this.FranchiseeId, this.PersonalId))
                {
                    this.ShowMessage(controller.Errors, CommonWeb.Enum.MessageTypes.Error);
                    return;
                }

                this.GalleryControl1.IsEdit = false;
                var advertiser = new AdvertiserController().FetchById(this.AdvertiserId);
                this.GalleryControl1.Visible = advertiser.AllowNewGalleries;

                this.ShowMessage("El anunciante ha sido eliminado exitosamente", CommonWeb.Enum.MessageTypes.Success);
                this.MainGridView.DataBind();
            }
            else
            {
                this.GalleryControl1.IsEdit = true;
                this.GalleryControl1.Visible = true;
                this.GalleryControl1.GalleryId = int.Parse(e.CommandArgument.ToString());
                this.GalleryControl1.FranchiseeId = this.FranchiseeId;
                this.GalleryControl1.LoadGallery();
            }
        }

        public override void MainDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["advertiserId"] = this.AdvertiserId;
            e.InputParameters["franchiseeId"] = this.FranchiseeId;
        }

        public override void CleanFilterControls()
        {
            
        }

        public override void MainGridView_DataBound(object sender, EventArgs e)
        {
            
        }

        protected void PageDropDownList_SelectedIndexChanged(Object sender, EventArgs e)
        {
            GridViewRow pagerRow = MainGridView.BottomPagerRow;

            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

            MainGridView.PageIndex = pageList.SelectedIndex;
        }

    }
}