<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdvertiserDetailControl.ascx.cs"
    Inherits="bsx.DirLaguna.Public.Controls.AdvertiserDetailControl" %>
<%@ Register Src="GalleryControl.ascx" TagName="GalleryControl" TagPrefix="bsx" %>
<%@ Register Src="AnnounceControl.ascx" TagName="AnnounceControl" TagPrefix="bsx" %>
<script type="text/javascript" src="../Scripts/jquery.lightbox-0.5.min.js"></script>
<link rel="stylesheet" type="text/css" href="../Scripts/jquery.lightbox-0.5.css"
    media="screen" />
<script type="text/javascript">
    $(function () {
        $('#gallery a').lightBox({
            fixedNavigation: true,
            imageLoading: '/Scripts/images/lightbox-ico-loading.gif', 	// (string) Path and the name of the loading icon
            imageBtnPrev: '/Scripts/images/lightbox-btn-prev.gif', 		// (string) Path and the name of the prev button image
            imageBtnNext: '/Scripts/images/lightbox-btn-next.gif', 		// (string) Path and the name of the next button image
            imageBtnClose: '/Scripts/images/lightbox-btn-close.gif', 	// (string) Path and the name of the close btn
            imageBlank: '/Scripts/images/lightbox-blank.gif'			// (string) Path and the name of a blank image (one pixel)

        }); // Select all links in object with gallery ID
        $('#announceDiv a').lightBox({
            fixedNavigation: true,
            imageLoading: '/Scripts/images/lightbox-ico-loading.gif', 	// (string) Path and the name of the loading icon
            imageBtnPrev: '/Scripts/images/lightbox-btn-prev.gif', 		// (string) Path and the name of the prev button image
            imageBtnNext: '/Scripts/images/lightbox-btn-next.gif', 		// (string) Path and the name of the next button image
            imageBtnClose: '/Scripts/images/lightbox-btn-close.gif', 	// (string) Path and the name of the close btn
            imageBlank: '/Scripts/images/lightbox-blank.gif'			// (string) Path and the name of a blank image (one pixel)

        }); // Select all links in object with gallery ID

    });
</script>
<script type="text/javascript">
<%=this.MapScript %>
</script>
<script type="text/javascript">
    $(function () {
        initialize();
    });
</script>
<%--<div class="listItem detailPage">
    <div class="span-1">
        <div class="itemRowMark">
        </div>
    </div>
    <div class="span-9">
        <div class="itemName itemData">
            <asp:Label ID="NameLabel" runat="server"></asp:Label>
        </div>
        <div class="itemAddress itemData">
            <asp:Label ID="AddressLabel" runat="server" />
        </div>
        <div class="itemWebAddress itemData">
            
        </div>
    </div>
    <div class="span-5 last">
        <div class="itemLogo">
            <asp:Image ID="AdvertiserImage" runat="server" />
        </div>
    </div>
    <div class="connectSocial">
        <asp:HyperLink ID="FacebookHyperLink" runat="server" ImageUrl="~/Content/Image/IconFacebook.png"
            Target="_blank" ToolTip="Facebook"></asp:HyperLink>
        <asp:HyperLink ID="TwitterHyperLink" runat="server" ImageUrl="~/Content/Image/IconTwitter.png"
            Target="_blank" ToolTip="Twitter"></asp:HyperLink>
    </div>
    <div class="clear">
    </div>
