<%@ Page Title="Mi cuenta" Language="C#" MasterPageFile="~/Shared/Admin.Master" AutoEventWireup="true"
    CodeBehind="AccountForm.aspx.cs" Inherits="bsx.DirLaguna.Advertiser.AccountForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="menuDiv">
        <p>
            <asp:HyperLink ID="MyAccountHyperLink1" runat="server" Text="Mi Cuenta"></asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="AdvertiserHyperlink" runat="server" Text="Datos de mi negocio"></asp:HyperLink>
        </p>
        <asp:PlaceHolder ID="OfficesPlaceHolder" runat="server">
            <p>
                <asp:HyperLink ID="OfficesHyperLink" runat="server" Text="Mis sucursales" Visible="false"></asp:HyperLink>
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="GalleriesPlaceHolder" runat="server">
            <p>
                <asp:HyperLink ID="GalleriesHyperLink" runat="server" Text="Mis Galerias" Visible="false"></asp:HyperLink>
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="CouponsPlaceHolder" runat="server">
            <p>
                <asp:HyperLink ID="CouponSetHyperLink" runat="server" Text="Mis Cuponeras" Visible="false"></asp:HyperLink>
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="BannersPlaceHolder" runat="server">
            <p>
                <asp:HyperLink ID="BannerHyperLink" runat="server" Text="Banners" Visible="false"></asp:HyperLink>
            </p>
        </asp:PlaceHolder>
        <p>
            <asp:HyperLink ID="LogoutHyperLink" runat="server" Text="Salir"></asp:HyperLink>
        </p>
    </div>
</asp:Content>
