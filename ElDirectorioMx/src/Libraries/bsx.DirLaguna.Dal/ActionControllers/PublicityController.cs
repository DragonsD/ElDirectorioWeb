using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bsx.DirLaguna.Dal.Carrier;

namespace bsx.DirLaguna.Dal.SelectControllers
{
    public partial class PublicityController
    {
        public bool Save(SimplePublicityCarrier carrier, out int usedId)
        {
            bool result = false;
            usedId = -1;

            Publicity pu;

            pu = new Publicity();
            this.db.Publicity.InsertOnSubmit(pu);
            pu.CityId = carrier.CityId;
            pu.WebPage = carrier.WebPage;
            pu.Prioridad = carrier.Prioridad;


            try
            {
                this.db.SubmitChanges();
                usedId = (int)pu.PublicityID;
                result = true;
            }
            catch (Exception ex)
            {
                usedId = -1;
                this.Errors.Add(ex.Message);

            }

            return result;
        }

        public bool UpdatePath(int id, string path)
        {
            if (string.IsNullOrEmpty(path))
                return true;
            Publicity item = this.FetchById(id);
            if (item == null)
                return true;
            try
            {
                item.Picture = path;
                this.db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
                return false;
            }
        }
    }
}
