using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using System.Web.Configuration;

namespace bsx.DirLaguna.Public
{

    

    public partial class Magazine : BasePage
    {

        public string ConfigPath
        {
            get
            {
                return string.Format("{0}/files/magazine/config.xml", WebConfigurationManager.AppSettings["UrlSiteAdmin"]);
            }
        }

        public string DefaultPage
        {
            get
            {
                int id = 0;
                int.TryParse(this.Request.QueryString["pag"], out id);
                return id.ToString();
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            this.SearchButton.Click += new ImageClickEventHandler(SearchButton_Click); //+= new EventHandler(SearchButton_Click);
            if(!IsPostBack)
                this.Page.Title = "Directorio - Revista";
        }

        void SearchButton_Click(object sender, ImageClickEventArgs e)
        {
            this.SearchPlaceHolder.Visible = true;
        }

        //void SearchButton_Click(object sender, EventArgs e)
        //{
        //    this.SearchPlaceHolder.Visible = true;
        //}
    }
}