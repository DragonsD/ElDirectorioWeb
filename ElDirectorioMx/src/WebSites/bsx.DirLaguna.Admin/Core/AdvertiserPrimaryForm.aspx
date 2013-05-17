<%@ Page Title="Nuevo anunciante" Language="C#" MasterPageFile="~/Shared/Normal.master"
    MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="AdvertiserPrimaryForm.aspx.cs"
    Inherits="bsx.DirLaguna.Admin.Core.AdvertiserPrimaryForm" %>

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
    <h1>
        <asp:Label ID="AdvertiserNameLabel" runat="server"></asp:Label>
    </h1>
    <hr />
    <p>
        <div class="span-16 last">
            <h3>
                Configuracion</h3>
            <p>
                <div class="span-4">
                    Estado
                </div>
                <div class="span-11">
                    eliminar
                    <%--                    <asp:DropDownList ID="StatusDropDownList" runat="server" CssClass="dropdown">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="StatusDropDownList" InitialValue=""></asp:RequiredFieldValidator>
                    --%>
                </div>
            </p>
            <p>
                <div class="span-4">
                    Mostrar en</div>
                <div class="span-11">
                    <asp:CheckBox ID="ShowInWebsiteCheckbox" runat="server" Text="Web" /><br />
                </div>
            </p>
            <p>
                <div class="prepend-4 span-11">
                    <asp:CheckBox ID="ShowInIOsCheckBox" runat="server" Text="App iOs" />
                </div>
            </p>
            <p>
                <div class="prepend-4 span-11" style="margin-bottom: 10px">
                    Es necesario para que el anunciante aparezca en cualquier lugar que tenga el estado
                    activo, ya a partir de ahí, debe escoger si aparece en Web, iOs o ambos.
                </div>
            </p>
            <p>
                <div class="span-4">
                    Prioridad</div>
                <div class="span-11">
                    <asp:TextBox ID="PriorityTextBox" runat="server" CssClass="text" Width="50px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic"
                        ErrorMessage="Requerido" ControlToValidate="PriorityTextBox"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Numerico"
                        ControlToValidate="PriorityTextBox" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </div>
                <div class="span-11 prepend-4" style="margin-bottom: 10px">
                    La prioridad hace que los elementos se ordenen de acuerdo a grupos dependiendo del
                    grupo, apareciendo en las listas aquellos que tengan una prioridad más alta tanto
                    dentro de los destacados como en la lista de anunciantes normales.<br />
                </div>
            </p>
        </div>
    </p>
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
