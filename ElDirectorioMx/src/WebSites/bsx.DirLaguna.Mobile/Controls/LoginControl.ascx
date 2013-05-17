<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs"
    Inherits="bsx.DirLaguna.Mobile.Controls.LoginControl" %>
<div class="loginContainer">
    <div id="login">
        <asp:LoginView ID="LoginView" runat="server">
            <AnonymousTemplate>
                <asp:Login ID="Login" CssClass="" runat="server" RememberMeSet="false" UserNameLabelText=""
                    FailureText="El usuario o la contraseña son inválidos" PasswordRecoveryUrl="~/Rememberme.aspx"
                    CreateUserUrl='<%=this.DashboardUrl %>' PasswordRecoveryText="Olvidé mi contraseña"
                    CreateUserText="Registrar" OnLoggedIn="Login_LoggedIn" OnLoggingIn="Login_LoggingIn"
                    OnLoginError="Login_LoginError">
                    <LayoutTemplate>
                        <div class="content-box">
                            <div class="content-box-content">
                                <div class="validator">
                                    <asp:Panel runat="server" ID="FailurePanel" Visible="false" CssClass="error">
                                        <asp:Label ID="FailureText" runat="server" EnableViewState="False"></asp:Label>
                                    </asp:Panel>
                                </div>
                                <div class="textUser">
                                    <div class="span-8 last">
                                        <div class="span-8 last">
                                            <asp:Label ID="Label1" runat="server" CssClass="LoginText requiredLabel" AssociatedControlID="UserName">Usuario</asp:Label>
                                        </div>
                                        <div class="span-8 last textContainer">
                                            <asp:TextBox ID="UserName" runat="server" SkinID="LoginInput" CssClass="LoginInput text formField"
                                                MaxLength="100"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="textPassword">
                                    <div class="span-8 last">
                                        <div class="span-8 last">
                                            <asp:Label ID="Label2" runat="server" CssClass="LoginText requiredLabel" AssociatedControlID="Password"
                                                Text="Contraseña"></asp:Label>
                                        </div>
                                        <div class="span-8 last textContainer">
                                            <asp:TextBox ID="Password" runat="server" SkinID="LoginInput" CssClass="LoginInput text formField"
                                                MaxLength="100" TextMode="Password"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="span-8 last">
                                    <div class="ButtonContainer filterField filterFieldButton">
                                        <asp:Button ID="LoginButton" runat="server" CssClass="button login" CommandName="Login"
                                            CausesValidation="true" Text="Iniciar sesión" ValidationGroup="ctl00$Login" />
                                        <br />
                                        <a href="/Rememberme.aspx" title="Recuperar Contraseña">Olvidé mi contraseña</a>
                                    </div>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </LayoutTemplate>
                    <FailureTextStyle CssClass="error" />
                </asp:Login>
            </AnonymousTemplate>
            <LoggedInTemplate>
                <ul class="loggedIn">
                    <li>
                        <asp:HyperLink NavigateUrl='<%=this.DashboardUrl %>' CssClass="startLink" ID="InicioHyperLink"
                            runat="server" Text="Ir al sistema"></asp:HyperLink>
                    </li>
                    <li>
                        <asp:LoginStatus ID="loginStatus" runat="server" CssClass="statusLink" LoginText="Entrar"
                            LogoutText="Salir" />
                    </li>
                    <li>
                        <asp:LoginName ID="loginName" CssClass="userNameLabel" runat="server" />
                    </li>
                </ul>
            </LoggedInTemplate>
        </asp:LoginView>
    </div>
</div>
