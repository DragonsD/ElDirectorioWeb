<%@ Page Title="Nuevo anunciante" Language="C#" MasterPageFile="~/Shared/Normal.master"
    MaintainScrollPositionOnPostback="true" AutoEventWireup="True" CodeBehind="AdvertiserForm.aspx.cs"
    Inherits="bsx.DirLaguna.Admin.Core.AdvertiserForm" %>

<%@ Register Src="~/Controls/FiscalDetailControl.ascx" TagName="FiscalDetailControl"
    TagPrefix="bsx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        function Count(text, long) {
            var maxlength = new Number(long);
            if (text.value.length > maxlength) {
                text.value = text.value.substring(0, maxlength);
                //alert(" Only " + long + " chars");
            }
        }

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
        Anunciante</h1>
    <hr />
    <p>
        <div class="span-16">
            <h3>
                Datos Generales</h3>
            <p>
                <div class="span-4">
                    Estado
                </div>
                <div class="span-11">
                    <asp:DropDownList ID="EstadoAdvertiserDropDownList" runat="server" CssClass="dropdown"
                        AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="EstadoAdvertiserRequiredFieldValidator" runat="server"
                        Display="Dynamic" ErrorMessage="Requerido" ControlToValidate="EstadoAdvertiserDropDownList"
                        InitialValue=""></asp:RequiredFieldValidator>
                </div>
            </p>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <Triggers>
                    <asp:PostBackTrigger ControlID="EstadoAdvertiserDropDownList" />
                </Triggers>
                <ContentTemplate>
                    <p>
                        <div class="span-4">
                            Ciudad
                        </div>
                        <div class="span-9 last">
                            <asp:DropDownList ID="MunicipioAdvertiserDropDownList" runat="server" CssClass="dropdown">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="MunicipioAdvertiserRequiredFieldValidator" runat="server"
                                Display="Dynamic" ErrorMessage="Requerido" ControlToValidate="MunicipioAdvertiserDropDownList"
                                InitialValue=""></asp:RequiredFieldValidator>
                        </div>
                    </p>
                </ContentTemplate>
            </asp:UpdatePanel>
            <p>
                <div class="span-4">
                    Nombre
                </div>
                <div class="span-11">
                    <asp:TextBox ID="NameTextBox" runat="server" CssClass="text"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="NameTextBox"></asp:RequiredFieldValidator>
                </div>
            </p>
            <p>
                <div class="span-4">
                    Descripción
                </div>
                <div class="span-11">
                    <asp:TextBox ID="DescriptionTextBox" runat="server" CssClass="multitext" TextMode="MultiLine"
                        Height="80px" onKeyUp="javascript:Count(this,70);" onChange="javascript:Count(this,70);"></asp:TextBox>
                </div>
                <div class="span-20 prepend-4 last">
                    Descripción de maximo 70 caracteres<br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="DescriptionTextBox"></asp:RequiredFieldValidator>
                <div class="clear">

                </div>
                </div>
                <div class="span-4" id="lbPromo" runat="server">
                    Activar Promociones del Club
                </div>
                <div class="span-11">
                    <asp:CheckBox ID="PromoClubCheckBox" runat="server" AutoPostBack="true" OnCheckedChanged="PromoClubCheckBox_CheckedChanged"/>
                </div>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <Triggers>
                    <asp:PostBackTrigger ControlID="PromoClubCheckBox" />
                </Triggers>
                    <ContentTemplate>
                        <asp:PlaceHolder ID="PromoClubPlaceHolder" runat="server" Visible="false">
                            <p>
                                <div class="span-4">

                                </div>
                                <div class="span-11">
                                    <asp:TextBox ID="PromocionesTextbox" runat="server" CssClass="multitext" TextMode="MultiLine"
                                        Height="80px" onKeyUp="javascript:Count(this,110);" onChange="javascript:Count(this,110);"></asp:TextBox>
                                </div>
                                <div class="span-20 prepend-4 last">
                                    Descripción de maximo 110 caracteres<br />
                                </div>
                                
                                <div class="span-4">
                                    Descripción Promoción 1
                                </div>
                                <div class="span-11">
                                    <asp:TextBox ID="Promo1TextBox" runat="server"></asp:TextBox>
                                </div>
                                <div class="span-4">
                                    Condiciones Promoción 1
                                </div>
                                <div class="span-11">
                                    <asp:TextBox ID="Condition1TextBox" runat="server"></asp:TextBox>
                                </div>
                                <div class="span-4">
                                    Seleccione Imagen para Promoción 1
                                </div>
                                <div class="span-11">
                                    <asp:Image ID="Promo1Image" runat="server" ImageAlign="Middle" />
                                    <asp:FileUpload ID="Promo1File" runat="server" />
                                </div>
                               <div class="span-20 prepend-4 last">
                                   <br />
                                </div>
                                <div class="span-4">
                                    Inicia el
                                </div>
                                <div class="span-11">
                                    <asp:TextBox ID="StartDateTextBox" runat="server" CssClass="text"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="StartDateRegularExpressionValidator" runat="server"
                                        ErrorMessage="Fecha no Valida" ControlToValidate="StartDateTextBox" Display="Dynamic"
                                        ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$">
                                    </asp:RegularExpressionValidator>
                                    <br />
                                </div>
                                <div class="span-4">
                                    Expira el
                                </div>
                                <div class="span-11">
                                    <asp:TextBox ID="EndDateTextBox" runat="server" CssClass="text"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="EndDateRegularExpressionValidator" runat="server"
                                        ErrorMessage="Fecha no Valida" ControlToValidate="EndDateTextBox" Display="Dynamic"
                                        ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$">
                                    </asp:RegularExpressionValidator>
                                    <br />
                                </div>
                            </p>
                        </asp:PlaceHolder>
                        </ContentTemplate>
                </asp:UpdatePanel>
            <div class="clear">
            </div>
            <p id="AditionalInfoP" runat="server">
                <p>
                    <div class="span-4">
                        Video
                    </div>
                    <div class="span-11">
                        <asp:TextBox ID="YoutubeTextBox" runat="server" CssClass="text"></asp:TextBox>
                    </div>
                </p>
                <div class="span-4">
                    Información adicional
                </div>
                <div class="span-11 last">
                    <CKEditor:CKEditorControl ID="XCKEditorControl" FilebrowserBrowseUrl="editorImageUploader.axd"
                        FilebrowserUploadUrl="editorImageUploader.axd" FilebrowserImageUploadUrl="editorImageUploader.axd"
                        runat="server" FilebrowserImageBrowseUrl="editorImageUploader.axd">
                    </CKEditor:CKEditorControl>
                </div>
            </p>
            <div class="clear">
            </div>
            <p>
                <div class="span-4">
                    Calle
                </div>
                <div class="span-11">
                    <asp:TextBox ID="StreetTextBox" runat="server" CssClass="text"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="NameTextBox"></asp:RequiredFieldValidator>
                </div>
            </p>
            <p>
                <div class="span-4">
                    Número
                </div>
                <div class="span-11">
                    <asp:TextBox ID="NumberTextBox" runat="server" CssClass="text"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="NameTextBox"></asp:RequiredFieldValidator>
                </div>
            </p>
            <p>
                <div class="span-4">
                    Colonia
                </div>
                <div class="span-11">
                    <asp:TextBox ID="NeghbornhodTextBox" runat="server" CssClass="text"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="NameTextBox"></asp:RequiredFieldValidator>
                </div>
            </p>
            <p>
                <div class="span-4">
                    Código Postal
                </div>
                <div class="span-11">
                    <asp:TextBox ID="ZipCodeTextBox" runat="server" CssClass="text"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="NameTextBox"></asp:RequiredFieldValidator>
                </div>
            </p>
            <p>
                <div class="span-4">
                    Página Web
                </div>
                <div class="span-11">
                    <asp:TextBox ID="WebPageTextBox" runat="server" CssClass="text"></asp:TextBox>
                </div>
            </p>
            <p>
                <div class="span-4">
                    Facebook
                </div>
                <div class="span-11">
                    <asp:TextBox ID="FacebookTextBox" runat="server" CssClass="text"></asp:TextBox>
                </div>
            </p>
            <p>
                <div class="span-4">
                    Twitter
                </div>
                <div class="span-11">
                    <asp:TextBox ID="TwitterTextBox" runat="server" CssClass="text"></asp:TextBox>
                </div>
            </p>
            <p>
                <div class="span-4">
                    Ubicación (mapa)
                </div>
                <div class="span-11">
                    <asp:TextBox ID="MapReferenceTextBox" runat="server" CssClass="text"></asp:TextBox>
                </div>
            </p>
        </div>
        <div class="span-8 last">
            <h3>
                Logotipo</h3>
            <p>
                <asp:Image ID="FullSizeLogoImage" runat="server" ImageAlign="Middle" />
            </p>
            <p>
                <asp:FileUpload ID="LogoUpload" runat="server" />
            </p>
        </div>
    </p>
    <div class="clear">
    </div>
    <div class="component">
        <div class="span-24 last">
            <h3>
                Telefonos</h3>
            <p>
                <div class="span-4">
                    Telefono
                </div>
                <div class="span-5">
                    <asp:TextBox ID="PhoneTextBox" runat="server" CssClass="text" Width="180px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="PhoneTextBox" ValidationGroup="PhoneGrp"></asp:RequiredFieldValidator>
                </div>
                <div class="span-3">
                    <asp:DropDownList ID="PhoneTypeDropDownList" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="PhoneTypeDropDownList" ValidationGroup="PhoneGrp"
                        InitialValue=""></asp:RequiredFieldValidator>
                </div>
            </p>
            <div class="span-7 append-4 last">
                <div class="control">
                    <asp:Button ID="AddPhoneButton" runat="server" Text="+" ValidationGroup="PhoneGrp" />
                </div>
            </div>
            <p>
                <div class="span-8 prepend-4 append-12 last">
                    <asp:GridView ID="PhoneGridView" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Description" HeaderText="Telefono" SortExpression="Description" />
                            <asp:BoundField DataField="TypeDescription" HeaderText="Tipo" SortExpression="" />
                            <asp:TemplateField HeaderText="" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="DelButton" runat="server" CommandName="DelItem" CommandArgument='<%#Eval("UiId") %>'
                                        CausesValidation="false" ImageUrl="~/App_Themes/Laguna/images/minus-circle.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </p>
        </div>
    </div>
    <div class="component">
        <div class="span-24 last">
            <h3>
                Correos electrónicos</h3>
            <p>
                <div class="span-4">
                    Correo electonico
                </div>
                <div class="span-8">
                    <asp:TextBox ID="EmailTextBox" runat="server" CssClass="text" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="EmailTextBox" ValidationGroup="EmailGrp"></asp:RequiredFieldValidator>
                </div>
            </p>
            <div class="span-7 append-4 last">
                <div class="control">
                    <asp:Button ID="EmailButton" runat="server" Text="+" ValidationGroup="EmailGrp" />
                </div>
            </div>
            <p>
                <div class="span-8 prepend-4 append-12 last">
                    <asp:GridView ID="EmailGridView" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Description" HeaderText="Correo" SortExpression="Description" />
                            <asp:TemplateField HeaderText="" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="DelButton" runat="server" CommandName="DelItem" CommandArgument='<%#Eval("UiId") %>'
                                        CausesValidation="false" ImageUrl="~/App_Themes/Laguna/images/minus-circle.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </p>
        </div>
    </div>
    <div class="component">
        <div class="span-24 last">
            <h3>
                Categorias</h3>
            <p>
                <div class="span-4">
                    Categoria
                </div>
                <div class="span-8">
                    <asp:DropDownList ID="CategoryDropDownList" runat="server" Width="310px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="CategoryDropDownList" ValidationGroup="CatGrp"
                        InitialValue=""></asp:RequiredFieldValidator>
                </div>
            </p>
            <div class="span-7 append-4 last">
                <div class="control">
                    <asp:Button ID="CategoryButton" runat="server" Text="+" ValidationGroup="CatGrp" />
                </div>
            </div>
            <p>
                <div class="span-8 prepend-4 append-12 last">
                    <asp:GridView ID="CategoryGridView" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Description" HeaderText="Categoria" SortExpression="Description" />
                            <asp:TemplateField HeaderText="" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="DelButton" runat="server" CommandName="DelItem" CommandArgument='<%#Eval("UiId") %>'
                                        CausesValidation="false" ImageUrl="~/App_Themes/Laguna/images/minus-circle.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </p>
        </div>
    </div>
    <div class="component">
        <div class="span-24 last">
            <h3>
                Etiquetas</h3>
            <p>
                <div class="span-4">
                    Etiquetas
                </div>
                <div class="span-8">
                    <asp:TextBox ID="TagTextBox" runat="server" CssClass="text" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="TagTextBox" ValidationGroup="LabelGrp"></asp:RequiredFieldValidator>
                </div>
            </p>
            <div class="control">
                <div class="span-4 append-4 last">
                    <asp:Button ID="TagButton" runat="server" Text="+" ValidationGroup="LabelGrp" />
                </div>
            </div>
            <p>
                <div class="span-8 prepend-4 append-12 last">
                    <%--<asp:ListBox ID="TagsListBox" runat="server" Width="170px"></asp:ListBox>--%>
                    <asp:GridView ID="TagsGridView" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Description" HeaderText="Etiqueta" SortExpression="Description" />
                            <asp:TemplateField HeaderText="" ItemStyle-Width="20px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="DelButton" runat="server" CommandName="DelItem" CommandArgument='<%#Eval("UiId") %>'
                                        CausesValidation="false" ImageUrl="~/App_Themes/Laguna/images/minus-circle.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </p>
        </div>
    </div>
    <div class="component">
        <div class="span-24 last">
            <p>
                <div class="span-4">
                    Requiere factura
                </div>
                <div class="span-20 last">
                    <asp:CheckBox ID="RequiredInvoiceCheckBox" runat="server" AutoPostBack="true" />
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <Triggers>
                        <asp:PostBackTrigger ControlID="RequiredInvoiceCheckBox" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:PlaceHolder ID="FiscalDetailPlaceHolder" runat="server">
                            <bsx:FiscalDetailControl ID="FiscalDetailControl" runat="server" />
                            <div class="clear">
                                <br />
                                <br />
                            </div>
                        </asp:PlaceHolder>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
        </div>
        <p>
            <div class="span-13 prepend-11 last">
                <div class="SearchButtonContainer">
                    <asp:LinkButton ID="SavenOfficeButton" runat="server" Text="Guardar y agregar sucursales"
                        class="button" />
                    <asp:LinkButton ID="SaveButton" runat="server" Text="Guardar" class="button" />
                    <asp:LinkButton ID="BackButton" runat="server" Text="Regresar" CausesValidation="false"
                        class="clearSearch"></asp:LinkButton>
                </div>
            </div>
        </p>
    </div>
</asp:Content>
