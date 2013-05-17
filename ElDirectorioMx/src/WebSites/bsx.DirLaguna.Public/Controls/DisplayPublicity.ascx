<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DisplayPublicity.ascx.cs" Inherits="bsx.DirLaguna.Public.Controls.DisplayPublicity" %>
<%@ Import Namespace="bsx.DirLaguna.Dal.SelectControllers" %>
<%@ Import Namespace="bsx.DirLaguna.CommonWeb" %>
<%@ Import Namespace="bsx.DirLaguna.Public.Code" %>
<asp:DataList ID="PublicitiesDataList" runat="server" DataSourceID="PublicitiesObjectDataSource"
    RepeatDirection="Horizontal" RepeatLayout="Flow">
    <ItemTemplate>
        <%--<div class="span-4 last" style="text-align: center;">--%>
        <div class="span-4 last couponItem">
            <asp:HyperLink ID="WebAddressLink" runat="server" NavigateUrl='<%# Eval("WebPage") %>'>
                <asp:Image ID="publicityImage" runat="server" ImageUrl='<%#Eval("PublicityId"),Eval("URLPublicity")%>' AlternateText="Image" />
            </asp:HyperLink>
        </div>
        <%--</div> Width="160px" --%>
    </ItemTemplate>
</asp:DataList>
<asp:DataList ID="PagerDataList" CssClass="pager" runat="server" RepeatDirection="Horizontal"
    RepeatLayout="Flow" DataSourceID="PublicitiesObjectDataSource">
    <ItemTemplate>
        <asp:LinkButton ID="PageLinkButton" CssClass="pageItem" runat="server" Text='<%# Eval("PageIndex") %>'
            CommandName="ChangePage" CommandArgument='<%# Eval("StartIndex") %>'></asp:LinkButton>
    </ItemTemplate>
</asp:DataList>
<asp:ObjectDataSource ID="PublicitiesObjectDataSource" runat="server" SelectMethod="FetchByEstadoMunicipio" TypeName="bsx.DirLaguna.Dal.SelectControllers.PublicityController">
    <SelectParameters>
        <asp:Parameter Name="advertiserId" Type="Int32" />
        <asp:Parameter Name="estadoId" Type="Int32" />
        <asp:Parameter Name="municipioId" Type="Int32" />
        <asp:Parameter Name="url" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>





