<%@ Page Title="Nueva Ciudad" Language="C#" MasterPageFile="~/Shared/Normal.master" AutoEventWireup="true" CodeBehind="CitiesForm.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.CitiesForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Ciudad</h1>
    <hr />
    <h3>
        Datos Generales</h3>
    <p>
        <div class="span-4">
            Nombre
        </div>
        <div class="span-8 append-12 last">
            <asp:TextBox ID="NameTextBox" runat="server" CssClass="text"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                ErrorMessage="Requerido" ControlToValidate="NameTextBox"></asp:RequiredFieldValidator>
        </div>
    </p>
    <p>
        <div class="span-24 last">
            <div class="SearchButtonContainer">
                <asp:LinkButton ID="SaveButton" runat="server" Text="Guardar" class="button" />
                <asp:LinkButton ID="BackButton" runat="server" Text="Regresar" CausesValidation="false" class="clearSearch"></asp:LinkButton>
            </div>
        </div>
    </p>

</asp:Content>
