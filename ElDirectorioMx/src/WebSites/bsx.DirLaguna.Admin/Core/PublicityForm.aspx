<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Normal.master" AutoEventWireup="true" CodeBehind="PublicityForm.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.PublicityForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="span-16">
        <div class="span-4">
            Ciudad:
        </div>
        <div class="span-12">
            <asp:DropDownList ID="CiudadDropDownList" runat="server" Height="20px" Width="204px"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="CiudadRequired" runat="server" Display="Dynamic"
                    ErrorMessage="Requerido" ControlToValidate="CiudadDropDownList" InitialValue=""></asp:RequiredFieldValidator>
        </div>
        <div class="span-4">
            Imagen:
        </div>
        <div class="span-12 last">
            <asp:FileUpload ID="PublicityFileUpload" runat="server" /><br />
            Imagen de 100px de alto y 260px de ancho
        </div>

        <div class="span-4">
            URL de Publicidad:
        </div>
        <div class="span-12">
            <asp:TextBox ID="LinkTextBox" runat="server" Height="16px" Width="204px"></asp:TextBox>
        </div>

        <div class="span-4">
            Prioridad:
        </div>
        <div class="span-12">
            <asp:TextBox ID="PrioridadTextBox" runat="server" Height="16px" Width="204px"></asp:TextBox>
            <br />
            La Prioridad mas alta es 8. Esto para el posicionamiento de los Banners
            <asp:RequiredFieldValidator ID="PrioridadRequired" runat="server" Display="Dynamic"
                    ErrorMessage="Requerido" ControlToValidate="PrioridadTextBox" InitialValue=""></asp:RequiredFieldValidator>
        </div>
    </div>
            <div class="span-16 last">
            <div class="SearchButtonContainer">
                <asp:LinkButton ID="SaveButton" runat="server" Text="Guardar" class="button" />
                <br />
                <asp:LinkButton ID="BackButton" runat="server" Text="Regresar" CausesValidation="false"
                    class="clearSearch"></asp:LinkButton>
            </div>
        </div>
</asp:Content>
