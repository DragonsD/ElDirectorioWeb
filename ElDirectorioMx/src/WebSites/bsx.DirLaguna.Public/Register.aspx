<%@ Page Title="Registro de usuario" Language="C#" MasterPageFile="~/Shared/NestedBaseMasterPage.Master"
    AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="bsx.DirLaguna.Public.Register" %>

<%--<asp:Content ID="Content3" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PrePageContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PreContainerPlaceHolder" runat="server">
</asp:Content>--%>
<asp:Content ID="Content6" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="aDetail">
        <div class="span-4">
            <label>
                Nombre de Usuario:
            </label>
        </div>
        <div class="span-8">
            <asp:TextBox ID="UserNameTextBox" runat="server" CssClass="text"></asp:TextBox>
        </div>
        <div class="prepend-4 span-8 last">
            <asp:RequiredFieldValidator ID="UserNameRequiredFieldValidator" runat="server" Display="Dynamic"
                ErrorMessage="Requerido" ControlToValidate="UserNameTextBox"></asp:RequiredFieldValidator>
        </div>
        <div class="clear">
        </div>
        <asp:Label ID="Msg" runat="server">
        </asp:Label>
    </div>
    <div class="aDetail">
        <div class="span-4">
            <label>
                Nombre:
            </label>
        </div>
        <div class="span-8">
            <asp:TextBox ID="NameTextBox" runat="server" CssClass="text"></asp:TextBox>
        </div>
        <div class="prepend-4 span-8 last">
            <asp:RequiredFieldValidator ID="NameRequiredFieldValidator" runat="server" Display="Dynamic"
                ErrorMessage="Requerido" ControlToValidate="NameTextBox"></asp:RequiredFieldValidator>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="aDetail">
        <div class="span-4">
            <label>
                Estado:
            </label>
        </div>
        <div class="span-8">
            <asp:DropDownList ID="StatesDropDownList" runat="server" AutoPostBack="true">
            </asp:DropDownList>
        </div>
        <div class="prepend-4 span-8 last">
            <asp:RequiredFieldValidator ID="StatesRequiredFieldValidator" runat="server" Display="Dynamic"
                ErrorMessage="Requerido" ControlToValidate="StatesDropDownList"></asp:RequiredFieldValidator>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="aDetail">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="StatesDropDownList" />
            </Triggers>
            <ContentTemplate>
                <div class="span-4">
                    <label>Ciudad</label>
                </div>
                <div class="span-8 last">
                    <asp:DropDownList ID="CitiesDropDownList" runat="server" CssClass="dropdown">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="MunicipioAdvertiserRequiredFieldValidator" runat="server"
                        Display="Dynamic" ErrorMessage="Requerido" ControlToValidate="CitiesDropDownList"
                        InitialValue=""></asp:RequiredFieldValidator>
                </div>
                <div class="prepend-4 span-8 last">
                    <asp:RequiredFieldValidator ID="CitiesRequiredFieldValidator" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="CitiesDropDownList"></asp:RequiredFieldValidator>
                </div>
                <div class="clear">
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="aDetail">
        <div class="span-4">
            <label>
                Edad:
            </label>
        </div>
        <div class="span-8">
            <%--<asp:TextBox ID="AgeTextBox" runat="server" CssClass="text"></asp:TextBox>--%>
            <asp:DropDownList ID="YearAgeDdl" runat="server">
                <asp:ListItem Selected="True" Value="1">1980</asp:ListItem>
                <asp:ListItem Value="2">1981</asp:ListItem>
                <asp:ListItem Value="3">1982</asp:ListItem>
                <asp:ListItem Value="4">1983</asp:ListItem>
                <asp:ListItem Value="5">1984</asp:ListItem>
                <asp:ListItem Value="6">1985</asp:ListItem>
                <asp:ListItem Value="7">1986</asp:ListItem>
                <asp:ListItem Value="8">1987</asp:ListItem>
                <asp:ListItem Value="9">1988</asp:ListItem>
                <asp:ListItem Value="10">1989</asp:ListItem>
                <asp:ListItem Value="11">1990</asp:ListItem>
                <asp:ListItem Value="12">1991</asp:ListItem>
                <asp:ListItem Value="13">1992</asp:ListItem>
                <asp:ListItem Value="14">1993</asp:ListItem>
                <asp:ListItem Value="15">1994</asp:ListItem>
                <asp:ListItem Value="16">1995</asp:ListItem>
                <asp:ListItem Value="17">1996</asp:ListItem>
                <asp:ListItem Value="18">1997</asp:ListItem>
                <asp:ListItem Value="19">1998</asp:ListItem>
                <asp:ListItem Value="20">1999</asp:ListItem>
                <asp:ListItem Value="21">2000</asp:ListItem>
                <asp:ListItem Value="22">2001</asp:ListItem>
                <asp:ListItem Value="23">2002</asp:ListItem>
                <asp:ListItem Value="24">2003</asp:ListItem>
                <asp:ListItem Value="25">2004</asp:ListItem>
                <asp:ListItem Value="26">2005</asp:ListItem>
                <asp:ListItem Value="27">2006</asp:ListItem>
            </asp:DropDownList>

        </div>
        <div class="prepend-4 span-8 last">
            <asp:RequiredFieldValidator ID="AgeRequiredFieldValidator" runat="server" Display="Dynamic"
                ErrorMessage="Requerido" ControlToValidate="YearAgeDdl"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="AgeCompareValidator" runat="server" ErrorMessage="Debe ser valor numerico entero"
                ControlToValidate="YearAgeDdl" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
        </div>
        <div class="clear">
        </div>
    </div>
    <asp:PlaceHolder ID="ConfirmPlaceHolder" runat="server">
        <div class="aDetail">
            <div class="span-4">
                <label>
                    Contraseña:</label>
            </div>
            <div class="span-8">
                <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" CssClass="text"></asp:TextBox>
            </div>
            <div class="prepend-4 span-8 last">
                <asp:RequiredFieldValidator ID="PassowrdRequiredFieldValidator" runat="server" Display="Dynamic"
                    ErrorMessage="Requerido" ControlToValidate="PasswordTextBox"></asp:RequiredFieldValidator>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="aDetail">
            <div class="span-4">
                <label>
                    Confirmar Contraseña:
                </label>
            </div>
            <div class="span-8">
                <asp:TextBox ID="ConfirmarTextBox" runat="server" TextMode="Password" CssClass="text"></asp:TextBox>
            </div>
            <div class="prepend-4 span-8 last">
                <asp:RequiredFieldValidator ID="ConfirmarRequiredFieldValidator" runat="server" Display="Dynamic"
                    ErrorMessage="Requerido" ControlToValidate="ConfirmarTextBox"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="PasswordCompareValidator" runat="server" ErrorMessage="La contraseña no es igual"
                    ControlToValidate="ConfirmarTextBox" ControlToCompare="PasswordTextBox" Display="Dynamic">
                </asp:CompareValidator>
            </div>
            <div class="clear">
            </div>
        </div>
    </asp:PlaceHolder>
    <div class="aDetail">
        <div class="span-4">
            <label>
                Correo:
            </label>
        </div>
        <div class="span-8">
            <asp:TextBox ID="EmailTextBox" runat="server" CssClass="text"></asp:TextBox>
        </div>
        <div class="prepend-4 span-8 last">
            <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" Display="Dynamic"
                ErrorMessage="Requerido" ControlToValidate="EmailTextBox"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator" runat="server"
                ControlToValidate="EmailTextBox" Display="Dynamic" ErrorMessage="Formato de correo no válido"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="aDetail">
        <div class="span-4">
            <label>
            </label>
        </div>
        <div class="span-8 last">
            <asp:CheckBox ID="AcceptCouponsCheckBox" runat="server" CssClass="checkbox" Text="Acepta recibir información de cupones" />
        </div>
        <div class="clear">
        </div>
    </div>
    <%--<div class="aDetail">
        <div class="span-4">
            <label>
                Comentario:
            </label>
        </div>
        <div class="span-8">
            <asp:TextBox ID="CommentTextBox" runat="server" CssClass="text"></asp:TextBox>
        </div>
    </div>--%>
    <div class="aDetail">
        <div class="span-4">
            <asp:Label ID="lbCuen" Text="¿Cuentas con una Tarjeta Del Club El Directorio?" runat="server" />
        </div>
        <div class="span-8 last">
            <asp:DropDownList ID="DecitionClub" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DecitionClub_SelectedIndexChanged">
                <asp:ListItem Value="1">Si</asp:ListItem>
                <asp:ListItem Value="2">No</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="aDetail">
        <div class="span-4">
            <asp:Label ID="lbFolio" Text="No. Folio" runat="server"/>
        </div>
        <div class="span-8 last">
            <asp:TextBox ID="txtNoFolio" runat="server"></asp:TextBox>
        </div>
        <div class="clear">
        </div>
    </div>
        <div class="clear">
        </div>
    </div>
    <div class="aDetail content-box-content">
        <div class="ButtonContainer">
            <%--<asp:ImageButton ID="SaveButton" runat="server" Text="Guardar" ImageUrl="~/App_Themes/Laguna/images/saveBtn.png" />--%>
            <asp:LinkButton ID="SaveButton2" runat="server" Text="Enviar" class="button" />
            <asp:LinkButton ID="BackButton" CssClass="BackButton" runat="server" Text="Regresar"
                CausesValidation="false"></asp:LinkButton>
        </div>
    </div>
</asp:Content>
<%--<asp:Content ID="Content7" ContentPlaceHolderID="AdsPageContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="PostPageContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="CustomJavascriptContentPlaceHolder" runat="server">
</asp:Content>--%>
