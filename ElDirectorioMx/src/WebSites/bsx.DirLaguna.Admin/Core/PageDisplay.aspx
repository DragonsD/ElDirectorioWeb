<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Normal.master" AutoEventWireup="true"
    CodeBehind="PageDisplay.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.PageDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="headerTitle">
        <div class="span-24 last">
            <div class="span-12">
                <h1>
                    Paginas
                </h1>
            </div>
            <div class="span-12 last">
                <div class="NewButtonContainer">
                    <asp:LinkButton ID="NewPageButton" runat="server" Text="Nuevo" class="button" />
                </div>
            </div>
        </div>
    </div>
    <hr />
    <asp:GridView ID="PagesGridView" runat="server" DataSourceID="PageObjectDataSource"
        AutoGenerateColumns="False" EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="Number" HeaderText="Number" SortExpression="Number" />
            <asp:BoundField DataField="SyncNumber" HeaderText="SyncNumber" SortExpression="SyncNumber" />
            <asp:BoundField DataField="CreatedOn" HeaderText="CreatedOn" SortExpression="CreatedOn" />
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# PageFormUrl((int)Eval("PageId")) %>'>
                        <asp:Image ID="Image2" ImageUrl="~/App_Themes/Laguna/images/magnifier--arrow.png"
                            ToolTip="Ver" runat="server" />
                    </a>
                </ItemTemplate>
                <ItemStyle Width="20px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# AnnounceFormUrl((int)Eval("PageId")) %>'>
                        <asp:Image ID="Image3" ImageUrl="~/App_Themes/Laguna/images/blue-document-image.png"
                            ToolTip="Ver Anuncios" runat="server" />
                    </a>
                </ItemTemplate>
                <ItemStyle Width="20px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="DeleteImageButton" runat="server" CommandArgument='<%#Eval("PageId") %>'
                        ImageUrl="~/App_Themes/Laguna/images/minus-button.png" ToolTip="Eliminar" CommandName="delPage"
                        OnClientClick="return confirm('Estas seguro que deseas Eliminar esta pagina?');" />
                </ItemTemplate>
                <ItemStyle Width="20px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="PageObjectDataSource" runat="server" SelectMethod="FetchAll"
        TypeName="bsx.DirLaguna.Dal.PageController"></asp:ObjectDataSource>
    <h2>
        Publicar XML
    </h2>
    <div class="SearchButtonContainer">
        <asp:LinkButton ID="PublishLinkButton" runat="server" Text="Publicar archivo xml" class="button"></asp:LinkButton>
    </div>
</asp:Content>
