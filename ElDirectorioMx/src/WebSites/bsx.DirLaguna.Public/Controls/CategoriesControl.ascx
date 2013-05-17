<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoriesControl.ascx.cs"
    Inherits="bsx.DirLaguna.Public.Controls.CategoriesControl" %>
<%@ Import Namespace="bsx.DirLaguna.Public.Code" %>
<%@ Import Namespace="bsx.DirLaguna.CommonWeb" %>
<asp:DataList ID="CategoriesDataList" runat="server" CssClass="letterMenu" HorizontalAlign="Center" RepeatLayout="Flow" RepeatDirection="Horizontal"
    DataSourceID="CategoriesDataSource">
    <ItemTemplate>
        <asp:HyperLink ID="LetterLinkButton" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem") %>'
            NavigateUrl='<%# Navigation.HomeForm +"?"+ QueryKeys.CategoryLetter+"="+ DataBinder.Eval(Container, "DataItem") %>'
            ToolTip='<%#"Categorias que comienzan con " + DataBinder.Eval(Container, "DataItem") %>'></asp:HyperLink>
    </ItemTemplate>
</asp:DataList>
<%--<asp:DataList ID="CategoriesDataList" runat="server" HorizontalAlign="Center" RepeatDirection="Horizontal"
    DataSourceID="CategoriesDataSource">
    <ItemTemplate>
        <asp:HyperLink ID="LetterLinkButton" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem") %>'
            NavigateUrl='<%# Navigation.CategoryDisplay+"?"+ QueryKeys.CategoryLetter+"="+ DataBinder.Eval(Container, "DataItem") %>'
            ToolTip='<%#"Categorias que comienzan con " + DataBinder.Eval(Container, "DataItem") %>'></asp:HyperLink>
    </ItemTemplate>
</asp:DataList>--%>
<asp:ObjectDataSource ID="CategoriesDataSource" runat="server" SelectMethod="FetchAllCategoryLetters"
    TypeName="bsx.DirLaguna.Dal.CategoryController"></asp:ObjectDataSource>
