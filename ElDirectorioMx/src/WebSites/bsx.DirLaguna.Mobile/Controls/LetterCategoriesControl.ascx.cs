using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal.Arguments;
using bsx.DirLaguna.Mobile.Code;

namespace bsx.DirLaguna.Mobile.Controls
{
    public partial class LetterCategoriesControl : System.Web.UI.UserControl
    {

        public string RequestedLetter
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.CategoryLetter]))
                    return this.Request.QueryString[QueryKeys.CategoryLetter];
                return string.Empty;
            }
        }

        public bool FilterFeatured
        {
            get
            {
                return false;
            }
        }

        public event EventHandler<IntEventArgs> CategorySelected;

        public string Keywords
        {
            get
            {
                return string.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CategoriesDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(CategoriesDataSource_Selecting);

        }

        public string CategoryUrl(int categoryId)
        {
            if (!string.IsNullOrEmpty(this.RequestedLetter))
                return string.Format("{0}?{1}={2}&{3}={4}", this.ResolveUrl(Navigation.AdvertiserDisplay), QueryKeys.CategoryId, categoryId, QueryKeys.CategoryLetter, this.RequestedLetter);
            return string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.AdvertiserDisplay), QueryKeys.CategoryId, categoryId);
        }

        void CategoriesDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["letter"] = this.RequestedLetter;
            e.InputParameters["keywords"] = this.Keywords;
            e.InputParameters["filterFeatured"] = this.FilterFeatured;
            e.InputParameters["cityId"] = -1;
        }


    }
}