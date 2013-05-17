using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Mobile.Code;
using bsx.DirLaguna.CommonWeb;

namespace bsx.DirLaguna.Mobile
{
    public partial class CategoryDisplay : System.Web.UI.Page
    {
        private const string letter = "Letter";
        public string Letter
        {
            get
            {
                if(this.Request.QueryString[letter] != null)
                    return this.Request.QueryString[letter].ToString();

                return string.Empty;
            }

        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LetterCategoriesControl1.CategorySelected += new EventHandler<Dal.Arguments.IntEventArgs>(LetterCategoriesControl1_CategorySelected);
            if (!IsPostBack)
            {
                this.BackUpHyperLink.NavigateUrl = this.ResolveUrl(Navigation.Default);
                this.BackBottomHyperLink.NavigateUrl = this.ResolveUrl(Navigation.Default);
            }

            this.titleLabel.Text = this.Letter.ToUpper();

            string content = string.Empty;
            if(string.IsNullOrEmpty(Letter))
                content = "Todas las Categorias";
            else
                content = string.Format("Categorias que comienzan con {0}", Letter.ToUpper());

            this.Page.Title = string.Format("ElDirectorio.mx - {0}", content);
        }

        void LetterCategoriesControl1_CategorySelected(object sender, Dal.Arguments.IntEventArgs e)
        {
            this.RequestedCategoryHidden.Value = e.Value.ToString();
            this.RefreshAdvertiserList();
        }

        private void RefreshAdvertiserList()
        {
            //this.AdvertiserDisplay1.RefreshData(this.RequestedCategoryHidden.Value);
        }

    }
}