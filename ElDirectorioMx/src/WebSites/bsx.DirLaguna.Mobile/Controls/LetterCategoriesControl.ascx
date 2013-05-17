<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LetterCategoriesControl.ascx.cs"
    Inherits="bsx.DirLaguna.Mobile.Controls.LetterCategoriesControl" %>
<asp:Repeater ID="CategoriesDataList" runat="server" DataSourceID="CategoriesDataSource">
    <ItemTemplate>
        <div class="itemRow">
            <asp:HyperLink ID="CategoryHyperLink" Text='<%# Eval("Name") %>' runat="server" NavigateUrl='<%# this.CategoryUrl((int)Eval("CategoryId")) %>'>
            </asp:HyperLink>
        </div>
    </ItemTemplate>
</asp:Repeater>
<%--<asp:DataList ID="CategoriesDataList" runat="server" CssClass="categoryList" RepeatLayout="Flow" 
DataSourceID="CategoriesDataSource">--%>
<%--</asp:DataList>--%>
<asp:ObjectDataSource ID="CategoriesDataSource" runat="server" SelectMethod="FetchCategoriesForLetter"
    TypeName="bsx.DirLaguna.Dal.CategoryController">
    <SelectParameters>
        <asp:Parameter Name="letter" Type="String" />
        <asp:Parameter Name="keywords" Type="String" />
        <asp:Parameter Name="filterFeatured" Type="Boolean" />
    </SelectParameters>
</asp:ObjectDataSource>
