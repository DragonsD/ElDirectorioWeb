using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.CommonWeb;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class CitiesDisplay : SimpleDisplayPage
    {
        public string CitiesForm(int id) { return string.Format(id > 0 ? "{0}?{1}={2}" : "{0}", this.ResolveUrl(Navigation.CitiesForm), QueryKeys.CityId, id); }

        public override ObjectDataSource MainDataSource { get { return this.CitiesDataSource; } }

        public override GridView MainGridView { get { return this.CitiesGridView; } }

        public override LinkButton MainNewButton { get { return this.NewCityButton; } }

        public override LinkButton MainSearchButton { get { return null; } }

        public override LinkButton MainCleanButton { get { return null; } }

        public override string ElementFormUrl { get { return this.ResolveUrl(Navigation.CitiesForm); } }

        public override void MainGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (!e.CommandName.Equals("delCity"))
                return;

            CityController controller = new CityController();
            if (!controller.Delete(int.Parse(e.CommandArgument.ToString())))
            {
                this.ShowMessage(controller.Errors, CommonWeb.Enum.MessageTypes.Error);
                return;
            }
            this.ShowMessage("La ciudad se ha eliminado exitosamente", CommonWeb.Enum.MessageTypes.Success);
            this.CitiesGridView.DataBind();
        }

        public override void MainDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e) { }

        public override void CleanFilterControls() { }

        public override void MainGridView_DataBound(object sender, EventArgs e) { }
    }
}