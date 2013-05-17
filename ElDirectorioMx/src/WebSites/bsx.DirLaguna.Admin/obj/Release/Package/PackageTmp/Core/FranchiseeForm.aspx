<%@ Page Title="Franquiciatario" Language="C#" MasterPageFile="~/Shared/Normal.master"
    AutoEventWireup="true" CodeBehind="FranchiseeForm.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.FranchiseeForm" %>

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
    </script>
    <h1>
        Franquiciatario</h1>
    <hr />
    <div class="span-16 append-8 last">
        <h3>
            Datos Generales</h3>
        <p>
            <div class="span-4">
                Nombre
            </div>
            <div class="span-11 last">
                <asp:TextBox ID="NameTextBox" runat="server" CssClass="text"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                    ErrorMessage="Requerido" ControlToValidate="NameTextBox"></asp:RequiredFieldValidator>
            </div>
        </p>
        <%--<p>
            <div class="span-4">
                Password
            </div>
            <div class="span-11 last">
                <asp:Label ID="PasswordLabel" runat="server" Text="[text]"></asp:Label>
            </div>
        </p>--%>
        <p>
            <div class="span-4">
                Nivel Franquiciatario
            </div>
            <div class="span-11 last">
                <asp:DropDownList ID="ShareLevelDropDownList" runat="server" CssClass="dropdown">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="ShareLevelRequiredFieldValidator" runat="server"
                    Display="Dynamic" ErrorMessage="Requerido" ControlToValidate="ShareLevelDropDownList"
                    InitialValue=""></asp:RequiredFieldValidator>
            </div>
        </p>
        <p>
            <div class="span-4">
                Estado
            </div>
            <div class="span-11 last">
                <asp:DropDownList ID="EstadoDropDownList" runat="server" CssClass="dropdown" AutoPostBack="true">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="EstadoRequiredFieldValidator" runat="server" Display="Dynamic"
                    ErrorMessage="Requerido" ControlToValidate="EstadoDropDownList" InitialValue=""></asp:RequiredFieldValidator>
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
                    <div class="span-11 last">
                        <asp:DropDownList ID="MunicipioDropDownList" runat="server" CssClass="dropdown">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="MunicipioRequiredFieldValidator" runat="server" Display="Dynamic"
                            ErrorMessage="Requerido" ControlToValidate="MunicipioDropDownList" InitialValue=""></asp:RequiredFieldValidator>
                    </div>
                </p>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:PlaceHolder ID="ConfirmPlaceHolder" runat="server">
            <p>
                <div class="span-4">
                    Contraseña
                </div>
                <div class="span-8">
                    <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" CssClass="text"></asp:TextBox>
                </div>
                <div class="span-4 last">
                    <asp:RequiredFieldValidator ID="PassowrdRequiredFieldValidator" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="PasswordTextBox"></asp:RequiredFieldValidator>
                </div>
            </p>
            <p>
                <div class="span-4">
                    Confirmar Contraseña
                </div>
                <div class="span-8">
                    <asp:TextBox ID="ConfirmarTextBox" runat="server" TextMode="Password" CssClass="text"></asp:TextBox>
                </div>
                <div class="span-4 last">
                    <asp:RequiredFieldValidator ID="ConfirmarRequiredFieldValidator" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="ConfirmarTextBox"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="PasswordCompareValidator" runat="server" ErrorMessage="La contraseña no es igual"
                        ControlToValidate="ConfirmarTextBox" ControlToCompare="PasswordTextBox" Display="Dynamic">
                    </asp:CompareValidator>
                </div>
            </p>
            <div class="clear">
            </div>
        </asp:PlaceHolder>
        <p>
            <div class="span-4">
                Correo
            </div>
            <div class="span-8">
                <asp:TextBox ID="EmailTextBox" runat="server" CssClass="text"></asp:TextBox>
            </div>
            <div class="span-4 last">
                <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" Display="Dynamic"
                    ErrorMessage="Requerido" ControlToValidate="EmailTextBox"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator" runat="server"
                    ControlToValidate="EmailTextBox" Display="Dynamic" ErrorMessage="Formato de correo no válido"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
        </p>
        <p>
            <div class="span-4">
                Dirección
            </div>
            <div class="span-11 last">
                <asp:TextBox ID="AddressTextBox" runat="server" CssClass="text"></asp:TextBox>
            </div>
        </p>
        <p>
            <div class="span-4">
                Teléfono
            </div>
            <div class="span-11 last">
                <asp:TextBox ID="PhoneTextBox" runat="server" CssClass="text"></asp:TextBox>
            </div>
        </p>
        <p>
            <div class="span-4">
                Celular
            </div>
            <div class="span-11 last">
                <asp:TextBox ID="CellTextBox" runat="server" CssClass="text"></asp:TextBox>
            </div>
        </p>
        <p>
            <div class="span-6 prepend-4 append-6 last">
                <asp:CheckBox ID="AprovedCheckBox" runat="server" Text="Aprobado" />
            </div>
        </p>
        <p>
            <div class="span-6 prepend-4 append-4 last">
                <asp:CheckBox ID="LockoutCheckBox" runat="server" Enabled="false" Text="Bloqueado" />
            </div>
        </p>
    </div>
    <p>
        <div class="span-11 prepend-4 last">
            <asp:CheckBox ID="RequiredInvoiceCheckBox" runat="server" AutoPostBack="true" Text="El usuario requiere factura?" />
        </div>
        <div class="clear">
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="RequiredInvoiceCheckBox" />
            </Triggers>
            <ContentTemplate>
                <asp:PlaceHolder ID="FiscalDetailPlaceHolder" runat="server">
                    <bsx:FiscalDetailControl ID="FiscalDetailCtrl1" runat="server"></bsx:FiscalDetailControl>
                </asp:PlaceHolder>
            </ContentTemplate>
        </asp:UpdatePanel>
    </p>
    <div class="clear">
    </div>
    <p>
        <div class="span-6 prepend-18 last">
            <div class="SearchButtonContainer">
                <asp:LinkButton ID="SaveButton" runat="server" Text="Guardar" class="button" />
                <asp:LinkButton ID="BackButton" runat="server" Text="Regresar" CausesValidation="false"
                    class="clearSearch"></asp:LinkButton>
            </div>
        </div>
    </p>
</asp:Content>
