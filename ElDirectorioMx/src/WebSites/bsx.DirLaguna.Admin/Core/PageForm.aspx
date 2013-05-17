<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Normal.master" AutoEventWireup="true"
    CodeBehind="PageForm.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.PageForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <script language="javascript" type="text/javascript">
        function solonumeros(e) {
            var key;
            if (window.event) // IE
            {
                key = e.keyCode;
            }
            else if (e.which) // Netscape/Firefox/Opera
            {
                key = e.which;
            }

            if (key < 48 || key > 57) {
                return false;
            }

            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="headerTitle">
        <div class="span-24 last">
            <div class="span-12">
                <h1>
                    <asp:Label ID="TitleLabel" runat="server" Text="Nueva Página"></asp:Label>
                </h1>
            </div>
        </div>
    </div>
    <hr />
    <p>
        <div class="span-24 last">
            <div class="span-19 last">
                <div class="span-19 last">
                    <div class="span-4">
                        Imagen
                    </div>
                    <div class="span-6">
                        <asp:FileUpload ID="PictureUpload" runat="server" />
                    </div>
                    <div class="span-2">
                        <asp:RequiredFieldValidator ErrorMessage="*Obligatorio" ID="PictureUploadRequiredFieldValidator"
                            runat="server" ControlToValidate="PictureUpload" ValidationGroup="AddItem" Display="Dynamic">   
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="span-7 last">
                        Imagen de 950px X 350px maximo (jpg, jpeg)
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="span-19 last">
                    <div class="span-4">
                        Numero Pagina
                    </div>
                    <div class="span-4">
                        <asp:TextBox ID="PageNumberTextBox" runat="server"></asp:TextBox>
                    </div>
                    <div class="span-4">
                        * Solo numeros.
                    </div>
                    <div class="span-3 last">
                        <asp:RequiredFieldValidator ErrorMessage="*Obligatorio" ID="PageNumberRequiredFieldValidator"
                            runat="server" ControlToValidate="PageNumberTextBox" ValidationGroup="AddItem">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <div class="span-5 last">
                <asp:Image ImageUrl="" ID="PageImage" runat="server" Width="160px" Height="160px" />
            </div>
        </div>
    </p>
    <div class="clear">
        <br />
        <br />
    </div>
    <p>
        <div class="span-24 last">
            <div class="SearchButtonContainer">
                <asp:LinkButton ID="SaveAndAddAnnounceButton" runat="server" Text="Guardar" class="button"
                    ValidationGroup="AddItem" />
                <asp:LinkButton ID="SaveButton" runat="server" Text="Guardar" class="button"
                    ValidationGroup="AddItem" />
                <asp:LinkButton ID="BackButton" runat="server" Text="Regresar" CausesValidation="false" class="clearSearch"></asp:LinkButton>
            </div>
        </div>
    </p>
</asp:Content>
