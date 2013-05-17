<%@ Page Language="C#" MasterPageFile="~/Shared/Base.Master" AutoEventWireup="true"
    CodeBehind="CategoryDisplay.aspx.cs" Inherits="bsx.DirLaguna.Mobile.CategoryDisplay" %>

<%@ Register Src="Controls/LetterCategoriesControl.ascx" TagName="LetterCategoriesControl"
    TagPrefix="bsx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ButtonContainer">
        <asp:HyperLink ID="BackUpHyperLink" runat="server" CssClass="back">Regresar</asp:HyperLink>
    </div>
    <asp:HiddenField ID="RequestedCategoryHidden" runat="server" />
    <div class="listContent">
        <div class="itemLetter">
            <h1>
                <asp:Label ID="titleLabel" runat="server"></asp:Label></h1>
            <bsx:LetterCategoriesControl ID="LetterCategoriesControl1" runat="server" />
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="ButtonContainer">
        <asp:HyperLink ID="BackBottomHyperLink" runat="server" CssClass="back">Regresar</asp:HyperLink>
    </div>
</asp:Content>
