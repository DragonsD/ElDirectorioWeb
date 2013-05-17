using System;
using System.Collections.Generic;
using System.Data.SQLite;
using NLog;

namespace bsx.DirLaguna.iOsDataStorage
{
    public class SqLiteCommander
    {
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private List<string> Commands { get; set; }

        public List<string> Error = new List<string>();

        private string dbName { get; set; }

        SQLiteConnection conn;

        public SqLiteCommander(string dbName)
        {
            this.dbName = dbName;
            this.conn = new SQLiteConnection(string.Format("Data Source={0}", this.dbName));
            this.Commands = new List<string>();
        }

        public string DeleTableData(string tableName)
        {
            return string.Format("delete from {0}", tableName);
        }

        public bool AddCommand(string command)
        {
            this.Commands.Add(command);
            if (Commands.Count % 1000 == 0 && !this.FlushCommands())
            {
                Console.WriteLine("Error");
                return false;
            }

            return true;
        }

        public void OpenConnection()
        {
            conn.Open();
        }

        public void CloseConnection()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
                conn.Close();
        }

        public bool ExecuteCommand(string commandText, List<RawParameter> commands)
        {
            bool result = false; ;
            //conn.Open();

            if (conn.State != System.Data.ConnectionState.Open)
            {
                Logger.Error("La conexion a la bd de sqlite no estaba lista");
                return false;
            }

            try
            {
                SQLiteCommand command = conn.CreateCommand();
                command.CommandText = commandText;
                command.CommandType = System.Data.CommandType.Text;

                foreach (var item in commands)
                {
                    SQLiteParameter parameter = new SQLiteParameter();
                    parameter.ParameterName = string.Format("@{0}", item.Name);
                    parameter.DbType = item.Type;
                    parameter.Value = item.Value;

                    command.Parameters.Add(parameter);
                }

                command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                this.Error.Add(ex.Message);
                Logger.Error("Error al guardar información en SqLite. {0}", ex.Message);
            }
            //finally
            //{
            //    if (conn.State != System.Data.ConnectionState.Closed)
            //        conn.Close();
            //}

            return result;

        }

        public bool FlushCommands()
        {
            bool result = false;

            SQLiteTransaction transaction = conn.BeginTransaction();
            try
            {
                foreach (var item in this.Commands)
                {
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = item;
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
                result = true;
                this.Commands.Clear();
            }
            catch (Exception ex)
            {
                this.Error.Add(ex.Message);
                transaction.Rollback();
            }
            return result;
        }
    }
}
