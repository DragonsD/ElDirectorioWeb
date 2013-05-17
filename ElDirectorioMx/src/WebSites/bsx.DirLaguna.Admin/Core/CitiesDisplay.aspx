<%@ Page Title="Ciudades" Language="C#" MasterPageFile="~/Shared/Normal.master" AutoEventWireup="true"
    CodeBehind="CitiesDisplay.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.CitiesDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="headerTitle">
        <div class="span-24 last">
            <div class="span-12">
                <h1>
                    Ciudades
                </h1>
            </div>
            <div class="span-12 last">
                <div class="NewButtonContainer">
                    <asp:LinkButton ID="NewCityButton" runat="server" Text="Nuevo" class="button" />
                </div>
            </div>
        </div>
    </div>
    <hr />
    <div class="span-24">
        <asp:GridView ID="CitiesGridView" runat="Server" AutoGenerateColumns="False" CssClass="tempGridView"
            DataSourceID="CitiesDataSource" EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Nombre" SortExpression="Name" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='<%# CitiesForm((int)Eval("CityId")) %>'>
                            <asp:Image ID="Image1" ImageUrl="~/App_Themes/Laguna/images/magnifier--arrow.png"
                                ToolTip="Ver" runat="server" />
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="DeleteImageButton" runat="server" CommandArgument='<%#Eval("CityId") %>'
                            ImageUrl="~/App_Themes/Laguna/images/minus-button.png" CommandName="delCity"
                            ToolTip="Eliminar" OnClientClick="return confirm('Estas seguro que deseas Eliminar esta ciudad?');" />
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
        </asp:GridView>
        <asp:ObjectDataSource ID="CitiesDataSource" runat="server" SelectMethod="FetchAll"
            TypeName="bsx.DirLaguna.Dal.CityController"></asp:ObjectDataSource>
    </div>
</asp:Content>
