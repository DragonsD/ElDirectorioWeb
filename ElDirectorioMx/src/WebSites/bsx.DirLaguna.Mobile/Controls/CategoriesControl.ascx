<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoriesControl.ascx.cs" Inherits="bsx.DirLaguna.Mobile.Controls.CategoriesControl" %>
<%@ Import Namespace="bsx.DirLaguna.Mobile.Code" %>
<%@ Import Namespace="bsx.DirLaguna.CommonWeb" %>

<div id="keyboard">
    <asp:Repeater ID="CategoriesDataList" runat="server" DataSourceID="CategoriesDataSource">
        <ItemTemplate>
            <div class="itemRow">
                <asp:HyperLink ID="LetterLinkButton" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem") %>'
                    NavigateUrl='<%# Navigation.CategoryDisplay+"?"+ QueryKeys.CategoryLetter+"="+ DataBinder.Eval(Container, "DataItem") %>'
                    ToolTip='<%#"Categorias que comienzan con " + DataBinder.Eval(Container, "DataItem") %>'></asp:HyperLink>
            </div>        
        </ItemTemplate>
    </asp:Repeater>
</div>
<asp:ObjectDataSource ID="CategoriesDataSource" runat="server" SelectMethod="FetchAllCategoryLetters"
    TypeName="bsx.DirLaguna.Dal.CategoryController"></asp:ObjectDataSource>
