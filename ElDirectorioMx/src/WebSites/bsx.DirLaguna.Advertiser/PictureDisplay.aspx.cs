﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Advertiser.Code;
using System.IO;
using bsx.DirLaguna.CommonWeb.Session;
using System.Configuration;

namespace bsx.DirLaguna.Advertiser
{
    public partial class PictureDisplay : SimpleDisplayPage
    {
        public int MaxPictureCurrentGallery
        {
            get
            {
                PictureController controller = new PictureController();
                return controller.GetTotalPictureByGalleryId(this.GalleryId);
            }

        }

        public int MaxPictures
        {
            get
            {
                return CouponSet.MaxCoupons;
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
            //return this.ThumbLocation(pictureId, false);
            //return string.Format("{0}\\{1}", Navigation.Config.GalleryPath, Picture.FullPicture(pictureId, false));
            return ResolveUrl(string.Format("{0}?{1}={2}&{3}={4}", urlImageBase, QueryKeys.PictureId, pictureId, QueryKeys.IsFullPicture, false));

        }

        public int GalleryId
        {
            get
            {
                if (this.Request.QueryString[QueryKeys.GalleryId] != null)
                    return int.Parse(this.Request.QueryString[QueryKeys.GalleryId].ToString());
                return -1;
            }
        }

        public int AdvertiserId
        {
            get
            {
                return SessionValues.AdvertiserId;
                //if (this.Request.QueryString[QueryKeys.AdvertiserId] != null)
                //    return int.Parse(this.Request.QueryString[QueryKeys.AdvertiserId].ToString());
                //return -1;
            }

        }

        public string ExtensionBase { get { return "jpg"; } }

        private int PictureId
        {
            get
            {
                if (this.ViewState["_pictureId"] != null)
                    return int.Parse(this.ViewState["_pictureId"].ToString());

                return -1;
            }
            set { this.ViewState["_pictureId"] = value; }
        }

        //public string PathBaseVirtual
        //{
        //    get
        //    {
        //        return string.Format("{0}\\{1}\\{2}\\", Navigation.Config.GalleryPath, this.AdvertiserId, this.GalleryId); ;
        //    }
        //}

        public string PathBase
        {
            get
            {
                return string.Format("{0}\\{1}\\{2}\\", this.Server.MapPath(Navigation.Config.GalleryPath), this.AdvertiserId, this.GalleryId); ;
            }
        }

        private string ThumbLocation(int pictureId)
        {
            return string.Format("{0}\\{1}.{2}", this.PathBase, bsx.DirLaguna.Dal.Advertiser.PictureThumbFileNameMask(pictureId), this.ExtensionBase.ToLower());
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.PictureControl1.Save += new EventHandler(PictureControl1_Save);
            this.PicturesDataList.ItemCommand += new DataListCommandEventHandler(PicturesDataList_ItemCommand);

            if (!this.IsPostBack)
            {
                this.PictureControl1.GalleryId = this.GalleryId;
                this.PictureControl1.FranchiseeId = this.FranchiseeId;
                this.BackHyperlink.NavigateUrl = this.ResolveUrl(Navigation.GalleryDisplay);

                this.PictureControl1.Visible = !(this.MaxPictureCurrentGallery >= this.MaxPictures);
                Gallery gl = new GalleryController().FetchById(this.GalleryId);
                if(gl != null)
                    this.GalleryLabel.Text = gl!= null ? gl.Name: string.Empty;
            }
        }

        void PicturesDataList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("delPicture"))
                return;

            PictureController controller = new PictureController();
            if (!controller.Delete(int.Parse(e.CommandArgument.ToString()), this.FranchiseeId, this.PersonalId))
            {
                this.ShowMessage(controller.Errors, CommonWeb.Enum.MessageTypes.Error);
                return;
            }

            this.PictureControl1.Visible = !(this.MaxPictureCurrentGallery >= this.MaxPictures);

            this.ShowMessage("La imagen ha sido eliminada exitosamente", CommonWeb.Enum.MessageTypes.Success);
            this.PicturesDataList.DataBind();
        }

        void PictureControl1_Save(object sender, EventArgs e)
        {
            if (this.PictureControl1.TotalPictureGallery == this.PictureControl1.PictureLimit)
            {
                this.ShowMessage(string.Format("No se pueden subir mas imagenes, ya se alcanzo el limite de {0} imagenes por galeria.", this.PictureControl1.PictureLimit), CommonWeb.Enum.MessageTypes.Error);
                this.PictureControl1.CleanControls();
                return;
            }

            int newPictureId = -1;
            if (this.PictureControl1.SaveMethod(out newPictureId))
            {
                if (!string.IsNullOrEmpty(this.PictureControl1.FilePictureUpload.FileName))
                {
                    string fn = System.IO.Path.GetFileName(this.PictureControl1.FilePictureUpload.PostedFile.FileName);
                    string[] parts = fn.Split('.');
                    string extension = parts[parts.Length - 1];

                    //string pathBase = string.Format("{0}\\{1}\\{2}\\", this.Server.MapPath(Navigation.Config.GalleryPath), this.AdvertiserId, this.GalleryId);
                    try
                    {
                        //if (!Directory.Exists(this.PathBase))
                        //    Directory.CreateDirectory(this.PathBase);

                        //string saveLocation = string.Format("{0}\\{1}.{2}", this.PathBase, bsx.DirLaguna.Dal.Advertiser.PictureFileNameMask(newPictureId), this.ExtensionBase.ToLower());

                        //ThumbnailHelper picture = new ThumbnailHelper(97, 97);
                        //picture.ProcessNewImage(this.PictureControl1.FilePictureUpload.PostedFile.InputStream, saveLocation, 600m);


                        //ThumbnailHelper thumb = new ThumbnailHelper(70, 70);
                        //thumb.ProcessNewImage(this.PictureControl1.FilePictureUpload.PostedFile.InputStream, this.ThumbLocation(newPictureId), 180m);
                        
                        ImageServicie.ImageService service = new ImageServicie.ImageService();
                        string[] errors = new string[10];

                        if (!service.SavePicture(this.AdvertiserId, this.GalleryId, newPictureId, this.PictureControl1.FilePictureUpload.FileBytes, ExtensionBase, out errors))
                        {
                            this.ShowMessage(errors, CommonWeb.Enum.MessageTypes.Error);
                        }

                    }
                    catch (Exception ex)
                    {
                        Logger.ErrorException(string.Format("Error al subir el archivo. {0}", ex.Message), ex);
                        Logger.ErrorException(string.Format("¡ No esta funcionando el servicio ImageService !. {0}", ex.Message), ex);
                        this.ShowMessage("Error al subir el archivo.", CommonWeb.Enum.MessageTypes.Error);
                        return;
                    }
                }

                this.PictureControl1.Visible = !(this.MaxPictureCurrentGallery >= this.MaxPictures);

                this.ShowMessage("El registro se ha guardado satisfactoriamente.", CommonWeb.Enum.MessageTypes.Success);
                this.PictureControl1.CleanControls();
                this.PicturesDataList.DataBind();
            }
            else
                this.ShowMessage("No se pudo guardar el registro.", CommonWeb.Enum.MessageTypes.Error);
        }

        public override ObjectDataSource MainDataSource
        {
            get { return this.PictureObjectDataSource; }
        }

        public override GridView MainGridView
        {
            get { return null; }
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

        }

        public override void MainDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["galleryId"] = this.GalleryId;
            e.InputParameters["franchiseeId"] = this.FranchiseeId;
        }

        public override void CleanFilterControls()
        {

        }

        public override void MainGridView_DataBound(object sender, EventArgs e)
        {

        }
    }
}