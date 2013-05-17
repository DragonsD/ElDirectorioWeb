<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PictureControl.ascx.cs" Inherits="bsx.DirLaguna.Advertiser.Controls.PictureControl" %>
<p>
    <div class="span-24 last">
        <div class="span-4">
            Nombre
        </div>
        <div class="span-8">
            <asp:TextBox ID="DescriptionTextBox" runat="server" CssClass="text"></asp:TextBox>
        </div>
        <div class="span-2 last">
            <asp:RequiredFieldValidator ID="DescriptionRequiredFieldValidator" runat="server"
                ValidationGroup="AddItem" Display="Dynamic" ErrorMessage="*Obligatorio" ControlToValidate="DescriptionTextBox"></asp:RequiredFieldValidator>
        </div>
    </div>
</p>
<p>
    <div class="span-24 last">
        <div class="span-4">
            Imagen
        </div>
        <div class="span-8">
            <asp:FileUpload ID="PictureUpload" runat="server" />
        </div>
        <div class="span-2">
            <asp:RequiredFieldValidator ErrorMessage="*Obligatorio" ID="PictureUploadRequiredFieldValidator"
                runat="server" ControlToValidate="PictureUpload" ValidationGroup="AddItem">
            </asp:RequiredFieldValidator>
        </div>
        <div class="span-10 last">
            Imagen de 950px X 350px maximo (jpg, jpeg, png o gif)
        </div>
        <div class="clear">
        </div>
    </div>
</p>
<div class="clear">
    <br />
    <br />
</div>
<p>
    <div class="span-24 last">
        <div class="SearchButtonContainer">
            <asp:LinkButton ID="SaveButton" runat="server" Text="Guardar" class="button"
                ValidationGroup="AddItem" />
            <asp:LinkButton ID="CleanButton" runat="server" Text="Limpiar" CausesValidation="false" class="clearSearch"></asp:LinkButton>
        </div>
    </div>
</p>
<hr />

