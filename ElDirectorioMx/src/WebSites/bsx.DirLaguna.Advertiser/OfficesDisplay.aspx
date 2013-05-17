<%@ Page Title="Mis sucursales" Language="C#" MasterPageFile="~/Shared/Admin.Master" AutoEventWireup="true"
    CodeBehind="OfficesDisplay.aspx.cs" Inherits="bsx.DirLaguna.Advertiser.OfficesDisplay" %>

<%@ Register Src="~/Controls/AdvertiserInfoControl.ascx" TagName="AdvertiserInfoCtrl"
    TagPrefix="bsx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="headerTitle">
        <div class="span-24 last">
            <div class="span-12">
                <h1>
                    Sucursales
                </h1>
            </div>
            <div class="span-12 last">
                <div class="NewButtonContainer">
                    <asp:LinkButton ID="NewOfficeButton" runat="server" Text="Nuevo" class="button" />
                </div>
            </div>
        </div>
    </div>

    <br />
    <p>
        <div class="span-24">
            <asp:GridView ID="OfficeGridView" runat="Server" AutoGenerateColumns="False" DataSourceID="OfficeDataSource"
                EnableModelValidation="True">
                <Columns>
                    <asp:BoundField DataField="OfficeId" HeaderText="OfficeId" SortExpression="AdvertiserId"
                        Visible="false" />
                    <asp:BoundField DataField="Name" HeaderText="Nombre" SortExpression="Name" />
                    <asp:BoundField DataField="Address" HeaderText="Dirección" SortExpression="Address" />
                    <asp:TemplateField HeaderText="Ciudad">
                        <ItemTemplate>
                            <asp:Label ID="CityLabel" runat="server" Text="Label"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div id="editDiv" runat="server" visible='<%# !Eval("Name").Equals("Matriz") %>'>
                                <a href='<%# OfficeFormUrl((int)Eval("OfficeId")) %>'>
                                    <asp:Image ID="Image2" ImageUrl="~/Content/css2/img/magnifier--arrow.png"
                                        ToolTip="Ver" runat="server" />
                                </a>
                            </div>
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="DeleteImageButton" runat="server" CommandArgument='<%#Eval("OfficeId") %>'
                                Visible='<%# !Eval("Name").Equals("Matriz") %>' ImageUrl="~/Content/css2/img/minus-button.png"
                                ToolTip="Eliminar" CommandName="delOffice" OnClientClick="return confirm('Estas seguro que deseas Eliminar esta sucursal?');" />
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
            <asp:ObjectDataSource ID="OfficeDataSource" runat="server" SelectMethod="FetchAdvertiserOffices"
                TypeName="bsx.DirLaguna.Dal.OfficeController">
                <SelectParameters>
                    <asp:Parameter Name="advertiserId" Type="Int32" />
                    <asp:Parameter Name="franchiseeId" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </p>
    <div class="clear">
        <br />
    </div>
    <hr />
    <p>
        NOTA: La sucursal Matriz es editable únicamente a través del formulario de anunciante (“Datos de mi negocio”).
    </p>
    <p>
        <div class="span-24 last">
            <div class="SearchButtonContainer">
            <asp:HyperLink ID="BackHyperlink" runat="server" Text="Regresar"></asp:HyperLink>
                
            </div>
        </div>
    </p>
</asp:Content>
