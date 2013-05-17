<%@ Page Title="ElDirectorio.mx - Cupon" Language="C#" MasterPageFile="~/Shared/Base.Master"
    AutoEventWireup="true" CodeBehind="CouponDetail.aspx.cs" Inherits="bsx.DirLaguna.Mobile.CouponDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ register src="~/Controls/RelatedCouponsControl.ascx" tagname="RelatedCouponsCtrl"
        tagprefix="bsx" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ButtonContainer">
        <asp:HyperLink ID="BackUpHyperLink" CssClass="back" runat="server">Regresar</asp:HyperLink>
    </div>
    <div class="clear">
    </div>
    <div class="span-16">
        <div class="aDetail">
            <div class="header">
                <h4>
                    <asp:Label ID="NameLabel" runat="server"></asp:Label></h4>
            </div>
        </div>
        <div class="aDetail">
            <div class="header">
                <label>
                    Proveedor
                </label>
            </div>
            <div class="content">
                <asp:LinkButton ID="CouponProviderLinkButton" runat="server"></asp:LinkButton>
            </div>
        </div>

        <div class="aDetail">
            <div class="header">
                <label>
                    Descripción
                </label>
            </div>
            <div class="content">
                <asp:Label ID="DescriptionLabel" runat="server"></asp:Label>
            </div>
        </div>
        <div class="aDetail">
            <div class="header">
                <label>
                    Cupón</label>
            </div>
            <div class="content couponImage">
                <asp:Image ID="couponImage" runat="server" ImageUrl="~/Content/coupons/default_large.jpg" />
            </div>
        </div>
        <div id="ConditionsDiv" runat="server" class="aDetail">
            <div class="header">
                <label>
                    Condiciones
                </label>
            </div>
            <div class="content">
                <asp:Label ID="ConditionsLabel" runat="server"></asp:Label>
            </div>
        </div>
        <div id="HowToCashDiv" runat="server" class="aDetail">
            <div class="header">
                <label>Cómo canjear </label>
            </div>
            <div class="content">
                <asp:Label ID="HowToCashLabel" runat="server"></asp:Label>
            </div>
        </div>
        <div class="aDetail">
            <div class="header">
                <label>
                    Válido desde el
                </label>
            </div>
            <div class="content">
                <asp:Label ID="StartLabel" runat="server"></asp:Label>
            </div>
        </div>
        <div id="EndDateDiv" runat="server" visible="false" class="aDetail">
            <div class="header">
                <label>
                    Válido hasta
                </label>
            </div>
            <div class="content">
                <asp:Label ID="EndLabel" runat="server"></asp:Label>
            </div>
        </div>
        <div id="OtherCouponsParagraph" runat="server" visible="false" class="aDetail">
            <div class="header">
                <h5>
                    <asp:Label ID="AdvertiserCouponsLabel" runat="server"></asp:Label>
                </h5>
            </div>
            <bsx:RelatedCouponsCtrl ID="AdvertiserRelatedCouponsCtrl" runat="server"></bsx:RelatedCouponsCtrl>
        </div>
        <%--<p>
            <h3>
                <asp:Label ID="CategoryCouponsLabel" runat="server"></asp:Label>
            </h3>
            <bsx:RelatedCouponsCtrl id="CategoryRelatedCouponsCtrl" runat="server">
            </bsx:RelatedCouponsCtrl>
        </p>--%>
    </div>
    <div class="clear">
    </div>
    <div class="ButtonContainer">
        <asp:HyperLink ID="BackBottomHyperLink" CssClass="back" runat="server">Regresar</asp:HyperLink>
    </div>
</asp:Content>
