<%@ Page Title="Imagenes de Galeria" Language="C#" MasterPageFile="~/Shared/Normal.master"
    AutoEventWireup="true" CodeBehind="PictureDisplay.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.PictureDisplay" %>

<%@ Register Src="../Controls/PictureControl.ascx" TagName="PictureControl" TagPrefix="bsx" %>
<%@ Register Src="../Controls/AdvertiserInfoControl.ascx" TagName="AdvertiserInfoCtrl"
    TagPrefix="bsx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="headerTitle">
        <div class="span-24 last">
            <h1>
                Imagenes de Galeria
            </h1>
        </div>
    </div>
    <div class="infocontainer">
        <p>
            <div class="span-4 infotext">
                Galería
            </div>
            <div class="span-20 last contenttext">
                <asp:Label ID="GalleryLabel" runat="server"></asp:Label>
            </div>
        </p>
    </div>
    <bsx:AdvertiserInfoCtrl ID="AdvertiserInfoCtrl1" runat="server"></bsx:AdvertiserInfoCtrl>
    <br />
    <bsx:PictureControl ID="PictureControl1" runat="server" />
    <hr />
    <p>
        <asp:DataList ID="PicturesDataList" runat="server" HorizontalAlign="Center" RepeatColumns="5"
            RepeatDirection="Horizontal" RepeatLayout="Flow" DataSourceID="PictureObjectDataSource"
            ShowFooter="False">
            <ItemTemplate>
                <div class="span-5 last">
                    <div class="itemList">
                        <div class="imageItem">
                            <asp:Image ImageUrl='<%# ImageUrl((int)Eval("PictureId")) %>' runat="server" />
                        </div>
                        <div class="textItem">
                                <asp:Label ID="Label1" Text='<%# Eval("Description") %>' runat="server"></asp:Label>
                        </div>
                        <div class="DeleteButtonContainer">
                            <asp:LinkButton ID="DeleteButton" runat="server" Text="Delete" CommandName="delPicture"
                                class="button" CommandArgument='<%# Eval("PictureId") %>' OnClientClick="return confirm('Estas seguro que deseas Eliminar esta imagen?');">
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </p>
    <div class="clear">
        <br />
        <br />
    </div>
    <p>
        <hr />
        <div class="span-24 last">
            <div class="SearchButtonContainer">
                <asp:LinkButton ID="BackButton" runat="server" Text="Regresar" CausesValidation="false"
                    class="clearSearch"></asp:LinkButton>
            </div>
        </div>
    </p>
    <asp:ObjectDataSource ID="PictureObjectDataSource" runat="server" SelectMethod="FetchAllByGalleryId"
        TypeName="bsx.DirLaguna.Dal.PictureController">
        <SelectParameters>
            <asp:Parameter Name="galleryId" Type="Int32" />
            <asp:Parameter Name="franchiseeId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
