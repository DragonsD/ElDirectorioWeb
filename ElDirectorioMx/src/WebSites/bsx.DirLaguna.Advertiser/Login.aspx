<%@ Page Title="El directorio - Mi cuenta" Language="C#" MasterPageFile="~/Shared/Public.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="bsx.DirLaguna.Advertiser.Login" %>

<%@ Register Src="~/Controls/LoginControl.ascx" TagName="LoginControl" TagPrefix="bsx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="span-24 last">
        <div id="loginDiv">
            <div class="framedContent">
                <p>
                    Inicia sesion para acceder al servicio.</p>
            </div>
            <div class="processImg">
                <bsx:LoginControl ID="LoginControl1" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
