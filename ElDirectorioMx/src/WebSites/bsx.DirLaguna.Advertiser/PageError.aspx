<%@ Page Title="Error" Language="C#" MasterPageFile="~/Shared/Admin.Master" AutoEventWireup="true"
    CodeBehind="PageError.aspx.cs" Inherits="bsx.DirLaguna.Advertiser.PageError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="text-align: center">
        Ha ocurrido un error.
        <br />
        <a href="Logout.aspx">Volver a intentarlo</a>
    </div>
</asp:Content>
