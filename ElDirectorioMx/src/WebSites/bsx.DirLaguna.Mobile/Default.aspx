<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" MasterPageFile="~/Shared/Base.Master"
    Inherits="bsx.DirLaguna.Mobile.Default" %>

<%@ Register Src="Controls/CategoriesControl.ascx" TagName="CategoriesControl" TagPrefix="bsx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="headerContainer">
        <!-- Standard <ul> with class of "tabs" -->
        <ul class="tabs">
            <!-- Give href an ID value of corresponding "tabs-content" <li>'s -->
            <li><a class="active" href="#Search">Buscar</a></li>
            <li><a href="#Browse">Directorio</a></li>
            <li><a href="CouponCategory.aspx">Cupones</a></li>
        </ul>
        <!-- Standard <ul> with class of "tabs-content" -->
        <ul class="tabs-content">
            <!-- Give ID that matches HREF of above anchors -->
            <li class="active" id="Search">
                <asp:Panel runat="server" ID="SearchPanel" CssClass="filterContainer" DefaultButton="SearchButton">
                    <div id="filters">
                        <div class="filterField">
                            <label>
                                Encuentra</label>
                            <asp:TextBox ID="SearchTextBox" runat="server" CssClass="text whatField">
                            </asp:TextBox>
                        </div>
                        <div class="filterField">
                            <label>
                                En</label>
                            <asp:DropDownList ID="WhereDropDownList" runat="server" DataTextField="Name" DataValueField="CityId">
                                <asp:ListItem Text="Todas las ciudades" Value="0">
                                </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="filterField filterFieldButton">
                            <asp:ImageButton ID="SearchButton" runat="server" CssClass="searchButton" ImageUrl="~/images/BttnBuscar.png"
                                Width="109px" Height="45px" />
                            <%--<asp:LinkButton ID="SearchButton" runat="server" CssClass="searchButton" Text="">
                        <asp:Image ID="SearchImage" runat="server" ImageUrl="~/images/BttnBuscar.png" Width="109px"
                            Height="45px" />
                    </asp:LinkButton>--%>
                        </div>
                    </div>
                </asp:Panel>
            </li>
            <li id="Browse">
                <div class="itemContent">
                    <h1>
                        <asp:Label ID="titleLabel" runat="server" Text="Directorio"></asp:Label></h1>
                    <bsx:CategoriesControl ID="CategoriesControl1" runat="server" />
                </div>
            </li>
        </ul>
        <%--<div class="browseSpace">
            <a href="Categories.aspx">
                <asp:Image ID="BrowseImage" runat="server" ImageUrl="~/content/img/dIRECTORIO2.png"
                    Width="120px" />
            </a>
        </div>--%>
        <%--<div id="redirectDiv">
            <asp:HyperLink ID="UrlSiteDesktopHyperLink" runat="server" NavigateUrl="http:localhost">Ir a versión Web</asp:HyperLink>
            <br />
        </div>--%>
        <div class="AppStore">
            <asp:HyperLink runat="server" ID="AppStoreHyperlink" NavigateUrl="https://itunes.apple.com/mx/app/el-directorio/id548424900?mt=8&uo=4">
                <asp:Image ID="AppStoreImage" runat="server" ImageUrl="~/images/appstoreblue.png"
                    Width="122px" />
            </asp:HyperLink>
        </div>
        <div class="clear">
        </div>
        <div class="AppStore">
            <asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl="https://play.google.com/store/apps/details?id=directorio.actividades#?t=W251bGwsMSwxLDIxMiwiZGlyZWN0b3Jpby5hY3RpdmlkYWRlcyJd">
                <asp:Image ID="AndroidImage" runat="server" ImageUrl="~/images/googleplay.png"
                    Width="122px" />
            </asp:HyperLink>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css" media="handheld"></style>
    <link rel="Stylesheet" type="text/css" href="App_Themes/mobil/main.css" />
</head>
<body>
    <form id="form1" runat="server">

    </form>
</body>
</html>--%>
