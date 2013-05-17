using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Admin.Code;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class CitiesForm : SimpleFormPage<City>
    {
        public int CityId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.CityId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.CityId]);
                return -1;
            }
        }

        public override City Source
        {
            get { return new CityController().FetchById(this.CityId); }
        }

        public override string SuccessUrl
        {
            get { return this.ResolveUrl(Navigation.CitiesDisplay); }
        }

        protected override LinkButton PageSaveButton
        {
            get { return this.SaveButton; }
        }

        public override void LoadViewFromModel(City source) 
        {
            this.NameTextBox.Text = source.Name;
            this.Title = string.Format("Editando a {0}", source.Name);
        }

        public override bool SaveMethod()
        {
            CityController controller = new CityController();
            bool result = false;

            try
            {
                if (!controller.Save(this.CityId, this.NameTextBox.Text))
                {
                    this.Errors = controller.Errors;
                }
                result = true;
            }
            catch (Exception ex)
            {
                Logger.ErrorException("Error al guardar la ciudad", ex);
            }

            return result;
        }

        public override void FillCatalogues()
        {

        }

        public override void SetMaxLenght()
        {
            this.NameTextBox.MaxLength = City.Columns.NameColumn.MaxLength;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!this.IsPostBack)
                this.BackButton.PostBackUrl = this.ResolveUrl(Navigation.CitiesDisplay);
        }

    }
}