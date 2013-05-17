<%@ Page Title="ElDirectorio.mx - Registro de usuario" Language="C#" MasterPageFile="~/Shared/Base.Master"
    AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="bsx.DirLaguna.Mobile.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1>
        Registro</h1>
    <div class="filterContainer">
        <div id="filters">
            <p>
                <div class="span-24 last">
                    <label class="span-4 requiredLabel">
                        Nombre de Usuario
                        <asp:RequiredFieldValidator ID="UserNameRequiredFieldValidator" runat="server" Display="Dynamic"
                            ErrorMessage="Requerido" ControlToValidate="UserNameTextBox"></asp:RequiredFieldValidator>
                    </label>
                    <div class="span-8">
                        <asp:TextBox ID="UserNameTextBox" runat="server" CssClass="text formField"></asp:TextBox>
                    </div>
                    <div class="span-8 last">
                    </div>
                </div>
            </p>
            <p>
                <div class="span-24 last">
                    <label class="span-4 requiredLabel">
                        Nombre
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                            ErrorMessage="Requerido" ControlToValidate="NameTextBox"></asp:RequiredFieldValidator>
                    </label>
                    <div class="span-8">
                        <asp:TextBox ID="NameTextBox" runat="server" CssClass="text formField"></asp:TextBox>
                    </div>
                    <div class="span-8 last">
                    </div>
                </div>
            </p>
            <p>
                <div class="span-24 last">
                    <label class="span-4 requiredLabel">
                        Estado
                        <asp:RequiredFieldValidator ID="StatesRequiredFieldValidator" runat="server" Display="Dynamic"
                            ErrorMessage="Requerido" ControlToValidate="StatesDropDownList"></asp:RequiredFieldValidator>
                    </label>
                    <div class="span-8">
                        <asp:DropDownList ID="StatesDropDownList" runat="server" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                    <div class="span-8 last">
                    </div>
                </div>
            </p>
            <p>
                <div class="span-24 last">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="StatesDropDownList" />
                        </Triggers>
                        <ContentTemplate>
                            <label class="span-4 requiredLabel">
                                Ciudad
                                <asp:RequiredFieldValidator ID="CityRequiredFieldValidator" runat="server" Display="Dynamic"
                                    ErrorMessage="Requerido" ControlToValidate="CitiesDropDownList"></asp:RequiredFieldValidator>
                            </label>
                            <div class="span-8">
                                <asp:DropDownList ID="CitiesDropDownList" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="span-8 last">
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </p>
            <p>
                <div class="span-24 last">
                    <label class="span-4 requiredLabel">
                        Edad
                        <asp:RequiredFieldValidator ID="AgeRequiredFieldValidator" runat="server" Display="Dynamic"
                            ErrorMessage="Requerido" ControlToValidate="AgeTextBox"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="AgeCompareValidator" runat="server" ErrorMessage="Debe ser valor numerico entero"
                            ControlToValidate="AgeTextBox" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                    </label>
                    <div class="span-8">
                        <asp:TextBox ID="AgeTextBox" runat="server" CssClass="text formField"></asp:TextBox>
                    </div>
                    <div class="span-8 last">
                    </div>
                </div>
            </p>
            <asp:PlaceHolder ID="ConfirmPlaceHolder" runat="server">
                <p>
                    <div class="span-24 last">
                        <label class="span-4 requiredLabel">
                            Contraseña
                            <asp:RequiredFieldValidator ID="PassowrdRequiredFieldValidator" runat="server" Display="Dynamic"
                                ErrorMessage="Requerido" ControlToValidate="PasswordTextBox"></asp:RequiredFieldValidator>
                        </label>
                        <div class="span-8">
                            <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" CssClass="text formField"></asp:TextBox>
                        </div>
                        <div class="span-8 last">
                        </div>
                    </div>
                </p>
                <p>
                    <div class="span-24 last">
                        <label class="span-4 requiredLabel">
                            Confirmar Contraseña
                            <asp:RequiredFieldValidator ID="ConfirmarRequiredFieldValidator" runat="server" Display="Dynamic"
                                ErrorMessage="Requerido" ControlToValidate="ConfirmarTextBox"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="PasswordCompareValidator" runat="server" CssClass="smallValidator"
                                ErrorMessage="Contraseña no coincide" ControlToValidate="ConfirmarTextBox" ControlToCompare="PasswordTextBox"
                                Display="Dynamic">
                            </asp:CompareValidator>
                        </label>
                        <div class="span-8">
                            <asp:TextBox ID="ConfirmarTextBox" runat="server" TextMode="Password" CssClass="text formField"></asp:TextBox>
                        </div>
                        <div class="span-8 last">
                        </div>
                    </div>
                </p>
            </asp:PlaceHolder>
            <p>
                <div class="span-24 last">
                    <label class="span-4 requiredLabel">
                        Correo
                        <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" Display="Dynamic"
                            ErrorMessage="Requerido" ControlToValidate="EmailTextBox"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator" runat="server"
                            ControlToValidate="EmailTextBox" Display="Dynamic" ErrorMessage="Correo no válido"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </label>
                    <div class="span-8">
                        <asp:TextBox ID="EmailTextBox" runat="server" CssClass="text formField"></asp:TextBox>
                    </div>
                    <div class="span-8 last">
                    </div>
                </div>
            </p>
            <div class="span-24 last">
                <p>
                    <div class="span-8 append-12 last">
                        <asp:CheckBox ID="AcceptCouponsCheckBox" CssClass="checkbox" Text="Acepta recibir información de cupones"
                            runat="server" />
                    </div>
                </p>
            </div>
            <p>
                <asp:Label ID="Msg" runat="server"></asp:Label>
            </p>
            <p>
                <div class="span-24 last">
                    <div class="ButtonContainer filterField filterFieldButton">
                        <asp:LinkButton ID="SaveButton" runat="server" Text="Guardar" class="button" />
                        <%--<asp:LinkButton ID="SaveButton" runat="server" Text="Guardar" />
                        <asp:LinkButton ID="BackButton" runat="server" Text="Regresar" CausesValidation="false"></asp:LinkButton>--%>
                    </div>
                </div>
            </p>
        </div>
    </div>
</asp:Content>
