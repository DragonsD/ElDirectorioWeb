<%@ Page Title="Nueva Categoria" Language="C#" MasterPageFile="~/Shared/Normal.master"
    AutoEventWireup="true" CodeBehind="CategoryForm.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.CategoryForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Categoria</h1>
    <hr />
    <h3>
        Datos Generales</h3>
    <p>
        <div class="span-4">
            Nombre
        </div>
        <div class="span-8">
            <asp:TextBox ID="NameTextBox" runat="server" CssClass="text"></asp:TextBox>
        </div>
        <div class="span-2 last">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                ErrorMessage="Requerido" ControlToValidate="NameTextBox"></asp:RequiredFieldValidator>
        </div>
    </p>
    <p>
        <div class="span-24 last">
            <div class="span-4">
                Imagen
            </div>
            <div class="span-12 last">
                <div class="span-6">
                    <asp:PlaceHolder ID="ImagePlaceHolder" runat="server">
                        <img src='<%=this.UrlImage %>' alt="Image" />
                    </asp:PlaceHolder>
                </div>
                <div class="span-6 last">
                    <asp:FileUpload ID="CategoryImageFileUpload" runat="server" />
                </div>
            </div>
        </div>
    </p>
    <p>
        <div class="span-10 prepend-4 last">
            <asp:CheckBox ID="FeaturedCheckbox" runat="server" Text="Categoría destacada" />
        </div>
    </p>
    <p>
        <div class="span-6 prepend-18">
            <div class="SearchButtonContainer">
                <asp:LinkButton ID="SaveButton" runat="server" Text="Guardar" class="button" />
                <asp:LinkButton ID="BackButton" runat="server" Text="Regresar" CausesValidation="false"
                    class="clearSearch"></asp:LinkButton>
            </div>
        </div>
    </p>
</asp:Content>
