<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Normal.master" AutoEventWireup="true"
    CodeBehind="BannerDisplay.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.BannerDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <style type="text/css">
        .pagePreview
        {
            overflow: auto;
            width: 950px;
            height: 239px;
        }
        .pagePreviewCommand
        {
            border-bottom: 1px solid #000;
            padding: 8px 0 10px;
            margin: 0 0 25px 0;
            text-align: right;
        }
        .editmode
        {
            height: auto !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="headerTitle">
        <div class="span-24 last">
            <div class="span-12">
                <h1>
                    Contenido del Banner
                </h1>
            </div>
            <div class="span-12 last">
                <div class="NewButtonContainer">
                    <asp:LinkButton ID="NewAdvertiserButton" runat="server" Text="Nuevo" class="button" />
                </div>
            </div>
        </div>
    </div>
    <div class="span-24 last">
        <asp:GridView ID="XGridView" runat="Server" AutoGenerateColumns="False" DataSourceID="XDataSource"
            EnableModelValidation="True" AllowPaging="false">
            <Columns>
                <asp:TemplateField HeaderText="Contenido">
                    <ItemTemplate>
                        <div class="pagePreview">
                            <%--<asp:Literal ID="XLiteral" runat="server" Text='<%#Eval("RealContent") %>'>
                            </asp:Literal>--%>
                            <asp:HyperLink ID="XHyperLink" runat="server" NavigateUrl='<%#Eval("Link") %>' ImageUrl='<%#Eval("Picture") %>'>
                            </asp:HyperLink>
                        </div>
                        <div class="pagePreviewCommand">
                            <asp:HyperLink runat="server" NavigateUrl='<%#Eval("BannerId","BannerForm.aspx?bannerid={0}") %>'
                                ID="EditLink" ImageUrl="~/App_Themes/Laguna/images/magnifier--arrow.png"></asp:HyperLink>
                            <%--<asp:LinkButton ID="DeleteButton" OnClientClick="return confirm('¿Esta seguro que desea borrar esta seccion?');"
                                CausesValidation="false" runat="server" Text="Borrar" CommandName="DeleteItem" />--%>
                            <asp:ImageButton ID="DeleteImageButton" runat="server" CommandArgument='<%#Eval("BannerId") %>'
                                ImageUrl="~/App_Themes/Laguna/images/minus-button.png" CommandName="delBanner"
                                ToolTip="Eliminar" OnClientClick="return confirm('Estas seguro que deseas Eliminar este banner?');" />
                        </div>
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
        <%--<asp:BoundField DataField="AdvertiserId" HeaderText="AdvertiserId" SortExpression="AdvertiserId"
                    Visible="false" />
                <asp:BoundField DataField="Name" HeaderText="Nombre" SortExpression="Name" />
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <asp:Label ID="StatusLabel" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ciudad">
                    <ItemTemplate>
                        <asp:Label ID="CityLabel" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Description" HeaderText="Descripcion" SortExpression="Description" />
                <asp:BoundField DataField="WebPage" HeaderText="Pagina Web" SortExpression="WebPage" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='<%# AdvertiserForm((int)Eval("AdvertiserId")) %>'>
                            <asp:Image ID="Image1" ImageUrl="~/App_Themes/Laguna/images/magnifier--arrow.png"
                                ToolTip="Ver" runat="server" />
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
                </asp:TemplateField>--%>
        <%--<asp:LinkButton ID="UpLinkButton" CausesValidation="false" runat="server" Text="Mover hacia arriba"
                        CommandName="Upload" />
                    &nbsp;
                    <asp:LinkButton ID="DownLinkButton" CausesValidation="false" runat="server" Text="Mover hacia abajo"
                        CommandName="Download" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
        <%--<PagerSettings Mode="NumericFirstLast" Position="Bottom" />
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
            </PagerTemplate>--%>
        <%--<div class="span-24 last" style="text-align: right">
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
        
        SelectCountMethod="FetchAllCount" 
        --%>
        <asp:ObjectDataSource ID="XDataSource" runat="server" SelectMethod="FetchAll" EnablePaging="false"
            TypeName="bsx.DirLaguna.Dal.BannerController">
            <SelectParameters>
                <%--<asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="description" Type="String" />
                <asp:Parameter Name="cityId" Type="Int32" />
                <asp:Parameter Name="statusId" Type="Int32" />
                <asp:Parameter Name="startRowIndex" Type="Int32" />
                <asp:Parameter Name="maximumRows" Type="Int32" />
                <asp:Parameter Name="sort" Type="String" />--%>
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
