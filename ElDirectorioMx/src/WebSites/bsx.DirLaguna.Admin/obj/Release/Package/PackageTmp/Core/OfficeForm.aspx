<%@ Page Title="Nueva Sucursal" Language="C#" MasterPageFile="~/Shared/Normal.master"
    AutoEventWireup="True" CodeBehind="OfficeForm.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.OfficeForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function Count(text, long) {
            var maxlength = new Number(long);
            if (text.value.length > maxlength) {
                text.value = text.value.substring(0, maxlength);
                //alert(" Only " + long + " chars");
            }
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1>
        <asp:Label ID="OfficeNameLabel" runat="server" Text="Nueva Sucursal"></asp:Label></h1>
    <hr />
    <p>
        <div class="span-16">
            <h3>
                Datos Generales</h3>
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
                    Calle
                </div>
                <div class="span-11">
                    <asp:TextBox ID="StreetTextBox" runat="server" CssClass="text"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="NameTextBox"></asp:RequiredFieldValidator>
                </div>
            </p>
            <p>
                <div class="span-4">
                    Número
                </div>
                <div class="span-11">
                    <asp:TextBox ID="NumberTextBox" runat="server" CssClass="text"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="NameTextBox"></asp:RequiredFieldValidator>
                </div>
            </p>
            <p>
                <div class="span-4">
                    Colonia
                </div>
                <div class="span-11">
                    <asp:TextBox ID="NeghbornhodTextBox" runat="server" CssClass="text"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="NameTextBox"></asp:RequiredFieldValidator>
                </div>
            </p>
            <p>
                <div class="span-4">
                    Código Postal
                </div>
                <div class="span-11">
                    <asp:TextBox ID="ZipCodeTextBox" runat="server" CssClass="text"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="NameTextBox"></asp:RequiredFieldValidator>
                </div>
            </p>
            <p>
                <div class="span-4">
                    Estado
                </div>
                <div class="span-11">
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
                        <div class="span-9 last">
                            <asp:DropDownList ID="MunicipioDropDownList" runat="server" CssClass="dropdown">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="MunicipioRequiredFieldValidator" runat="server" Display="Dynamic"
                                ErrorMessage="Requerido" ControlToValidate="MunicipioDropDownList" InitialValue=""></asp:RequiredFieldValidator>
                        </div>
                    </p>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="clear">
            </div>
            <p>
                <div class="span-4">
                    Ubicación (mapa)
                </div>
                <div class="span-11">
                    <asp:TextBox ID="MapReferenceTextBox" runat="server" CssClass="text"></asp:TextBox>
                </div>
            </p>
        </div>
    </p>
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
