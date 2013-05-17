<%@ Page Title="Cupones" Language="C#" MasterPageFile="~/Shared/NestedBaseMasterPage.Master" AutoEventWireup="true"
    CodeBehind="CouponDisplay.aspx.cs" Inherits="bsx.DirLaguna.Public.CouponDisplay" %>
<%@ Register Src="Controls/CouponCategoriesControl.ascx" TagName="CatCtrl" TagPrefix="bsx" %>
<%@ Register Src="Controls/ActiveCouponsControl.ascx" TagName="CouponsCtrl" TagPrefix="bsx" %>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
    <div class="span-4">
        <bsx:CatCtrl ID="CatCtrl1" runat="server" />
    </div>
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
    </div>
        <bsx:CouponsCtrl ID="CouponsCtrl1" runat="server" IsClub="false"/>
    </div>
    <div class="clear">
    </div>
</asp:Content>
