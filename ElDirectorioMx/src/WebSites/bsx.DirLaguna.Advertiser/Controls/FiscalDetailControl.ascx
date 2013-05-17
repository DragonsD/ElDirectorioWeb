<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FiscalDetailControl.ascx.cs" Inherits="bsx.DirLaguna.Advertiser.Controls.FiscalDetailControl" %>
<h3>
    Datos Fiscales</h3>
    <div class="clear">
        <br />
    </div>
<p>
    <div class="span-4">
        Nombre
    </div>
    <div class="span-20 last">
        <asp:TextBox ID="FiscalNameTextBox" runat="server" CssClass="text" Width="300px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="FiscalNameRequiredFieldValidator" runat="server"
            Display="Dynamic" ErrorMessage="Requerido" ControlToValidate="FiscalNameTextBox"></asp:RequiredFieldValidator>
    </div>
</p>
<p>
    <div class="span-4">
        RFC
    </div>
    <div class="span-20 last">
        <asp:TextBox ID="RFCTextBox" runat="server" CssClass="text" Width="300px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RFCRequiredFieldValidator" runat="server" Display="Dynamic"
            ErrorMessage="Requerido" ControlToValidate="RFCTextBox"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RFCRegularExpressionValidator" runat="server"
            ErrorMessage="Formato de RFC no valido" ControlToValidate="RFCTextBox" Display="Dynamic"
            ValidationExpression="[A-Z,Ñ,&amp;]{3,4}[0-9]{2}[0-1][0-9][0-3][0-9][A-Z,0-9]?[A-Z,0-9]?[0-9,A-Z]?"></asp:RegularExpressionValidator>
    </div>
</p>
<p>
    <div class="span-4">
        Estado
    </div>
    <div class="span-20 last">
        <asp:DropDownList ID="EstadoDropDownList" runat="server" CssClass="dropdown" AutoPostBack="true">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="EstadoRequiredFieldValidator" runat="server" Display="Dynamic"
            ErrorMessage="Requerido" ControlToValidate="EstadoDropDownList" InitialValue=""></asp:RequiredFieldValidator>
    </div>
</p>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
        <asp:PostBackTrigger ControlID="EstadoDropDownList" />
    </Triggers>
    <ContentTemplate>
        <p>
            <div class="span-4">
                Municipio
            </div>
            <div class="span-20 last">
                <asp:DropDownList ID="MunicipioDropDownList" runat="server" CssClass="dropdown">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="MunicipioRequiredFieldValidator" runat="server" Display="Dynamic"
                    ErrorMessage="Requerido" ControlToValidate="MunicipioDropDownList" InitialValue=""></asp:RequiredFieldValidator>
            </div>
        </p>
    </ContentTemplate>
</asp:UpdatePanel>
<p>
    <div class="span-4">
        Poblacion
    </div>
    <div class="span-20 last">
        <asp:TextBox ID="PoblacionTextBox" runat="server" CssClass="text" Width="300px"></asp:TextBox>
    </div>
</p>
<p>
    <div class="span-4">
        Calle
    </div>
    <div class="span-20 last">
        <asp:TextBox ID="StreetTextBox" runat="server" CssClass="text" Width="300px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="StreetRequiredFieldValidator" runat="server" Display="Dynamic"
            ErrorMessage="Requerido" ControlToValidate="StreetTextBox"></asp:RequiredFieldValidator>
    </div>
</p>
<p>
    <div class="span-4">
        Numero Exterior
    </div>
    <div class="span-20 last">
        <asp:TextBox ID="ExteriorNumberTextBox" runat="server" CssClass="text" Width="100px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ExteriorNumberRequiredFieldValidator" runat="server"
            Display="Dynamic" ErrorMessage="Requerido" ControlToValidate="ExteriorNumberTextBox"></asp:RequiredFieldValidator>
    </div>
</p>
<p>
    <div class="span-4">
        Numero Interior
    </div>
    <div class="span-20 last">
        <asp:TextBox ID="InteriorNumberTextBox" runat="server" CssClass="text" Width="100px"></asp:TextBox>
    </div>
</p>
<p>
    <div class="span-4">
        Colonia
    </div>
    <div class="span-20 last">
        <asp:TextBox ID="ColonyTextBox" runat="server" CssClass="text" Width="300px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ColonyRequiredFieldValidator" runat="server" Display="Dynamic"
            ErrorMessage="Requerido" ControlToValidate="ColonyTextBox"></asp:RequiredFieldValidator>
    </div>
</p>
<p>
    <div class="span-4">
        Codigo Postal
    </div>
    <div class="span-20 last">
        <asp:TextBox ID="ZipCodeTextBox" runat="server" CssClass="text" Width="100px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ZipCodeRequiredFieldValidator" runat="server" Display="Dynamic"
            ErrorMessage="Requerido" ControlToValidate="ZipCodeTextBox"></asp:RequiredFieldValidator>
    </div>
</p>
<p>
    <div class="span-4">
        Correo receptor
    </div>
    <div class="span-20 last">
        <asp:TextBox ID="ContactEmailTextBox" runat="server" CssClass="text" Width="300px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ContactEmailRequiredFieldValidator" runat="server"
            Display="Dynamic" ErrorMessage="Requerido" ControlToValidate="ContactEmailTextBox">
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="ContactEmailRegularExpressionValidator" runat="server"
            ControlToValidate="ContactEmailTextBox" Display="Dynamic" ErrorMessage="Formato de correo No Valido"
            ForeColor="Red" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>
    </div>
</p>
