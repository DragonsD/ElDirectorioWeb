using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using NLog;
using System.Diagnostics;

namespace bsx.DirLaguna.SqliteUpdater
{
    class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Logger.Info("Iniciando la actualización");
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.ServiceUrl);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                Logger.ErrorException("Ha ocurrido un error", ex);
                Logger.Error(ex.Message);
            }
            finally
            {
                watch.Stop();
                Logger.Info("La ejecucion ha tomado {0:#,#} milisegundos", watch.ElapsedMilliseconds);
            }

        }
    }
}
