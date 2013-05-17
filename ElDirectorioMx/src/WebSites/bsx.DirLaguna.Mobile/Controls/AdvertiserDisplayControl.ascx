<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdvertiserDisplayControl.ascx.cs"
    Inherits="bsx.DirLaguna.Mobile.Controls.AdvertiserDisplayControl" %>
<%@ Import Namespace="bsx.DirLaguna.Mobile.Code" %>
<%@ Import Namespace="bsx.DirLaguna.CommonWeb" %>
<asp:DataList ID="AdvertisersDataList" runat="server" DataSourceID="AdvertisersObjectDataSource"
    HorizontalAlign="Center" RepeatColumns="1" RepeatDirection="Horizontal">
    <ItemTemplate>
        <div class="listItem" style='<%# ((bool)Eval("Featured"))?"background-color:#EEEEEE; border: 1px solid #3eacdc; padding-top:10px; margin:10px 0;": "" %>'>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# this.AdvertiserUrl((int)Eval("AdvertiserId")) %>'
                CssClass='<%# StyleDestacados((bool)Eval("Featured")) %>'>
                <div class="imageItem">
                    <asp:Image ID="logoImage" runat="server" AlternateText="[na]" ImageUrl='<%# ImageUrl((int)Eval("AdvertiserId")) %>' />
                </div>
                <div class="textItem">
                    <asp:Label ID="NameLabel" CssClass="itemName" runat="server" Text='<%# Eval("Name") %>' />
                    <br />
                    <small>
                        <asp:Literal ID="AddressLabel" runat="server" Text='<%# Eval("Address") + ". " + Eval("CityName") %>'>
                        </asp:Literal>
                    </small>
                </div>
                <div class="clear">
                </div>
            </asp:HyperLink></div>
    </ItemTemplate>
</asp:DataList><%--            

<div >
                    
                </div>

<asp:HyperLink ID="logoLink" CssClass="itemLogo" runat="server" NavigateUrl='<%# this.ResolveUrl(Navigation.AdvertiserForm)+"?"+QueryKeys.AdvertiserId+"="+Eval("AdvertiserId") %>'>
                    
                </asp:HyperLink>

<div class="span-1">
                <div class="itemRowMark">
                    <%#Container.ItemIndex + 1 + StartIndex%>
                </div>
            </div>--%><%--<asp:PlaceHolder ID="ExtraData" runat="server" Visible="false">
                    <div class="itemWebAddress itemData">
                        <asp:HyperLink ID="WebAddressLink" Text='<%# Eval("WebPage") %>' runat="server" NavigateUrl='<%# Eval("WebPage") %>'>
                        </asp:HyperLink>
                    </div>
                    <div class="itemDescription itemData">
                        <blockquote>
                            <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                        </blockquote>
                    </div>
                </asp:PlaceHolder>--%>
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
<asp:DataList ID="PagerDataList" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
    CssClass="pager">
    <ItemTemplate>
        <asp:LinkButton ID="PageLinkButton" runat="server" Text='<%# Eval("PageIndex") %>'
            CommandName="ChangePage" CommandArgument='<%# Eval("StartIndex") %>'></asp:LinkButton></ItemTemplate>
</asp:DataList>