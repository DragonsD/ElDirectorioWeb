<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdvertiserInfoControl.ascx.cs" Inherits="bsx.DirLaguna.Advertiser.Controls.AdvertiserInfoControl" %>
<div class="infocontainer">
    <p>
        <div class="span-4 infotext">
            Anunciante
        </div>
        <div class="span-20 last contenttext">
            <asp:Label ID="NameLabel" runat="server"></asp:Label>
        </div>
    </p>
    <p>
        <div class="span-4 infotext">
            Franquiciatario
        </div>
        <div class="span-20 last contenttext">
            <asp:Label ID="FranchiseeLabel" runat="server"></asp:Label>
        </div>
    </p>
    <p>
        <div class="span-4 infotext">
            Vigencia Actual
        </div>
        <div class="span-20 last contenttext">
            <asp:Label ID="VigencyLabel" runat="server"></asp:Label>
        </div>
    </p>
</div>
<div class="clear">
</div>
