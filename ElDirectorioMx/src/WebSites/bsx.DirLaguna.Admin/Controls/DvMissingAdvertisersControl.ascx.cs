using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using System.Collections;

namespace bsx.DirLaguna.Admin.Controls
{
    public partial class DvMissingAdvertisersControl : System.Web.UI.UserControl
    {
        public string  NameAdvertiser
        {
            get { return this.NameAdvertiserTextBox.Text; }
        }

        public int EstadoId
        {
            get
            {
                if (this.StatesDropDownList.SelectedIndex <= 0)
                    return -1;
                return int.Parse(this.StatesDropDownList.SelectedValue.ToString());
            }
        }

        public int MunicipioId
        {
            get
            {
                if (this.CitiesDropDownList.SelectedIndex <= 0)
                    return -1;
                return int.Parse(this.CitiesDropDownList.SelectedValue.ToString());
            }
        }

        public int PageSize
        {
            get
            {
                if (this.ViewState["pagesize"] != null)
                    return (int)this.ViewState["pagesize"];
                return 10;
            }
            set { this.ViewState["pagesize"] = value; }
        }

        public string AdvertiserDVForm(int id) { return string.Format(id > 0 ? "{0}?{1}={2}" : "{0}", this.ResolveUrl(Navigation.DvUpdaterForm), QueryKeys.AdvertiserId, id); }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdvertiserLessDVObjectDataSource.Selecting += new ObjectDataSourceSelectingEventHandler(AdvertiserLessDVObjectDataSource_Selecting);

            this.See50LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See100LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See200LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See20LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);
            this.See10LinkButton.Command += new CommandEventHandler(SeePageSizeLinkButton_Command);

            this.AdvertiserLessDVGridView.DataBound+=new EventHandler(AdvertiserLessDVGridView_DataBound);

            this.StatesDropDownList.SelectedIndexChanged += new EventHandler(StatesDropDownList_SelectedIndexChanged);
            this.SearchFranchiseeButton.Click += new EventHandler(SearchFranchiseeButton_Click);
            this.CleanFiltersLinkButton.Click += new EventHandler(CleanFiltersLinkButton_Click);
            if (!Page.IsPostBack)
            {
                var states = new EstadoController().FetchAll();

                this.FillComboBox(this.StatesDropDownList,
                        from x in states orderby x.Name ascending select x,
                        Estado.ColumnNames.EstadoId,
                        Estado.ColumnNames.Name);

                var cities = new MunicipioController().FetchAllByEstadoId(this.EstadoId);
                this.FillComboBox(this.CitiesDropDownList,
                        from x in cities orderby x.Name ascending select x,
                        Municipio.ColumnNames.MunicipioId,
                        Municipio.ColumnNames.Name);
            }
        }

        void CleanFiltersLinkButton_Click(object sender, EventArgs e)
        {
            this.NameAdvertiserTextBox.Text = string.Empty;
            this.StatesDropDownList.SelectedIndex = 0;
            this.CitiesDropDownList.SelectedIndex = 0;
            this.AdvertiserLessDVGridView.DataBind();
        }

        void SearchFranchiseeButton_Click(object sender, EventArgs e)
        {
            this.AdvertiserLessDVGridView.DataBind();
        }

        void StatesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cities = new MunicipioController().FetchAllByEstadoId(this.EstadoId);
            this.FillComboBox(this.CitiesDropDownList,
                    from x in cities orderby x.Name ascending select x,
                    Municipio.ColumnNames.MunicipioId,
                    Municipio.ColumnNames.Name);
        }

        void SeePageSizeLinkButton_Command(object sender, CommandEventArgs e)
        {
            this.PageSize = int.Parse(e.CommandArgument.ToString());
            this.AdvertiserLessDVGridView.DataBind();
        }

        void AdvertiserLessDVObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            this.AdvertiserLessDVGridView.PageSize = this.PageSize;

            e.InputParameters["nameAdvertiser"] = this.NameAdvertiser;
            e.InputParameters["estadoId"] = this.EstadoId;
            e.InputParameters["municipioId"] = this.MunicipioId;
            e.InputParameters["startRowIndex"] = 0;
            e.InputParameters["maximumRows"] = this.PageSize;
            e.InputParameters["sort"] = Franchisee.ColumnNames.Name;
        }

        protected void PageDropDownList_SelectedIndexChanged(Object sender, EventArgs e)
        {
            GridViewRow pagerRow = AdvertiserLessDVGridView.BottomPagerRow;

            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

            AdvertiserLessDVGridView.PageIndex = pageList.SelectedIndex;
        }

        protected void FillComboBox(System.Web.UI.WebControls.DropDownList dropdown, IEnumerable collection, string dataValueField, string dataTextField)
        {
            dropdown.DataSource = collection;
            dropdown.DataValueField = dataValueField;
            dropdown.DataTextField = dataTextField;
            dropdown.DataBind();

            dropdown.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", string.Empty));
        }

        public void AdvertiserLessDVGridView_DataBound(object sender, EventArgs e)
        {
            GridViewRow pagerRow = this.AdvertiserLessDVGridView.BottomPagerRow;

            if (pagerRow == null)
                return;

            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

            if (pageList != null)
            {
                for (int i = 0; i < this.AdvertiserLessDVGridView.PageCount; i++)
                {
                    int pageNumber = i + 1;
                    ListItem item = new ListItem(pageNumber.ToString());

                    if (i == this.AdvertiserLessDVGridView.PageIndex)
                    {
                        item.Selected = true;
                    }

                    pageList.Items.Add(item);
                }
            }
        }

    }
}