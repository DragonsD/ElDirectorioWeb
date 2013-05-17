<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Normal.master" AutoEventWireup="true"
    CodeBehind="AnnounceForm.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.AnnounceForm" %>

<%@ Register Src="../Controls/AnnounceControl.ascx" TagName="PictureControl" TagPrefix="bsx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="headerTitle">
        <div class="span-24 last">
            <div class="span-12">
                <h1>
                    Imagenes de Anuncio
                </h1>
            </div>
        </div>
    </div>
    <hr />
    <bsx:PictureControl ID="AnnounceControl1" runat="server" />
    <hr />
    <p>
        <asp:GridView ID="AnnounceGridView" runat="server" AutoGenerateColumns="False" DataSourceID="AnnounceObjectDataSource"
            EnableModelValidation="True">
            <Columns>
                <asp:TemplateField HeaderText="Pagina" SortExpression="Page.Number">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Page.Number") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Anunciante" SortExpression="Advertiser.Name">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Advertiser.Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="DeleteImageButton" runat="server" CommandArgument='<%#Eval("AnnounceId") %>'
                            ImageUrl="~/App_Themes/Laguna/images/minus-button.png" ToolTip="Eliminar" CommandName="delAnnounce"
                            OnClientClick="return confirm('Estas seguro que deseas Eliminar este anuncio?');" />
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </p>
    <div class="clear">
        <br />
        <br />
    </div>
    <p>
        <hr />
        <div class="SearchButtonContainer">
            <asp:LinkButton ID="BackButton" runat="server" Text="Regresar" CausesValidation="false" class="clearSearch"></asp:LinkButton>
        </div>
    </p>
    <asp:ObjectDataSource ID="AnnounceObjectDataSource" runat="server" SelectMethod="FetchAllByPageId"
        TypeName="bsx.DirLaguna.Dal.AnnounceController">
        <SelectParameters>
            <asp:Parameter Name="pageId" Type="Int32" />
            <asp:Parameter Name="franchiseeId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
