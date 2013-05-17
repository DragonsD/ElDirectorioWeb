<%@ Page Title="Conceptos" Language="C#" MasterPageFile="~/Shared/Normal.master"
    AutoEventWireup="true" CodeBehind="AccountConceptForm.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.AccountConceptForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Conceptos</h1>
    <hr />
    <p>
        <asp:DataList ID="ConceptsDataList" runat="server" DataSourceID="AccountDetailObjectDataSource">
            <ItemTemplate>
                <div class="span-16 last">
                    <div class="span-4">
                        <asp:Label ID="ConceptKeyLabel" runat="server" Text='<%# Eval("ConceptKey") %>' />
                    </div>
                    <div class="span-12 last">
                        <asp:DropDownList ID="ConceptsDropDownList" runat="server" CssClass="dropdown">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ConceptsDropDownList"
                            Display="Dynamic" ErrorMessage="Requerido">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
                <asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Eval("Description") %>' Width="300px" />
                <asp:Label ID="AccountConceptIdLabel" runat="server" Text='<%# Eval("AccountConceptId") %>'
                    Style="display: none" />
                <asp:Label ID="GorilaIdLabel" runat="server" Text='<%# Eval("GorilaId") %>' Style="display: none" />
            </ItemTemplate>
        </asp:DataList>
        <asp:ObjectDataSource ID="AccountDetailObjectDataSource" runat="server" SelectMethod="FetchListAll"
            TypeName="bsx.DirLaguna.Dal.AccountConceptController"></asp:ObjectDataSource>
    </p>
    <h1>
        Sucursal</h1>
    <hr />
    <p>
        <div class="span-16 last">
            <div class="span-4">
                Sucursal
            </div>
            <div class="span-12 last">
                <asp:DropDownList ID="OfficesDropDownList" runat="server" CssClass="dropdown">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="OfficesDropDownList"
                    Display="Dynamic" ErrorMessage="Requerido">
                </asp:RequiredFieldValidator>
            </div>
        </div>
    </p>
    <p>
        <div class="span-16 last">
            <div class="span-4">
                Cuenta Bancaria
            </div>
            <div class="span-12 last">
                <asp:DropDownList ID="BankAccountDropDownList" runat="server" CssClass="dropdown">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="BankAccountRequiredFieldValidator" runat="server" ControlToValidate="BankAccountDropDownList"
                    Display="Dynamic" ErrorMessage="Requerido">
                </asp:RequiredFieldValidator>
            </div>
        </div>
    </p>
    <p>
        <div class="span-24 last">
            <div class="SearchButtonContainer">
                <asp:LinkButton ID="SaveButton" runat="server" Text="Guardar" class="button" />
            </div>
            <%--            <asp:LinkButton ID="BackButton" runat="server" Text="Regresar" CausesValidation="false" class="clearSearch"></asp:LinkButton>
            --%>
        </div>
    </p>
</asp:Content>
