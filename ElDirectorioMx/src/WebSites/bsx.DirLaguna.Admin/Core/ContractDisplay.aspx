<%@ Page Title="Contrataciones" Language="C#" MasterPageFile="~/Shared/Normal.master"
    AutoEventWireup="true" CodeBehind="ContractDisplay.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.ContractDisplay" %>

<%@ Register Src="../Controls/AdvertiserInfoControl.ascx" TagName="AdvertiserInfoCtrl"
    TagPrefix="bsx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="headerTitle">
        <div class="span-12">
            <h1>
                Contrataciones
            </h1>
        </div>
        <div class="span-24 last">
            <div class="NewButtonContainer">
                <asp:LinkButton ID="NewContractButton" runat="server" Text="Nuevo" class="button" />
            </div>
        </div>
    </div>
    <div class="span-24 last">
        <bsx:AdvertiserInfoCtrl ID="AdvertiserInfoCtrl1" runat="server"></bsx:AdvertiserInfoCtrl>
        <br />
        <asp:GridView ID="ContractGridView" runat="server" AutoGenerateColumns="False" DataSourceID="ContractObjectDataSource"
            EnableModelValidation="True">
            <Columns>
                <asp:TemplateField HeaderText="Contenido">
                    <ItemTemplate>
                        <asp:BulletedList ID="SpecsBulletedList" runat="server">
                        </asp:BulletedList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Activo">
                    <ItemTemplate>
                        <asp:Label ID="ActiveLabel" runat="server" Text='<%#((bool)Eval("IsActive"))?"Si":"No" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ContractDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Contratacion"
                    SortExpression="ContractDate" />
                <asp:BoundField DataField="EndDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Final"
                    SortExpression="EndDate" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="PdfLinkButton" runat="server" NavigateUrl='<%# PrintDocumentUrl(Eval("InvoiceId"),true) %>'
                            Visible='<%# Eval("InvoiceId") !=null %>'>
                            <asp:Image ID="PdfImage" ImageUrl="~/App_Themes/Laguna/images/document-pdf-text.png"
                                ToolTip="Pdf" runat="server" />
                        </asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="XmlLinkButton" runat="server" NavigateUrl='<%# PrintDocumentUrl(Eval("InvoiceId"),false) %>'
                            Visible='<%# Eval("InvoiceId") !=null %>'>
                            <asp:Image ID="Image1" ImageUrl="~/App_Themes/Laguna/images/blue-document-template.png"
                                ToolTip="Xml" runat="server" />
                        </asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="EditHyperlink" runat="server" NavigateUrl='<%# ContractForm((int)Eval("ContractId")) %>'
                            Visible='<%#Eval("InvoiceId")==null %>'>
                            <asp:Image ID="ContactImage" ImageUrl="~/App_Themes/Laguna/images/pencil.png" ToolTip="Editar"
                                runat="server" />
                        </asp:HyperLink>
                        <asp:Label ID="InvoiceIdLabel" runat="server" Text='<%# Eval("InvoiceId") %>' Style="display: none;"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="DeleteImageButton" runat="server" CommandArgument='<%#Eval("ContractId") %>'
                            ImageUrl="~/App_Themes/Laguna/images/minus-button.png" CommandName="delContract"
                            CausesValidation="false" ToolTip="Eliminar" OnClientClick="return confirm('Estas seguro que deseas Eliminar esta contratacion?');" />
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
        <asp:ObjectDataSource ID="ContractObjectDataSource" runat="server" SelectMethod="FetchAllByAdvertiserId"
            TypeName="bsx.DirLaguna.Dal.ContractController">
            <SelectParameters>
                <asp:Parameter Name="advertiserId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <div class="span-24 last">
        <div class="SearchButtonContainer">
            <asp:HyperLink ID="BackHyperLink" runat="server" class="clearSearch">Regresar</asp:HyperLink>
        </div>
    </div>
</asp:Content>
