<%@ Page Title="Portada Web" Language="C#" MasterPageFile="~/Shared/Normal.master" AutoEventWireup="true"
    CodeBehind="PrePage.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.PrePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Preportada</h1>
    <hr />
    <div class="span-24 last">
        <div>
            <div class="span-5">
                <label>
                    Contenido de la preportada
                </label>
            </div>
            <div class="span-15">
                Diseña la preportada. (Ancho maximo 950px, altura puede ser la que sea)
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
