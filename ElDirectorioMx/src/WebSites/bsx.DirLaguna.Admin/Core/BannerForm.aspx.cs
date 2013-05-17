using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb.Base;
using System.IO;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class BannerForm : SimpleFormPage<Banner>
    {
        #region properties

        public int Tipo
        {
            get
            {
                return int.Parse(TipoRadioButtonList.SelectedValue);
            }
            set
            {
                this.TipoRadioButtonList.SelectedValue = value.ToString();
                this.TypeMultiView.ActiveViewIndex = value;
            }
        }

        public bool EsImagen
        {
            get
            {
                return this.Tipo == 0;
            }
            set
            {
                this.Tipo = value ? 0 : 1;
            }
        }

        public int BannerId
        {
            get
            {
                int id = 0;
                int.TryParse(this.Request.QueryString["bannerid"], out id);
                return id;
            }
        }

        public int Prioridad
        {
            get
            {
                int id = 0;
                int.TryParse(this.PrioridadTextBox.Text, out id);
                return id;
            }
            set
            {
                this.PrioridadTextBox.Text = value.ToString();
            }
        }

        //public string Contenido
        //{
        //    get
        //    {
        //        return string.Empty;
        //    }
        //    set
        //    {

        //    }
        //}

        #endregion

        #region event
        protected void Page_Load(object sender, EventArgs e)
        {
            this.SaveButton.Click += new EventHandler(SaveButton_Click);
            this.BackHyperlink.NavigateUrl = Navigation.BannerDisplay;
            this.TipoRadioButtonList.SelectedIndexChanged += new EventHandler(TipoRadioButtonList_SelectedIndexChanged);            
        }

        void TipoRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TypeMultiView.ActiveViewIndex = this.Tipo;
        }


        void SaveButton_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        public override Banner Source
        {
            get 
            {
                BannerController con = new BannerController();                
                return con.FetchById(this.BannerId);
            }
        }

        public override string SuccessUrl
        {
            get {
                return this.ResolveUrl(Navigation.BannerDisplay);
            }
        }

        protected override LinkButton PageSaveButton
        {
            get { return this.SaveButton; }
        }

        public override void LoadViewFromModel(Banner source)
        {
            this.Prioridad = source.Priority;
            this.LinkTextBox.Text = source.Link;
            this.XImage.ImageUrl = source.Picture; //string.Format("~/content/banner/{0}{1}", source.BannerId, source.Picture);
            this.XFileUploadRequiredFieldValidator.Enabled = false;
        }

        public override bool SaveMethod()
        {
            BannerController con = new BannerController();
            /*if (this.XFileUpload.HasFile && this.XFileUpload.FileBytes.Length > 0)
                filePath = Path.GetExtension(this.XFileUpload.FileName);*/
            int bannerId = 0;
            //bool result = con.Save(this.BannerId, filePath, this.LinkTextBox.Text, this.Prioridad, out bannerId);
            bool result = con.Save(this.BannerId, this.LinkTextBox.Text, this.Prioridad, out bannerId);
            if (!result)
                return result;
            string tempPath = null;
            string filePath = null;
            if (this.XFileUpload.HasFile && this.XFileUpload.FileBytes.Length > 0) //new file
            {
                filePath = string.Format("~/content/banner/{0}{1}", bannerId, Path.GetExtension(this.XFileUpload.FileName));
                tempPath = this.Server.MapPath(filePath);
                filePath = this.ResolveUrl(filePath); //this.ResolveClientUrl(filePath);
                try
                {
                    this.XFileUpload.SaveAs(tempPath);
                }
                catch (Exception)
                {
                    return false;                    
                }                
            }            
            result = con.UpdatePath(bannerId, filePath);
            return result;
        }

        public override void FillCatalogues()
        {
            
        }

        public override void SetMaxLenght()
        {
            this.PrioridadTextBox.MaxLength = 8;
            this.LinkTextBox.MaxLength = Banner.Columns.LinkColumn.MaxLength;
        }
    }
}