<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuControl.ascx.cs" Inherits="bsx.DirLaguna.Public.Controls.MenuControl" %>
<ul id="main-menu" class="hMenu">
    <asp:Repeater ID="MenuRepeater" runat="server">
        <ItemTemplate>
            <li>
                <asp:HyperLink ID="ItemHyperLink" CssClass='<%# Eval("CssClass")%>' runat="server" NavigateUrl='<%# Eval("URL")%>'>
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