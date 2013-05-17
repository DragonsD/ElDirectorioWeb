<%@ Page Title="Cupones" Language="C#" MasterPageFile="~/Shared/NestedBaseMasterPage.Master" AutoEventWireup="True"
    CodeBehind="CouponDisplayDirectorio.aspx.cs" Inherits="bsx.DirLaguna.Public.CouponDisplayDirectorio" %>
<%@ Register Src="Controls/CouponCategoriesControl.ascx" TagName="CatCtrl" TagPrefix="bsx" %>
<%@ Register Src="Controls/ActiveCouponsControl.ascx" TagName="CouponsCtrl" TagPrefix="bsx" %>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
    <div class="span-4">
        <bsx:CatCtrl ID="CatCtrl1" runat="server" />
    </div>
    <h4>Promociones de Anunciantes para Anunciantes</h4>
    <div class="span-6">
        <div class="span-4">
            <asp:DropDownList ID="ddlCityCouponFilter" runat="server" DataTextField="Name" DataValueField="CityId">
                <asp:ListItem Text="Todas las ciudades" Value="0">
                </asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="span-2">
            <asp:Button runat="server" ID="btnFilterCityCoupon" Text="Filtrar" OnClick="btnFilterCityCoupon_Click"/>
        </div>
    </div>
    <div class="span-11 last">
    <div class="framedContent">
        <h4>
            <asp:HyperLink runat="server" NavigateUrl="~/RegisterClub.aspx" Text="Cuentas con una tarjeta de Club El Directorio Registralo Aquí" ID="RegisterHyperLink" />
        </h4>
    </div>
        <bsx:CouponsCtrl ID="CouponsCtrl1" runat="server" IsClub="true"/>
    </div>
    <div class="clear">
    </div>
</asp:Content>

