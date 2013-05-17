<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DvMissingAdvertisersControl.ascx.cs"
    Inherits="bsx.DirLaguna.Admin.Controls.DvMissingAdvertisersControl" %>
<h3>
    Anunciantes sin DV
</h3>
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
<div class="span-24 last">
    <asp:GridView ID="AdvertiserLessDVGridView" runat="server" AutoGenerateColumns="False"
        DataSourceID="AdvertiserLessDVObjectDataSource" 
        EnableModelValidation="True" AllowPaging="True">
        <Columns>
            <asp:TemplateField HeaderText="Franquiciatario">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Franchisee.Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre Anunciante" SortExpression="Name">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='<%# AdvertiserDVForm((int)Eval("AdvertiserId")) %>'>
                        <asp:Image ID="Image1" ImageUrl="~/App_Themes/Laguna/images/gear--arrow.png" ToolTip="Agregar DV"
                            runat="server" />
                    </a>
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
        <PagerSettings Mode="NumericFirstLast" Position="Bottom" />
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
    <asp:ObjectDataSource ID="AdvertiserLessDVObjectDataSource" runat="server" SelectMethod="FetchAllLessDV"
        TypeName="bsx.DirLaguna.Dal.AdvertiserController" EnablePaging="True" 
        SelectCountMethod="FetchAllLessDVCount" SortParameterName="sort">
        <SelectParameters>
            <asp:Parameter Name="nameAdvertiser" Type="String" />
            <asp:Parameter Name="estadoId" Type="Int32" />
            <asp:Parameter Name="municipioId" Type="Int32" />
            <asp:Parameter Name="startRowIndex" Type="Int32" />
            <asp:Parameter Name="maximumRows" Type="Int32" />
            <asp:Parameter Name="sort" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>
