<%@ Page Title="Registro al Club El Directorio" Language="C#" MasterPageFile="~/Shared/NestedBaseMasterPage.Master"
    AutoEventWireup="true" CodeBehind="RegisterClub.aspx.cs" Inherits="bsx.DirLaguna.Public.RegisterClub" %>
<asp:Content ID="Content6" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
<div class="framedContent">
    <div class="filterField span-10 whatField">
        <asp:TextBox placeholder="No. Folio de la Tarjeta" ID="tbTArjeta"
            runat="server" CssClass="text whatField"></asp:TextBox>
            <div class="aDetail content-box-content">
            <div class="ButtonContainer">
                <asp:LinkButton ID="btnEnviar" CssClass="BackButton" runat="server" Text="Enviar"
                    CausesValidation="false"></asp:LinkButton>
            </div>
        </div>
    </div>
</div>
</asp:Content>


