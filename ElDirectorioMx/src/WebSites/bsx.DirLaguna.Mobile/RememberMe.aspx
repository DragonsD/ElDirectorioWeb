<%@ Page Title="ElDirectorio.mx - Recuperar contraseña" Language="C#" MasterPageFile="~/Shared/Base.Master"
    AutoEventWireup="true" CodeBehind="RememberMe.aspx.cs" Inherits="bsx.DirLaguna.Mobile.RememberMe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Recuperar contraseña</h1>
    <asp:Label ID="Msg" runat="server" ForeColor="maroon" /><br />
    <br />
    <div class="filterContainer">
        <div id="filters">
            <label class="requiredLabel">
                Nombre de usuario
                <asp:RequiredFieldValidator ID="UsernameRequiredValidator" runat="server" ControlToValidate="UsernameTextBox"
                    ForeColor="red" Display="Dynamic" ErrorMessage="Requerido" />
            </label>
            <asp:TextBox ID="UsernameTextBox" Columns="30" runat="server" AutoPostBack="false"
                CssClass="text formField" />
            <div class="ButtonContainer filterField filterFieldButton">
                <asp:Button ID="EmailPasswordButton" Text="Enviar a mi Email" runat="server" />
            </div>
            <div class="clear">
            <br />
            </div>
            <div class="recoverPass ButtonContainer" style="text-align:center;">
                <a href="/Login.aspx" title="Ir Login">Ir a Login :)</a>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
