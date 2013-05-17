using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Admin.Code;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class AnnounceForm : SimpleFormPage<Announce>
    {
        public int PageId
        {
            get
            {
                if (this.Request.QueryString[QueryKeys.PageId] != null)
                    return int.Parse(this.Request.QueryString[QueryKeys.PageId]);
                return -1;
            }
        }

        public string PathBase
        {
            get
            {
                return this.Server.MapPath(Navigation.Config.MagazinePath); 
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.AnnounceControl1.Save += new EventHandler(AnnounceControl1_Save);
            this.AnnounceObjectDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(AnnounceObjectDataSource_Selecting);
            this.AnnounceGridView.RowCommand += new GridViewCommandEventHandler(AnnounceGridView_RowCommand);
            if (!IsPostBack)
            {
                if (this.Request.UrlReferrer != null)
                    this.BackButton.PostBackUrl = this.Request.UrlReferrer.ToString();
                else
                    this.BackButton.PostBackUrl = this.ResolveUrl(Navigation.PageDisplay);
            }
        }

        void AnnounceGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (!e.CommandName.Equals("delAnnounce"))
                return;

            AnnounceController controller = new AnnounceController();
            if (!controller.Delete(int.Parse(e.CommandArgument.ToString()), this.FranchiseeId))
            {
                this.ShowMessage(controller.Errors, CommonWeb.Enum.MessageTypes.Error);
                return;
            }

            this.ShowMessage("El anuncio ha sido eliminado exitosamente", CommonWeb.Enum.MessageTypes.Success);
            this.AnnounceGridView.DataBind();

        }

        void AnnounceObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["pageId"] = this.PageId;
            e.InputParameters["franchiseeId"] = this.FranchiseeId;
        }

        void AnnounceControl1_Save(object sender, EventArgs e)
        {
            int newAnnounceId = -1;
            if (this.AnnounceControl1.SaveMethod(out newAnnounceId))
            {
                if (!string.IsNullOrEmpty(this.AnnounceControl1.FilePictureUpload.FileName))
                {
                    string fn = System.IO.Path.GetFileName(this.AnnounceControl1.FilePictureUpload.PostedFile.FileName);
                    string[] parts = fn.Split('.');
                    string extension = parts[parts.Length - 1];

                    try
                    {
                        if (!Directory.Exists(this.PathBase))
                            Directory.CreateDirectory(this.PathBase);

                        string saveLocation = string.Format("{0}\\announce_{1}.jpg", this.PathBase, newAnnounceId);
                        ThumbnailHelper picture = new ThumbnailHelper(97, 97);
                        picture.ProcessNewImage(this.AnnounceControl1.FilePictureUpload.PostedFile.InputStream, saveLocation, 600m);

                        string saveLocationThumb = string.Format("{0}\\announce_{1}_thumb.jpg", this.PathBase, newAnnounceId);
                        ThumbnailHelper pictureThumb = new ThumbnailHelper(70, 70);
                        pictureThumb.ProcessNewImage(this.AnnounceControl1.FilePictureUpload.PostedFile.InputStream, saveLocationThumb, 120m);
                    }
                    catch (Exception ex)
                    {
                        Logger.ErrorException(string.Format("Error al subir el archivo. {0}", ex.Message), ex);
                        this.ShowMessage("Error al subir el archivo.", CommonWeb.Enum.MessageTypes.Error);
                        return;
                    }
                }

                this.ShowMessage("El registro se ha guardado satisfactoriamente.", CommonWeb.Enum.MessageTypes.Success);
                this.AnnounceControl1.CleanControls();
                this.AnnounceGridView.DataBind();
            }
            else
                this.ShowMessage("No se pudo guardar el registro.", CommonWeb.Enum.MessageTypes.Error);
        }


        public override Announce Source
        {
            get { return new AnnounceController().FetchById(1); }
        }

        public override string SuccessUrl
        {
            get { return string.Empty; }
        }

        protected override LinkButton PageSaveButton
        {
            get { return null; }
        }

        public override void LoadViewFromModel(Announce source)
        {
            
        }

        public override bool SaveMethod()
        {
            return true;
        }

        public override void FillCatalogues()
        {
            
        }

        public override void SetMaxLenght()
        {
            
        }
    }
}