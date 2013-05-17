<%@ Page Title="Resultados de búsqueda" Language="C#" MasterPageFile="~/Shared/Base.Master"
    AutoEventWireup="true" CodeBehind="SearchResultForm.aspx.cs" Inherits="bsx.DirLaguna.Public.SearchResultForm" %>

<%@ Register Src="Controls/CategoriesControl.ascx" TagName="CatCtrl" TagPrefix="bsx" %>
<%@ Import Namespace="bsx.DirLaguna.Public.Code" %>
<%@ Import Namespace="bsx.DirLaguna.CommonWeb" %>
<%@ Register Src="Controls/AdvertiserDisplay.ascx" TagName="AdvertiserDisplay" TagPrefix="uc1" %>
<%@ Register Src="Controls/LetterCategoriesControl.ascx" TagName="LetterCategoriesControl"
    TagPrefix="uc2" %>
<%@ Register Src="Controls/MapControl.ascx" TagName="MapCtrl" TagPrefix="bsx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
    <div class="listContainer catList">
        <h3 class="letterMenu">
            Resultados de la búsqueda</h3>
        <div class="listContentWrapper">
            <div class="listContent" id="ResultSetDiv" runat="server">
                <div class="span-4">
                    <uc2:LetterCategoriesControl ID="LetterCategoriesControl1" runat="server" FilterFeatured="false" />
                </div>
                <div class="span-11 last">
                    <%--<bsx:MapCtrl ID="MapCtrl1" runat="server" />--%>
                    <uc1:AdvertiserDisplay ID="AdvertiserDisplay2" runat="server"/>
                </div>
                <div class="clear">
                </div>
            </div>
            <div id="EmptyDiv" runat="server" class="listContent" style="font-size: large; color: #888888; font-weight: bold;
                text-align: center; padding-top: 20px">
                <p>
                    La búsqueda no ha arrojado resultados.</p>
                <p>
                    Por favor redefine los criterios requeridos</p>
            </div>
        </div>
        <div class="listContainerFooter">
        </div>
    </div>
</asp:Content>
