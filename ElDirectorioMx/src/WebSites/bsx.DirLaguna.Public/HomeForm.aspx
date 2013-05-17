<%@ Page Title="ElDirectorio.mx" Language="C#" MasterPageFile="~/Shared/Base.Master"
    AutoEventWireup="True" CodeBehind="HomeForm.aspx.cs" Inherits="bsx.DirLaguna.Public.HomeForm" %>

<%@ Register Src="Controls/LetterCategoriesControl.ascx" TagName="LetterCategoriesControl"
    TagPrefix="uc1" %>
<%@ Register Src="Controls/CategoriesControl.ascx" TagName="CatCtrl" TagPrefix="bsx" %>
<%@ Register Src="Controls/MapControl.ascx" TagName="MapCtrl" TagPrefix="bsx" %>
<%@ Register Src="Controls/AdvertiserDisplay.ascx" TagName="AdvertiserDisplay" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
    <div class="listContainer catList">
        <asp:HiddenField ID="RequestedCategoryHidden" runat="server" />
        <bsx:CatCtrl ID="CatCtrl1" runat="server" />
        <div class="listContentWrapper">
            <div class="listContent">
                <div class="span-4">
                    <uc1:LetterCategoriesControl ID="LetterCategoriesControl1" runat="server" />
                </div>
                <div class="span-11 last">
                    <%--<bsx:MapCtrl ID="MapCtrl1" runat="server" />--%>
                    <%--<uc2:AdvertiserDisplay ID="AdvertiserDisplay2" runat="server" DisplayFeatured="true" />--%>
                    <uc2:AdvertiserDisplay ID="AdvertiserDisplay1" runat="server"/>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="listContainerFooter">
        </div>
    </div>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="PrePageContentPlaceHolder" runat="server">
    
</asp:Content>
--%>