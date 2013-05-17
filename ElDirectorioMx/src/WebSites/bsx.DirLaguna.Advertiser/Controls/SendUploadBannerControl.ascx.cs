using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb.Session;

namespace bsx.DirLaguna.Advertiser.Controls
{
    public partial class SendUploadBannerControl : System.Web.UI.UserControl
    {
        public string ValidationGroup
        {
            get
            {
                if (this.ViewState["_validationGroup"] == null)
                    return string.Empty;
                return this.ViewState["_validationGroup"].ToString();
            }
            set
            {
                this.ViewState["_validationGroup"] = value;
            }

        }

        public List<string> Errors
        {
            get
            {
                if (this.ViewState["_errors"] == null)
                    return new List<string>();
                return (List<string>)this.ViewState["_errors"];
            }
            set
            {
                this.ViewState["_errors"] = value;
            }
        }

        public FileUpload FileUpload
        {
            get
            {
                return this.FileFileUpload;
            }
        }

        public string Url
        {
            get
            {
                return this.UrlTextBox.Text;
            }
        }

        public string TitleBanner
        {
            get
            {
                return this.TitleBannerTextBox.Text;
            }
            set
            {
                this.TitleBannerTextBox.Text = value;
            }
        }

        public bool Visible
        {
            get
            {
                return this.ControlDiv.Visible;
            }
            set
            {
                this.ControlDiv.Visible = value;
            }
        }

        /// <summary>
        /// Funcion para validar si los datos son correctos
        /// </summary>
        /// <returns> 
        /// 1 : Estan completos los datos de los dos campos
        /// 0 : Falta de especificar alguno de los datos
        /// -1: Es valido ya que no quiere guardar ningun datos del banner.
        /// </returns>
        public int Validate()
        {
            this.Errors = new List<string>();
            if (this.FileFileUpload.HasFile)
            {
                string fn = System.IO.Path.GetFileName(this.FileFileUpload.PostedFile.FileName);
                string[] parts = fn.Split('.');
                string extension = parts[parts.Length - 1];

                if (extension != "png")
                {
                    this.Errors.Add(string.Format("El archivo de la imagen debe ser png en el banner {0}", this.TitleBanner));
                    return 0;
                }
            }

            //if (this.FileFileUpload.HasFile && !string.IsNullOrEmpty(this.UrlTextBox.Text))
            //    return 1;

            if (!this.FileFileUpload.HasFile) // && string.IsNullOrEmpty(this.UrlTextBox.Text))
                return -1;

            //if (this.FileFileUpload.HasFile && string.IsNullOrEmpty(this.UrlTextBox.Text))
            //{
            //    this.Errors.Add(string.Format("Falta especificar el valor de la Url. en el banner {0}", this.TitleBanner));
            //    return 0;
            //}

            //if (!this.FileFileUpload.HasFile && !string.IsNullOrEmpty(this.UrlTextBox.Text))
            //{
            //    this.Errors.Add(string.Format("Falta especificar el valor de la imagen a subir en el banner {0}", this.TitleBanner));
            //    return 0;
            //}

            return 1; // Solo para que no marque warning;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Errors = new List<string>();
                //this.FileUploadRequiredFieldValidator.ValidationGroup = this.ValidationGroup;
            }
        }

    }
}