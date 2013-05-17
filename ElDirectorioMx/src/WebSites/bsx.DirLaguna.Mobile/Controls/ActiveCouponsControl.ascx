<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ActiveCouponsControl.ascx.cs" Inherits="bsx.DirLaguna.Mobile.Controls.ActiveCouponsControl" %>
<%@ Import Namespace="bsx.DirLaguna.Dal" %>
<%@ Import Namespace="bsx.DirLaguna.CommonWeb" %>
<%@ Import Namespace="bsx.DirLaguna.Mobile.Code" %>

<asp:DataList ID="CouponsDataList" runat="server" DataSourceID="CouponsObjectDataSource"
    RepeatDirection="Horizontal" RepeatLayout="Flow">
    <ItemTemplate>
        <div class="couponItem">
            <asp:HyperLink ID="CouponHyperlink" runat="server" NavigateUrl='<%# this.DetailUrl((int)Eval("CouponId")) %>'>
                <asp:Image ID="couponImage" runat="server" ImageUrl='<%#Eval("CouponId",(bool)Eval("HasPicture")? this.CouponPictureUrl((int)Eval("CouponId"),Coupon.Sizes.Medium):"~/Content/coupons/default_medium.jpg") %>'/>
            </asp:HyperLink>
        </div>
    </ItemTemplate>
</asp:DataList>
<asp:DataList ID="PagerDataList" CssClass="pager" runat="server" RepeatDirection="Horizontal"
    RepeatLayout="Flow">
    <ItemTemplate>
        <asp:LinkButton ID="PageLinkButton" CssClass="pageItem" runat="server" Text='<%# Eval("PageIndex") %>'
            CommandName="ChangePage" CommandArgument='<%# Eval("StartIndex") %>'></asp:LinkButton>
    </ItemTemplate>
</asp:DataList>

<asp:ObjectDataSource ID="CouponsObjectDataSource" runat="server" SelectMethod="FetchAvailableCoupons"
    TypeName="bsx.DirLaguna.Dal.CouponController">
    <SelectParameters>
        <asp:Parameter Name="categoryId" Type="Int32" />
        <asp:Parameter Name="advertiserId" Type="Int32" />
                <asp:Parameter Name="cityId" Type="Int32" />
        <asp:Parameter Name="startRowIndex" Type="Int32" />
        <asp:Parameter Name="maximumRows" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
