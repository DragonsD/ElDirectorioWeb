<%@ Page Title="ElDirectorio.mx" Language="C#" MasterPageFile="~/Shared/Special.Master" AutoEventWireup="true" CodeBehind="Portada.aspx.cs" Inherits="bsx.DirLaguna.Public.Portada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Refresh" content="10; url=<%=this.HomeUrl %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Literal ID="XLiteral" runat="server">
    </asp:Literal>
</asp:Content>
