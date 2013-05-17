<%@ Page Language="C#" MasterPageFile="~/Shared/Base.Master" AutoEventWireup="true"
    CodeBehind="AdvertiserDisplay.aspx.cs" Inherits="bsx.DirLaguna.Mobile.AdvertiserDisplay" %>

<%@ Register Src="Controls/AdvertiserDisplayControl.ascx" TagName="AdvertiserDisplayControl"
    TagPrefix="bsx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ButtonContainer">
        <asp:HyperLink ID="BackUpHyperLink" CssClass="back" runat="server">Regresar</asp:HyperLink>
    </div>
    <div class="listContent">
        <div class="itemContent">
            <bsx:AdvertiserDisplayControl ID="AdvertiserDisplayControl2" runat="server" DisplayFeatured ="true" />
            <bsx:AdvertiserDisplayControl ID="AdvertiserDisplayControl1" runat="server" DisplayFeatured ="false" />
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="ButtonContainer">
        <asp:HyperLink ID="BackBottomHyperLink" CssClass="back" runat="server">Regresar</asp:HyperLink>
    </div>
</asp:Content>
