<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AnnounceControl.ascx.cs"
    Inherits="bsx.DirLaguna.Mobile.Controls.AnnounceControl" %>
    <div id="AnnouncesDiv">
        <asp:DataList ID="AnnounceDataList" runat="server" DataSourceID="AnnounceObjectDataSource" RepeatLayout="Flow" RepeatDirection="Horizontal">
            <ItemTemplate>
                <a href='<%# ImageUrl((int)Eval("AnnounceId")) %>'>
                    <img src='<%# ImageUrlThumb((int)Eval("AnnounceId")) %>' width="72" alt="" /></a>
            </ItemTemplate>
        </asp:DataList>
    </div>
<asp:ObjectDataSource ID="AnnounceObjectDataSource" runat="server" SelectMethod="FetchAllByAdvertiserId"
    TypeName="bsx.DirLaguna.Dal.AnnounceController">
    <SelectParameters>
        <asp:Parameter Name="advertiserId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
