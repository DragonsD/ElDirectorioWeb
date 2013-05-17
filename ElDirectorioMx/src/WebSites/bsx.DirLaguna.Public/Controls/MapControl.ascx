<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MapControl.ascx.cs"
    Inherits="bsx.DirLaguna.Public.Controls.MapControl" %>
<script type="text/javascript">
<%=this.MapScript %>
</script>
<script type="text/javascript">
    $(function () {
        initialize();
    });
</script>
<h2 class="featuredTitle">
    <asp:Label ID="EmptyLabel" runat="server" Text="No hay resultados qué mostrar" Visible="false"></asp:Label>
</h2>
<div id="ResultsetDiv" runat="server" visible="true">
    <h2 class="featuredTitle">
        <asp:Label ID="TitleLabel" runat="server" Text="Resultados."></asp:Label>
    </h2>
    <div class="map">
        <div id="map_canvas" style="width: 100%; height: 100%">
        </div>
    </div>
    <div>
        <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" width="430" height="60"
            id="movie_name" align="middle">
            <param name="movie" value='<%=this.FlashFileName %>' />
            <!--[if !IE]>-->
            <object type="application/x-shockwave-flash" data='<%=this.FlashUrl %>' width="430"
                height="60">
                <param name="movie" value='<%=this.FlashFileName %>' />
                <!--<![endif]-->
                <a href="http://www.adobe.com/go/getflash">
                    <img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif"
                        alt="Get Adobe Flash player" />
                </a>
                <!--[if !IE]>-->
            </object>
            <!--<![endif]-->
        </object>
        <%--    <object type="application/x-shockwave-flash" data='<%=this.FlashUrl %>' width="600"
        height="150">
        <param name="movie" value='<%=this.FlashFileName %>' />
        <param name="wmode" value="transparent" />
    </object>--%>
    </div>
</div>
