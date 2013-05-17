using System.IO;
using System.Web;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Dal.Enum;

namespace bsx.DirLaguna.Admin.Handlers
{
    public class DatabaseHandler : IHttpHandler
    {
        public bool IsReusable { get { return false; } }

        public void ProcessRequest(HttpContext context)
        {

            if (string.IsNullOrEmpty(context.Request.QueryString[QueryKeys.SqliteDbVersion]))
            {
                System.IO.File.WriteAllText("D:\\temp\\2.txt", "Error: La version esta vacia");
                context.Response.ContentType = "text/html";
                context.Response.End();
                return;
            }

            int version = int.Parse(context.Request.QueryString[QueryKeys.SqliteDbVersion]);

            //TODO: quitar esta sección de codigo cuando bajemos la aplicación
            if (string.IsNullOrEmpty(context.Request.QueryString[QueryKeys.NeedNewVersion]))
                if (version == 0)
                {
                    string oldDbName = "dirLaguna.db";
                    string oldBasePath = context.Server.MapPath(Navigation.Config.DbPath);
                    string oldSqliteDb = string.Format("{0}\\{1}", oldBasePath, oldDbName);

                    FileInfo oldDb = new FileInfo(oldSqliteDb);
                    context.Response.ContentType = "application/octet-stream";
                    context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", oldDbName));
                    context.Response.TransmitFile(oldSqliteDb, 0, oldDb.Length);
                }
                else
                {
                    context.Response.ContentType = "text/html";
                    context.Response.End();
                    return;
                }

            string rawDevice = context.Request.QueryString[QueryKeys.DeviceType];
            int device = string.IsNullOrEmpty(rawDevice) ?
                        (int)AccountConceptKeyEnum.iOsApp :
                        int.Parse(rawDevice);

            var lastUpdate = new SqliteUpdateController().FetchLastUpdate();

            if (lastUpdate == null || version >= lastUpdate.SqliteUpdateId)
            {
                context.Response.ContentType = "text/html";
                context.Response.End();
                return;
            }

            string basePath = context.Server.MapPath(Navigation.Config.DbPath);

            string dbName = Navigation.Config.SqliteDbName.Replace("db", "gz");

            string sqliteDb = string.Format("{0}\\{2}\\{1}" , basePath, dbName, device);
            //builder.AppendFormat("Intentando encontrar '{0}'\n");
            if (!File.Exists(sqliteDb))
            {
                //builder.AppendLine("Error: La base de datos no ha sido encontrada");
                return;
            }

            FileInfo db = new FileInfo(sqliteDb);
            context.Response.ContentType = "application/octet-stream";
            context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", dbName));
            context.Response.TransmitFile(sqliteDb, 0, db.Length);
        }
    }

}