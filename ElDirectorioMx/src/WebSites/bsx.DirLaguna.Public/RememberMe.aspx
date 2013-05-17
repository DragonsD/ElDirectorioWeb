<%@ Page Title="Recuperar contraseña" Language="C#" MasterPageFile="~/Shared/NestedBaseMasterPage.Master"
    AutoEventWireup="true" CodeBehind="RememberMe.aspx.cs" Inherits="bsx.DirLaguna.Public.RememberMe" %>

<asp:Content ID="Content4" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
    <div class="framedContent">
        <div class="loginContainer">
            <asp:Label ID="Msg" runat="server" ForeColor="maroon" /><br />
            <div id="login">
                <div class="content-box">
                    <div class="content-box-content">
                        <%--Username:--%>
                        <div class="textContainer filterField">
                            <asp:TextBox placeholder="Nombre de usuario" ID="UsernameTextBox" Columns="30" runat="server"
                                CssClass="LoginInput text whatField" AutoPostBack="false" />
                        </div>
                        <asp:RequiredFieldValidator ID="UsernameRequiredValidator" runat="server" ControlToValidate="UsernameTextBox"
                            ForeColor="red" Display="Dynamic" ErrorMessage="Required" /><br />
                        <div class="ButtonContainer">
                            <asp:Button ID="EmailPasswordButton" Text="Enviar a mi Email" runat="server" />
                        </div>
                        <div class="clear">
                        <br />
                        </div>
                        <div class="recoverPass ButtonContainer">
                            <a href="/Login.aspx" title="Ir Login">Ir a Login :)</a>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
