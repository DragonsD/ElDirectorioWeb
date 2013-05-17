<%@ Page Title="Publicidad General" Language="C#" MasterPageFile="~/Shared/Normal.master"
    AutoEventWireup="true" CodeBehind="GenPublicityForm.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.GenPublicityForm" %>

<%@ Import Namespace="bsx.DirLaguna.CommonWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <p>
        <div class="span-24">
            <h1>
                Publicidad General</h1>
        </div>
    </p>
    <hr />
    <p>
        <div class="span-12">
            <h3>
                Banner Principal (*.swf)</h3>
            <p>
                <div class="span-4">
                    Archivo:</div>
                <div class="span-20 last">
                    <asp:FileUpload ID="MainUpload" runat="server" /></div>
            </p>
            <p>
                <object type="application/x-shockwave-flash" data='<%=this.MainFlashUrl %>' width="450"
                    height="80">
                    <param name='<%=SwfNames.MainSwfName %>' value="9.swf" />
                    <param name="wmode" value="transparent" />
                </object>
            </p>
            <p>
                <div class="span-3 prepend-9 ">
                <div class="SearchButtonContainer">
                        <%--<asp:Button ID="SaveMainButton" runat="server" Text="Guardar" />--%>
                        <asp:LinkButton ID="SaveMainButton" Text="Guardar" runat="server" class="button" />
                    </div>
                </div>
            </p>
        </div>
        <div class="span-12 last">
            <h3>
                Banner default para categorias (*.swf)</h3>
            <p>
                <div class="span-4">
                    Archivo:</div>
                <div class="span-20 last">
                    <asp:FileUpload ID="DefualtFileUpload" runat="server" /></div>
            </p>
            <p>
                <object type="application/x-shockwave-flash" data='<%=this.CatDefaultFlashUrl %>'
                    width="450" height="80">
                    <param name='<%=SwfNames.DefaultCatPublicityName %>' value="9.swf" />
                    <param name="wmode" value="transparent" />
                </object>
            </p>
            <p>
                <div class="SearchButtonContainer">
                    <asp:LinkButton ID="SaveDefaultButton" runat="server" class="button" Text="Guardar" />
                </div>
            </p>
        </div>
    </p>
</asp:Content>
