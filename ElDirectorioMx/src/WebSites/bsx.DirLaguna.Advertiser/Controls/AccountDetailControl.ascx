<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountDetailControl.ascx.cs"
    Inherits="bsx.DirLaguna.Advertiser.Controls.AccountDetailControl" %>
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
    <br />
    <br />
    <div class="clar">
    </div>
    <h3 style="padding-bottom:15px">
        Caracteristicas contratadas
    </h3>
    <p>
        <div class="span-24 last">
            <asp:GridView ID="ConceptGridView" runat="server" AutoGenerateColumns="False" DataSourceID="AccountDetailObjectDataSource"
                EnableModelValidation="True" ShowFooter="True">
                <Columns>
                    <asp:TemplateField HeaderText="Concepto" SortExpression="ConceptKey">
                        <ItemTemplate>
                            <asp:Label ID="ConceptKeyLabel" runat="server" Text='<%# Eval("ConceptKey") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="300px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cantidad" SortExpression="TotalMax">
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
