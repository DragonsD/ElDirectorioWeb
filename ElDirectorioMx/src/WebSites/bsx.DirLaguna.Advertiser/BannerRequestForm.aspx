<%@ Page Title="Mis peticiones para banner" Language="C#" MasterPageFile="~/Shared/Admin.Master"
    AutoEventWireup="true" CodeBehind="BannerRequestForm.aspx.cs" Inherits="bsx.DirLaguna.Advertiser.BannerRequestForm" %>

<%@ Register Src="Controls/SendUploadBannerControl.ascx" TagName="SendUploadBannerControl"
    TagPrefix="bsx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="headerTitle">
        <div class="span-24 last">
            <h1>
                <asp:Label ID="TitleBanner" runat="server"></asp:Label>
            </h1>
            <br />
        </div>
    </div>
    <asp:PlaceHolder ID="NotHasControlsPlaceHolder" runat="server">
        <h1>No hay Banners Activados</h1>
    </asp:PlaceHolder>
    <bsx:SendUploadBannerControl ID="SendUploadBannerControl1" runat="server" />
    <bsx:SendUploadBannerControl ID="SendUploadBannerControl2" runat="server" />
    <bsx:SendUploadBannerControl ID="SendUploadBannerControl3" runat="server" />
    <bsx:SendUploadBannerControl ID="SendUploadBannerControl4" runat="server" />
    <div class="clear">
    </div>

    <p>
        <div class="span-24 last">
            <div class="SearchButtonContainer">
                <asp:LinkButton ID="SendButton" runat="server" Text="Enviar" class="button" ValidationGroup="ValidImage" />
                <asp:LinkButton ID="BackButton" runat="server" Text="Regresar" CausesValidation="false"
                    class="clearSearch"></asp:LinkButton>
            </div>
        </div>
    </p>
</asp:Content>
