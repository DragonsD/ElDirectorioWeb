<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FiscalDetailReadOnlyControl.ascx.cs"
    Inherits="bsx.DirLaguna.Admin.Controls.FiscalDetailReadOnlyControl" %>
<h3>
    Datos Fiscales</h3>
<p>
    <div class="span-24 last">
        <div class="span-4">
            Nombre
        </div>
        <div class="span-20 last">
            <asp:Label ID="FiscalNameLabel" runat="server"></asp:Label>
        </div>
    </div>
</p>
<p>
    <div class="span-24 last">
        <div class="span-4">
            RFC
        </div>
        <div class="span-20 last">
            <asp:Label ID="RFCLabel" runat="server"></asp:Label>
        </div>
    </div>
</p>
<p>
    <div class="span-24 last">
        <div class="span-4">
            Estado
        </div>
        <div class="span-20 last">
            <asp:Label ID="EstadoLabel" runat="server">
            </asp:Label>
        </div>
    </div>
</p>
<p>
    <div class="span-24 last">
        <div class="span-4">
            Municipio
        </div>
        <div class="span-20 last">
            <asp:Label ID="MunicipioLabel" runat="server">
            </asp:Label>
        </div>
    </div>
</p>
<p>
    <div class="span-24 last">
        <div class="span-4">
            Poblacion
        </div>
        <div class="span-20 last">
            <asp:Label ID="PoblacionLabel" runat="server"></asp:Label>
        </div>
    </div>
</p>
<p>
    <div class="span-24 last">
        <div class="span-4">
            Calle
        </div>
        <div class="span-20 last">
            <asp:Label ID="StreetLabel" runat="server"></asp:Label>
        </div>
    </div>
</p>
<p>
    <div class="span-24 last">
        <div class="span-4">
            Numero Exterior
        </div>
        <div class="span-20 last">
            <asp:Label ID="ExteriorNumberLabel" runat="server"></asp:Label>
        </div>
    </div>
</p>
<p>
    <div class="span-24 last">
        <div class="span-4">
            Numero Interior
        </div>
        <div class="span-20 last">
            <asp:Label ID="InteriorNumberLabel" runat="server" CssClass="text" Width="100px"></asp:Label>
        </div>
    </div>
</p>
<p>
    <div class="span-24 last">
        <div class="span-4">
            Colonia
        </div>
        <div class="span-20 last">
            <asp:Label ID="ColonyLabel" runat="server"></asp:Label>
        </div>
    </div>
</p>
<p>
    <div class="span-24 last">
        <div class="span-4">
            Codigo Postal
        </div>
        <div class="span-20 last">
            <asp:Label ID="ZipCodeLabel" runat="server"></asp:Label>
        </div>
    </div>
</p>
<p>
    <div class="span-24 last">
        <div class="span-4">
            Correo receptor
        </div>
        <div class="span-20 last">
            <asp:Label ID="ContactEmailLabel" runat="server"></asp:Label>
        </div>
    </div>
</p>
