<%@ Page Title="Autentificación" Language="C#" MasterPageFile="~/Shared/Public.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="bsx.DirLaguna.Admin.Default" %>

<%@ Register Src="Controls/LoginControl.ascx" TagName="LoginControl" TagPrefix="bsx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="processImg">
        <bsx:LoginControl ID="LoginControl1" runat="server" />
    </div>
</asp:Content>
