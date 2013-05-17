using System;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class OfficeDisplay : SimpleDisplayPage
    {
        public int AdvertiserId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.AdvertiserId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.AdvertiserId]);
                return -1;
            }
        }

        public string OfficeFormUrl(int id) { return string.Format("{0}?{1}={2}&{3}={4}", this.ResolveUrl(Navigation.OfficeForm), QueryKeys.OfficeId, id, QueryKeys.AdvertiserId, this.AdvertiserId); }

        public override ObjectDataSource MainDataSource { get { return this.OfficeDataSource; } }

        public override GridView MainGridView { get { return this.OfficeGridView; } }

        public override LinkButton MainNewButton { get { return this.NewOfficeButton; } }

        public override LinkButton MainSearchButton { get { return null; } }

        public override LinkButton MainCleanButton { get { return null; } }

        public override string ElementFormUrl { get { return string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.OfficeForm), QueryKeys.AdvertiserId, this.AdvertiserId); } }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var advertiser = new AdvertiserController().FetchById(this.AdvertiserId);
            this.NewOfficeButton.Visible = advertiser.AllowNewOffices;

            if (!this.IsPostBack)
            {
                this.BackButton.PostBackUrl = this.ResolveUrl(Navigation.AdvertiserDisplay);
            }
        }

        public override void MainGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (!e.CommandName.Equals("delOffice"))
                return;

            OfficeController controller = new OfficeController();
            if (!controller.Delete(this.AdvertiserId, int.Parse(e.CommandArgument.ToString()), this.FranchiseeId, this.PersonalId))
            {
                this.ShowMessage(controller.Errors, CommonWeb.Enum.MessageTypes.Error);
                return;
            }

            var advertiser = new AdvertiserController().FetchById(this.AdvertiserId);
            this.NewOfficeButton.Visible = advertiser.AllowNewOffices;

            this.ShowMessage("La sucursal ha sido eliminada exitosamente", CommonWeb.Enum.MessageTypes.Success);
            this.OfficeGridView.DataBind();
        }

        public override void MainDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["advertiserId"] = this.AdvertiserId;
            e.InputParameters["franchiseeId"] = this.FranchiseeId;
        }

        public override void CleanFilterControls() { }

        public override void MainGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Office office = e.Row.DataItem as Office;

            if (office == null)
                return;

            GridViewRow row = e.Row as GridViewRow;
            if (row == null)
                return;

            Label cityLabel = row.FindControl("CityLabel") as Label;
            if(cityLabel!= null)
                cityLabel.Text = cityLabel != null ? office.City.Name : string.Empty;

        }

        public override void MainGridView_DataBound(object sender, EventArgs e) { }
    }
}