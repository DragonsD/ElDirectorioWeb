<%@ Page Title="Mis Cuponeras" Language="C#" MasterPageFile="~/Shared/Admin.Master" AutoEventWireup="true" CodeBehind="CouponSetDisplay.aspx.cs" Inherits="bsx.DirLaguna.Advertiser.CouponSetDisplay" %>
<%@ Register Src="~/Controls/AdvertiserInfoControl.ascx" TagName="AdvertiserInfoCtrl"
    TagPrefix="bsx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="headerTitle">
        <div class="span-24 last">
            <div class="span-12">
                <h1>
                    Cuponeras
                </h1>
            </div>
            <div class="span-12 last">
                <div class="NewButtonContainer">
                    <asp:LinkButton ID="NewCouponSetButton" runat="server" Text="Nueva" class="button" />
                </div>
            </div>
        </div>
    </div>
    <h3>
        <bsx:AdvertiserInfoCtrl id="AdvertiserInfoCtrl1" runat="server">
        </bsx:AdvertiserInfoCtrl>
    </h3>
    <p>
        <div class="span-24">
            <asp:GridView ID="CouponSetGridView" runat="Server" AutoGenerateColumns="False" DataSourceID="CouponSetDataSource"
                EnableModelValidation="True">
                <Columns>
                    <asp:BoundField DataField="CouponSetId" HeaderText="CouponSetId" SortExpression="CouponSetId"
                        Visible="false" />
                    <asp:BoundField DataField="Name" HeaderText="Nombre" SortExpression="Name" />
                    <asp:BoundField DataField="Description" HeaderText="Descripcion" SortExpression="Description" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href='<%# CouponDisplayUrl((int)Eval("CouponSetId")) %>'>
                                <asp:Image ID="Image1" ImageUrl="~/Content/css2/img/credit-cards.png" ToolTip="Cupones"
                                    runat="server" />
                            </a>
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href='<%# CouponSetFormUrl((int)Eval("CouponSetId")) %>'>
                                <asp:Image ID="Image2" ImageUrl="~/Content/css2/img/magnifier--arrow.png"
                                    ToolTip="Ver" runat="server" />
                            </a>
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="DeleteImageButton" runat="server" CommandArgument='<%#Eval("CouponSetId") %>'
                                ImageUrl="~/Content/css2/img/minus-button.png" ToolTip="Eliminar" CommandName="delCouponSet"
                                OnClientClick="return confirm('Estas seguro que deseas Eliminar esta cuponera?');" />
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
            <asp:ObjectDataSource ID="CouponSetDataSource" runat="server" SelectMethod="FetchAdvertiserCouponSets"
                TypeName="bsx.DirLaguna.Dal.CouponSetController">
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
    <p>
        <div class="span-24 last">
            <div class="SearchButtonContainer">
                <asp:LinkButton ID="BackButton" runat="server" Text="Regresar" CausesValidation="false"
                    class="clearSearch"></asp:LinkButton>
            </div>
        </div>
    </p>
</asp:Content>
