using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Mobile.Code;
using bsx.DirLaguna.CommonWeb.Base;

namespace bsx.DirLaguna.Mobile
{
    public partial class Default : PublicBasePage
    {
        public string UrlSiteDesktop
        {
            get
            {
                System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
                return ((string)(configurationAppSettings.GetValue("UrlSiteDesktop", typeof(string))));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.UrlSiteDesktopHyperLink.NavigateUrl = this.UrlSiteDesktop;
            this.WhereDropDownList.DataBound += new EventHandler(WhereDropDownList_DataBound);
            //DirLaguna.Dal.DirLagunaModelDataContext context = new Dal.DirLagunaModelDataContext();
            //int aux = (from x in context.Cities select x).Count();
            //this.Response.Write(aux.ToString());
            this.SearchButton.Click += new ImageClickEventHandler(SearchButton_Click); //+= new EventHandler(SearchButton_Click);
            this.PreRender += new EventHandler(Default_PreRender);
            this.Page.Title = "ElDirectorio.mx - Inicio";
        }

        void SearchButton_Click(object sender, ImageClickEventArgs e)
        {
            PublicBasePage p = this.Page as PublicBasePage;
            if (p != null)
                p.SelectedCityId = int.Parse(this.WhereDropDownList.SelectedValue);

            this.Response.Redirect(string.Format("{0}?{1}={2}&{3}={4}", this.ResolveUrl(Navigation.AdvertiserDisplay), QueryKeys.Keywords, this.SearchTextBox.Text, QueryKeys.CityId, this.WhereDropDownList.SelectedValue));

        }

        void Default_PreRender(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                PublicBasePage p = this.Page as PublicBasePage;
                if (p != null)
                {
                    CityController cities = new CityController();
                    this.WhereDropDownList.DataSource = cities.FechAllActive(Dal.Enum.AccountConceptKeyEnum.Website);
                    this.WhereDropDownList.DataBind();

                    this.WhereDropDownList.SelectedIndex =
                        this.WhereDropDownList.Items.IndexOf(this.WhereDropDownList.Items.FindByValue(p.SelectedCityId.ToString()));

                }
            }
        }

        void WhereDropDownList_DataBound(object sender, EventArgs e)
        {
            this.WhereDropDownList.Items.Insert(0, new ListItem("Todas las ciudades", "0"));
        }

    }
}