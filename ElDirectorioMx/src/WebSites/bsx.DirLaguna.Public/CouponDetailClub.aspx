<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/NestedBaseMasterPage.master" AutoEventWireup="true" 
    CodeBehind="CouponDetailClub.aspx.cs" Inherits="bsx.DirLaguna.Public.CouponDetailClub" %>

<%@ Register Src="~/Controls/RelatedCouponsControl.ascx" TagName="RelatedCouponsCtrl" TagPrefix="bsx" %>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
    <div >
        <%--<h1>
            <asp:Label ID="NameLabel" runat="server"></asp:Label></h1>--%>
        <div class="aDetail">
            <div class="span-5">
                <label>
                    Proveedor:</label>
            </div>
            <div class="span-8">
                <asp:LinkButton ID="CouponProviderLinkButton" runat="server"></asp:LinkButton>
            </div>
            <div class="span-2 last">
                <a href='<%= this.PrintUrl %>' target="_blank">
                    <img src="Content/Image/printer.png" alt="Imprimir" />
                </a>
                <asp:LinkButton ID="PrintLinkButton" runat="server"></asp:LinkButton>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="aDetail">
            <div class="span-5">
                <label>
                    Descripción:</label>
            </div>
            <div class="span-10 last">
                <asp:Label ID="DescriptionLabel" runat="server"></asp:Label>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="aDetail">
            <div class="span-5">
                <label>
                    Cupón:</label>
            </div>
            <div class="span-10 last">
                <asp:Image ID="couponImage" runat="server" ImageUrl="~/Content/coupons/default_large.jpg" />
            </div>
            <div class="clear">
            </div>
        </div>
        <div id="ConditionsDiv" runat="server" class="aDetail">
            <div class="span-5">
                <label>
                    Condiciones:</label>
            </div>
            <div class="span-10 last">
                <asp:Label ID="ConditionsLabel" runat="server"></asp:Label>
            </div>
            <div class="clear">
            </div>
        </div>
        <div id="HowToCashDiv" runat="server" class="aDetail">
            <div class="span-5">
                <label>
                    Cómo canjear:</label>
            </div>
            <div class="span-10 last">
                <asp:Label ID="HowToCashLabel" runat="server"></asp:Label>
            </div>
            <div class="clear">
            </div>
        </div>
            <div class="clear">
            </div>
        </div>
        <div id="OtherCouponsParagraph" runat="server" class="aDetail otherCouponsList" visible="false">
            <h3>
                <asp:Label ID="AdvertiserCouponsLabel" runat="server"></asp:Label>
            </h3>
            <bsx:RelatedCouponsCtrl ID="AdvertiserRelatedCouponsCtrl" runat="server"></bsx:RelatedCouponsCtrl>
        </div>
</asp:Content>
