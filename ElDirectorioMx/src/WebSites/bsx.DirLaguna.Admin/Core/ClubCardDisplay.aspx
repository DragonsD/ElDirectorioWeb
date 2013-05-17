<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Normal.master" AutoEventWireup="true" CodeBehind="ClubCardDisplay.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.ClubCardDisplay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="headerTitle">
        <div class="span-24 last">
            <div class="span-12">
                <h1>
                    Club El Directorio
                </h1>
            </div>
            <div class="span-12 last">
                <div class="NewButtonContainer">
                    <asp:LinkButton ID="NewCardButton" runat="server" Text="Registrar Tarjeta" class="button" OnClick="NewCardButton_Click"/>
                </div>
            </div>
        </div>
    </div>
    <p>
        <div class="span-24">
                <div class="span-12">
                    <asp:DropDownList ID="AdvertiserDropdownList" runat="server" AutoPostBack="True" DataSourceID="AdvertiserDataSource" DataTextField="Name" DataValueField="AdvertiserId"></asp:DropDownList>
                </div>
                <table  id="tbCard" runat="server" visible="false">
                    <tr>
                        <td class="label">Folio:</td>
                        <td>
                            <asp:TextBox ID="FolioTextBox" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="label">Fecha de Expedición</td>
                        <td>
                            <asp:Calendar ID="FechaExpedicionCalendar" runat="server"> </asp:Calendar>
                        </td>
                    </tr>
                    <tr>
                        <td class="label">Anunciante:</td>
                        <td>
                            <asp:DropDownList ID="ddlAdvertiser" runat="server" AutoPostBack="True" DataSourceID="AdvertiserDataSource" DataTextField="Name" DataValueField="AdvertiserId"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div class="NewButtonContainer" style="text-align:center">
                                <asp:LinkButton ID="InsertButton" runat="server" Text="Insertar" CssClass="button"/>
                            </div>
                        </td>
                    </tr>
                </table>
            <div class="clear">

            </div>
            <h3>Tarjetas del Directorio</h3>
            <br />
            <asp:GridView ID="CardClubGridView" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" DataSourceID="ClubCardDataSource" DataKeyNames="CardID" AllowPaging="True">
                <Columns>
                    <asp:TemplateField HeaderText="Anunciante" SortExpression="Advertiser.Name">
                        <ItemTemplate>
                            <%#Eval("Advertiser.Name")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Folio" HeaderText="Folio" SortExpression="Folio" />
                    <asp:BoundField DataField="FechaExpedicion" HeaderText="Fecha de Expedicion" SortExpression="FechaExpedicion" />
                    <asp:BoundField DataField="Expira" HeaderText="Expira" InsertVisible="False" SortExpression="Expira" />
                </Columns>
                <EmptyDataTemplate>
                    <div class="span-24 last">
                        <div class="dataEmpty">
                            <span>No hay datos para mostrar</span>
                        </div>
                    </div>
                </EmptyDataTemplate>
            </asp:GridView>
            <div class="clear">

            </div>
            <h3>Detalles de la Tarjeta</h3>
            <br />
            <div class="span-10">
            <asp:GridView ID="ClubCardDetailsGridView" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" DataSourceID="VwClubClubCardDataSource" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="Folio" HeaderText="Folio" SortExpression="Folio" />
                    <asp:BoundField DataField="Name" HeaderText="Nombre" SortExpression="Name" />
                    <asp:BoundField DataField="City" HeaderText="Ciudad" SortExpression="City" />
                    <asp:BoundField DataField="Email" HeaderText="E-mail" SortExpression="Email" />
                </Columns>
                <EmptyDataTemplate>
                    <div class="span-24 last">
                        <div class="dataEmpty">
                            <span>No hay datos para mostrar</span>
                        </div>
                    </div>
                </EmptyDataTemplate>
            </asp:GridView>
            </div>      
                <asp:LinqDataSource ID="ClubCardDataSource" runat="server" ContextTypeName="bsx.DirLaguna.Dal.DirLagunaModelDataContext" TableName="ClubCard" Where="AdvertiserId == @AdvertiserId" EnableInsert="True">
                    <WhereParameters>
                        <asp:ControlParameter ControlID="AdvertiserDropdownList" Name="AdvertiserId" PropertyName="SelectedValue" Type="Int32" />
                    </WhereParameters>
                </asp:LinqDataSource>
                <asp:LinqDataSource ID="AdvertiserDataSource" runat="server" ContextTypeName="bsx.DirLaguna.Dal.DirLagunaModelDataContext" TableName="VwAdvertiser" OnSelecting="AdvertiserDataSource_Selecting" OrderBy="Name">
                </asp:LinqDataSource>
        </div>
    <asp:LinqDataSource ID="VwClubClubCardDataSource" runat="server" ContextTypeName="bsx.DirLaguna.Dal.DirLagunaModelDataContext" TableName="VwCardClubGuest" Where="AdvertiserId == @AdvertiserId">
        <WhereParameters>
            <asp:ControlParameter ControlID="AdvertiserDropdownList" Name="AdvertiserId" PropertyName="SelectedValue" Type="Int32" />
        </WhereParameters>
    </asp:LinqDataSource>
    </p>
</asp:Content>
