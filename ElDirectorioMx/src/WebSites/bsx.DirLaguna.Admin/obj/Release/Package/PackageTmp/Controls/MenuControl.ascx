<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuControl.ascx.cs"
    Inherits="bsx.DirLaguna.Admin.Controls.MenuControl" %>
<ul id="main-menu">
    <asp:Repeater ID="MenuRepeater" runat="server">
        <ItemTemplate>
            <li>
                <asp:HyperLink ID="ItemHyperLink" runat="server" NavigateUrl='<%# Eval("URL")%>'>
                   <span><%#Eval("Text")%></span>
                </asp:HyperLink>
                <%--<asp:HyperLink ID="HyperLink1" CssClass='<%# Eval("CssClass")%>' runat="server" ToolTip='<%# Eval("SecondURL")%>'
                    NavigateUrl='<%# Eval("URL")%>'>
                   <span><%#Eval("Text")%></span>
                </asp:HyperLink>--%>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
