using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal.SelectControllers;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal.Carrier;
using bsx.DirLaguna.CommonWeb.Session;
using System.IO;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class AdvertiserPrimaryForm : SimpleFormPage<Advertiser>
    {
        public int NewAdvertiserId
        {
            get
            {
                if (this.ViewState["newAdvertiserId"] != null)
                    return (int)this.ViewState["newAdvertiserId"];
                return -1;
            }
            set { this.ViewState["newAdvertiserId"] = value; }
        }

        public int AdvertiserId
        {
            get
            {
                if (this.Request.QueryString[QueryKeys.AdvertiserId] != null)
                    return int.Parse(this.Request.QueryString[QueryKeys.AdvertiserId]);
                return -1;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.BackButton.PostBackUrl = string.IsNullOrEmpty(this.Request.UrlReferrer.ToString()) ? this.ResolveUrl(Navigation.AdvertiserPrimaryDisplay) : this.Request.UrlReferrer.ToString();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            if (!this.IsPostBack)
            {
            }
        }

        public override void FillCatalogues()
        {
            var cities = from x in new CityController().FetchAll()
                         orderby x.Name
                         select x;

            //this.FillComboBox(this.StatusDropDownList,
            //        new StatusController().FetchAll(),
            //        Status.ColumnNames.StatusId,
            //        Status.ColumnNames.DisplayName);

        }

        public override void SetMaxLenght()
        {
            this.PriorityTextBox.MaxLength = Advertiser.Columns.PriorityColumn.MaxLength;
        }

        public override Advertiser Source { get { return new AdvertiserController().FetchById(this.AdvertiserId); } }

        public override string SuccessUrl { get { return this.ResolveUrl(Navigation.AdvertiserPrimaryDisplay); } }

        protected override LinkButton PageSaveButton { get { return this.SaveButton; } }

        public override bool SaveMethod()
        {
            int usedId = -1;
            AdvertiserController controller = new AdvertiserController();
            bool result = false;
            try
            {
                result = controller.UpdateAdvertiserPrimary(
                        this.AdvertiserId,
                        //int.Parse(this.StatusDropDownList.SelectedValue),
                        int.Parse(this.PriorityTextBox.Text),
                        this.PersonalId,
                        out usedId);
            }
            catch (Exception ex)
            {
                Logger.ErrorException("Error al guardar el anunciante", ex);
            }

            if (!result)
                this.Errors = controller.Errors;

            return result;
        }

        public override void LoadViewFromModel(Advertiser source)
        {
            this.AdvertiserNameLabel.Text = string.Format("Anunciante {0}", source.Name);
            this.PriorityTextBox.Text = source.Priority.ToString();

            this.Title = string.Format("Editando a {0}", source.Name);
        }
    }
}