using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bsx.DirLaguna.CommonWeb;
using bsx.DirLaguna.Admin.Code;
using bsx.DirLaguna.CommonWeb.Session;

namespace bsx.DirLaguna.Admin.Controls
{
    public partial class MenuControl : System.Web.UI.UserControl
    {
        public bool IsPrimary { get { return SessionValues.IsPrimary; } }

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

            // Anunciantes Primarios
            if (this.IsPrimary)
                list.Add(new MenuItemUI { Text = "Franquiciatarios", URL = ResolveUrl(Navigation.FranchiseeDisplay), Text2 = "|" });

            // Anunciantes
            list.Add(new MenuItemUI { Text = "Mis Anunciantes", URL = ResolveUrl(Navigation.AdvertiserDisplay), Text2 = "|" });

            // Categorias
            if (SessionValues.PersonalTypeId == Dal.PersonalTypeEnum.UserSuperAdmin)
                list.Add(new MenuItemUI { Text = "Categorías", URL = ResolveUrl(Navigation.CategoriesDisplay), Text2 = "|" });

            // Tarjetas del Club
            if (SessionValues.PersonalTypeId == Dal.PersonalTypeEnum.UserSuperAdmin)
                list.Add(new MenuItemUI { Text = "Tarjetas del Club", URL = ResolveUrl(Navigation.ClubCardForm), Text2 = "|" });

            // Publicidad General
            if (this.IsPrimary)
                list.Add(new MenuItemUI { Text = "Publicidad Gen.", URL = ResolveUrl(Navigation.GenPublicityForm), Text2 = "|" });

            // Banner Lateral
            if (SessionValues.PersonalTypeId == Dal.PersonalTypeEnum.UserSuperAdmin)
                list.Add(new MenuItemUI { Text = "Banners Laterales", URL = ResolveUrl(Navigation.PublicityDisplay), Text2 = "|" });

            //Publicidad por Imagen
            if (SessionValues.PersonalTypeId == Dal.PersonalTypeEnum.UserSuperAdmin)
                list.Add(new MenuItemUI { Text = "Publicidad Img", URL = ResolveUrl(Navigation.PublicityForm), Text2 = "|" });

            // Usuarios
            if (SessionValues.PersonalTypeId == Dal.PersonalTypeEnum.UserAdmin)
                list.Add(new MenuItemUI { Text = "Usuarios", URL = ResolveUrl(Navigation.UserDisplay), Text2 = "|" });

            // Ciudades
            //if (SessionValues.PersonalTypeId == Dal.PersonalTypeEnum.UserSuperAdmin)
            //    list.Add(new MenuItemUI { Text = "Ciudades", URL = ResolveUrl(Navigation.CitiesDisplay), Text2 = "|" });

            // Banner
            if (this.IsPrimary)
                list.Add(new MenuItemUI { Text = "Banner", URL = ResolveUrl(Navigation.BannerDisplay), Text2 = "|" });

            // Revista
            //list.Add(new MenuItemUI { Text = "Revista", URL = ResolveUrl(Navigation.PageDisplay), Text2 = "|" });

            // Actualizar iOs
            if (SessionValues.PersonalTypeId == Dal.PersonalTypeEnum.UserSuperAdmin)
                list.Add(new MenuItemUI { Text = "Act. Apps", URL = ResolveUrl(Navigation.iOsUpdateForm), Text2 = "|" });

            // Preportada
            if (this.IsPrimary)
            {
                list.Add(new MenuItemUI { Text = "Portada Web", URL = ResolveUrl(Navigation.PrePage), Text2 = "|" });
                list.Add(new MenuItemUI { Text = "Portada Apps", URL = ResolveUrl(Navigation.PrePageiOs), Text2 = "|" });
                list.Add(new MenuItemUI { Text = "Correos", URL = ResolveUrl(Navigation.EmailDisplay), Text2 = "|" });

                list.Add(new MenuItemUI { Text = "Franquicias", URL = ResolveUrl(Navigation.FranchiseePage), Text2 = "|" });
                list.Add(new MenuItemUI { Text = "Anúnciate", URL = ResolveUrl(Navigation.AdYourSelfPage), Text2 = "|" });
            }



            // Conceptos
            if (this.IsPrimary)
                list.Add(new MenuItemUI { Text = "Conceptos", URL = ResolveUrl(Navigation.AccountConceptForm), Text2 = "|" });

            return list;
        }
    }
}