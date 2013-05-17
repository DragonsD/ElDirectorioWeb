using System;
using System.Linq;
using System.Collections;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Dal.Carrier;

namespace bsx.DirLaguna.Admin.Controls
{
    public partial class FiscalDetailControl : System.Web.UI.UserControl
    {
        public int FiscalDeailId
        {
            get
            {
                if (this.ViewState["_FiscalDetailId"] != null)
                    return (int)this.ViewState["_FiscalDetailId"];
                return -1;
            }
            set
            {
                this.ViewState["_FiscalDetailId"] = value;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!this.IsPostBack)
            {
                this.LoadCatalogues();
            }
        }

        private void LoadCatalogues()
        {
            this.FillComboBox(this.EstadoDropDownList,
                new EstadoController().FetchAll(),
                Estado.ColumnNames.EstadoId,
                Estado.ColumnNames.Name);
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.EstadoDropDownList.SelectedIndexChanged += new EventHandler(EstadoDropDownList_SelectedIndexChanged);
        }

        private void ClearControls()
        {
            this.FiscalNameTextBox.Text = string.Empty;
            this.RFCTextBox.Text = string.Empty;
            this.StreetTextBox.Text = string.Empty;
            this.PoblacionTextBox.Text = string.Empty;
            this.ExteriorNumberTextBox.Text = string.Empty;
            this.InteriorNumberTextBox.Text = string.Empty;
            this.ColonyTextBox.Text = string.Empty;
            this.ZipCodeTextBox.Text = string.Empty;
            this.ContactEmailTextBox.Text = string.Empty;

            this.EstadoDropDownList.SelectedIndex = 0;
            this.MunicipioDropDownList.SelectedIndex = 0;
        }

        public void LoadData()
        {
            if (this.FiscalDeailId < 0)
            {
                this.ClearControls();
                return;
            }

            Dal.FiscalDetail detail = new FiscalDetailController().FetchById(this.FiscalDeailId);

            this.FiscalNameTextBox.Text = detail.Name;
            this.RFCTextBox.Text = detail.RFC;
            this.StreetTextBox.Text = detail.Street;
            this.PoblacionTextBox.Text = detail.Poblacion;
            this.ExteriorNumberTextBox.Text = detail.ExteriorNumber;
            this.InteriorNumberTextBox.Text = detail.InteriorNumber;
            this.ColonyTextBox.Text = detail.Colony;
            this.ZipCodeTextBox.Text = detail.ZipCode;
            this.ContactEmailTextBox.Text = detail.ContactEmail;

            ListItem item = this.EstadoDropDownList.Items.FindByValue(detail.EstadoId.ToString());
            if (item == null)
                this.EstadoDropDownList.SelectedIndex = 0;
            else
                this.EstadoDropDownList.SelectedIndex = this.EstadoDropDownList.Items.IndexOf(item);

            this.FillMunicipios();

            ListItem itemMunicipio = this.MunicipioDropDownList.Items.FindByValue(detail.MunicipioId.ToString());
            if (item == null)
                this.MunicipioDropDownList.SelectedIndex = 0;
            else
                this.MunicipioDropDownList.SelectedIndex = this.MunicipioDropDownList.Items.IndexOf(itemMunicipio);
        }

        void EstadoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillMunicipios();
        }

        private void FillMunicipios()
        {
            var municipios = new MunicipioController().FetchAllByEstadoId(int.Parse(this.EstadoDropDownList.SelectedValue));

            this.FillComboBox(this.MunicipioDropDownList,
                    from x in municipios orderby x.Name select x,
                    Municipio.ColumnNames.MunicipioId,
                    Municipio.ColumnNames.Name);
        }

        protected void FillComboBox(System.Web.UI.WebControls.DropDownList dropdown, IEnumerable collection, string dataValueField, string dataTextField)
        {
            dropdown.DataSource = collection;
            dropdown.DataValueField = dataValueField;
            dropdown.DataTextField = dataTextField;
            dropdown.DataBind();

            dropdown.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", string.Empty));
        }

        public SimpleFiscalDetailCarrier Carrier
        {
            get
            {
                SimpleFiscalDetailCarrier carrier = new SimpleFiscalDetailCarrier();
                carrier.FiscalName = this.FiscalNameTextBox.Text;
                carrier.RFC = this.RFCTextBox.Text;
                carrier.Street = this.StreetTextBox.Text;
                carrier.Poblacion = this.PoblacionTextBox.Text;
                carrier.ExteriorNumber = this.ExteriorNumberTextBox.Text;
                carrier.InteriorNumber = this.InteriorNumberTextBox.Text;
                carrier.Colony = this.ColonyTextBox.Text;
                carrier.ZipCode = this.ZipCodeTextBox.Text;
                carrier.ContactEmail = this.ContactEmailTextBox.Text;
                if (!string.IsNullOrEmpty(this.RFCTextBox.Text))
                {
                    carrier.EstadoId = int.Parse(this.EstadoDropDownList.SelectedValue);
                    carrier.MunicipioId = !string.IsNullOrEmpty(this.MunicipioDropDownList.SelectedValue) ? int.Parse(this.MunicipioDropDownList.SelectedValue) : -1;
                }
                return carrier;
            }
        }
    }
}