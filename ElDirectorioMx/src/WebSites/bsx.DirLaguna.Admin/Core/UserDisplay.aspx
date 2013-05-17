<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Shared/Normal.master" AutoEventWireup="true"
    CodeBehind="UserDisplay.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.UserDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="headerTitle">
        <div class="span-24 last">
            <div class="span-12">
                <h1>
                    Usuarios
                </h1>
            </div>
            <div class="span-12 last">
                <div class="NewButtonContainer">
                    <asp:LinkButton ID="NewUserButton" runat="server" Text="Nuevo" class="button" />
                </div>
            </div>
        </div>
    </div>
    <hr />
    <div class="span-24">
        <asp:GridView ID="UsersGridView" runat="Server" AutoGenerateColumns="False" CssClass="tempGridView"
            DataSourceID="UsersDataSource" EnableModelValidation="True">
            <Columns>
                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <asp:Label ID="nameLabel" Text='<%# Eval("aspnet_User.UserName")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:TemplateField HeaderText="Esta aprobado" SortExpression="IsApproved">
                    <ItemTemplate>
                        <asp:Label ID="ApprovedTextLabel" runat="server" Text=""></asp:Label>
                        <asp:CheckBox ID="IsApprovedCheckBox" runat="server" Checked='<%# Bind("IsApproved") %>'
                            Visible="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Esta bloqueado" SortExpression="IsLockedOut">
                    <ItemTemplate>
                        <asp:Label ID="IsLockedOutLabel" runat="server" Text='<%# Bind("IsLockedOut") %>'></asp:Label>
                        <asp:CheckBox ID="IsLockedOutCheckBox" runat="server" Checked='<%# Bind("IsLockedOut") %>'
                            Visible="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="LastLoginDate" HeaderText="Ultima Fecha de Login" SortExpression="LastLoginDate"
                    DataFormatString="{0:dd - MMM - yyyy / hh:mm:ss}" />
                <asp:BoundField DataField="Comment" HeaderText="Comentario" SortExpression="Comment" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='<%# UserForm((string)Eval("aspnet_User.UserName")) %>'>
                            <asp:Image ID="Image1" ImageUrl="~/App_Themes/Laguna/images/magnifier--arrow.png"
                                ToolTip="Ver" runat="server" />
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="DeleteImageButton" runat="server" CommandArgument='<%#Eval("aspnet_User.UserName") %>'
                            ImageUrl="~/App_Themes/Laguna/images/minus-button.png" CommandName="delUser"
                            ToolTip="Eliminar" OnClientClick="return confirm('Estas seguro que deseas Eliminar este usuario?');" />
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
            <PagerSettings Mode="NumericFirstLast" />
            <%--            <PagerTemplate>
                <asp:ImageButton ID="imgFirst" runat="server" CommandName="Page" CommandArgument="First"
                    ImageUrl="~/App_Themes/Laguna/images/arrow-first.png" Height="14px" Width="16px" />
                <asp:ImageButton ID="imgPrev" runat="server" CommandName="Page" CommandArgument="Prev"
                    ImageUrl="~/App_Themes/Laguna/images/arrow-prev.png" Height="14px" Width="11px" />
                <asp:DropDownList ID="PageDropDownList" AutoPostBack="true" OnSelectedIndexChanged="PageDropDownList_SelectedIndexChanged"
                    runat="server" />
                <asp:ImageButton ID="imgNext" runat="server" CommandName="Page" CommandArgument="Next"
                    ImageUrl="~/App_Themes/Laguna/images/arrow-next.png" Height="14px" Width="11px" />
                <asp:ImageButton ID="imgLast" runat="server" CommandName="Page" CommandArgument="Last"
                    ImageUrl="~/App_Themes/Laguna/images/arrow-last.png" Height="14px" Width="16px" />
            </PagerTemplate>--%>
        </asp:GridView>
        <asp:ObjectDataSource ID="UsersDataSource" runat="server" SelectMethod="FetchAll"
            EnablePaging="false" SelectCountMethod="FetchAllCount" TypeName="bsx.DirLaguna.Dal.UserController">
            <SelectParameters>
                <asp:Parameter Name="franchiseeId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
