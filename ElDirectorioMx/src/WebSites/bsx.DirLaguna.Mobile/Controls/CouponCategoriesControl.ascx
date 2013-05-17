<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CouponCategoriesControl.ascx.cs"
    Inherits="bsx.DirLaguna.Mobile.Controls.CouponCategoriesControl" %>
<asp:DataList ID="CategoriesDataList" runat="server" CssClass="categoryList" DataSourceID="CategoriesDataSource" RepeatLayout="Flow" RepeatColumns="10000">
    <ItemTemplate>
        <div class="itemRow">
            <asp:LinkButton ID="CategoryLinkButton" runat="server" Text='<%# Eval("Name") %>'
                CommandName="SeeCategory" CommandArgument='<%# Eval("CategoryId") %>'></asp:LinkButton>
        </div>
    </ItemTemplate>
</asp:DataList>
<asp:ObjectDataSource ID="CategoriesDataSource" runat="server" SelectMethod="FetchCouponsCategories"
    TypeName="bsx.DirLaguna.Dal.CategoryController">
    <SelectParameters>
        <asp:Parameter Name="letter" Type="String" />
        <asp:Parameter Name="cityId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
