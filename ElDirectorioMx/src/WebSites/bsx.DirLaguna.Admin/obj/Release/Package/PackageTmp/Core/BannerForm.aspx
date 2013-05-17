<%@ Page Title="Banners" Language="C#" MasterPageFile="~/Shared/Normal.master" AutoEventWireup="true"
    CodeBehind="BannerForm.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.BannerForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Banner</h1>
    <hr />
    <div class="span-24 last">
        <div>
            <asp:PlaceHolder ID="TipoPlaceHolder" Visible="false" runat="server">
                <div class="span-4">                    
                        Tipo
                </div>
                <div class="span-20">
                    <asp:RadioButtonList ID="TipoRadioButtonList" runat="server" AutoPostBack="true">
                        <asp:ListItem Text="Imagen" Selected="true" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Contenido" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="clear">
                </div>
            </asp:PlaceHolder>
        </div>
        <asp:MultiView ID="TypeMultiView" runat="server" ActiveViewIndex="0">
            <asp:View ID="ImagenView" runat="server">
                <div>
                    <div class="span-4">                        
                            Imagen
                    </div>
                    <div class="span-10 ">
                        <asp:FileUpload ID="XFileUpload" runat="server" />
                        <asp:RequiredFieldValidator ErrorMessage="*Obligatorio" ID="XFileUploadRequiredFieldValidator"
                            runat="server" ControlToValidate="XFileUpload" ValidationGroup="AddItem">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="span-10 last">
                        Imagen de 950px X 239px maximo (jpg, jpeg, png o gif)
                    </div>
                    <div class="clear">
                    </div>
                    <p></p>
                </div>
                <div>
                    <div class="span-4">                        
                            Enlace
                    </div>
                    <div class="span-10">
                        <asp:TextBox ID="LinkTextBox" runat="server" CssClass="text"></asp:TextBox>
                    </div>
                    <div class="span-10 last">
                        Opcional. Una dirección a donde lleva este banner. Por ejemplo: http://google.com/
                    </div>
                    <div class="clear">
                    </div>
                    <p></p>
                </div>
                <div>
                    <div class="span-4">              
                            Prioridad
                    </div>
                    <div class="span-10">
                        <asp:TextBox ID="PrioridadTextBox" runat="server" CssClass="text"></asp:TextBox>
                    </div>
                    <div class="span-10 last">
                        Mas alto salen primero
                    </div>
                    <div class="clear">
                    </div>
                    <p></p>
                </div>
                <div>
                    
                    <p>Imagen actual</p>
                    <asp:Image ID="XImage" Width="500px" runat="server" />
                </div>
            </asp:View>
            <asp:View ID="ContentView" runat="server">
                <div>
                    <div class="span-4">
                        <label>
                            Contenido</label>
                    </div>
                    <div class="span-24 last">
                        <CKEditor:CKEditorControl ID="txt_contents" FilebrowserBrowseUrl="editorImageUploader.axd"
                            FilebrowserUploadUrl="editorImageUploader.axd" FilebrowserImageUploadUrl="editorImageUploader.axd"
                            runat="server" FilebrowserImageBrowseUrl="editorImageUploader.axd">
                        </CKEditor:CKEditorControl>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>
        <div class="SearchButtonContainer">
            <asp:LinkButton ID="SaveButton" runat="server" Text="Guardar" class="button" />
            <asp:HyperLink ID="BackHyperlink" runat="server" Text="Regresar" class="clearSearch"></asp:HyperLink>
            <%--<asp:LinkButton ID="BackButton" runat="server" Text="Regresar" CausesValidation="false"></asp:LinkButton>--%>
        </div>
    </div>
</asp:Content>
