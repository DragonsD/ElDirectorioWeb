<%@ Page Language="C#"  MasterPageFile="~/Shared/Base.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="bsx.DirLaguna.Mobile.Categories" %>

<%@ Register src="Controls/CategoriesControl.ascx" tagname="CategoriesControl" tagprefix="bsx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ButtonContainer">
        <asp:HyperLink ID="BackUpHyperLink" runat="server" CssClass="back">Regresar</asp:HyperLink>
    </div>
    <div class="itemContent">
        <h1><asp:Label ID="titleLabel" runat="server" Text="Directorio"></asp:Label></h1>
        <bsx:CategoriesControl ID="CategoriesControl1" runat="server" />
    </div>
    <div class="ButtonContainer">
        <asp:HyperLink ID="BackBottomHyperLink" runat="server" CssClass="back">Regresar</asp:HyperLink>
    </div>

</asp:Content>

