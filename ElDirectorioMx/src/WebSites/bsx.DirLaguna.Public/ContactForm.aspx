<%@ Page Title="¡Anúnciate!" Language="C#" MasterPageFile="~/Shared/NestedBaseMasterPage.Master"
    AutoEventWireup="true" CodeBehind="ContactForm.aspx.cs" Inherits="bsx.DirLaguna.Public.ContactForm" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
    <%-- <p>
        <div class="span-16 last logoDirImage" style="text-align: center">
            <asp:Image ID="directorioImage" runat="server" ImageUrl="~/Content/css2/img/LogoElDirectorio.png"
                AlternateText="ElDirectorio.mx" />
            <p style="color: #bbbbbb; text-align: center">
                de Publysorpresas S.A. de C.V.</p>
        </div>
        <div class="clear">
        </div>
    </p>
    <p>
        <div class="span-12 prepend-2 last" style="text-align:justify;">
            <div id="textContact" style="font-size: 20px">
                <p>
                    ¡Posiciona tu marca o negocio en el Directorio a un precio accesible e incrementa
                    tus ventas!</p><br />
            </div>
            <div id="textContact" style="font-size: 20px">
                <p>
                    Envía un correo electrónico con tus datos: <b>nombre, ciudad y teléfonos (LADA incluida)</b>
                    a <a href="mailto:ventas@eldirectorio.mx&subject=Contacto"><b>ventas@eldirectorio.mx</b></a>
                    y uno de nuestros ejecutivos se pondrá en contacto contigo.
                </p><br />
            </div>
            <p>
                <div id="Div1" style="font-size: 20px">
                    O si prefieres comunícate al (871) 227 7080 para hablar con uno de nuestros representantes.
                </div>
            </p>
        </div>
    </p>--%>
    <div style="padding:0 10px;">
    <asp:Literal ID="XLiteral" runat="server">
    </asp:Literal>
    </div>
</asp:Content>
