<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SendUploadBannerControl.ascx.cs"
    Inherits="bsx.DirLaguna.Advertiser.Controls.SendUploadBannerControl" %>
<asp:PlaceHolder ID="ControlDiv" runat="server">
    <div id="headerTitle">
        <div class="span-24 last">
            <h3>
                <asp:Label ID="TitleBannerTextBox" runat="server" Text="Banner X"></asp:Label>
            </h3>
            <br />
        </div>
    </div>
    <div class="span-17 prepend-4 last">
        <asp:FileUpload ID="FileFileUpload" runat="server" />
        <%--        <asp:RequiredFieldValidator ID="FileUploadRequiredFieldValidator" runat="server" ControlToValidate="FileFileUpload" ErrorMessage="  * Requerido">
        </asp:RequiredFieldValidator>--%>
    </div>
    <div class="span-24 last">
        <div class="span-4">
            Al dar clic, redirigir al siguiente link:
        </div>
        <div class="span-17 last">
            <asp:TextBox ID="UrlTextBox" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="clear">
        <br />
    </div>
    <hr />
</asp:PlaceHolder>