</div>--%>
<div class="moreDetails">
    <div class="aDetail">
        <div class="span-5">
            <label>
                Acerca de:</label>
        </div>
        <div class="span-10 last">
            <blockquote>
                <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
            </blockquote>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="aDetail">
        <div class="span-5">
            <label>
                Website:</label>
        </div>
        <div class="span-10 last">
            <asp:HyperLink ID="WebPageHyperLink" runat="server" Target="_blank"></asp:HyperLink>
        </div>
        <div class="clear">
        </div>
    </div>
    <asp:PlaceHolder ID="AditionalPlaceHolder" runat="server" Visible="true">
        <div class="aDetail">
            <div class="span-5">
                <label>
                    Información adicional:</label>
            </div>
            <div class="span-10 last">
                <asp:Literal ID="AditionalLiteral" runat="server" Text='<%# Eval("AditionalInfo") %>' />
            </div>
            <div class="clear">
            </div>
        </div>
    </asp:PlaceHolder>
    <div id="PhonesDiv" runat="server" class="aDetail">
        <div class="span-5">
            <label>
                Telefonos:</label>
        </div>
        <div class="span-10 last">
            <asp:BulletedList ID="PhoneBulletedList" runat="server">
            </asp:BulletedList>
        </div>
        <div class="clear">
        </div>
    </div>
    <div id="EmailDiv" runat="server" class="aDetail">
        <div class="span-5">
            <label>
                Correos electronicos:</label>
        </div>
        <div class="span-10 last">
            <asp:DataList ID="EmailDataList" runat="server" RepeatLayout="Flow" RepeatColumns="1"
                RepeatDirection="Vertical" DataSourceID="EmailObjectDataSource">
                <ItemTemplate>
                    <a href='<%# Eval("Address","mailto:{0}?subject=Información")%>'>
                        <asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>' /></a>
                </ItemTemplate>
            </asp:DataList>
            <asp:ObjectDataSource ID="EmailObjectDataSource" runat="server" SelectMethod="FetchAdvertiserEmails"
                TypeName="bsx.DirLaguna.Dal.EmailController">
                <SelectParameters>
                    <asp:Parameter Name="advertiserId" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
        <div class="clear">
        </div>
    </div>
    <div id="divMapa" class="aDetail divMapa" runat="server">
        <%--<div class="span-5">
            <label>
                Mapa:</label>
        </div>
        <div class="span-10 last">
            <div id="map_canvas" style="width: 390px; height: 240px">
            </div>
        </div>
        <div class="clear">
        </div>--%>
    </div>
    <div id="galleryDiv" class="aDetail" runat="server">
        <div class="span-5">
            <label>
                Galerias:</label>
        </div>
        <div class="span-10 last">
            <div id="gallery">
                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="GalleriesObjectDataSource">
                    <ItemTemplate>
                        <bsx:GalleryControl ID="GalleryControl1" GalleryId='<%# Eval("GalleryId") %>' runat="server" />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <div id="OfficesDiv" runat="server" class="aDetail">
        <div class="span-5">
            <label>
                Sucursales:</label>
        </div>
        <div class="span-10 last">
            <asp:DataList ID="OfficeDataList" runat="server" DataSourceID="OfficeDataSource">
                <ItemTemplate>
                    <b>
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' /></b>
                    <br />
                    Dirección:
                    <asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("CompleteAddress") %>' />
                    <br />
                    <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City.Name") %>' />
                </ItemTemplate>
            </asp:DataList>
            <asp:ObjectDataSource ID="OfficeDataSource" runat="server" SelectMethod="FetchAdvertiserOffices"
                TypeName="bsx.DirLaguna.Dal.OfficeController">
                <SelectParameters>
                    <asp:Parameter Name="advertiserId" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
        <div class="clear">
        </div>
    </div>
    <div id="AnnouncesDiv" class="aDetail" runat="server">
        <div class="span-5">
            <label>
                Anuncio:</label>
        </div>
        <div class="span-10 last">
            <div id="announceDiv">
                <bsx:AnnounceControl ID="AnnounceControl1" runat="server" />
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="clear">
    </div>
    <div id="CouponDiv" class="aDetail" runat="server">
        <div class="span-5">
            <label>
                Cupones</label>
        </div>
        <div class="content">
            <asp:LinkButton ID="CouponLinkButton" runat="server">Ver cupones</asp:LinkButton>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="clear">
    </div>
    <asp:PlaceHolder ID="PagesPlaceHolder" runat="server">
        <div class="aDetail">
            <div class="span-5">
                <label>
                    Pagina en directorio:</label>
            </div>
            <div class="span-10 last">
                <asp:BulletedList ID="PagesBulletedList" CssClass="hMenu categoriesList" runat="server"
                    DisplayMode="HyperLink">
                </asp:BulletedList>
            </div>
            <div class="clear">
            </div>
        </div>
    </asp:PlaceHolder>
    <div id="CategoriesDiv" runat="server" class="aDetail">
        <div class="span-5">
            <label>
                Categorías relacionadas:</label>
        </div>
        <div class="span-10 last">
            <asp:BulletedList ID="CategoriesBulletedList" CssClass="hMenu categoriesList" runat="server"
                DisplayMode="HyperLink">
            </asp:BulletedList>
        </div>
        <div class="clear">
        </div>
    </div>
    <div id="QrDiv" runat="server" class="aDetail">
        <div class="span-5">
            <label>
                Consúltame en tu smartphone:</label>
        </div>
        <div class="span-10 last">
            <asp:Image ID="QrImage" runat="server" AlternateText="[QrCode]" />
        </div>
        <div class="clear">
        </div>
    </div>
    <asp:PlaceHolder ID="ConnectSocialPlaceHolder" runat="server">
        <div class="aDetail">
            <div class="span-5">
                <label>
                    Social:
                </label>
            </div>
            <div class="span-10 last">
                <div class="connectSocial">
                    <asp:HyperLink ID="FacebookHyperLink" runat="server" ImageUrl="~/Content/Image/IconFacebook.png"
                        Target="_blank" ToolTip="Facebook"></asp:HyperLink>
                    <asp:HyperLink ID="TwitterHyperLink" runat="server" ImageUrl="~/Content/Image/IconTwitter.png"
                        Target="_blank" ToolTip="Twitter"></asp:HyperLink>
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
    </asp:PlaceHolder>
    <div class="shareArea">
        <div id="fb-root">
        </div>
        <script>            (function (d, s, id) {
                var js, fjs = d.getElementsByTagName(s)[0];
                if (d.getElementById(id)) return;
                js = d.createElement(s); js.id = id;
                js.src = "//connect.facebook.net/en_US/all.js#xfbml=1";
                fjs.parentNode.insertBefore(js, fjs);
            } (document, 'script', 'facebook-jssdk'));</script>
        <div class="fb-like" data-send="true" data-layout="button_count" data-width="140"
            data-show-faces="true" data-font="tahoma">
        </div>
        <div class="twitContainer">
            <a href="https://twitter.com/share" class="twitter-share-button" data-lang="es">Twittear</a>
            <script>                !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = "//platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");</script>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="clear">
    </div>
