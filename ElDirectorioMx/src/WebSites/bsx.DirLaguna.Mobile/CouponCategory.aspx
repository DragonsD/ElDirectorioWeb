<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Base.Master" AutoEventWireup="true"
    CodeBehind="CouponCategory.aspx.cs" Inherits="bsx.DirLaguna.Mobile.CouponCategory" %>

<%@ Register Src="Controls/CouponCategoriesControl.ascx" TagName="CouponCategoriesControl"
    TagPrefix="bsx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ButtonContainer">
        <asp:HyperLink ID="BackUpHyperLink" CssClass="back" runat="server">Regresar</asp:HyperLink>
    </div>
    <div class="clear"></div>
    <h1>
        Cupones</h1>
    <div class="span-3">
        <bsx:CouponCategoriesControl ID="CatCtrl1" runat="server" />
    </div>
    <div class="ButtonContainer">
        <asp:HyperLink ID="BackBottomHyperLink" CssClass="back" runat="server">Regresar</asp:HyperLink>
    </div>
</asp:Content>
