<%@ Page Title="Mis Datos" Language="C#" MasterPageFile="~/Shared/Admin.Master" AutoEventWireup="true"
    CodeBehind="MyAccount.aspx.cs" Inherits="bsx.DirLaguna.Advertiser.MyAccount" %>

<%@ Register Src="~/Controls/ContractsControl.ascx" TagName="ContractsControl" TagPrefix="bsx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h1>
        Mis servicios contratados</h1>
    <bsx:ContractsControl ID="ContractsCtrl1" runat="server"></bsx:ContractsControl>
    <hr />
    <div class="span-24">
        <asp:ChangePassword ID="ChangePassword1" runat="server" EnableViewState="False" ContinueDestinationPageUrl="~/AccountForm.aspx"
            ChangePasswordButtonText="Cambiar Contraseña" PasswordLabelText="Contraseña"
            NewPasswordLabelText="Nueva Contraseña" ConfisrmNewPasswordLabelText="Confirmar Nueva Contraseña"
            SuccessText="La contraseña se ha cambiado satisfactoriamente." ChangePasswordTitleText="Cambiar tu contraseña"
            NewPasswordRegularExpressionErrorMessage="Ha ocurrido un error al cambiar la contraseña"
            SuccessTitleText="Cambio de contraseña exitoso.">
            <ChangePasswordTemplate>
                <h1>
                    Cambiar tu contraseña</h1>
                <div class="span-17 last">
                    <p>
                        <div class="span-5">
                            <asp:Label ID="Label2" runat="server" AssociatedControlID="CurrentPassword">Contraseña</asp:Label>
                        </div>
                        <div class="span-12 last">
                            <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" class="text"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="CurrentPassword"
                                ErrorMessage="* Requerido" ToolTip="Requerido" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </p>
                </div>
                <div class="span-17 last">
                    <p>
                        <div class="span-5">
                            <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">Nueva Contraseña</asp:Label>
                        </div>
                        <div class="span-12 last">
                            <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" class="text"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                ErrorMessage="* Requerido" ToolTip="Requerido" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </p>
                </div>
                <div class="span-17 last">
                    <p>
                        <div class="span-5">
                            <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirmar Nueva Contraseña</asp:Label>
                        </div>
                        <div class="span-12 last">
                            <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password" class="text"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                ErrorMessage="* Requerido" ToolTip="Requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                                ForeColor="Red" ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="La contraseña no coincide">
                            </asp:CompareValidator>
                        </div>
                    </p>
                </div>
                <p>
                    <div class="span-17 last">
                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                    </div>
                </p>
                <div class="clear">
                </div>
                <p>
                </p>
                <div class="ButtonContainer" style="text-align: right">
                    <asp:LinkButton ID="ChangePasswordPushButton" runat="server" Text="Cambiar Contraseña"
                        class="button" CommandName="ChangePassword" />
                    <%--<asp:ImageButton ID="ChangePasswordPushButton" runat="server" Text="Cambiar Contraseña"
                        CommandName="ChangePassword" ImageUrl="~/App_Themes/Laguna/images/saveBtn.png" />--%>
                    <asp:LinkButton ID="BackButton" runat="server" Text="Regresar" CausesValidation="false"
                        PostBackUrl="~/AccountForm.aspx"></asp:LinkButton>
                </div>
            </ChangePasswordTemplate>
            <ContinueButtonStyle CssClass="button" Height="40px" />
        </asp:ChangePassword>
    </div>
</asp:Content>
