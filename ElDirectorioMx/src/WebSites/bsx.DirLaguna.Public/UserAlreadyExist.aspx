<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/NestedBaseMasterPage.master" AutoEventWireup="true" CodeBehind="UserAlreadyExist.aspx.cs" Inherits="bsx.DirLaguna.Public.UserAlreadyExist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderTitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
    <h1><%= this.Message %></h1>

    <div class="aDetail content-box-content">
        <div class="ButtonContainer">
            <asp:LinkButton ID="BackButton" CssClass="BackButton" runat="server" Text="Regresar"
                CausesValidation="false"></asp:LinkButton>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
