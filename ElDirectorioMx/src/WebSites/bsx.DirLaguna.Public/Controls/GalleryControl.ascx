<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GalleryControl.ascx.cs"
    Inherits="bsx.DirLaguna.Public.Controls.GalleryControl" %>
<p>
    <div class="span-10 last">
        <div class="textName">
            <asp:Label ID="GalleryNameLabel" runat="server"></asp:Label>
        </div>
    </div>
    <div class="span-10 last">
        <asp:Repeater ID="ImagesRepeater" runat="server" DataSourceID="PictureObjectDataSource">
            <HeaderTemplate>
                <div class="gallery">
            </HeaderTemplate>
            <ItemTemplate>
                <a href='<%# ImageUrl((int)Eval("PictureId")) %>'>
                    <img src='<%# ImageUrlThumb((int)Eval("PictureId")) %>' width="72" alt="" /></a>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource ID="PictureObjectDataSource" runat="server" SelectMethod="FetchAllByGalleryId"
            TypeName="bsx.DirLaguna.Dal.PictureController">
            <SelectParameters>
                <asp:Parameter Name="galleryId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</p>
