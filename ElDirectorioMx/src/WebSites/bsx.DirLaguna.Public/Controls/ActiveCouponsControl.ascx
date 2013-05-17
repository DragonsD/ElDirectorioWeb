<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="ActiveCouponsControl.ascx.cs"
    Inherits="bsx.DirLaguna.Public.Controls.ActiveCouponsControl" %>
<%@ Import Namespace="bsx.DirLaguna.Dal" %>
<%@ Import Namespace="bsx.DirLaguna.CommonWeb" %>
<%@ Import Namespace="bsx.DirLaguna.Public.Code" %>
<asp:DataList ID="CouponsDataList" runat="server" DataSourceID="CouponsObjectDataSource"
    RepeatDirection="Horizontal" RepeatLayout="Flow">
    <ItemTemplate>
        <%--<div class="span-4 last" style="text-align: center;">--%>
        <div class="span-4 last couponItem">
            <asp:HyperLink ID="CouponHyperlink" runat="server" NavigateUrl='<%# (bool)Eval("IsClub") ?  this.CouponUrlClub((int)Eval("CouponId")) : this.CouponUrl((int)Eval("CouponId")) %>'>
                <asp:Image ID="couponImage" runat="server" ImageUrl='<%#Eval("CouponId",(bool)Eval("HasPicture")? this.CouponPictureUrl((int)Eval("CouponId"),Coupon.Sizes.Medium):"~/Content/coupons/default_medium.jpg") %>' AlternateText="Image" />
                <%--<asp:Image ID="couponImage" runat="server" ImageUrl='<%#(bool)Eval("IsClub")?"~/Content/Image/couponClub.jpg" : "~/Content/Image/coupon.jpg"%>' AlternateText="Image" />--%>
            </asp:HyperLink>
        </div>
        <%--</div> Width="160px" --%>
    </ItemTemplate>
</asp:DataList>
<br />
<asp:DataList ID="PagerDataList" CssClass="pager" runat="server" RepeatDirection="Horizontal"
    RepeatLayout="Flow">
    <ItemTemplate>
        <asp:LinkButton ID="PageLinkButton" CssClass="pageItem" runat="server" Text='<%# Eval("PageIndex") %>'
            CommandName="ChangePage" CommandArgument='<%# Eval("StartIndex") %>'></asp:LinkButton>
    </ItemTemplate>
</asp:DataList>

<asp:ObjectDataSource ID="CouponsObjectDataSource" runat="server" SelectMethod="FetchAvailableCouponsClub"
    TypeName="bsx.DirLaguna.Dal.CouponController">
    <SelectParameters>
        <asp:Parameter Name="isclub" Type="Boolean" />
        <asp:Parameter Name="categoryId" Type="Int32" />
        <asp:Parameter Name="advertiserId" Type="Int32" />
        <asp:Parameter Name="cityId" Type="Int32" />
        <asp:Parameter Name="startRowIndex" Type="Int32" />
        <asp:Parameter Name="maximumRows" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>


