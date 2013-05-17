<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Base.Master" AutoEventWireup="true"
    CodeBehind="DetailForm.aspx.cs" Inherits="bsx.DirLaguna.Public.DetailForm" %>

<%@ Register Src="Controls/LetterCategoriesControl.ascx" TagName="LetterCategoriesControl"
    TagPrefix="uc1" %>
    <%@ Register Src="Controls/AdvertiserHeaderControl.ascx" TagName="AdvertiserHeaderControl"
    TagPrefix="uc2" %>
<%@ Register Src="Controls/AdvertiserDetailControl.ascx" TagName="AdvertiserDetailControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <link rel="stylesheet" type="text/css" href="../Scripts/jquery.lightbox-0.5.css"
        media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
    <%--<div class="span-4">
        <uc1:LetterCategoriesControl ID="LetterCategoriesControl1" runat="server" />
    </div>--%>
    <div class="span-17">
        <div class="listContainer">
            <div class="listContentWrapper">
                <div class="listContent">
                    <uc2:AdvertiserDetailControl ID="AdvertiserDetailControl1" runat="server" />
                </div>
            </div>
            <div class="listContainerFooter">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PreContainerPlaceHolder" runat="server">
    <uc2:AdvertiserHeaderControl ID="AdvertiserHeaderControl1" runat="server" />
</asp:Content>
