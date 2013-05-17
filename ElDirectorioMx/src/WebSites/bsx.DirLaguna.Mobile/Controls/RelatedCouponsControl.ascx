<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RelatedCouponsControl.ascx.cs" Inherits="bsx.DirLaguna.Mobile.Controls.RelatedCouponsControl" %>
<%@ Import Namespace="bsx.DirLaguna.Dal" %>
<%@ Import Namespace="bsx.DirLaguna.CommonWeb" %>
<%@ Import Namespace="bsx.DirLaguna.Mobile.Code" %>
<asp:DataList ID="CouponsDataList" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
    <ItemTemplate>
        <div class="couponItem couponItemSmall">
            <asp:HyperLink ID="CouponHyperlink" runat="server" NavigateUrl='<%# Eval("CouponId",string.Format("{0}?{1}=",this.ResolveUrl(Navigation.CouponDetail),QueryKeys.CouponId)+"{0}") %>'>
                <asp:Image ID="couponImage" runat="server" ImageUrl='<%#Eval("CouponId",(bool)Eval("HasPicture")? this.CouponPictureUrl((int)Eval("CouponId"),Coupon.Sizes.Small):"~/Content/coupons/default_small.jpg") %>' />
            </asp:HyperLink>
        </div>
    </ItemTemplate>
</asp:DataList>
