<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AnnounceControl.ascx.cs"
    Inherits="bsx.DirLaguna.Admin.Controls.AnnounceControl" %>
<p>
    <div class="span-24 last">
        <div class="span-19">
            <div class="span-19 last">
                <div class="span-3">
                    Anunciante
                </div>
                <div class="span-8">
                    <asp:DropDownList ID="AdvertisersDropDownList" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="span-3 last">
                    <asp:RequiredFieldValidator ID="AdvertisersDropDownListRequiredFieldValidator" runat="server"
                        ValidationGroup="AddItem" Display="Dynamic" ErrorMessage="*Obligatorio" ControlToValidate="AdvertisersDropDownList"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="span-19 last">
                <div class="span-3">
                    Imagen
                </div>
                <div class="span-6">
                    <asp:FileUpload ID="PictureUpload" runat="server" />
                </div>
                <div class="span-3">
                    <asp:RequiredFieldValidator ErrorMessage="*Obligatorio" ID="PictureUploadRequiredFieldValidator" Display="Dynamic"
                        runat="server" ControlToValidate="PictureUpload" ValidationGroup="AddItem">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="span-9 last">
                    Imagen de 950px X 350px maximo (jpg, jpeg, png o gif)
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="span-5 last">
            <asp:Image ImageUrl="<%#this.PathImage %>" ID="PageImage" runat="server" Width="160px" Height="160px" />
        </div>
    </div>
</p>
<p>
    <div class="span-24 last">
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
