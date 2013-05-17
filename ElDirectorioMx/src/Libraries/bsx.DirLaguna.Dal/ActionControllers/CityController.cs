using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class CityController
    {
        public bool Save(int cityId, string name)
        {
            bool result = false;

            City city = this.FetchById(cityId);
            if (city == null)
            {
                city = new City();
                this.db.City.InsertOnSubmit(city);
            }

            city.Name = name;
            city.Deleted = false;

            try
            {
                this.db.SubmitChanges();
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
            }

            return result;
        }

        public bool Delete(int cityId)
        {
            bool result = false;

            City city = this.FetchById(cityId);
            if (city == null)
            {
                this.Errors.Add("El elemento no existe");
                return false;
            }

            try
            {
                city.Deleted = true;

                this.db.SubmitChanges();
                result = true;
            }
            catch (Exception ex)
            {
                this.Errors.Add(ex.Message);
            }

            return result;
        }
    }
}
