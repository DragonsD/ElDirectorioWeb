using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class GenPublicityForm : BasePage
    {
        public string MainFlashUrl
        {
            get
            {
                return string.Format("{2}{0}{1}",
                    this.ResolveUrl(Navigation.Config.GenPublicityPath),
                    SwfNames.MainSwfName,
                    Properties.Settings.Default.SiteUrl);
            }
        }

        public string CatDefaultFlashUrl
        {
            get
            {
                return string.Format("{2}{0}{1}",
                    this.ResolveUrl(Navigation.Config.GenPublicityPath),
                    SwfNames.DefaultCatPublicityName,
                    Properties.Settings.Default.SiteUrl);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.SaveMainButton.Click += new EventHandler(SaveMainButton_Click); // new EventHandler(SaveMainButton_Click);
            this.SaveDefaultButton.Click += new EventHandler(SaveDefaultButton_Click);
        }

        void SaveDefaultButton_Click(object sender, EventArgs e)
        {
            this.ProcessImage(this.DefualtFileUpload, "CatDefaultFlash.swf");
        }

        void SaveMainButton_Click(object sender, EventArgs e)
        {
            this.ProcessImage(this.MainUpload, "MainFlash.swf");
        }

        List<string> Errors = new List<string>();

        private void ProcessImage(FileUpload upload, string name)
        {
            string fn = System.IO.Path.GetFileName(upload.PostedFile.FileName);
            string[] parts = fn.Split('.');
            string extension = parts[parts.Length - 1];

            if (!extension.ToLower().Equals("swf"))
            {
                this.Errors.Add("El archivo de medios no es de un tipo apropiado. Utilice *.swf. Los datos se han guardado bien, solo vuelva a subir el archivo");
                return;
            }

            FileHelper.DeleteExistingFiles(this.Server.MapPath(Navigation.Config.GenPublicityPath), name);
            string saveLocation = string.Format("{0}\\{1}", this.Server.MapPath(Navigation.Config.GenPublicityPath), name);

            try
            {
                upload.PostedFile.SaveAs(saveLocation);
            }
            catch (Exception ex)
            {
                this.Errors.Add("Ha ocurrido un error al subir el archivo. " + ex.Message);
            }
        }
    }
}