<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdvertiserDisplay.ascx.cs"
    Inherits="bsx.DirLaguna.Public.Controls.AdvertiserDisplay" %>
<%@ Import Namespace="bsx.DirLaguna.Public.Code" %>
<%@ Import Namespace="bsx.DirLaguna.CommonWeb" %>
<h2 class="featuredTitle">
    <asp:Label ID="TitleLabel" Text="Todos los Negocios" runat="server"></asp:Label>
</h2>

<asp:DataList ID="AdvertisersDataList" runat="server" DataSourceID="AdvertisersObjectDataSource"
    RepeatColumns="1" RepeatDirection="Horizontal" RepeatLayout="Flow">
    <ItemTemplate>
        <div class="listItem" style='<%# ((bool)Eval("Featured"))%>' >
            <div class="span-1" style="text-align:center; padding-left:3px">
                <div class="itemRowMark">
                    <%#Container.ItemIndex + 1 + StartIndex%>
                </div>
            </div>
            <div class="span-7 last">
                <div class="itemName itemData">
                    <%--<asp:HyperLink ID="NameLink" Text='<%# Eval("Name") %>' runat="server" NavigateUrl='<%# this.ResolveUrl(Navigation.DetailForm)+"?"+QueryKeys.AdvertiserId+"="+Eval("AdvertiserId") %>'>--%>
                    <asp:HyperLink ID="HyperLink1" Text='<%# Eval("Name") %>' runat="server" NavigateUrl='<%# this.AdvertiserUrl((int)Eval("AdvertiserId")) %>'>
                    </asp:HyperLink>
                </div>
                <div class="itemAddress itemData">
                    <asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("FullAddress")  + ". " + Eval("CityName") %>'/>
                </div>
                <div class="itemDescription itemData">
                    <blockquote>
                        <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                    </blockquote>
                </div>
                <div class="itemDescription itemData">
                    <asp:HyperLink ID="WebAddressLink" Text='<%# this.CutWebPage((string)Eval("WebPage")) %>' runat="server" NavigateUrl='<%# Eval("WebPage") %>'>
                    </asp:HyperLink>
                </div>
            </div>
            <div class="span-3 last">
                <asp:HyperLink ID="logoLink" CssClass="itemLogo" runat="server" NavigateUrl='<%# this.ResolveUrl(Navigation.DetailForm)+"?"+QueryKeys.AdvertiserId+"="+Eval("AdvertiserId") %>'>
                    <asp:Image ID="logoImage" runat="server" AlternateText="[na]" ImageUrl='<%# this.LogoUrl((int) Eval("AdvertiserId")) %>' />
                </asp:HyperLink>
            </div>
			<div class="span-9">
				<div class="span-1">
					<asp:Image ID="FeaturedImage" runat="server" ImageUrl="~/Content/Image/featured.png" AlternateText="[*]" Visible='<%#(bool)Eval("Featured") %>' />
				</div>
				<div class="span-7 last">
					<div class="promoDescription">
						<asp:HyperLink ID="PromoAdLink" Text='<%# Eval("PromocionesClub") %>' runat="server" NavigateUrl='<%# this.PromoUrl((int)Eval("AdvertiserId")) %>' Visible='<%#(bool)Eval("Featured") %>' >
						</asp:HyperLink>
					</div>
				</div>
			</div>
            <div class="clear">
            </div>
        </div>
    </ItemTemplate>
</asp:DataList>
<asp:ObjectDataSource ID="AdvertisersObjectDataSource" runat="server" SelectMethod="FetchCategoryAdvertisers"
    TypeName="bsx.DirLaguna.Dal.VwAdvertiserController">
    <SelectParameters>
        <%--<asp:Parameter Name="displayFeatured" Type="Boolean" />--%>
        <asp:Parameter Name="requestedCategory" Type="String" />
        <asp:Parameter Name="keywords" Type="String" />
        <asp:Parameter Name="startRowIndex" Type="Int32" />
        <asp:Parameter Name="maximumRows" Type="Int32" />
        <asp:Parameter Name="cityId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:DataList ID="PagerDataList" CssClass="pager" runat="server" RepeatDirection="Horizontal"
    RepeatLayout="Flow">
    <ItemTemplate>
        <asp:LinkButton ID="PageLinkButton" CssClass="pageItem" runat="server" Text='<%# Eval("PageIndex") %>'
            CommandName="ChangePage" CommandArgument='<%# Eval("StartIndex") %>'></asp:LinkButton>
    </ItemTemplate>
</asp:DataList>
