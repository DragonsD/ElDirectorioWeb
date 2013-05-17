<%@ Page Title="Cupón" Language="C#" MasterPageFile="~/Shared/Admin.Master" AutoEventWireup="true"
    CodeBehind="CouponForm.aspx.cs" Inherits="bsx.DirLaguna.Advertiser.CouponForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function Count(text, long) {
            var maxlength = new Number(long);
            if (text.value.length > maxlength) {
                text.value = text.value.substring(0, maxlength);
                //alert(" Only " + long + " chars");
            }
        }
        $(function () {
            $("#<%=StartDateTextBox.ClientID %>").datepicker();
            $("#format").change(function () {
                $("#<%=StartDateTextBox.ClientID %>").datepicker("option", "dateFormat", $(this).val());
            });
            $("#<%=EndDateTextBox.ClientID %>").datepicker();
            $("#format").change(function () {
                $("#<%=EndDateTextBox.ClientID %>").datepicker("option", "dateFormat", $(this).val());
            });
        });
    </script>
    <h1>
        <asp:Label ID="CouponNameLabel" runat="server" Text="Nuevo Cupon"></asp:Label></h1>
    <hr />
    <div class="span-16">
        <h3>
            Cupon</h3>
        <p>
            <div class="span-4">
                Estado
            </div>
            <div class="span-12 last">
                <asp:DropDownList ID="StatusDropDownList" runat="server" CssClass="dropdown">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic"
                    ErrorMessage="Requerido" ControlToValidate="StatusDropDownList" InitialValue=""></asp:RequiredFieldValidator>
            </div>
        </p>
        <p>
            <div class="span-4">
                Nombre
            </div>
            <div class="span-12 last">
                <asp:TextBox ID="NameTextBox" runat="server" CssClass="text"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                    ErrorMessage="Requerido" ControlToValidate="NameTextBox"></asp:RequiredFieldValidator>
            </div>
        </p>
        <p>
            <div class="span-4">
                Descripcion
            </div>
            <div class="span-12 last">
                <asp:TextBox ID="DescriptionTextBox" runat="server" CssClass="multitext" TextMode="MultiLine"
                    Height="80px" onKeyUp="javascript:Count(this,480);" onChange="javascript:Count(this,480);"></asp:TextBox>
                <%--                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                    ErrorMessage="Requerido" ControlToValidate="DescriptionTextBox"></asp:RequiredFieldValidator><br />
                maximo 190 caracteres--%>
            </div>
        </p>
        <p>
            <div class="span-4">
                Condiciones
            </div>
            <div class="span-12 last">
                <asp:TextBox ID="ConditionsTextBox" runat="server" CssClass="multitext" TextMode="MultiLine"
                    Height="80px" onKeyUp="javascript:Count(this,480);" onChange="javascript:Count(this,480);"></asp:TextBox>
                <%--                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                    ErrorMessage="Requerido" ControlToValidate="ConditionsTextBox"></asp:RequiredFieldValidator><br />
                maximo 190 caracteres--%>
            </div>
        </p>
        <p>
            <div class="span-4">
                Como canjear
            </div>
            <div class="span-12 last">
                <asp:TextBox ID="HowToCashTextBox" runat="server" CssClass="multitext" TextMode="MultiLine"
                    Height="80px" onKeyUp="javascript:Count(this,480);" onChange="javascript:Count(this,480);"></asp:TextBox>
                <%--                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                    ErrorMessage="Requerido" ControlToValidate="HowToCashTextBox"></asp:RequiredFieldValidator><br />
                maximo 190 caracteres--%>
            </div>
        </p>
        <p>
            <div class="span-4">
                Categoria
            </div>
            <div class="span-12 last">
            </div>
            <asp:DropDownList ID="CategoryDropDownList" runat="server" Width="310px">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic"
                ErrorMessage="Requerido" ControlToValidate="CategoryDropDownList" ValidationGroup="CatGrp"
                InitialValue=""></asp:RequiredFieldValidator>
            <asp:Button ID="CategoryButton" runat="server" Text="+" ValidationGroup="CatGrp" />
        </p>
        <p>
            <div class="span-8 prepend-4 append-12 last">
                <asp:GridView ID="CategoryGridView" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Categoria" SortExpression="Name" />
                        <asp:TemplateField HeaderText="" ItemStyle-Width="20px">
                            <ItemTemplate>
                                <asp:ImageButton ID="DelButton" runat="server" CommandName="DelItem" CommandArgument='<%#Eval("Id") %>'
                                    CausesValidation="false" ImageUrl="~/App_Themes/Laguna/images/minus-circle.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </p>
        <p>
            <div class="span-4">
                Inicia el
            </div>
            <div class="span-12 last">
                <asp:TextBox ID="StartDateTextBox" runat="server" CssClass="text"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                    ErrorMessage="Requerido" ControlToValidate="StartDateTextBox"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="StartDateRegularExpressionValidator" runat="server"
                    ErrorMessage="Fecha no Valida" ControlToValidate="StartDateTextBox" Display="Dynamic"
                    ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$">
                </asp:RegularExpressionValidator>
                <br />
            </div>
        </p>
        <p>
            <div class="span-4">
                Expira el
            </div>
            <div class="span-12 last">
                <asp:TextBox ID="EndDateTextBox" runat="server" CssClass="text"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                    ErrorMessage="Requerido" ControlToValidate="EndDateTextBox"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="EndDateRegularExpressionValidator" runat="server"
                    ErrorMessage="Fecha no Valida" ControlToValidate="EndDateTextBox" Display="Dynamic"
                    ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$">
                </asp:RegularExpressionValidator>
                <br />
            </div>
        </p>
        <p>
            <div class="span-12 prepend-4 last">
                <asp:CheckBox ID="ExpirableCheckBox" runat="server" Text="El cupon expira?" />
            </div>
        </p>
        <div class="clear">
            <br />
        </div>
        <p>
            <div class="span-4">
                Imagen
            </div>
            <div class="span-12 last">
                <asp:FileUpload ID="ImageFileUpload" runat="server"></asp:FileUpload><br />
                Imagen de 600px de alto y 400 de ancho
            </div>
        </p>
    </div>
    <div class="span-8 last">
        <asp:PlaceHolder ID="ImagePlaceHolder" runat="server">
            <img alt="" src='<%=this.ImageUrl %>' />
        </asp:PlaceHolder>
    </div>
    <div class="clear">
    </div>
    <p>
        <div class="span-24 last">
            <div class="SearchButtonContainer">
                <asp:LinkButton ID="SaveButton" runat="server" Text="Guardar" class="button" />
                <asp:LinkButton ID="BackButton" runat="server" Text="Regresar" CausesValidation="false"
                    class="clearSearch"></asp:LinkButton>
            </div>
        </div>
    </p>
</asp:Content>
