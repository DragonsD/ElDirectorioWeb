<%@ Page Title="Categorias" Language="C#" MasterPageFile="~/Shared/Normal.master"
    AutoEventWireup="true" CodeBehind="CategoriesDisplay.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.CategoriesDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <script language="javascript" type="text/javascript">
        function changePage(ctrl, page) {
            alert('fuera!!!');
            __doPostBack(ctrl, page);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="headerTitle">
        <div class="span-24 last">
            <div class="span-12">
                <h1>
                    Categorias
                </h1>
            </div>
            <div class="span-12 last">
                <div class="NewButtonContainer">
                    <asp:LinkButton ID="NewCategoryButton" runat="server" Text="Nuevo" class="button" />
                </div>
            </div>
        </div>
    </div>
    <hr />
    <asp:Panel ID="SearchPanel" runat="server" DefaultButton="SearchCategoryButton">

    <div class="span-4">
        Nombre
    </div>
    <div class="span-8">
        <asp:TextBox ID="NameTextBox" runat="server" CssClass="text" Width="80%"></asp:TextBox>
    </div>
    <div class="span-4">
        Letra
    </div>
    <div class="span-8 last">
        <asp:TextBox ID="LetterTextBox" runat="server" CssClass="text" Width="80%"></asp:TextBox>
    </div>
    <div class="span-6 prepend-18 last">
        <div class="SearchButtonContainer">
            <asp:LinkButton ID="SearchCategoryButton" runat="server" Text="Buscar" class="button" />
            <asp:LinkButton ID="CleanFiltersLinkButton" runat="server" Text="Limpiar" class="clearSearch" />
        </div>
    </div>
    </asp:Panel>
    <div class="span-24">
        <asp:GridView ID="CategoriesGridView" runat="Server" AutoGenerateColumns="False"
            CssClass="tempGridView" DataSourceID="CategoriesDataSource" EnableModelValidation="True"
            AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="AdvertiserId" HeaderText="AdvertiserId" SortExpression="AdvertiserId"
                    Visible="false" />
                <asp:BoundField DataField="Name" HeaderText="Nombre" SortExpression="Name" />
                <asp:BoundField DataField="Letter" HeaderText="Letra" SortExpression="Letter" ItemStyle-Width="20px"
                    ItemStyle-CssClass="cellstyle">
                    <ItemStyle Width="20px"></ItemStyle>
                </asp:BoundField>
                <asp:CheckBoxField DataField="Featured" HeaderText="En portada" ItemStyle-Width="20px" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='<%# CatPublicityDisplay((int)Eval("CategoryId")) %>'>
                            <asp:Image ID="Image1" ImageUrl="~/App_Themes/Laguna/images/balloon--pencil.png"
                                ToolTip="Publicidad" runat="server" />
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='<%# AdvertiserForm((int)Eval("CategoryId")) %>'>
                            <asp:Image ID="Image2" ImageUrl="~/App_Themes/Laguna/images/magnifier--arrow.png"
                                ToolTip="Ver" runat="server" />
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="DeleteImageButton" runat="server" CommandArgument='<%#Eval("CategoryId") %>'
                            ImageUrl="~/App_Themes/Laguna/images/minus-button.png" CommandName="delCategory"
                            ToolTip="Eliminar" OnClientClick="return confirm('Estas seguro que deseas Eliminar esta categoria?');" />
                        <%--                        <asp:LinkButton ID="DeleteLinkButton" runat="server" Text="Delete" CommandArgument='<%#Eval("CategoryId") %>'
                            CommandName="delCategory" OnClientClick="return confirm('Estas seguro que deseas Eliminar esta categoria?');"></asp:LinkButton>--%>
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
            <PagerSettings Mode="NumericFirstLast" />
            <PagerTemplate>
                <asp:ImageButton ID="imgFirst" runat="server" CommandName="Page" CommandArgument="First"
                    ImageUrl="~/App_Themes/Laguna/images/arrow-first.png" Height="14px" Width="16px" />
                <asp:ImageButton ID="imgPrev" runat="server" CommandName="Page" CommandArgument="Prev"
                    ImageUrl="~/App_Themes/Laguna/images/arrow-prev.png" Height="14px" Width="11px" />
                <asp:DropDownList ID="PageDropDownList" AutoPostBack="true" OnSelectedIndexChanged="PageDropDownList_SelectedIndexChanged"
                    runat="server" />
                <asp:ImageButton ID="imgNext" runat="server" CommandName="Page" CommandArgument="Next"
                    ImageUrl="~/App_Themes/Laguna/images/arrow-next.png" Height="14px" Width="11px" />
                <asp:ImageButton ID="imgLast" runat="server" CommandName="Page" CommandArgument="Last"
                    ImageUrl="~/App_Themes/Laguna/images/arrow-last.png" Height="14px" Width="16px" />
            </PagerTemplate>
        </asp:GridView>
        <asp:ObjectDataSource ID="CategoriesDataSource" runat="server" SelectMethod="FetchAll"
            EnablePaging="true" SelectCountMethod="FetchAllCount" TypeName="bsx.DirLaguna.Dal.CategoryController">
            <SelectParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="letter" Type="String" />
                <asp:Parameter Name="highlighted" Type="Boolean" />
                <asp:Parameter Name="startRowIndex" Type="Int32" />
                <asp:Parameter Name="maximumRows" Type="Int32" />
                <asp:Parameter Name="sort" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
