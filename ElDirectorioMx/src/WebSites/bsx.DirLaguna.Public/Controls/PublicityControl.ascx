<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PublicityControl.ascx.cs" Inherits="bsx.DirLaguna.Public.Controls.PublicityControl" %>
<%@ Import Namespace="bsx.DirLaguna.Dal" %>
<%@ Import Namespace="bsx.DirLaguna.CommonWeb" %>
<%@ Import Namespace="bsx.DirLaguna.Public.Code" %>
<asp:DataList ID="PublicityDataList" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" DataSourceID="PublicityDataSource">
    <ItemTemplate>
        <div class="span-4 last couponItem">
            <asp:Image ID="publicityImage" runat="server" AlternateText="Image" ImageUrl='<%#this.PublicityPictureUrl((int)Eval("PublicityId"))%>'/>
        </div>
    </ItemTemplate>
</asp:DataList>
<asp:ObjectDataSource ID="PublicityDataSource" runat="server" TypeName="bsx.DirLaguna.Dal.SelectControllers.PublicityController" OnSelecting="PublicityDataSource_Selecting" SelectMethod="FetchAll">
    <SelectParameters>
        <asp:Parameter Name="publicityId" Type="Int32" />
        <asp:Parameter DefaultValue="" Name="cityId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
