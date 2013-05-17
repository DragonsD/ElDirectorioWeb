<%@ Page Title="Nuevo usuario" Language="C#" MasterPageFile="~/Shared/Normal.master"
    AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.UserForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="headerTitle">
        <h1>
            Usuario</h1>
    </div>
    <hr />
    <p>
        <div class="span-24 last">
            <div class="span-4">
                Nombre de Usuario
            </div>
            <div class="span-8">
                <asp:TextBox ID="UserNameTextBox" runat="server" CssClass="text"></asp:TextBox>
            </div>
            <div class="span-8 last">
                <asp:RequiredFieldValidator ID="UserNameRequiredFieldValidator" runat="server" Display="Dynamic"
                    ErrorMessage="Requerido" ControlToValidate="UserNameTextBox"></asp:RequiredFieldValidator>
            </div>
        </div>
    </p>
    <asp:PlaceHolder ID="ConfirmPlaceHolder" runat="server">
        <p>
            <div class="span-24 last">
                <div class="span-4">
                    Contraseña
                </div>
                <div class="span-8">
                    <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" CssClass="text"></asp:TextBox>
                </div>
                <div class="span-8 last">
                    <asp:RequiredFieldValidator ID="PassowrdRequiredFieldValidator" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="PasswordTextBox"></asp:RequiredFieldValidator>
                </div>
            </div>
        </p>
        <p>
            <div class="span-24 last">
                <div class="span-4">
                    Confirmar Contraseña
                </div>
                <div class="span-8">
                    <asp:TextBox ID="ConfirmarTextBox" runat="server" TextMode="Password" CssClass="text"></asp:TextBox>
                </div>
                <div class="span-8 last">
                    <asp:RequiredFieldValidator ID="ConfirmarRequiredFieldValidator" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="ConfirmarTextBox"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="PasswordCompareValidator" runat="server" ErrorMessage="La contraseña no es igual"
                        ControlToValidate="ConfirmarTextBox" ControlToCompare="PasswordTextBox" Display="Dynamic">
                    </asp:CompareValidator>
                </div>
            </div>
        </p>
    </asp:PlaceHolder>
    <p>
        <div class="span-24 last">
            <div class="span-4">
                Correo
            </div>
            <div class="span-8">
                <asp:TextBox ID="EmailTextBox" runat="server" CssClass="text"></asp:TextBox>
            </div>
            <div class="span-8 last">
                <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" Display="Dynamic"
                    ErrorMessage="Requerido" ControlToValidate="EmailTextBox"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator" runat="server"
                    ControlToValidate="EmailTextBox" Display="Dynamic" ErrorMessage="Formato de correo no válido"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
        </div>
    </p>
    <div class="span-24 last">
        <p>
            <div class="span-4">
                Aprobado
            </div>
            <div class="span-8 append-12 last">
                <asp:CheckBox ID="AprovedCheckBox" runat="server" />
            </div>
        </p>
    </div>
    <div class="span-24 last">
        <p>
            <div class="span-4">
                Bloqueado
            </div>
            <div class="span-8 append-12 last">
                <asp:CheckBox ID="LockoutCheckBox" runat="server" Enabled="false" />
            </div>
        </p>
    </div>
    <div class="span-24 last">
        <p>
            <div class="span-4">
                Comentario
            </div>
            <div class="span-8">
                <asp:TextBox ID="CommentTextBox" runat="server" CssClass="text"></asp:TextBox>
            </div>
            <div class="span-8 last">
                <%--                <asp:RequiredFieldValidator ID="CommentRequiredFieldValidator" runat="server" Display="Dynamic"
                    ErrorMessage="Requerido" ControlToValidate="CommentTextBox"></asp:RequiredFieldValidator>--%>
            </div>
        </p>
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
