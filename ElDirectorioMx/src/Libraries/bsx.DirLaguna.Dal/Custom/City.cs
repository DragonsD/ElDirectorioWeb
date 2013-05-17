using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bsx.DirLaguna.Dal
{
    public partial class City
    {
        public bool HasActiveAdvertisers
        {
            get
            {
                CityController controller = new CityController();
                return controller.FetchAdvertisersCount(this.CityId) > 0;
            }
        }
    }
}
