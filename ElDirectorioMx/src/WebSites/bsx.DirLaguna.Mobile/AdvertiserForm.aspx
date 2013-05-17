<%@ Page Language="C#"  MasterPageFile="~/Shared/Base.Master" AutoEventWireup="true" CodeBehind="AdvertiserForm.aspx.cs"
    Inherits="bsx.DirLaguna.Mobile.AdvertiserForm" %>

<%@ Register Src="Controls/AdvertiserDetailControl.ascx" TagName="AdvertiserDetailControl" TagPrefix="bsx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js">
    </script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.16/jquery-ui.min.js">
    </script>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyAeDPbRR8cx6ZoDIhJhauDaV9z3kCtQpiM&sensor=false">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ButtonContainer">
        <asp:HyperLink ID="BackUpHyperLink" CssClass="back" runat="server">Regresar</asp:HyperLink>
    </div>
    <div>
        <bsx:AdvertiserDetailControl ID="AdvertiserDetailControl1" runat="server" />
    </div>
    <div class="ButtonContainer">
        <asp:HyperLink ID="BackBottomHyperLink" CssClass="back" runat="server">Regresar</asp:HyperLink>
    </div>
</asp:Content>
