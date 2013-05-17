<%@ Page Title="Mis Galerias" Language="C#" MasterPageFile="~/Shared/Admin.Master"
    AutoEventWireup="true" CodeBehind="GalleriesDisplay.aspx.cs" Inherits="bsx.DirLaguna.Advertiser.GalleriesDisplay" %>

<%@ Register Src="/Controls/GalleryControl.ascx" TagName="GalleryControl" TagPrefix="bsx" %>
<%@ Register Src="Controls/AdvertiserInfoControl.ascx" TagName="AdvertiserInfoControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="headerTitle">
        <div class="span-24 last">
            <div class="span-12">
                <h1>
                    Galerias
                </h1>
            </div>
        </div>
    </div>
    <h3>
        Nueva Galería</h3>
    <bsx:GalleryControl ID="GalleryControl1" runat="server" />
    <hr />
    <div class="span-24 last">
        <asp:GridView ID="GalleriesGridView" runat="server" AutoGenerateColumns="False" DataSourceID="GalleryObjectDataSource"
            EnableModelValidation="True">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Nombre" SortExpression="Name" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='<%# PictureDisplay((int)Eval("GalleryId")) %>'>
                            <asp:Image ID="OfficeImage" ImageUrl="~/Content/Image/camera--plus.png" ToolTip="Imagenes"
                                runat="server" />
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="EditImageButton" runat="server" CommandArgument='<%#Eval("GalleryId") %>'
                            ImageUrl="~/Content/Image/pencil.png" CommandName="editGallery" CausesValidation="false"
                            ToolTip="Modificar" />
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="DeleteImageButton" runat="server" CommandArgument='<%#Eval("GalleryId") %>'
                            ImageUrl="~/Content/Image/minus-button.png" CommandName="delGallery" CausesValidation="false"
                            ToolTip="Eliminar" OnClientClick="return confirm('Estas seguro que deseas Eliminar esta galeria?');" />
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
        <asp:ObjectDataSource ID="GalleryObjectDataSource" runat="server" SelectMethod="FetchAllByAdvertiserId"
            TypeName="bsx.DirLaguna.Dal.GalleryController">
            <SelectParameters>
                <asp:Parameter Name="advertiserId" Type="Int32" />
                <asp:Parameter Name="franchiseeId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <div class="clear">
        <hr />
        <br />
        <br />
    </div>
    <p>
        <div class="SearchButtonContainer">
            <asp:HyperLink ID="BackHyperlink" runat="server" Text="Regresar"></asp:HyperLink>
        </div>
    </p>
</asp:Content>
