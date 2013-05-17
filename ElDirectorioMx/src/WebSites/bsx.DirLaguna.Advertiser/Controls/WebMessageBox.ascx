<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebMessageBox.ascx.cs" Inherits="bsx.DirLaguna.Advertiser.Controls.WebMessageBox" %>
<asp:Panel ID="MessageBoxPanel" runat="server" CssClass="MessageContainer" Style="display: none">
    <asp:HyperLink runat="server" ID="CloseButtonLink" CssClass="close-button" Text=""
        NavigateUrl="javascript:void(0);" EnableViewState="false" Visible="true">
    </asp:HyperLink>
    <asp:Literal ID="MessageLiteral" runat="server" EnableViewState="false"></asp:Literal>
</asp:Panel>
<div class="container">
</div>
<script type="text/javascript">
    function WebMessageBox_ShowNoticeMessage(message) {
        var msg = "<ul class='notice'><li>" + message + "</li></ul>";
        var $anchorHtml = $('#<%= this.CloseButtonLink.ClientID %>');
        var $messageBox = $('#<%= this.MessageBoxPanel.ClientID %>');
        $messageBox.html(msg);
        $messageBox.prepend($anchorHtml);
        $messageBox.css('display', 'block');
    }

    function WebMessageBox_Hide() {
        $('#<%= this.MessageBoxPanel.ClientID %>').hide();
    }
</script>
