using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class PageDisplay : SimpleDisplayPage
    {
        public string PageFormUrl(int id) { return string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.PageForm), QueryKeys.PageId, id); }

        public string AnnounceFormUrl(int id) { return string.Format("{0}?{1}={2}", this.ResolveUrl(Navigation.AnnounceForm), QueryKeys.PageId, id); }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.PublishLinkButton.Click += new EventHandler(PublishLinkButton_Click);
            this.MainGridView.RowCommand +=new GridViewCommandEventHandler(MainGridView_RowCommand);
        }

        void PublishLinkButton_Click(object sender, EventArgs e)
        {
            MagazineHelper helper = new MagazineHelper(this.Server.MapPath(Navigation.Config.MagazinePath), this.ResolveUrl(Navigation.Config.MagazinePath));
            if (!helper.PublishXmlMagazine())
            {
                this.ShowMessage("Ha ocurrido un error durante la publicacion del archivo. Pongase en contacto con soporte", CommonWeb.Enum.MessageTypes.Error);
                return;
            }
            this.ShowMessage("El archivo XML se ha publicado exitosamente", CommonWeb.Enum.MessageTypes.Success);
        }

        public string PageForm(int id) { return string.Format(id > 0 ? "{0}?{1}={2}" : "{0}", this.ResolveUrl(Navigation.AdvertiserForm), QueryKeys.PageId, id); }

        public override ObjectDataSource MainDataSource
        {
            get { return this.PageObjectDataSource; }
        }

        public override GridView MainGridView
        {
            get { return this.PagesGridView; }
        }

        public override LinkButton MainNewButton
        {
            get { return this.NewPageButton; }
        }

        public override LinkButton MainSearchButton
        {
            get { return null; }
        }

        public override LinkButton MainCleanButton
        {
            get { return null; }
        }

        public override string ElementFormUrl
        {
            get { return this.ResolveUrl(Navigation.PageForm); }
        }

        public override void MainGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (!e.CommandName.Equals("delPage"))
                return;

            PageController controller = new PageController();
            if (!controller.Delete(int.Parse(e.CommandArgument.ToString())))
            {
                this.ShowMessage(controller.Errors, CommonWeb.Enum.MessageTypes.Error);
                return;
            }

            this.ShowMessage("La pagina ha sido eliminada exitosamente", CommonWeb.Enum.MessageTypes.Success);
            this.MainGridView.DataBind();
        }

        public override void MainDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        public override void CleanFilterControls()
        {

        }

        public override void MainGridView_DataBound(object sender, EventArgs e)
        {

        }
    }
}