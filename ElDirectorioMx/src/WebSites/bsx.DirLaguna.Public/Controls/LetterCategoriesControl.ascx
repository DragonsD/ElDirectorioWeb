<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="LetterCategoriesControl.ascx.cs"
    Inherits="bsx.DirLaguna.Public.Controls.LetterCategoriesControl" %>
<%--<div style="font-weight: bold; padding-bottom: 10px; font-size: 16px; margin-left: 5px;">
    Categorías
</div>--%>
<asp:DataList ID="CategoriesDataList" runat="server" CssClass="categoryList" DataSourceID="CategoriesDataSource">
    <ItemTemplate>
        <asp:LinkButton ID="CategoryLinkButton" runat="server" Text='<%# Eval("Name") %>'
            CommandName="SeeCategory" CommandArgument='<%# Eval("CategoryId") %>'></asp:LinkButton>
    </ItemTemplate>
</asp:DataList>
<asp:ObjectDataSource ID="CategoriesDataSource" runat="server" SelectMethod="FetchCategoriesForLetter"
    TypeName="bsx.DirLaguna.Dal.CategoryController">
    <SelectParameters>
        <asp:Parameter Name="letter" Type="String" />
        <asp:Parameter Name="keywords" Type="String" />
        <asp:Parameter Name="filterFeatured" Type="Boolean" />
        <asp:Parameter Name="cityId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
