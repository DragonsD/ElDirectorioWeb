<%@ Page Title="Contratación" Language="C#" MasterPageFile="~/Shared/Admin.Master"
    AutoEventWireup="true" CodeBehind="ContractForm.aspx.cs" Inherits="bsx.DirLaguna.Advertiser.ContractForm" %>

<%@ Register Src="~/Controls/AccountDetailControl.ascx" TagName="AccountDetailControl"
    TagPrefix="bsx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h1>
        Contratación</h1>
    <hr />
    <p>
        <div class="span-16 last">
            <h3>
                <asp:Label ID="AdvertiserNameLabel" runat="server" CssClass="text" Text=""></asp:Label>
            </h3>
        </div>
    </p>
    <p>
        <bsx:AccountDetailControl ID="AccountDetailControl1" runat="server" />
    </p>
    <div class="clear">
    </div>
    <p>
        <div class="span-24 last">
            <div class="SearchButtonContainer">
                <asp:LinkButton ID="SaveButton" runat="server" Text="Pasar a Pagar" class="button" />
                <asp:LinkButton ID="BackLinkButton" runat="server" Text="Regresar" CausesValidation="false"
                    class="clearSearch"></asp:LinkButton>
            </div>
        </div>
    </p>
    <div class="clear">
    </div>
</asp:Content>
