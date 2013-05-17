using System;
using System.Collections.Generic;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Public.Code;

namespace bsx.DirLaguna.Public.Controls
{
    public partial class MenuControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.RefreshMenu();
        }

        public void RefreshMenu()
        {
            //List<MenuItemUI> list = this.GenerateMenuItemsByPermission();
            this.MenuRepeater.DataSource = this.GenerateMenuMenu();
            this.MenuRepeater.DataBind();
        }

        public List<MenuItemUI> GenerateMenuMenu()
        {
            List<MenuItemUI> list = new List<MenuItemUI>();

            list.Add(new MenuItemUI { Text = "Inicio", URL = ResolveUrl(Navigation.HomeForm), Text2 = "|" });
            
            /*list.Add(new MenuItemUI { Text = "Categorias", URL = ResolveUrl(Navigation.HomeForm), Text2 = "|" });
            list.Add(new MenuItemUI { Text = "Ofertas", URL = ResolveUrl(Navigation.HomeForm), Text2 = "|" });
            list.Add(new MenuItemUI { Text = "Destacados", URL = ResolveUrl(Navigation.HomeForm), Text2 = "|" });
            list.Add(new MenuItemUI { Text = "Para empresas", URL = ResolveUrl(Navigation.HomeForm), Text2 = "|" });*/
            
            //list.Add(new MenuItemUI { Text = "Busqueda", URL = ResolveUrl(Navigation.SearchResultForm), Text2 = "|" });
            list.Add(new MenuItemUI { Text = "Cupones", URL = ResolveUrl(Navigation.CouponDisplay), Text2 = "|" });
            list.Add(new MenuItemUI { Text = "Club El Directorio", URL = ResolveUrl(Navigation.CouponDisplayDirectorio), Text2 = "|" });
            list.Add(new MenuItemUI { Text = "¿Quiénes somos?", URL = ResolveUrl(Navigation.About), Text2 = "|" });
            list.Add(new MenuItemUI { Text = "¡Anúnciate!", URL = ResolveUrl(Navigation.ContactForm), Text2 = "|" });
            list.Add(new MenuItemUI { Text = "Franquicias", URL = ResolveUrl(Navigation.FranchisesForm), Text2 = "|" });
            
            //list.Add(new MenuItemUI { Text = "Revista", URL = ResolveUrl(Navigation.Magazine), Text2 = "|" });

            String currentUrl = this.Request.Url.ToString().ToLower();
            foreach (MenuItemUI item in list)
            {
                if (currentUrl.Contains(item.URL.ToLower()))
                {
                    item.CssClass = "current";
                }
                else
                {
                    item.CssClass = string.Empty;
                }

            }

            return list;
        }

    }
}