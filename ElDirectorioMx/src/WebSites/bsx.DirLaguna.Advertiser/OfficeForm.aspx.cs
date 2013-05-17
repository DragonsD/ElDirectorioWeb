using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Advertiser.Code;
using bsx.DirLaguna.CommonWeb.Session;

namespace bsx.DirLaguna.Advertiser
{
    public partial class OfficeForm : SimpleFormPage<Office>
    {
        public int EstadoId
        {
            get
            {
                if (this.EstadoDropDownList.SelectedIndex == 0)
                    return -1;
                return int.Parse(this.EstadoDropDownList.SelectedValue.ToString());
            }
            set
            {
                ListItem item = this.EstadoDropDownList.Items.FindByValue(value.ToString());
                if (item == null)
                    this.EstadoDropDownList.SelectedIndex = 0;
                else
                    this.EstadoDropDownList.SelectedIndex = this.EstadoDropDownList.Items.IndexOf(item);
            }
        }

        public int MunicipioOfficeId
        {
            get
            {
                if (this.MunicipioDropDownList.SelectedIndex == 0)
                    return -1;
                return int.Parse(this.MunicipioDropDownList.SelectedValue.ToString());
            }
            set
            {
                ListItem item = this.MunicipioDropDownList.Items.FindByValue(value.ToString());
                if (item == null)
                    this.MunicipioDropDownList.SelectedIndex = 0;
                else
                    this.MunicipioDropDownList.SelectedIndex = this.MunicipioDropDownList.Items.IndexOf(item);
            }
        }

        public int OfficeId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.OfficeId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.OfficeId]);
                return -1;
            }
        }

        public override Office Source
        {
            get
            {
                OfficeController controller = new OfficeController();
                return controller.FetchById(this.OfficeId, this.FranchiseeId);
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.BackButton.PostBackUrl = this.ResolveUrl(Navigation.OfficeDisplay);
            this.EstadoDropDownList.SelectedIndexChanged += new EventHandler(EstadoAdvertiserDropDownList_SelectedIndexChanged);

        }

        public override string SuccessUrl { get { return this.ResolveUrl(Navigation.OfficeDisplay); } }

        protected override LinkButton PageSaveButton { get { return this.SaveButton; } }

        public override void LoadViewFromModel(Office source)
        {
            Municipio municipio = new MunicipioController().FetchById(source.MunicipioId);
            this.EstadoId = municipio.EstadoId;

            this.FillComboBox(this.MunicipioDropDownList,
                    new MunicipioController().FetchAllByEstadoId(this.EstadoId),
                    Municipio.ColumnNames.MunicipioId,
                    Municipio.ColumnNames.Name);

            this.MunicipioOfficeId = source.MunicipioId;

            this.NameTextBox.Text = source.Name;
            this.OfficeNameLabel.Text = string.Format("{0}. {1}", source.Advertiser.Name, source.Name);
            this.StreetTextBox.Text = source.Address;
            this.NumberTextBox.Text = source.Number;
            this.ZipCodeTextBox.Text = source.ZipCode;
            this.NeghbornhodTextBox.Text = source.Neibornhod;

            this.MapReferenceTextBox.Text = (source.MapReferenceX.HasValue && source.MapReferenceY.HasValue) ? string.Format("{0},{1}", source.MapReferenceX.Value, source.MapReferenceY.Value) : string.Empty;

            this.Title = string.Format("Editando a {0}", source.Name);
        }

        public override bool SaveMethod()
        {
            if (this.NameTextBox.Text.Trim().ToLower().Equals("matriz"))
            {

                this.Errors.Add("El nombre 'Matriz' esta reservado para uso del sistema.");
                return false;
            }

            OfficeController controller = new OfficeController();
            bool result = false;

            decimal? mapX = null, mapY = null;

            if (!string.IsNullOrEmpty(this.MapReferenceTextBox.Text))
            {
                string[] items = this.MapReferenceTextBox.Text.Split(',');
                mapX = decimal.Parse(items[0]);
                mapY = decimal.Parse(items[1]);
            }

            try
            {
                if (!controller.Save(
                            this.OfficeId, 
                            SessionValues.AdvertiserId, 
                            this.MunicipioOfficeId, 
                            this.NameTextBox.Text,
                            this.StreetTextBox.Text,
                            this.NumberTextBox.Text,
                            this.ZipCodeTextBox.Text,
                            this.NeghbornhodTextBox.Text,
                            mapX, 
                            mapY, 
                            this.FranchiseeId, 
                            this.PersonalId))
                {
                    this.Errors = controller.Errors;
                }
                result = true;
            }
            catch (Exception ex)
            {
                Logger.ErrorException("Error al guardar una sucursal", ex);
            }

            return result;
        }

        public override void FillCatalogues()
        {
            var cities = from x in new CityController().FetchAll()
                         orderby x.Name
                         select x;

            this.FillComboBox(this.EstadoDropDownList,
                    new EstadoController().FetchAll(),
                    Estado.ColumnNames.EstadoId,
                    Estado.ColumnNames.Name);

        }

        public override void SetMaxLenght()
        {
            this.NameTextBox.MaxLength = bsx.DirLaguna.Dal.Advertiser.Columns.NameColumn.MaxLength;
        }

        void EstadoAdvertiserDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cities = new MunicipioController().FetchAllByEstadoId(this.EstadoId);
            this.FillComboBox(this.MunicipioDropDownList,
                    from x in cities orderby x.Name ascending select x,
                    Municipio.ColumnNames.MunicipioId,
                    Municipio.ColumnNames.Name);
        }
    }
}