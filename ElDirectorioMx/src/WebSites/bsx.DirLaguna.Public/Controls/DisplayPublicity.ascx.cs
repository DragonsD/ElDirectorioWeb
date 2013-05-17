using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Public.Code;
using bsx.DirLaguna.Dal;
using bsx.DirLaguna.Dal.SelectControllers;

namespace bsx.DirLaguna.Public.Controls
{
    public partial class DisplayPublicity : System.Web.UI.UserControl
    {
        private const int PageSize = 18;

        public int StartIndex
        {
            get
            {
                if (this.ViewState["startIndex"] != null)
                    return (int)this.ViewState["startIndex"];
                return 0;
            }
            set { this.ViewState["startIndex"] = value; }
        }

        public int EstadoId
        {
            get
            {
                if (this.ViewState["estadoId"] != null)
                    return (int)this.ViewState["estadoId"];
                return -1;
            }
            set { this.ViewState["estadoId"] = value; }
        }

        public int MunicipioId
        {
            get
            {
                if (this.ViewState["municipioId"] != null)
                    return (int)this.ViewState["municipioId"];
                return -1;
            }
            set { this.ViewState["municipioId"] = value; }
        }

        public int AdvertiserId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString[QueryKeys.AdvertiserId]))
                    return int.Parse(this.Request.QueryString[QueryKeys.AdvertiserId]);
                return -1;
            }
        }

        public string PublicityUrl(int publicityId)
        {
            return string.Format("{0}?{1}={2}", ConfigurationManager.AppSettings["UrlPublicity"], QueryKeys.AdvertiserId, publicityId);
        }

        public int SelectedCityId
        {
            get
            {
                int id = 0;
                HttpCookie myCookie = this.Request.Cookies["DirLagunaCiudad"];
                if (myCookie != null)
                {
                    int.TryParse(myCookie.Value, out id);
                }
                return id;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}