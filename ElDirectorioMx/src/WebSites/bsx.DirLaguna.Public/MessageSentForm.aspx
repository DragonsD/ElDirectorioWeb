<%@ Page Title="Envio de correo" Language="C#" MasterPageFile="~/Shared/Base.Master"
    AutoEventWireup="true" CodeBehind="MessageSentForm.aspx.cs" Inherits="bsx.DirLaguna.Public.MessageSentForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <style type="text/css">
        .pText
        {
            margin: 10px;
        }
        .lastP
        {
            margin-bottom: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageContentPlaceHolder" runat="server">
    <div class="listContainer">
        <div class="listContentWrapper">
            <div class="listContent">
                <h1>
                    <asp:Label ID="TitleLabel" runat="server" Text="sample"></asp:Label></h1>
                <p>
                    <div id="logoImage">
                        <div class="span-15 last" style="text-align: center">
                            <asp:Image ID="directorioImage" runat="server" ImageUrl="~/Content/css2/img/LogoElDirectorio.png"
                                AlternateText="ElDirectorio.mx" />
                        </div>
                        <p style="color: #bbbbbb; text-align: center">
                            Publysorpresas S.A. de C.V.</p>
                        <div class="clear">
                        </div>
                    </div>
                </p>
                <p>
                    <div class="span-11 prepend-2 append-2 lastP">
                        <asp:MultiView ID="ResultMultiView" runat="server" ActiveViewIndex="0">
                            <asp:View ID="FailureView" runat="server">
                                <p class="pText">
                                    <asp:Literal ID="nameLiteral" runat="server" Text='<%=this.CustomerName %>'></asp:Literal>
                                </p>
                                <p class="pText">
                                    <b>Ha ocurrido un problema</b> al enviar tu correo, te pedimos que vuelvas a intentarlo
                                    o utilices nuestros otros medios de contacto.</p>
                                <p class="pText">
                                    Por tu comprehensión gracias!</p>
                                <p class="pText">
                                    Atte.</p>
                                <p class="pText">
                                    ElDirectorio.mx</p>
                            </asp:View>
                            <asp:View ID="SuccessView" runat="server">
                                <p class="pText">
                                    <asp:Literal ID="Literal1" runat="server" Text='<%=this.CustomerName %>'></asp:Literal>
                                </p>
                                <p class="pText">
                                    Hemos enviado tu correo con nuestros agentes <b>exitosamente</b>, en breve nos pondremos
                                    en contacto contigo! Estamos seguros que podemos hacer grandes cosas juntos!.</p>
                                <p class="pText">
                                    Es un gusto que te hayas interesado en nuestra franquicia. Nos ponemos a tus ordenes</p>
                                <p class="pText">
                                    Atte.</p>
                                <p class="pText">
                                    ElDirectorio.mx</p>
                            </asp:View>
                        </asp:MultiView>
                    </div>
                </p>
                <div class="clear">
                </div>
                <p style="text-align: center">
                    <a href="HomeForm.aspx">Regresa a ElDirectorio.mx</a></p>
            </div>
        </div>
        <div class="listContainerFooter">
        </div>
    </div>
</asp:Content>
