<%@ Page Title="Directorio" Language="C#" MasterPageFile="~/Shared/Base.Master" AutoEventWireup="True"
    CodeBehind="CategoryDisplay.aspx.cs" Inherits="bsx.DirLaguna.Public.CategoryDisplay" %>

<%@ Register Src="Controls/LetterCategoriesControl.ascx" TagName="LetterCategoriesControl"
    TagPrefix="uc1" %>
<%@ Register Src="Controls/CategoriesControl.ascx" TagName="CatCtrl" TagPrefix="bsx" %>
<%@ Register Src="Controls/AdvertiserDisplay.ascx" TagName="AdvertiserDisplay" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
    <div class="listContainer">
        <asp:HiddenField ID="RequestedCategoryHidden" runat="server" />
        <bsx:CatCtrl ID="CatCtrl1" runat="server" />
        <div class="listContent">
            <div class="span-4">
                <uc1:LetterCategoriesControl ID="LetterCategoriesControl1" runat="server" />
            </div>
            <div class="span-11 last">
                <uc2:AdvertiserDisplay ID="AdvertiserDisplay1" runat="server" />
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>
