<%@ Page Title="ElDirectorio.mx - Cupones" Language="C#" MasterPageFile="~/Shared/Base.Master"
    AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="bsx.DirLaguna.Mobile.Login" %>

<%@ Register Src="Controls/LoginControl.ascx" TagName="LoginControl" TagPrefix="bsx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Inicia sesión</h1>
    <p>
        Inicia sesion para acceder a los cupones. Si no tienes una cuenta
        <asp:HyperLink runat="server" NavigateUrl="~/Register.aspx" Text="Registrate ahora"
            ID="RegisterHyperLink">
        </asp:HyperLink>, es muy fácil y gratis.</p>
    </p>
    <div class="processImg">
        <div class="filterContainer">
            <div id="filters">
                <bsx:LoginControl ID="LoginControl1" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
