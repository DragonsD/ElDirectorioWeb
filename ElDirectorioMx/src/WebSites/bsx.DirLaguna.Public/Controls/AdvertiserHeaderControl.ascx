<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdvertiserHeaderControl.ascx.cs"
    Inherits="bsx.DirLaguna.Public.Controls.AdvertiserHeaderControl" %>
<div class="detailHeader">
    <h1>
        <asp:Label ID="NameLabel" runat="server">
        </asp:Label>
    </h1>
    <div class="logoContainer span-6">
        <asp:Image ID="LogoImage" runat="server" />
    </div>
    <div class="map span-17 last">
        <div id="map_canvas" style="width: 100%; height: 100%; display:none;">
        </div>
        <script type="text/javascript">
            $(document).ready(function () { if ($(".divMapa").length > 0) $("#map_canvas").show(); });
        </script>
    </div>
</div>
