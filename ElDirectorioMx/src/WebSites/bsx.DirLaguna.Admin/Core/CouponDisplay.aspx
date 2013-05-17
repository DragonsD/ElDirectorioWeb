﻿<%@ Page Title="Cupones" Language="C#" MasterPageFile="~/Shared/Normal.master" AutoEventWireup="true"
    CodeBehind="CouponDisplay.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.CouponDisplay" %>

<%@ Register Src="../Controls/AdvertiserInfoControl.ascx" TagName="AdvertiserInfoCtrl"
    TagPrefix="bsx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="headerTitle">
        <div class="span-24 last">
            <div class="span-12">
                <h1>
                    Cupones
                </h1>
                <br />
            </div>
            <div class="span-12 last">
                <div class="NewButtonContainer">
                    <asp:LinkButton ID="NewCouponButton" runat="server" Text="Nuevo" class="button" />
                </div>
            </div>
        </div>
    </div>
    <div class="infocontainer">
        <p>
            <div class="span-4 infotext">
                Cuponera
            </div>
            <div class="span-20 last contenttext">
                <asp:Label ID="CouponSetLabel" runat="server"></asp:Label>
            </div>
        </p>
    </div>
    <bsx:AdvertiserInfoCtrl ID="AdvertiserInfoCtrl1" runat="server"></bsx:AdvertiserInfoCtrl>
    <br />
    <p>
        <div class="span-24">
            <asp:GridView ID="CouponsGridView" runat="Server" AutoGenerateColumns="False" DataSourceID="CouponDataSource"
                EnableModelValidation="True">
                <Columns>
                    <asp:BoundField DataField="CouponId" HeaderText="CouponId" SortExpression="CouponId"
                        Visible="false" />
                    <asp:BoundField DataField="Name" HeaderText="Nombre" SortExpression="Name" />
                    <asp:BoundField DataField="Description" HeaderText="Descripcion" SortExpression="Description" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href='<%# CouponFormUrl((int)Eval("CouponId")) %>'>
                                <asp:Image ID="Image2" ImageUrl="~/App_Themes/Laguna/images/magnifier--arrow.png"
                                    ToolTip="Ver" runat="server" />
                            </a>
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="DeleteImageButton" runat="server" CommandArgument='<%#Eval("CouponId") %>'
                                ImageUrl="~/App_Themes/Laguna/images/minus-button.png" ToolTip="Eliminar" CommandName="delCoupon"
                                OnClientClick="return confirm('Estas seguro que deseas Eliminar este cupon?');" />
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
            <asp:ObjectDataSource ID="CouponDataSource" runat="server" SelectMethod="FetchCouponSetCoupons"
                TypeName="bsx.DirLaguna.Dal.CouponController">
                <SelectParameters>
                    <asp:Parameter Name="advertiserId" Type="Int32" />
                    <asp:Parameter Name="franchiseeId" Type="Int32" />
                    <asp:Parameter Name="couponSetId" Type="Int32" />
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
