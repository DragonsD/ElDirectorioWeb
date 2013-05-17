<%@ Page Title="Base de datos Apps" Language="C#" MasterPageFile="~/Shared/Normal.master"
    AutoEventWireup="True" CodeBehind="iOsUpdateForm.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.iOsUpdateForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Actualización de datos en apps (iOs, Android)
    </h1>
    <hr />
    <h3>
        Información importante</h3>
    <p>
        <div class="span-24" style="margin-bottom: 20px">
            La ejecución de esta operación genera un archivo nuevo de base datos para los dispositivos
            mobiles que tenga instalada la aplicación nativa de Directorio.mx para iOs y Android. Es conveniente
            mencionar que la base de datos se genera unicamente cuando hay datos con cambios
            recientes posteriores a la ultima actualizacion.
        </div>
    </p>
    <p>
        <div class="span-24" style="margin-bottom: 20px">
            Es posible que la operación tarde unos minutos, por favor <b>NO de clic repetidamente
                al boton</b> ya queso puede provocar funcionamientos erráticos en el sistema
            y datos corruptos que terminarían en los clientes con iOs en detrimento de la experiencia
            de usuario.
        </div>
    </p>
    <div class="clear">
    </div>
    <h3>
        Ultima actualizacion registrada
    </h3>
    <p>
        <div class="span-24">
            <asp:Label ID="LastUpdateLabel" runat="server" Text="undefined"></asp:Label>
        </div>
    </p>
    <p>
        <div class="span-24 last">
            <div class="SearchButtonContainer">
                <asp:LinkButton ID="UpdateDataBaseLinkButton" runat="server" class="button" Text="Actualizar" />
                <asp:HyperLink ID="BackHyperlink" runat="server" class="clearSearch" NavigateUrl="~/Core/AdvertiserDisplay.aspx"
                    Text="Regresar"></asp:HyperLink>
            </div>
        </div>
    </p>
</asp:Content>
