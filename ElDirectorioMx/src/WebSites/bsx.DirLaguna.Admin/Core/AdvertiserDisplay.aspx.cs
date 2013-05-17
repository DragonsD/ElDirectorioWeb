using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.CommonWeb.Session;
using bsx.DirLaguna.Dal.Enum;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class AdvertiserDisplay : SimpleDisplayPage
    {
        public string GalleryDisplay(int id) { return string.Format(id > 0 ? "{0}?{1}={2}" : "{0}", this.ResolveUrl(Navigation.GalleryDisplay), QueryKeys.AdvertiserId, id); }

        public string AdvertiserForm(int id) { return string.Format(id > 0 ? "{0}?{1}={2}" : "{0}", this.ResolveUrl(Navigation.AdvertiserForm), QueryKeys.AdvertiserId, id); }

        public string ContractDisplay(int advertiserId) { return string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.ContractDisplay), QueryKeys.AdvertiserId, advertiserId); }

        public string CouponSetDisplay(int advertiserId) { return string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.CouponSetDisplay), QueryKeys.AdvertiserId, advertiserId); }

        public string OfficesForm(int id) { return string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.OfficeDisplay), QueryKeys.AdvertiserId, id); }

        public override ObjectDataSource MainDataSource { get { return this.AdvertiserDataSource; } }

        public override GridView MainGridView { get { return this.AdvertisersGridView; } }

        public override LinkButton MainNewButton { get { return this.NewAdvertiserButton; } }

        public override LinkButton MainSearchButton { get { return this.SearchAdvertiserButton; } }

        public override LinkButton MainCleanButton { get { return this.CleanFiltersLinkButton; } }

        public override string ElementFormUrl { get { return this.ResolveUrl(Navigation.AdvertiserForm); } }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.See50LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See100LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See200LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See20LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.MainNewButton.Visible = SessionValues.IsPrimary;

            this.AdvertisersGridView.RowDataBound += new GridViewRowEventHandler(AdvertisersGridView_RowDataBound);
        }

        void AdvertisersGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Advertiser adv = e.Row.DataItem as Advertiser;

            if (adv == null)
                return;

            GridViewRow row = e.Row as GridViewRow;
            if (row == null)
                return;

            AccountDetailController acController = new AccountDetailController();

            int galeries = acController.FetchTotalFor(adv.AdvertiserId, AccountConceptKeyEnum.Galerias);
            int sucursales = acController.FetchTotalFor(adv.AdvertiserId, Dal.Enum.AccountConceptKeyEnum.Sucursales);
            int cupones = acController.FetchTotalFor(adv.AdvertiserId, Dal.Enum.AccountConceptKeyEnum.Coupons);

            HyperLink editHp = e.Row.FindControl("EditHyperLink") as HyperLink;

            if (editHp != null)
                editHp.Visible = acController.FetchAnyDetail(adv.AdvertiserId);

            HyperLink galleriesHp = e.Row.FindControl("GalleriesHyperLink") as HyperLink;
            HyperLink officesHp = e.Row.FindControl("OfficesHyperLink") as HyperLink;
            HyperLink couponsHp = e.Row.FindControl("CouponSetHyperLink") as HyperLink;

            if (galleriesHp != null && galeries > 0)
                galleriesHp.Visible = true;

            if (officesHp != null && sucursales > 1)
                officesHp.Visible = true;

            if (couponsHp != null && cupones > 0)
                couponsHp.Visible = true;
        }

        void SeePageSizeLinkButton_Command(object sender, CommandEventArgs e)
        {
            this.PageSize = int.Parse(e.CommandArgument.ToString());
            this.AdvertisersGridView.DataBind();
        }

        public override void MainGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (!e.CommandName.Equals("delAdvertiser"))
                return;

            AdvertiserController controller = new AdvertiserController();
            if (!controller.Delete(int.Parse(e.CommandArgument.ToString()), this.FranchiseeId, this.PersonalId))
            {
                this.ShowMessage(controller.Errors, CommonWeb.Enum.MessageTypes.Error);
                return;
            }

            this.ShowMessage("El anunciante ha sido eliminado exitosamente", CommonWeb.Enum.MessageTypes.Success);
            this.AdvertisersGridView.DataBind();
        }

        public int PageSize
        {
            get
            {
                if (this.ViewState["pagesize"] != null)
                    return (int)this.ViewState["pagesize"];
                return 20;
            }
            set { this.ViewState["pagesize"] = value; }
        }

        public override void MainDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            this.AdvertisersGridView.PageSize = this.PageSize;

            e.InputParameters["name"] = this.NameTextBox.Text;
            e.InputParameters["description"] = this.DescriptionTextBox.Text;
            e.InputParameters["cityId"] = string.IsNullOrEmpty(this.CityDropDownList.SelectedValue) ? "-1" : this.CityDropDownList.SelectedValue;
            e.InputParameters["statusId"] = string.IsNullOrEmpty(this.StateDropDownList.SelectedValue) ? "-1" : this.StateDropDownList.SelectedValue;
            e.InputParameters["franchiseeId"] = this.FranchiseeId;
            e.InputParameters["startRowIndex"] = 0;
            e.InputParameters["maximumRows"] = this.PageSize;
            e.InputParameters["sort"] = Advertiser.ColumnNames.Name;
        }

        public override void LoadFilterDropDowns()
        {
            this.FillComboBox(this.CityDropDownList,
                    new CityController().FetchAll(),
                    City.ColumnNames.CityId,
                    City.ColumnNames.Name);

            this.FillComboBox(this.StateDropDownList,
                    new StatusController().FetchAll(),
                    Status.ColumnNames.StatusId,
                    Status.ColumnNames.DisplayName);
        }

        public override void MainGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Advertiser adv = e.Row.DataItem as Advertiser;

            if (adv == null)
                return;

            GridViewRow row = e.Row as GridViewRow;
            if (row == null)
                return;

            //Label statusLabel = row.FindControl("StatusLabel") as Label;
            //if (statusLabel != null)
            //    statusLabel.Text = adv.Status.DisplayName;

            Label cityLabel = row.FindControl("CityLabel") as Label;
            if (cityLabel != null)
                cityLabel.Text = string.Format("{0}, {1}", adv.Municipio.Name, adv.Municipio.Estado.Name);
        }

        public override void CleanFilterControls()
        {
            this.NameTextBox.Text = string.Empty;
            this.DescriptionTextBox.Text = string.Empty;
            this.StateDropDownList.SelectedIndex = -1;
            this.CityDropDownList.SelectedIndex = -1;
        }

        protected void PageDropDownList_SelectedIndexChanged(Object sender, EventArgs e)
        {
            GridViewRow pagerRow = MainGridView.BottomPagerRow;

            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

            MainGridView.PageIndex = pageList.SelectedIndex;
        }

        public override void MainGridView_DataBound(object sender, EventArgs e)
        {
            GridViewRow pagerRow = MainGridView.BottomPagerRow;

            if (pagerRow == null)
                return;

            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

            if (pageList != null)
            {
                for (int i = 0; i < MainGridView.PageCount; i++)
                {
                    int pageNumber = i + 1;
                    ListItem item = new ListItem(pageNumber.ToString());

                    if (i == MainGridView.PageIndex)
                    {
                        item.Selected = true;
                    }

                    pageList.Items.Add(item);
                }
            }
        }

        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.MainGridView.DataBind();
        }

        public object Adveriser { get; set; }
    }
}
