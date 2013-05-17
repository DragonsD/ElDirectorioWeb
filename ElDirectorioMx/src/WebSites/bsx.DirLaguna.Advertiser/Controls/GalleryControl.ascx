<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GalleryControl.ascx.cs" Inherits="bsx.DirLaguna.Advertiser.Controls.GalleryControl" %>
<p>
    <div class="span-4">
        Nombre
    </div>
    <div class="span-8 append-12 last">
        <asp:TextBox ID="GalleryNameTextBox" runat="server" CssClass="text"></asp:TextBox>
        <asp:RequiredFieldValidator ID="GalleryNameRequiredFieldValidator" runat="server"
            Display="Dynamic" ErrorMessage="Requerido" ControlToValidate="GalleryNameTextBox"></asp:RequiredFieldValidator>
    </div>
</p>
<p>
    <div class="span-24 last">
        <div class="SearchButtonContainer">
            <asp:LinkButton ID="SaveButton" runat="server" Text="Guardar" class="button" />
            <asp:LinkButton ID="CleanButton" runat="server" Text="Limpiar" CausesValidation="false"
                class="clearSearch"></asp:LinkButton>
        </div>
    </div>
</p>
