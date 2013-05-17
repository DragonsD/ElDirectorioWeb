<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GalleryControl.ascx.cs" Inherits="bsx.DirLaguna.Mobile.Controls.GalleryControl" %>
<p>
    <div class="span-10 last">
        <div class="textName">
            <asp:Label ID="GalleryNameLabel" runat="server"></asp:Label>
        </div>
    </div>
    <div class="gallery">
        <asp:Repeater ID="ImagesRepeater" runat="server" DataSourceID="PictureObjectDataSource">
            <ItemTemplate>
                <a href='<%# ImageUrl((int)Eval("PictureId")) %>'>
                    <img src='<%# ImageUrlThumb((int)Eval("PictureId")) %>' width="72" alt="" /></a>
            </ItemTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource ID="PictureObjectDataSource" runat="server" SelectMethod="FetchAllByGalleryId"
            TypeName="bsx.DirLaguna.Dal.PictureController">
            <SelectParameters>
                <asp:Parameter Name="galleryId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</p>
