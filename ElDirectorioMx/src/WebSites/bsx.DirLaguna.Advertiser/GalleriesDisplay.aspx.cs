using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Advertiser.Code;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.CommonWeb.Session;

namespace bsx.DirLaguna.Advertiser
{
    public partial class GalleriesDisplay : SimpleDisplayPage
    {
        public string PictureDisplay(int galleryId)
        {
            return string.Format(galleryId > 0 ? "{0}?{1}={2}" : "{0}", this.ResolveUrl(Navigation.PictureDisplay), QueryKeys.GalleryId, galleryId);
        }

        public int AdvertiserId
        {
            get
            {
                return SessionValues.AdvertiserId;
            }

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.GalleryControl1.Save += new EventHandler(GalleryControl1_Save);

            if (!this.IsPostBack)
            {
                var advertiser = new AdvertiserController().FetchById(this.AdvertiserId);
                this.GalleryControl1.Visible = advertiser.AllowNewGalleries;

                this.GalleryControl1.AdvertiserId = this.AdvertiserId;
                this.GalleryControl1.FranchiseeId = this.FranchiseeId;
                this.BackHyperlink.NavigateUrl = this.ResolveUrl(Navigation.AccountForm);
                this.GalleryControl1.IsEdit = false;
            }
        }

        void GalleryControl1_Save(object sender, EventArgs e)
        {
            if (this.GalleryControl1.SaveMethod())
            {
                this.ShowMessage("El registro se ha guardado satisfactoriamente.", CommonWeb.Enum.MessageTypes.Success);
                this.GalleryControl1.CleanControls();
                this.GalleryControl1.IsEdit = false;
                this.MainGridView.DataBind();
            }
            else
                this.ShowMessage("No se pudo guardar el registro.", CommonWeb.Enum.MessageTypes.Error);

            var advertiser = new AdvertiserController().FetchById(this.AdvertiserId);
            this.GalleryControl1.Visible = advertiser.AllowNewGalleries;
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

                var advertiser = new AdvertiserController().FetchById(this.AdvertiserId);
                this.GalleryControl1.Visible = advertiser.AllowNewGalleries;
                this.GalleryControl1.IsEdit = false;
                this.ShowMessage("La imagen ha sido eliminada exitosamente", CommonWeb.Enum.MessageTypes.Success);
                this.MainGridView.DataBind();
            }
            else
            {
                this.GalleryControl1.GalleryId = int.Parse(e.CommandArgument.ToString());
                this.GalleryControl1.FranchiseeId = this.FranchiseeId;
                this.GalleryControl1.Visible = true;
                this.GalleryControl1.IsEdit = true;
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
