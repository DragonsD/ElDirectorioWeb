<%@ Page Title="Franquiciatarios" Language="C#" MasterPageFile="~/Shared/Normal.master"
    AutoEventWireup="true" CodeBehind="FranchiseeDisplay.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.FranchiseeDisplay" %>

<%@ Register Src="../Controls/DvMissingAdvertisersControl.ascx" TagName="DvMissingAdvertisersControl"
    TagPrefix="bsx" %>
<%@ Register Src="~/Controls/PendingContractsControl.ascx" TagName="ContractControl"
    TagPrefix="bsx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server"
    defaultbutton="SearchFranchiseeButton">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="headerTitle">
        <div class="span-24 last">
            <div class="span-12">
                <h1>
                    Franquiciatarios
                </h1>
            </div>
            <div class="span-12 last">
                <div class="NewButtonContainer">
                    <asp:LinkButton class="button" ID="NewFranchiseeButton" runat="server" Text="Nuevo" />
                </div>
            </div>
        </div>
    </div>
    <hr />
    <asp:Panel ID="SearchPanel" runat="server" defaultbutton="SearchFranchiseeButton">
        <div class="span-4">
            Nombre
        </div>
        <div class="span-8">
            <asp:TextBox ID="NameTextBox" runat="server" CssClass="text" Width="80%"></asp:TextBox>
        </div>
        <div class="span-4">
            Correo
        </div>
        <div class="span-8 last">
            <asp:TextBox ID="EmailTextBox" runat="server" CssClass="text" Width="80%"></asp:TextBox>
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
        <%--    <div class="span-4">
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
    </div>--%>
        <div class="span-6 prepend-18 last">
            <div class="SearchButtonContainer">
                <asp:LinkButton ID="SearchFranchiseeButton" runat="server" Text="Buscar" class="button" />
                <asp:LinkButton ID="CleanFiltersLinkButton" runat="server" Text="Limpiar" class="clearSearch" />
            </div>
        </div>
        <div class="clear">
            <br />
            <br />
        </div>
    </asp:Panel>
    <div class="span-24">
        <asp:GridView ID="FranchiseesGridView" runat="Server" AutoGenerateColumns="False"
            DataSourceID="FranchiseeDataSource" EnableModelValidation="True" AllowPaging="True">
            <Columns>
                <asp:TemplateField HeaderText="Datos del franquiciatario" SortExpression="Name">
                    <ItemTemplate>
                        <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Name") %>' Font-Bold="true"></asp:Label>
                        <div id="EmailDiv" runat="server" visible='<%# !String.IsNullOrEmpty((string)Eval("Email")) %>'>
                            <asp:HyperLink ID="EmailHyperLink" runat="server" Text='<%#Eval("Email") %>' NavigateUrl='<%# Eval("Email","mailto:{0}")%>'></asp:HyperLink>
                        </div>
                        <div id="PhoneDiv" runat="server" visible='<%# !String.IsNullOrEmpty((string)Eval("Phone")) %>'>
                            <asp:Label ID="PhoneLabel" runat="server" Text='<%#Eval("Phone") %>'></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="LastHire" HeaderText="Ultima contratacion" DataFormatString="{0:d}"
                    ItemStyle-Width="40px" ItemStyle-CssClass="cellstyle" />
                <asp:BoundField DataField="AdvertiserCount" HeaderText="Anunciantes" ItemStyle-Width="40px"
                    ItemStyle-CssClass="cellstyle" />
                <asp:BoundField DataField="CurrentAdvertiserCount" HeaderText="Anunciantes de este mes"
                    ItemStyle-Width="40px" ItemStyle-CssClass="cellstyle" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='<%# FranchiseeDisplayUrl((int)Eval("FranchiseeId")) %>'>
                            <asp:Image ID="Image1" ImageUrl="~/App_Themes/Laguna/images/users.png" ToolTip="Ver Anunciantes"
                                runat="server" />
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='<%# FranchiseeForm((int)Eval("FranchiseeId")) %>'>
                            <asp:Image ID="Image2" ImageUrl="~/App_Themes/Laguna/images/magnifier--arrow.png"
                                ToolTip="Ver" runat="server" />
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="DeleteImageButton" runat="server" CommandArgument='<%#Eval("FranchiseeId") %>'
                            ImageUrl="~/App_Themes/Laguna/images/minus-button.png" CommandName="delFranchisee"
                            ToolTip="Eliminar" OnClientClick="return confirm('Estas seguro que deseas Eliminar este franquiciatario?');" />
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
        <asp:ObjectDataSource ID="FranchiseeDataSource" runat="server" SelectMethod="FetchAll"
            EnablePaging="True" SelectCountMethod="FetchAllCount" TypeName="bsx.DirLaguna.Dal.FranchiseeController">
            <SelectParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="email" Type="String" />
                <asp:Parameter Name="estadoId" Type="Int32" />
                <asp:Parameter Name="cityId" Type="Int32" />
                <asp:Parameter Name="startRowIndex" Type="Int32" />
                <asp:Parameter Name="maximumRows" Type="Int32" />
                <asp:Parameter Name="sort" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <div class="clear">
        <br />
        <br />
    </div>
    <bsx:DvMissingAdvertisersControl ID="DvMissingAdvertisersControl1" runat="server" />
    <div class="clear">
        <br />
        <br />
    </div>
    <bsx:ContractControl ID="NotInvoicedControl" runat="server"></bsx:ContractControl>
    <div class="clear">
        <br />
        <br />
    </div>
    <bsx:ContractControl ID="UnpayedControl" runat="server"></bsx:ContractControl>
    <div class="clear">
        <br />
        <br />
    </div>
    <bsx:ContractControl ID="NoActiveControl" runat="server"></bsx:ContractControl>
    <div class="clear">
        <br />
        <br />
    </div>
</asp:Content>
