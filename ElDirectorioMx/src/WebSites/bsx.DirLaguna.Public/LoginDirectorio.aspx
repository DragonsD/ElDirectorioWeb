<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/NestedBaseMasterPage.master" AutoEventWireup="true" CodeBehind="LoginDirectorio.aspx.cs" Inherits="bsx.DirLaguna.Public.LoginDirectorio" %>
<%@ Register Src="~/Controls/LoginClub.ascx" TagName="LoginClub" TagPrefix="lc" %>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
    <div class="framedContent">
        <p>
            Promociones de Anunciantes para Anunciantes
            <asp:HyperLink runat="server" NavigateUrl="~/Register.aspx" Text="Regístrate ahora"
                ID="RegisterHyperLink">
            </asp:HyperLink>, es muy fácil y gratis.</p>
    </div>
    <div class="">
        <lc:LoginClub ID="LoginControl1" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
