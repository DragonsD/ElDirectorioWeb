<%@ Page Title="Contratación" Language="C#" MasterPageFile="~/Shared/Normal.master"
    AutoEventWireup="true" CodeBehind="ContractForm.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.ContractForm" %>

<%@ Register Src="../Controls/AccountDetailControl.ascx" TagName="AccountDetailControl"
    TagPrefix="bsx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#<%=CompromiseDate.ClientID %>").datepicker();
            $("#format").change(function () {
                $("#<%=CompromiseDate.ClientID %>").datepicker("option", "dateFormat", $(this).val());
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Contrataciones</h1>
    <hr />
    <p>
        <div class="span-16 last">
            <h3>
                <asp:Label ID="AdvertiserNameLabel" runat="server" CssClass="text" Text=""></asp:Label>
            </h3>
        </div>
    </p>
    <asp:PlaceHolder ID="IsPrimaryPlaceHolder" runat="server">
        <p>
            <div class="span-24 last">
                <div class="span-4">
                    Activa
                </div>
                <div class="span-8 last">
                    <asp:CheckBox ID="ActiveCheckBox" runat="server"></asp:CheckBox>
                </div>
            </div>
        </p>
        <p>
            <div class="span-24 last">
                <div class="span-4">
                    Pagada
                </div>
                <div class="span-8 last">
                    <asp:CheckBox ID="IsPaidCheckBox" runat="server"></asp:CheckBox>
                </div>
            </div>
        </p>
        <p>
            <div class="span-24 last">
                <div class="span-4">
                    Factura
                </div>
                <div class="span-8 last">
                    <asp:TextBox ID="InvoiceTextBox" class="text" Width="100px" runat="server"></asp:TextBox>
                </div>
            </div>
        </p>
        <p>
            <div class="span-24 last">
                <div class="span-4">
                    Fecha compromiso
                </div>
                <div class="span-8 last">
                    <asp:TextBox ID="CompromiseDate" class="text" Width="100px" runat="server"></asp:TextBox>
                </div>
            </div>
        </p>
    </asp:PlaceHolder>
    <div class="clear">
        <br />
    </div>
    <p>
        <bsx:AccountDetailControl ID="AccountDetailControl1" runat="server" />
    </p>
    <div class="clear">
    </div>
    <p>
        <div class="span-24 last">
            <div class="SearchButtonContainer">
                <asp:LinkButton ID="SaveButton" runat="server" Text="Guardar" class="button" />
                <asp:LinkButton ID="BackLinkButton" runat="server" Text="Regresar" CausesValidation="false"
                    class="clearSearch"></asp:LinkButton>
            </div>
        </div>
    </p>
    <div class="clear">
    </div>
</asp:Content>
