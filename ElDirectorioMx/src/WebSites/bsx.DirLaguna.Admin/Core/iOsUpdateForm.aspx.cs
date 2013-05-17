using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb.Base;
using bsx.DirLaguna.iOsDataStorage;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.Dal;

namespace bsx.DirLaguna.Admin.Core
{
    public partial class iOsUpdateForm : BasePage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.UpdateDataBaseLinkButton.Click += new EventHandler(UpdateDataBaseImageButton_Click);

            if (!this.IsPostBack)
                this.LoadData();
        }

        void UpdateDataBaseImageButton_Click(object sender, EventArgs e)
        {
            DataBuilder.SetupStruct setup = new DataBuilder.SetupStruct()
            {
                SourcePath = Server.MapPath(Navigation.Config.SourceDbPath) + "\\" + Navigation.Config.SqliteDbName,
                TempPath = Server.MapPath(Navigation.Config.TempDbPath) + "\\" + Navigation.Config.SqliteDbName,
                LogoPath = Server.MapPath(Navigation.Config.LogoPath),
                PictureHandler = Properties.Settings.Default.PictureHandler,
                TargetPath = Server.MapPath(Navigation.Config.DbPath),
                DbName = Navigation.Config.SqliteDbName,
                CouponHandler = Properties.Settings.Default.CouponHandler,
                LogoHandler = Properties.Settings.Default.LogoHandler
            };

            DataBuilder builder = new DataBuilder(setup);

            if (!builder.ProccessData())
            {
                this.ShowMessage(builder.Errors, CommonWeb.Enum.MessageTypes.Error);
                return;
            }

            this.ShowMessageInPrevious("La información se ha actualizado exitosamente (android y ios)", CommonWeb.Enum.MessageTypes.Success);
            this.Response.Redirect(this.ResolveUrl(Navigation.AdvertiserDisplay));
        }

        private void LoadData()
        {
            SqliteUpdateController controller = new SqliteUpdateController();
            var lastUpdate = controller.FetchLastUpdate();

            this.LastUpdateLabel.Text = string.Format("La ultima actualización se realizó el dia {0:f} con un total de {1:#,0} y {2:#,0} registros activos en iOs y Android respectivamente", lastUpdate.UpdateDate, lastUpdate.ActiveRecords, lastUpdate.AndroidRecords);
        }

    }
}