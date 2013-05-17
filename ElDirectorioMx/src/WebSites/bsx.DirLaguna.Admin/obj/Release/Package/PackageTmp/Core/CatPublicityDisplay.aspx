<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Normal.master" AutoEventWireup="true"
    CodeBehind="CatPublicityDisplay.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.CatPublicityDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="headerTitle">
        <div class="span-24 last">
            <div class="span-12">
                <h1>
                    Publicidad especializada
                </h1>
            </div>
            <div class="span-12 last">
                <div class="NewButtonContainer">
                    <asp:LinkButton ID="NewCatPublictyButton" runat="server" Text="Nuevo" class="button" />
                </div>
            </div>
        </div>
    </div>
    <h3>
        <asp:Label ID="HeaderLabel" runat="server" Text="[aqui voy a poner la categoria]"></asp:Label>
    </h3>
    <div class="span-24">
        <asp:GridView ID="CatPublicityGridView" runat="Server" AutoGenerateColumns="False"
            DataSourceID="CatPublicityDataSource" EnableModelValidation="True" AllowPaging="false">
            <Columns>
                <asp:BoundField DataField="CatPublicityId" HeaderText="AdvertiserId" SortExpression="AdvertiserId"
                    Visible="false" />
                <asp:BoundField DataField="Name" HeaderText="Nombre" SortExpression="Name" />
                <asp:BoundField DataField="Description" HeaderText="Descripcion" SortExpression="Description" />
                <%--<asp:BoundField DataField="WebPage" HeaderText="Pagina Web" SortExpression="WebPage" />--%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='<%# CatPublicityForm((int)Eval("CatPublicityId")) %>'>
                            <asp:Image ID="Image2" ImageUrl="~/App_Themes/Laguna/images/magnifier--arrow.png"
                                ToolTip="Ver" runat="server" />
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="DeleteImageButton" runat="server" CommandArgument='<%#Eval("CatPublicityId") %>'
                            ImageUrl="~/App_Themes/Laguna/images/minus-button.png" ToolTip="Eliminar" CommandName="delAdvertiser"
                            OnClientClick="return confirm('Estas seguro que deseas Eliminar esta publicidad?');" />
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div class="span-24 last">
                    <div class="dataEmpty">
                        <span>No hay datos para mostrar</span>
                    </div>
                </div>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:ObjectDataSource ID="CatPublicityDataSource" runat="server" SelectMethod="FetchForCategory"
            TypeName="bsx.DirLaguna.Dal.CatPublicityController" SortParameterName="sort">
            <SelectParameters>
                <asp:Parameter Name="categoryId" Type="Int32" />
                <asp:Parameter Name="startRowIndex" Type="Int32" />
                <asp:Parameter Name="maximumRows" Type="Int32" />
                <asp:Parameter Name="sort" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <p>
        <div class="SearchButtonContainer">
            <asp:LinkButton ID="BackButton" runat="server" Text="Regresar" CausesValidation="false" class="clearSearch></asp:LinkButton>
        </div>
    </p>
</asp:Content>
