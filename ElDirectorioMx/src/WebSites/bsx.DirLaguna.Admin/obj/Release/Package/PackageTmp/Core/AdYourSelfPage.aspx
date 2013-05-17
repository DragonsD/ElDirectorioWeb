<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Normal.master" AutoEventWireup="true" CodeBehind="AdYourSelfPage.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.AdYourSelfPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
  <h1>
        Anúnciate</h1>
    <hr />
    <div class="span-24 last">
        <div>
            <div class="span-5">
                <label>
                    Contenido de la página
                </label>
            </div>
            <div class="span-15">
                Escribe el contenido de la página de Anúnciate, es el mismo para dispositivos móviles. Se recomienda solo poner el logo del directorio, texto y links. (Sin tablas, ni paneles de tamaño fijo)
            </div>
            <div class="span-24 last">
                <CKEditor:CKEditorControl ID="XCKEditorControl" FilebrowserBrowseUrl="editorImageUploader.axd"
                    FilebrowserUploadUrl="editorImageUploader.axd" FilebrowserImageUploadUrl="editorImageUploader.axd"
                    runat="server" FilebrowserImageBrowseUrl="editorImageUploader.axd">
                </CKEditor:CKEditorControl>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="24 last">
                <div class="SearchButtonContainer">
                <asp:LinkButton ID="SaveButton" runat="server" Text="Guardar" class="button" />
            </div>
        </div>
    </div>
</asp:Content>
