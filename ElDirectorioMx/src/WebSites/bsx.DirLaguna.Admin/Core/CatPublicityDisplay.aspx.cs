using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class CatPublicityDisplay : SimpleDisplayPage
    {
        public int CategoryId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.CategoryId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.CategoryId]);
                return -1;
            }
        }

        public string CatPublicityForm(int id)
        {
            return string.Format("{0}?{1}={2}&{3}={4}", this.ResolveUrl(Navigation.CatPublicityForm), QueryKeys.CatPublicityId, id, QueryKeys.CategoryId, this.CategoryId);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.IsPostBack)
            {
                this.BackButton.PostBackUrl = this.ResolveUrl(Navigation.CategoriesDisplay);
                Category cat = new CategoryController().FetchById(this.CategoryId);
                if (cat != null)
                {                    
                    this.HeaderLabel.Text = string.Format("Categoria: {0}", cat.Name);
                    this.Title = string.Format("Publicidad para {0}", cat.Name);
                }
            }
        }

        public override ObjectDataSource MainDataSource { get { return this.CatPublicityDataSource; } }

        public override GridView MainGridView { get { return this.CatPublicityGridView; } }

        public override LinkButton MainNewButton { get { return this.NewCatPublictyButton; } }

        public override LinkButton MainSearchButton { get { return null; } }

        public override LinkButton MainCleanButton { get { return null; } }

        public override string ElementFormUrl { get { return string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.CatPublicityForm), QueryKeys.CategoryId, this.CategoryId); } }

        public override void MainGridView_RowCommand(object sender, GridViewCommandEventArgs e) { }

        public override void MainDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["categoryId"] = this.CategoryId;
            e.InputParameters["maximumRows"] = 10;
        }

        public override void CleanFilterControls() { }

        public override void MainGridView_DataBound(object sender, EventArgs e)
        {

        }

    }
}