</div>
<div id="commentsArea">
    <div id="disqus_thread">
    </div>
    <script type="text/javascript">
        /* * * CONFIGURATION VARIABLES: EDIT BEFORE PASTING INTO YOUR WEBPAGE * * */
        var disqus_shortname = 'eldirectorio'; // required: replace example with your forum shortname

        /* * * DON'T EDIT BELOW THIS LINE * * */
        (function () {
            var dsq = document.createElement('script'); dsq.type = 'text/javascript'; dsq.async = true;
            dsq.src = 'http://' + disqus_shortname + '.disqus.com/embed.js';
            (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(dsq);
        })();
    </script>
    <noscript>
        Please enable JavaScript to view the <a href="http://disqus.com/?ref_noscript">comments
            powered by Disqus.</a></noscript>
    <a href="http://disqus.com" class="dsq-brlink">comments powered by <span class="logo-disqus">
        Disqus</span></a>
    <%--<div id="disqus_thread">
    </div>
    <script type="text/javascript">
        var disqus_developer = 1;
    </script>
    <script type="text/javascript">
        /* * * CONFIGURATION VARIABLES: EDIT BEFORE PASTING INTO YOUR WEBPAGE * * */
        var disqus_shortname = 'directoriolaguna'; // required: replace example with your forum shortname

        /* * * DON'T EDIT BELOW THIS LINE * * */
        (function () {
            var dsq = document.createElement('script'); dsq.type = 'text/javascript'; dsq.async = true;
            dsq.src = 'http://' + disqus_shortname + '.disqus.com/embed.js';
            (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(dsq);
        })();
    </script>
    <noscript>
        Please enable JavaScript to view the <a href="http://disqus.com/?ref_noscript">comments
            powered by Disqus.</a></noscript>
    <a href="http://disqus.com" class="dsq-brlink">blog comments powered by <span class="logo-disqus">
        Disqus</span></a>--%>
</div>
<div style="display: none">
    <asp:Label ID="TagsLabel" runat="server" Font-Italic="true"></asp:Label>
</div>
<asp:ObjectDataSource ID="GalleriesObjectDataSource" runat="server" SelectMethod="FetchAllByAdvertiserId"
    TypeName="bsx.DirLaguna.Dal.GalleryController">
    <SelectParameters>
        <asp:Parameter Name="advertiserId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
