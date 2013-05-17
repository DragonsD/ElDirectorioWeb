<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AnnounceControl.ascx.cs" Inherits="bsx.DirLaguna.Public.Controls.AnnounceControl" %>
<p>
<%--    <div class="span-10 last">
        <div class="textName">
            <asp:Label ID="AnnounceNameLabel" runat="server"></asp:Label>
        </div>
    </div>--%>
    <div class="span-10 last">
        <asp:DataList ID="AnnounceDataList" runat="server"  
            DataSourceID="AnnounceObjectDataSource" RepeatColumns="5" 
            RepeatDirection="Horizontal">
            <ItemTemplate>
                <a href='<%# ImageUrl((int)Eval("AnnounceId")) %>'>
                    <img src='<%# ImageUrlThumb((int)Eval("AnnounceId")) %>' width="72" alt="" /></a>
            </ItemTemplate>
        </asp:DataList>
        <asp:ObjectDataSource ID="AnnounceObjectDataSource" runat="server" SelectMethod="FetchAllByAdvertiserId"
            TypeName="bsx.DirLaguna.Dal.AnnounceController">
            <SelectParameters>
                <asp:Parameter Name="advertiserId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</p>
