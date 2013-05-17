<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Public.Master" AutoEventWireup="true"
    CodeBehind="Rememberme.aspx.cs" Inherits="bsx.DirLaguna.Admin.Rememberme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="processImg">
        <div class="loginContainer">
            <asp:Label ID="Msg" runat="server" ForeColor="maroon" /><br />
            <div id="remembermeDiv">
                <div class="content-box">
                    <div class="content-box-content">
                        <div class="textUser">
                            <div class="span-8 last">
                                <asp:Label ID="Label1" runat="server" CssClass="LoginText" AssociatedControlID="UsernameTextBox">Nombre de Usuario</asp:Label>
                            </div>
                            <div class="span-8 last">
                                <div class="textContainer">
                                    <asp:TextBox ID="UsernameTextBox" Columns="30" runat="server" CssClass="LoginInput text whatField"
                                        AutoPostBack="false" />
                                </div>
                                <asp:RequiredFieldValidator ID="UsernameRequiredValidator" runat="server" ControlToValidate="UsernameTextBox"
                                    ForeColor="red" Display="Dynamic" ErrorMessage="Requerido" /><br />
                                <div class="ButtonContainer">
                                    <asp:LinkButton ID="EmailPasswordButton" Text="Enviar a mi Email" runat="server" class="button">
                                    </asp:LinkButton>
                                </div>
                            </div>
                            <div class="recoverPass ButtonContainer">
                                <a href="/Default.aspx" title="Ir Login">Ir a Login :)</a>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
