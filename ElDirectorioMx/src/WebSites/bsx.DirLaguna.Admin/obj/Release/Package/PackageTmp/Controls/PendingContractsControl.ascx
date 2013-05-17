<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PendingContractsControl.ascx.cs"
    Inherits="bsx.DirLaguna.Admin.Controls.PendingContractsControl" %>
<div id="headerTitle">
    <h3>
        <asp:Label ID="TitelLabel" runat="server"></asp:Label>
    </h3>
</div>
<div class="span-24 last">
    <hr />
    <div class="span-4">
        Nombre
    </div>
    <div class="span-20 last">
        <asp:TextBox ID="NameAdvertiserTextBox" runat="server" CssClass="text" Width="80%"></asp:TextBox>
    </div>
    <div class="span-4">
        Estado
    </div>
    <div class="span-8">
        <asp:DropDownList ID="StatesDropDownList" runat="server" AutoPostBack="true">
        </asp:DropDownList>
    </div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="StatesDropDownList" />
        </Triggers>
        <ContentTemplate>
            <div class="span-4">
                Ciudad
            </div>
            <div class="span-8 last">
                <asp:DropDownList ID="CitiesDropDownList" runat="server">
                </asp:DropDownList>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="span-6 prepend-18 last">
        <div class="SearchButtonContainer">
            <asp:LinkButton ID="SearchFranchiseeButton" runat="server" Text="Buscar" class="button" />
            <asp:LinkButton ID="CleanFiltersLinkButton" runat="server" Text="Limpiar" class="clearSearch" />
        </div>
    </div>
</div>
<div class="span-24">
    <asp:GridView ID="ContractsGridView" runat="Server" AutoGenerateColumns="False" CssClass="tempGridView"
        DataSourceID="ContractsDataSource" EnableModelValidation="True" AllowPaging="True">
        <Columns>
            <asp:TemplateField HeaderText="Franquicia">
                <ItemTemplate>
                    <asp:Label ID="FranchiseeLabel" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Anunciante">
                <ItemTemplate>
                    <asp:Label ID="AdvertiserLabel" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ContractDate" HeaderText="Inicia el" SortExpression="ContractDate"
                DataFormatString="{0:d}" ItemStyle-Width="20px" ItemStyle-CssClass="cellstyle">
                <ItemStyle CssClass="cellstyle" Width="20px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="EndDate" HeaderText="Vence en" SortExpression="EndDate"
                DataFormatString="{0:d}" ItemStyle-Width="20px" />
            <asp:CheckBoxField DataField="IsActive" HeaderText="Activo" SortExpression="IsActive"
                ItemStyle-Width="20px" />
            <asp:CheckBoxField DataField="IsPaid" HeaderText="Pagado" SortExpression="IsPaid"
                ItemStyle-Width="20px" />
            <asp:TemplateField HeaderText="Factura" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:HyperLink ID="InvoiceHyperlink" runat="server" Text='<%#Eval("Folio") %>' NavigateUrl='<%# PrintDocumentUrl(Eval("InvoiceId"),true) %>'
                        Visible='<%# Eval("InvoiceId") !=null %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="ActionLinkButton" runat="server" Text="Test" CommandName="ActionCommand"
                        CommandArgument='<%#Eval("ContractId") %>' OnClientClick="return confirm('¿Estas seguro que quieres completar esta accion?');"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="20px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="InvoiceContractLink" runat="server" NavigateUrl='<%# InvoiceContractForm((int)Eval("AdvertiserId"), (int)Eval("ContractId")) %>'>Facturar</asp:HyperLink>
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
    <div class="span-24" style="text-align: right">
        Ver:
        <asp:LinkButton ID="See10LinkButton" runat="server" CommandName="ChangeSize" CommandArgument="10"
            Text="10"></asp:LinkButton>
        <asp:LinkButton ID="See20LinkButton" runat="server" CommandName="ChangeSize" CommandArgument="20"
            Text="20"></asp:LinkButton>
        <asp:LinkButton ID="See50LinkButton" runat="server" CommandName="ChangeSize" CommandArgument="50"
            Text="50"></asp:LinkButton>
        <asp:LinkButton ID="See100LinkButton" runat="server" CommandName="ChangeSize" CommandArgument="100"
            Text="100"></asp:LinkButton>
        <asp:LinkButton ID="See200LinkButton" runat="server" CommandName="ChangeSize" CommandArgument="200"
            Text="200"></asp:LinkButton>
    </div>
    <asp:ObjectDataSource ID="ContractsDataSource" runat="server" SelectMethod="FetchPendingContracts"
        EnablePaging="True" SelectCountMethod="FetchPendingContractsCount" TypeName="bsx.DirLaguna.Dal.ContractController">
        <SelectParameters>
            <asp:Parameter Name="requested" Type="Object" />
            <asp:Parameter Name="nameAdvertiser" Type="String" />
            <asp:Parameter Name="estadoId" Type="Int32" />
            <asp:Parameter Name="municipioId" Type="Int32" />
            <asp:Parameter Name="startRowIndex" Type="Int32" />
            <asp:Parameter Name="maximumRows" Type="Int32" />
            <asp:Parameter Name="sort" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>
