using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bsx.DirLaguna.CommonWeb.Base
{
    public class PublicBasePage : System.Web.UI.Page
    {
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
            set
            {
                HttpCookie myCookie = new HttpCookie("DirLagunaCiudad");
                DateTime now = DateTime.Now;
                // Set the cookie value.
                myCookie.Value = value.ToString();
                // Set the cookie expiration date.
                myCookie.Expires = now.AddDays(360);
                // Add the cookie.
                Response.Cookies.Add(myCookie);
            }
        }

        public int SelectedCouponCityId
        {
            get
            {
                int id = 0;
                HttpCookie myCookie = this.Request.Cookies["DirLagunaCiudadCoupon"];
                if (myCookie != null)
                {
                    int.TryParse(myCookie.Value, out id);
                }
                return id;
            }
            set
            {
                HttpCookie myCookie = new HttpCookie("DirLagunaCiudadCoupon");
                DateTime now = DateTime.Now;
                // Set the cookie value.
                myCookie.Value = value.ToString();
                // Set the cookie expiration date.
                myCookie.Expires = now.AddDays(360);
                // Add the cookie.
                Response.Cookies.Add(myCookie);
            }
        }

    }

}
