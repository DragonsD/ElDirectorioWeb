<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountDetailControl.ascx.cs"
    Inherits="bsx.DirLaguna.Admin.Controls.AccountDetailControl" %>
<script type="text/javascript">
    $(function () {
        $("#<%=ContractDateTextBox.ClientID %>").datepicker();
        $("#format").change(function () {
            $("#<%=ContractDateTextBox.ClientID %>").datepicker("option", "dateFormat", $(this).val());
        });
    });
</script>
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
                $("#<%=TotalHiddenField.ClientID %>").val("0");
            }
            else {
                $("[id*=ConceptGridView][id*=TotalLabel]").text('Total: ' + total.toFixed(2));
                $("#<%=TotalHiddenField.ClientID %>").val(total.toFixed(2));
            }
        }

    </script>

<div class="span-16">
    <h3>
        Vigencia</h3>
    <p>
        <div class="span-4" style="padding-left: 5px;">
            Fecha contratacion
        </div>
        <div class="span- 8 last">
            <asp:TextBox ID="ContractDateTextBox" runat="server" class="text" Width="100px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ContractRequiredFieldValidator" runat="server" Display="Dynamic"
                ErrorMessage="Requerido" ControlToValidate="ContractDateTextBox"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Fecha no Valida"
                ControlToValidate="ContractDateTextBox" Display="Dynamic" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$">
            </asp:RegularExpressionValidator>
        </div>
    </p>
    <br />
    <br />
    <br />
    <div class="clar">
    </div>
    <h3>
        Caracteristicas contratadas</h3>
    <p>
    <div class="span-24 last">
        <asp:GridView ID="ConceptGridView" runat="server" AutoGenerateColumns="False" DataSourceID="AccountDetailObjectDataSource"
            EnableModelValidation="True" ShowFooter="True">
            <Columns>
                <asp:TemplateField HeaderText="Concepto" SortExpression="ConceptKey">
                    <ItemTemplate>
                        <asp:Label ID="ConceptKeyLabel" runat="server" Text='<%# Eval("ConceptKey") %>'></asp:Label>
                        <div class="divDescription">
                        <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="300px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cantidad" SortExpression="TotalMax" ItemStyle-Width="150px">
                    <ItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" class='<%#String.Format("QuantityText{0}", Container.DataItemIndex) %>'
                                Text='<%# Bind("TotalMax") %>' onblur='calculateTotal()'>
                            </asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Numero No Valido"
                                ControlToValidate="TextBox2" Type="Integer" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" Display="Dynamic" ErrorMessage="Debe ser al menos 0"
                                ControlToValidate="TextBox2" Operator="GreaterThanEqual" ValueToCompare="0">
                            </asp:CompareValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2"
                                Display="Dynamic" ErrorMessage="Requerido">
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="TotalMaxCompareValidator" runat="server" Display="Dynamic"
                                ErrorMessage='<%# Eval("TotalMax", "El valor tiene que ser menor o igual a {0}") %>'
                                ControlToValidate="TextBox2" Operator="LessThanEqual" Type="Integer" ValueToCompare='<%# Eval("TotalMax") %>'
                                Enabled='<%#((int)Eval("TotalMax"))>0 %>'>
                            </asp:CompareValidator>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Precio" SortExpression="AccountConceptId">
                    <ItemTemplate>
                        <div style="text-align: right;">
                            <asp:Label ID="UnitPriceLabel" runat="server"></asp:Label>
                            <asp:Label ID="UnitPriceLessSymbolLabel" class='<%#String.Format("PriceText{0}", Container.DataItemIndex) %>'
                                runat="server" Style="display: none;"></asp:Label>
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
    </div>
        <asp:HiddenField ID="TotalHiddenField" runat="server" />
        <asp:ObjectDataSource ID="AccountDetailObjectDataSource" runat="server" SelectMethod="FetchListAllByConfiguration"
            TypeName="bsx.DirLaguna.Dal.AccountConceptController"></asp:ObjectDataSource>
    </p>
</div>
