<%@ Page Title="Cuponera" Language="C#" MasterPageFile="~/Shared/Admin.Master" AutoEventWireup="true" CodeBehind="CouponSetForm.aspx.cs" Inherits="bsx.DirLaguna.Advertiser.CouponSetForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h1>
        <asp:Label ID="OfficeNameLabel" runat="server" Text="Nueva Cuponera"></asp:Label></h1>
    <hr />
    <p>
        <div class="span-16">
            <h3>
                Cuponera</h3>
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
                <div class="span-4">
                    Descripcion
                </div>
                <div class="span-8">
                    <asp:TextBox ID="DescriptionTextBox" runat="server" CssClass="text"></asp:TextBox>
                </div>
                <div class="span-2 last">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="DescriptionTextBox"></asp:RequiredFieldValidator>
                </div>
            </p>
        </div>
    </p>
    <div class="clear">
    </div>
    <p>
        <div class="span-24 last">
            <div class="SearchButtonContainer">
                <asp:LinkButton ID="SaveButton" runat="server" Text="Guardar" class="button" />
                <asp:LinkButton ID="BackButton" runat="server" Text="Regresar" CausesValidation="false"
                    class="clearSearch"></asp:LinkButton>
            </div>
        </div>
    </p>
</asp:Content>
