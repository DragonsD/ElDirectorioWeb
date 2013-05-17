using System;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Public
{
    public partial class SearchResultForm : PublicBasePage
    {
        public string Keywords
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.Keywords]))
                    return this.Request.QueryString[QueryKeys.Keywords];
                return string.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LetterCategoriesControl1.CategorySelected += new EventHandler<Dal.Arguments.IntEventArgs>(LetterCategoriesControl1_CategorySelected);
            if (!this.IsPostBack && !this.EvaluateEmptyResultset(string.Empty))
            {

                this.AdvertiserDisplay2.Keywords = this.Keywords;
                this.AdvertiserDisplay2.CityId = this.SelectedCityId;

                this.LetterCategoriesControl1.Keywords = this.Keywords;
                this.LetterCategoriesControl1.CityId = this.SelectedCityId;
            }

            if (!this.IsPostBack && !this.EvaluateEmptyResultset(string.Empty))
            {

                this.AdvertiserDisplay2.Keywords = this.Keywords;
                this.AdvertiserDisplay2.CityId = this.SelectedCityId;

                this.LetterCategoriesControl1.Keywords = this.Keywords;
                this.LetterCategoriesControl1.CityId = this.SelectedCityId;
            }
        }

        private bool EvaluateEmptyResultset(string category)
        {
            VwAdvertiserController controller = new VwAdvertiserController();
            int countFeatured = controller.FetchCategoryAdvertisersCount(string.Empty, this.Keywords, this.SelectedCityId);
            int countUnFeatured = controller.FetchCategoryAdvertisersCount(string.Empty, this.Keywords, this.SelectedCityId);

            int count = countFeatured + countUnFeatured;

            this.EmptyDiv.Visible = count == 0;
            this.ResultSetDiv.Visible = count > 0;

            return count == 0;
        }

        void LetterCategoriesControl1_CategorySelected(object sender, Dal.Arguments.IntEventArgs e)
        {
            if (!this.EvaluateEmptyResultset(e.Value.ToString()))
            {
                //this.AdvertiserDisplay1.RefreshData(e.Value.ToString());
                this.AdvertiserDisplay2.RefreshData(e.Value.ToString());
                //this.MapCtrl1.RefreshData(e.Value.ToString());
            }
        }
    }
}