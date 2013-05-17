<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Base.Master" AutoEventWireup="true"
    CodeBehind="SignupForm.aspx.cs" Inherits="bsx.DirLaguna.Public.Admin.SignupForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <style type="text/css">
        #itemListContainer
        {
            margin-top: 20px;
        }
        #itemList tr td
        {
            vertical-align: top;
            border-bottom: 1px solid #F0F0F0;
        }
        #itemList tbody td label
        {
            font-weight: normal;
            font-size: 11px;
        }
        tbody tr:nth-child(2n) td textarea, tbody tr.even td textarea
        {
            background: none repeat scroll 0 0 #E5ECF9;
        }
        #aspnetForm
        {
            /*background: transparent url("/App_Themes/Colibri/images/bg2.png") repeat;*/
            padding-bottom: 0px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            documentReady = true;
            calculateTotal();
        });

        function numericKeyPress(event) {
            if (event.which == 13) {
                event.preventDefault();
                $(this).blur();
            }
        }

        function calculateTotal() {
            var totalRows = $("#<%=ConceptGridView.ClientID %> tr").length - 2;
            var total = 0;
            for (var i = 0; i < totalRows; i++) {
                var quantity = $('.QuantityText' + i);
                var price = $('.PriceText' + i);
                total = total + $(quantity).val() * $(price).text();
            }
            if (isNaN(total)) {
                $("[id*=ConceptGridView][id*=TotalLabel]").text('Total: 0.00');
            }
            else {
                $("[id*=ConceptGridView][id*=TotalLabel]").text('Total: ' + total.toFixed(2));
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PrePageContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PreContainerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="content-box-content">
        <h1>
            Registro</h1>
        <hr />
        <div class="span-20 last">
            <p>
                <div class="span-4">
                    Estado
                </div>
                <div class="span-16 last">
                    <asp:DropDownList ID="EstadoDropDownList" runat="server" CssClass="dropdown"
                        AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="EstadoRequiredFieldValidator" runat="server"
                        Display="Dynamic" ErrorMessage="Requerido" ControlToValidate="EstadoDropDownList"
                        InitialValue=""></asp:RequiredFieldValidator>
                </div>
            </p>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <Triggers>
                    <asp:PostBackTrigger ControlID="EstadoDropDownList" />
                </Triggers>
                <ContentTemplate>
                    <p>
                        <div class="span-4">
                            Ciudad
                        </div>
                        <div class="span-16 last">
                            <asp:DropDownList ID="MunicipioDropDownList" runat="server" CssClass="dropdown">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="MunicipioRequiredFieldValidator" runat="server"
                                Display="Dynamic" ErrorMessage="Requerido" ControlToValidate="MunicipioDropDownList"
                                InitialValue=""></asp:RequiredFieldValidator>
                        </div>
                    </p>
                </ContentTemplate>
            </asp:UpdatePanel>

            <p>
                <div class="span-4">
                    Negocio / Anunciante
                </div>
                <div class="span-16 last">
                    <asp:TextBox ID="AdvertiserNameTextBox" runat="server" class="text"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="AdvertiserNameRequiredFieldValidator" runat="server"
                        Display="Dynamic" ErrorMessage=" * Requerido" ControlToValidate="AdvertiserNameTextBox"></asp:RequiredFieldValidator>
                </div>
            </p>
            <p>
                <div class="span-4">
                    Descripción
                </div>
                <div class="span-16 last">
                    <asp:TextBox ID="DescriptionTextBox" runat="server" class="text"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="DescriptionRequiredFieldValidator" runat="server"
                        Display="Dynamic" ErrorMessage=" * Requerido" ControlToValidate="DescriptionTextBox"></asp:RequiredFieldValidator>
                </div>
            </p>
            <p>
                <div class="span-4">
                    Direccion
                </div>
                <div class="span-16 last">
                    <asp:TextBox ID="AddressTextBox" runat="server" class="text"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="AddressRequiredFieldValidator" runat="server" Display="Dynamic"
                        ErrorMessage=" * Requerido" ControlToValidate="AddressTextBox"></asp:RequiredFieldValidator>
                </div>
            </p>
            <p>
                <div class="span-4">
                    Contacto
                </div>
                <div class="span-16 last">
                    <asp:TextBox ID="ContactTextBox" runat="server" class="text"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ContactRequiredFieldValidator" runat="server" Display="Dynamic"
                        ErrorMessage=" * Requerido" ControlToValidate="ContactTextBox"></asp:RequiredFieldValidator>
                </div>
            </p>
            <p>
                <div class="span-4">
                    Contraseña
                </div>
                <div class="span-16 last">
                    <asp:TextBox ID="PasswordTextBox" runat="server" class="text"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PassowrdRequiredFieldValidator" runat="server" Display="Dynamic"
                    ErrorMessage=" * Requerido" ControlToValidate="PasswordTextBox"></asp:RequiredFieldValidator>
                </div>
            </p>
            <p>
                <div class="span-4">
                    Confirmar Contraseña
                </div>
                <div class="span-16 last">
                    <asp:TextBox ID="ConfirmarTextBox" runat="server" class="text"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ConfirmarRequiredFieldValidator" runat="server" Display="Dynamic"
                    ErrorMessage="Requerido" ControlToValidate="ConfirmarTextBox"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="PasswordCompareValidator" runat="server" ErrorMessage=" * La contraseña no es igual"
                    ControlToValidate="ConfirmarTextBox" ControlToCompare="PasswordTextBox" Display="Dynamic">
                </asp:CompareValidator>
                </div>
            </p>
            <p>
                <div class="span-4">
                    Correo electrónico
                </div>
                <div class="span-16 last">
                    <asp:TextBox ID="EmailTextBox" runat="server" class="text"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" Display="Dynamic"
                        ErrorMessage=" * Requerido" ControlToValidate="EmailTextBox"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="EmailTextBox"
                        Display="Dynamic" ErrorMessage=" * Format No Válido" ForeColor="Red" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>
                </div>
            </p>
            <asp:HiddenField ID="jsonTextBox" runat="server" Value=""></asp:HiddenField>
            <div class="clear">
                <br />
            </div>
        </div>
        <div class="span-20 last">
            Quiero que mi anuncio sea:
        </div>
        <div class="clear">
        </div>
        <div class="span-20 last">
            <asp:GridView ID="ConceptGridView" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSourceAccountConcept"
                EnableModelValidation="True" ShowFooter="True">
                <Columns>
                    <asp:BoundField DataField="ConceptKey" HeaderText="Concepto" SortExpression="ConceptKey" />
                    <asp:TemplateField HeaderText="Cantidad" SortExpression="TotalMax">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" class='<%#String.Format("QuantityText{0}", Container.DataItemIndex) %>'
                                Text='<%# Bind("TotalMax") %>' onblur='calculateTotal()'>
                            </asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Valor No Valido"
                             ControlToValidate="TextBox2" Type="Integer" Operator="DataTypeCheck" ></asp:CompareValidator>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Precio" SortExpression="AccountConceptId">
                        <ItemTemplate>
                            <div style="text-align: right;">
                                <asp:Label ID="UnitPriceLabel" runat="server"></asp:Label>
                                <asp:Label ID="UnitPriceLessSymbolLabel" class='<%#String.Format("PriceText{0}", Container.DataItemIndex) %>'
                                    runat="server" style="display:none;"></asp:Label>
                            </div>
                            <asp:Label ID="AccountConceptIdLabel" runat="server" Text='<%# Eval("AccountConceptId") %>'
                                Style="display: none;"></asp:Label>
                            <asp:Label ID="GorilaIdLabel" runat="server" Text='<%# Eval("GorilaId") %>' Style="display: none;"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                        <FooterTemplate>
                            <asp:Label ID="TotalLabel" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSourceAccountConcept" runat="server" SelectMethod="FetchListAllByConfiguration"
                TypeName="bsx.DirLaguna.Dal.AccountConceptController"></asp:ObjectDataSource>
        </div>
        <div class="clear">
        </div>
        <div class="span-20 last">
        </div>
        <div class="clear">
        </div>
        <div class="span-24 last">
            <asp:Label ID="Msg" runat="server"></asp:Label>
        </div>
        <div class="span-20 last">
            <div class="ButtonContainer">
                <asp:LinkButton ID="SaveAndPaymentButton" runat="server" Text="Registrar y Pasar a Pagar"
                    class="button" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="AdsPageContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="PostPageContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="CustomJavascriptContentPlaceHolder"
    runat="server">
</asp:Content>
