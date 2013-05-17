<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Base.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="bsx.DirLaguna.Public.Admin.Login" %>

<%@ Register Src="~/Controls/LoginAdminControl.ascx" TagName="LoginAdminControl" TagPrefix="bsx" %>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
    <div class="processImg">
        <bsx:LoginAdminControl ID="LoginControl1" runat="server" />
    </div>
</asp:Content>
