using System;
using System.Linq;
using System.Collections;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Dal.Carrier;

namespace bsx.DirLaguna.Admin.Controls
{
    public partial class FiscalDetailReadOnlyControl : System.Web.UI.UserControl
    {
        public int? FiscalDetailId
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
                this.LoadData();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void ClearControls()
        {
            this.FiscalNameLabel.Text = string.Empty;
            this.RFCLabel.Text = string.Empty;
            this.StreetLabel.Text = string.Empty;
            this.PoblacionLabel.Text = string.Empty;
            this.ExteriorNumberLabel.Text = string.Empty;
            this.InteriorNumberLabel.Text = string.Empty;
            this.ColonyLabel.Text = string.Empty;
            this.ZipCodeLabel.Text = string.Empty;
            this.ContactEmailLabel.Text = string.Empty;

            this.EstadoLabel.Text = string.Empty;
            this.MunicipioLabel.Text = string .Empty;
        }

        public void LoadData()
        {
            if (this.FiscalDetailId < 0)
            {
                this.ClearControls();
                return;
            }

            Dal.FiscalDetail detail = new FiscalDetailController().FetchById((int)this.FiscalDetailId);

            this.FiscalNameLabel.Text = detail.Name;
            this.RFCLabel.Text = detail.RFC;
            this.StreetLabel.Text = detail.Street;
            this.PoblacionLabel.Text = detail.Poblacion;
            this.ExteriorNumberLabel.Text = detail.ExteriorNumber;
            this.InteriorNumberLabel.Text = detail.InteriorNumber;
            this.ColonyLabel.Text = detail.Colony;
            this.ZipCodeLabel.Text = detail.ZipCode;
            this.ContactEmailLabel.Text = detail.ContactEmail;

            EstadoController estadoController = new EstadoController();
            Estado estado = estadoController.FetchById(detail.EstadoId);
            this.EstadoLabel.Text = estado != null ? estado.Name : string.Empty;

            MunicipioController municipioController = new MunicipioController();
            Municipio municipio = municipioController.FetchById(detail.MunicipioId);
            this.MunicipioLabel.Text = municipio != null ? municipio.Name : string.Empty;
        }
    }
}