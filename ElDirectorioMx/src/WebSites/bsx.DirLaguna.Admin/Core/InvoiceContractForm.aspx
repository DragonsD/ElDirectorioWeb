<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Normal.master" AutoEventWireup="true"
    CodeBehind="InvoiceContractForm.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.InvoiceContractForm" %>

<%@ Register Src="~/Controls/FiscalDetailReadOnlyControl.ascx" TagName="FiscalDetailReadOnlyControl"
    TagPrefix="bsx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <style>
        #main
        {
            margin: 0 auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="span-24 last">
        <div id="main">
            <h1>
                Facturar Contratacion</h1>
            <hr />
            <div class="span-24 last">
                <bsx:FiscalDetailReadOnlyControl ID="FiscalDetailReadOnlyControl" runat="server" />
            </div>
            <div class="clear">
                <br />
                <br />
            </div>
            <div class="span-24 last">
                <asp:GridView ID="DetailGridView" runat="server" AutoGenerateColumns="False" DataSourceID="DetailObjectDataSource"
                    EnableModelValidation="True">
                    <Columns>
                        <asp:BoundField DataField="DisplayText" HeaderText="Concepto" ReadOnly="True" SortExpression="DisplayText" />
                        <asp:BoundField DataField="Quantity" HeaderText="Cantidad" SortExpression="Quantity" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="DetailObjectDataSource" runat="server" SelectMethod="FetchAllQuantityMoreCeroByContractId"
                    TypeName="bsx.DirLaguna.Dal.AccountDetailController">
                    <SelectParameters>
                        <asp:Parameter Name="contractId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
            <div class="clear">
                <br />
                <br />
            </div>
            <p>
                <div class="span-13 prepend-11 last">
                    <div class="SearchButtonContainer">
                        <asp:LinkButton ID="InvoiceButton" runat="server" Text="Facturar" class="button" />
                        <asp:LinkButton ID="BackButton" runat="server" Text="Regresar" CausesValidation="false"
                            class="clearSearch"></asp:LinkButton>
                    </div>
                </div>
            </p>
        </div>
    </div>
</asp:Content>
