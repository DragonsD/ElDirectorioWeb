using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class SqliteUpdateController
    {
        public bool Save(int iOsRrecords, int andrRecords)
        {
            bool result = false;

            try
            {
                SqliteUpdate update = new SqliteUpdate()
                {
                    UpdateDate = DateTime.Now,
                    ActiveRecords = iOsRrecords,
                    AndroidRecords = andrRecords
                };
                this.db.SqliteUpdates.InsertOnSubmit(update);
                this.db.SubmitChanges();
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
}
