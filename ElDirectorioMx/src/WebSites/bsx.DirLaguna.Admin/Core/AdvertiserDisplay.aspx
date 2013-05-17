<%@ Page Title="Anunciantes" Language="C#" MasterPageFile="~/Shared/Normal.master"
    AutoEventWireup="true" CodeBehind="AdvertiserDisplay.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.AdvertiserDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="headerTitle">
        <div class="span-24 last">
            <div class="span-12">
                <h1>
                    Mis Anunciantes
                </h1>
            </div>
            <div class="span-12 last">
                    <div class="NewButtonContainer">
                        <asp:LinkButton ID="NewAdvertiserButton" runat="server" Text="Nuevo" class="button" />
                    </div>
            </div>
        </div>
    </div>
    <hr />
    <asp:Panel ID="SearchPanel" runat="server" DefaultButton="SearchAdvertiserButton">
        <div class="span-4">
            Nombre
        </div>
        <div class="span-8">
            <asp:TextBox ID="NameTextBox" runat="server" CssClass="text" Width="80%"></asp:TextBox>
        </div>
        <div class="span-4">
            Descripcion
        </div>
        <div class="span-8 last">
            <asp:TextBox ID="DescriptionTextBox" runat="server" CssClass="text" Width="80%"></asp:TextBox>
        </div>
        <div class="span-4">
            Ciudad
        </div>
        <div class="span-8">
            <asp:DropDownList ID="CityDropDownList" runat="server">
            </asp:DropDownList>
        </div>
        <div class="span-4">
            Estado
        </div>
        <div class="span-8 last">
            <asp:DropDownList ID="StateDropDownList" runat="server">
            </asp:DropDownList>
        </div>
        <div class="span-6 prepend-18 last">
            <div class="SearchButtonContainer">
                <asp:LinkButton ID="SearchAdvertiserButton" runat="server" Text="Buscar" class="button" />
                <asp:LinkButton ID="CleanFiltersLinkButton" runat="server" Text="Limpiar"  class="clearSearch"  />
            </div>
        </div>
    </asp:Panel>
    <div class="span-24">
        <asp:GridView ID="AdvertisersGridView" runat="Server" AutoGenerateColumns="False"
            DataSourceID="AdvertiserDataSource" EnableModelValidation="True" AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="AdvertiserId" HeaderText="AdvertiserId" SortExpression="AdvertiserId"
                    Visible="false" />
                <asp:TemplateField HeaderText="Nombre" SortExpression="Name" ItemStyle-Width="45%">
                    <ItemTemplate>
                        <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Name") %>' Font-Bold="true"></asp:Label><br />
                        <asp:Label ID="CityLabel" runat="server" Text="Label" ForeColor="Gray"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
<%--                <asp:TemplateField HeaderText="Estado" ItemStyle-Width="70px" ItemStyle-CssClass="cellstyle">
                    <ItemTemplate>
                        <asp:Label ID="StatusLabel" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Descripcion" SortExpression="Description" ItemStyle-Width="40%">
                    <ItemTemplate>
                        <asp:Label ID="DescriptionLabel" runat="server" Text='<%#Eval("Description") %>'></asp:Label><br />
                        <asp:HyperLink ID="WebPageHyperlink" runat="server" NavigateUrl='<%#Eval("WebPage") %>'
                            Target="_blank" Text='<%#Eval("WebPage") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="15%" HeaderText="Espec.">
                    <ItemTemplate>
                        <asp:HyperLink ID="EditHyperLink" runat="server" NavigateUrl='<%# AdvertiserForm((int)Eval("AdvertiserId")) %>'
                            Visible="false">
                            <asp:Image ID="Image1" ImageUrl="~/App_Themes/Laguna/images/magnifier--arrow.png"
                                ToolTip="Ver" runat="server" />
                        </asp:HyperLink>
                        <asp:HyperLink ID="OfficesHyperLink" runat="server" NavigateUrl='<%# OfficesForm((int)Eval("AdvertiserId")) %>'
                            Visible="false">
                            <asp:Image ID="OfficeImage" ImageUrl="~/App_Themes/Laguna/images/store--plus.png"
                                ToolTip="Sucursales" runat="server" />
                        </asp:HyperLink>
                        <asp:HyperLink ID="GalleriesHyperLink" runat="server" NavigateUrl='<%# GalleryDisplay((int)Eval("AdvertiserId")) %>'
                            Visible="false">
                            <asp:Image ID="Image3" ImageUrl="~/App_Themes/Laguna/images/photo-album.png" ToolTip="Galeria"
                                runat="server" />
                        </asp:HyperLink>
                        <asp:HyperLink ID="CouponSetHyperLink" runat="server" NavigateUrl='<%# CouponSetDisplay((int)Eval("AdvertiserId")) %>'
                            Visible="false">
                            <asp:Image ID="Image2" ImageUrl="~/App_Themes/Laguna/images/credit-cards.png" ToolTip="Cuponeras"
                                runat="server" />
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='<%# ContractDisplay((int)Eval("AdvertiserId")) %>'>
                            <asp:Image ID="ContractImage" ImageUrl="~/App_Themes/Laguna/images/blue-folder-open-document-text.png"
                                ToolTip="Contrataciones" runat="server" />
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="DeleteImageButton" runat="server" CommandArgument='<%#Eval("AdvertiserId") %>'
                            ImageUrl="~/App_Themes/Laguna/images/minus-button.png" CommandName="delAdvertiser"
                            ToolTip="Eliminar" OnClientClick="return confirm('Estas seguro que deseas Eliminar este anunciante?');" />
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
            <asp:LinkButton ID="See20LinkButton" runat="server" CommandName="ChangeSize" CommandArgument="20"
                Text="20"></asp:LinkButton>
            <asp:LinkButton ID="See50LinkButton" runat="server" CommandName="ChangeSize" CommandArgument="50"
                Text="50"></asp:LinkButton>
            <asp:LinkButton ID="See100LinkButton" runat="server" CommandName="ChangeSize" CommandArgument="100"
                Text="100"></asp:LinkButton>
            <asp:LinkButton ID="See200LinkButton" runat="server" CommandName="ChangeSize" CommandArgument="200"
                Text="200"></asp:LinkButton>
        </div>
        <asp:ObjectDataSource ID="AdvertiserDataSource" runat="server" SelectMethod="FetchAll"
            EnablePaging="true" SelectCountMethod="FetchAllCount" TypeName="bsx.DirLaguna.Dal.AdvertiserController">
            <SelectParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="description" Type="String" />
                <asp:Parameter Name="cityId" Type="Int32" />
                <asp:Parameter Name="statusId" Type="Int32" />
                <asp:Parameter Name="franchiseeId" Type="Int32" />
                <asp:Parameter Name="startRowIndex" Type="Int32" />
                <asp:Parameter Name="maximumRows" Type="Int32" />
                <asp:Parameter Name="sort" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
