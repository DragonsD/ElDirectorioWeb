<%@ Page Title="Ingresar digito verificador" Language="C#" MasterPageFile="~/Shared/Normal.master" AutoEventWireup="true"
    CodeBehind="DvUpdaterForm.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.DvUpdaterForm" %>

<%@ Register Src="../Controls/AdvertiserInfoControl.ascx" TagName="AdvertiserInfoCtrl"
    TagPrefix="bsx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Editar Digito Verificador</h1>
    <hr />
    <p><bsx:AdvertiserInfoCtrl ID="AdvertiserInfoCtrl1" runat="server"></bsx:AdvertiserInfoCtrl></p>
    <br />
    <p>
        <div class="span-16">
            <div class="span-4">
                Digito Verificador
            </div>
            <div class="span-11">
                <asp:TextBox ID="DvTextBox" runat="server" CssClass="text">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="dvRequiredFieldValidator" runat="server" Display="Dynamic"
                    ErrorMessage="Requerido" ControlToValidate="DvTextBox"></asp:RequiredFieldValidator>
            </div>
        </div>
    </p>
    <p>
        <div class="span-13 prepend-11 last">
            <div class="SearchButtonContainer">
                <asp:LinkButton ID="SaveButton" runat="server" Text="Guardar" class="button" />
                <asp:LinkButton ID="BackButton" runat="server" Text="Regresar" CausesValidation="false"
                    class="clearSearch"></asp:LinkButton>
            </div>
        </div>
    </p>
</asp:Content>
