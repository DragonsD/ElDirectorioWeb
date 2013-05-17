<%@ Page Title="Inicia sesión" Language="C#" MasterPageFile="~/Shared/NestedBaseMasterPage.Master"
    AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="bsx.DirLaguna.Public.Login" %>

<%@ Register Src="Controls/LoginControl.ascx" TagName="LoginControl" TagPrefix="bsx" %>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <style type="text/css">
    </style>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
    <div class="framedContent">
        <p>
            Inicia sesión para acceder a los cupones. Si no tienes una cuenta
            <asp:HyperLink runat="server" NavigateUrl="~/Register.aspx" Text="Regístrate ahora"
                ID="RegisterHyperLink">
            </asp:HyperLink>, es muy fácil y gratis.</p>
    </div>
    <div class="">
        <bsx:LoginControl ID="LoginControl1" runat="server" />
    </div>
</asp:Content>