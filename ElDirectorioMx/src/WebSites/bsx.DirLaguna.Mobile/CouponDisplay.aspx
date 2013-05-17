<%@ Page Title="ElDirectorio.mx - Cupones" Language="C#" MasterPageFile="~/Shared/Base.Master" AutoEventWireup="true" CodeBehind="CouponDisplay.aspx.cs" Inherits="bsx.DirLaguna.Mobile.CouponDisplay" %>

<%@ Register src="Controls/ActiveCouponsControl.ascx" tagname="ActiveCouponsControl" tagprefix="bsx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ButtonContainer">
        <asp:HyperLink ID="BackUpHyperLink" CssClass="back" runat="server">Regresar</asp:HyperLink>
    </div>
    <div class="clear">
    </div>
    <h1><asp:Label ID="CategoryNameLabel" runat="server"></asp:Label></h1>
    <div class="span-13 last">
        <bsx:ActiveCouponsControl ID="CouponsCtrl1" runat="server" />
    </div>
    <div class="clear">
    </div>
    <div class="ButtonContainer">
        <asp:HyperLink ID="BackBottomHyperLink" CssClass="back" runat="server">Regresar</asp:HyperLink>
    </div>
</asp:Content>
