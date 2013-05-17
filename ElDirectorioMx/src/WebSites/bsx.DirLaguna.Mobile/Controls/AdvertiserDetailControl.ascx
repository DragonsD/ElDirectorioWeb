<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdvertiserDetailControl.ascx.cs"
    Inherits="bsx.DirLaguna.Mobile.Controls.AdvertiserDetailControl" %>
<%@ Register Src="~/Controls/GalleryControl.ascx" TagName="GalleryControl" TagPrefix="bsx" %>
<%@ Register Src="~/Controls/AnnounceControl.ascx" TagName="AnnounceControl" TagPrefix="bsx" %>
<script type="text/javascript">
<%=this.MapScript %>
</script>
<script type="text/javascript">
    $(function () {
        initialize();
    });
</script>
<div class="detailPage">
    <div class="itemContentLogo">
        <div class="itemLogo">
            <asp:Image ID="AdvertiserImage" runat="server" />
        </div>
    </div>
    <div class="listItem ">
        <div class="itemRox">
            <div class="itemRowMark">
            </div>
        </div>
        <div class="aDetail">
            <div class="header">
                <h4>
                    <asp:Label ID="NameLabel" runat="server"></asp:Label>
                </h4>
            </div>
            <div class="content">
                <blockquote>
                    <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                </blockquote>
                <div class="itemAddress itemData">
                    <asp:Label ID="AddressLabel" runat="server" />
                </div>
                <div class="itemWebAddress itemData">
                    <asp:HyperLink ID="WebPageHyperLink" runat="server" CssClass="website" Text="Sitio Oficial"
                        Target="_blank"></asp:HyperLink>
                </div>
                <div class="connectSocial">
                    <asp:HyperLink ID="FacebookHyperLink" runat="server" CssClass="facebookLink" ToolTip="Facebook"
                        Text="Facebook"></asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="TwitterHyperLink" CssClass="twitterLink" runat="server" ToolTip="Twitter"
                        Text="Twitter"></asp:HyperLink>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="moreDetails">
        <%--<div class="aDetail">
            <div class="header">
                <label>
                    Acerca de</label>
            </div>
            <div class="content">
            </div>
            <div class="clear">
            </div>
        </div>--%>
        <asp:PlaceHolder ID="AditionalPlaceHolder" runat="server" Visible="true">
            <div class="aDetail">
                <div class="header">
                    <label>
                        Información adicional:</label>
                </div>
                <div class="content">
                    <asp:Literal ID="AditionalLiteral" runat="server" Text='<%# Eval("AditionalInfo") %>' />
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:PlaceHolder>
        <div id="PhonesDiv" runat="server" class="aDetail">
            <div class="header">
                <label class="phoneNumber">
                    Telefonos</label>
            </div>
            <div class="content">
                <asp:BulletedList ID="PhoneBulletedList" CssClass="elementList phoneList" runat="server">
                </asp:BulletedList>
            </div>
            <div class="clear">
            </div>
        </div>
        <div id="EmailDiv" runat="server" class="aDetail">
            <div class="header">
                <label class="email">
                    Correos electronicos</label>
            </div>
            <div class="content">
                <asp:DataList ID="EmailDataList" runat="server" CssClass="elementList emailList"
                    RepeatLayout="Flow" RepeatColumns="1" RepeatDirection="Vertical" DataSourceID="EmailObjectDataSource">
                    <ItemTemplate>
                        <a class="emailLink" href='<%# Eval("Address","mailto:{0}?subject=Información")%>'>
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
        <div id="divMapa" class="aDetail" runat="server">
            <div class="header">
                <label>
                    Mapa</label>
            </div>
            <div class="content">
                <div id="map_canvas" style="width: 100%; height: 240px">
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div id="CategoriesDiv" runat="server" class="aDetail">
            <div class="header">
                <label>
                    Categorías relacionadas</label>
            </div>
            <div class="content">
                <asp:BulletedList ID="CategoriesBulletedList" CssClass="hMenu categoriesList" runat="server"
                    DisplayMode="HyperLink">
                </asp:BulletedList>
            </div>
            <div class="clear">
            </div>
        </div>
        <%--        <div class="aDetail">
            <div class="header">
                <label>
                    Pagina en directorio</label>
            </div>
            <div class="content">
                Poner aqui la pagina del directorio (es link?)
            </div>
            <div class="clear">
            </div>
        </div>--%>
        <div id="OfficesDiv" runat="server" class="aDetail">
            <div class="header">
                <label>
                    Sucursales</label>
            </div>
            <div class="content">
                <asp:DataList ID="OfficeDataList" runat="server" DataSourceID="OfficeDataSource">
                    <ItemTemplate>
                        <div class="itemAddress">
                            <b>
                                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' /></b>
                            <br />
                            <small>Dirección
                                <asp:Literal ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>'>
                                </asp:Literal>
                                <br />
                                <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City.Name") %>' />
                            </small>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="OfficeDataSource" runat="server" SelectMethod="FetchAdvertiserOffices"
                    TypeName="bsx.DirLaguna.Dal.OfficeController">
                    <SelectParameters>
                        <asp:Parameter Name="advertiserId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
        <div id="galleryDiv" class="aDetail" runat="server">
            <div class="header">
                <label>
                    Galerias</label>
            </div>
            <div class="content">
                <div id="gallery">
                    <asp:Repeater ID="GalleriesRepeater" runat="server" DataSourceID="GalleriesObjectDataSource">
                        <ItemTemplate>
                            <bsx:GalleryControl ID="GalleryControl1" GalleryId='<%# Eval("GalleryId") %>' runat="server" />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div id="AnnounceDiv" class="aDetail" runat="server">
            <div class="header">
                <label>
                    Anuncio</label>
            </div>
            <div class="content">
                <bsx:AnnounceControl ID="AnnounceControl1" runat="server" />
            </div>
            <div class="clear">
            </div>
        </div>
        <div id="CouponDiv" class="aDetail" runat="server">
            <div class="header">
                <label>
                    Cupones</label>
            </div>
            <div class="content">
                <asp:LinkButton ID="CouponLinkButton" runat="server">Ver cupones</asp:LinkButton>
            </div>
            <div class="clear">
            </div>
        </div>

        <div class="shareArea">
            <div id="fb-root">
            </div>
            <div class="twitContainer">
                <a href="https://twitter.com/share" class="twitter-share-button" data-lang="es">Twittear</a>
                <script>                    !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = "//platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");</script>
            </div>
            <script>                (function (d, s, id) {
                    var js, fjs = d.getElementsByTagName(s)[0];
                    if (d.getElementById(id)) return;
                    js = d.createElement(s); js.id = id;
                    js.src = "//connect.facebook.net/en_US/all.js#xfbml=1";
                    fjs.parentNode.insertBefore(js, fjs);
                } (document, 'script', 'facebook-jssdk'));</script>
            <div class="doLike">
                <div class="fb-like" data-send="false" data-layout="button_count" data-width="90"
                    data-show-faces="false" data-font="tahoma">
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
</div>
<asp:ObjectDataSource ID="GalleriesObjectDataSource" runat="server" SelectMethod="FetchAllByAdvertiserId"
    TypeName="bsx.DirLaguna.Dal.GalleryController">
    <SelectParameters>
        <asp:Parameter Name="advertiserId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
