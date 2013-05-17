using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.iOsDataStorage;
using bsx.DirLaguna.Admin.Code;

namespace bsx.DirLaguna.Admin
{
    public partial class SqliteGeneration_h3554h : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.ProcessData();
        }

        private void ProcessData()
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
                //TODO: loguear el error
                return;
            }
        }
    }
}