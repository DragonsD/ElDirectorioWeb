<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Normal.master" AutoEventWireup="true" CodeBehind="PublicityDisplay.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.PublicityDisplay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h3>Publicida Detalles</h3>
    <br />
    <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="CityId"></asp:DropDownList>
    <br />
    <div class="span-24 last">
            <asp:GridView ID="PublicityGridView" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" DataSourceID="PublicityDataSource" DataKeyNames="PublicityID">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:TemplateField HeaderText="Ciudad" SortExpression="City.Name">
                        <ItemTemplate>
                            <%#Eval("City.Name")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="WebPage" HeaderText="Página Web" SortExpression="WebPage" />
                    <asp:BoundField DataField="Prioridad" HeaderText="Prioridad" SortExpression="Prioridad" />
                    <asp:TemplateField HeaderText="Publicidad">
                        <ItemTemplate>
                            <asp:HyperLink ID="XHyperLink" runat="server" ImageUrl='<%#Eval("Picture") %>'>
                            </asp:HyperLink>
                        </ItemTemplate>
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

        <asp:LinqDataSource ID="PublicityDataSource" runat="server" ContextTypeName="bsx.DirLaguna.Dal.DirLagunaModelDataContext" OrderBy="Prioridad desc" TableName="Publicity" EnableDelete="True" EnableUpdate="True" Where="CityId == @CityId">
            <WhereParameters>
                <asp:ControlParameter ControlID="ddlCity" Name="CityId" PropertyName="SelectedValue" Type="Int32" />
            </WhereParameters>
        </asp:LinqDataSource>

        <asp:ObjectDataSource ID="CityDataSource" runat="server" SelectMethod="FechAllActive" TypeName="bsx.DirLaguna.Dal.CityController">
            <SelectParameters>
                <asp:Parameter DefaultValue="5" Name="device" Type="Object" />
            </SelectParameters>
            </asp:ObjectDataSource>
    </div>
</asp:Content>
