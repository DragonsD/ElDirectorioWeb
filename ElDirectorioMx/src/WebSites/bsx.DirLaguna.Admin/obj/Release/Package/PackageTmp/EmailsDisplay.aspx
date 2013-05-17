<%@ Page Title="Suscriptores" Language="C#" MasterPageFile="~/Shared/Normal.master" AutoEventWireup="true"
    CodeBehind="EmailsDisplay.aspx.cs" Inherits="bsx.DirLaguna.Admin.EmailsDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="headerTitle">
        <div class="span-24 last">
            <div class="span-12">
                <h1>
                    Correos
                </h1>
            </div>
            <div class="span-12 last">
            </div>
        </div>
    </div>
    <hr />
    <div class="span-24">
        <asp:GridView ID="EmailGridView" runat="server" AutoGenerateColumns="False" 
            EnableModelValidation="True" AllowPaging="False" >
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Nombre" SortExpression="Name" />
                <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:TemplateField HeaderText="Nombre de Usuario" SortExpression="UserName">
                    <ItemTemplate>
                        <asp:Label ID="UserNameLabel" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email" SortExpression="Email">
                    <ItemTemplate>
                        <asp:Label ID="EmailLabel" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CheckBoxField DataField="SendPublicity" HeaderText="Enviar Cupones" SortExpression="SendPublicity" />
            </Columns>
            <EmptyDataTemplate>
                <div class="span-24 last">
                    <div class="dataEmpty">
                        <span>No hay datos para mostrar</span>
                    </div>
                </div>
            </EmptyDataTemplate>
            <PagerSettings Mode="NumericFirstLast" Position="Bottom" />
            <PagerTemplate>
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
            </PagerTemplate>
        </asp:GridView>
        <div class="span-24" style="text-align: right">
            Ver:
            <asp:LinkButton ID="See20LinkButton" runat="server" CommandName="ChangeSize" CommandArgument="20"
                Text="20"></asp:LinkButton>
            <asp:LinkButton ID="See50LinkButton" runat="server" CommandName="ChangeSize" CommandArgument="50"
                Text="50"></asp:LinkButton>
            <asp:LinkButton ID="See100LinkButton" runat="server" CommandName="ChangeSize" CommandArgument="100"
                Text="100"></asp:LinkButton>
            <asp:LinkButton ID="See200LinkButton" runat="server" CommandName="ChangeSize" CommandArgument="200"
                Text="200"></asp:LinkButton>
        </div>
<%--        <asp:ObjectDataSource ID="EmailDataSource" runat="server" SelectMethod="FetchAllGuest"
            EnablePaging="True" SelectCountMethod="FetchAllGuestCount" TypeName="bsx.DirLaguna.Dal.PublicContent.UserPublicController"
            SortParameterName="sort">
            <SelectParameters>
                <asp:Parameter Name="startRowIndex" Type="Int32" />
                <asp:Parameter Name="maximumRows" Type="Int32" />
                <asp:Parameter Name="sort" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>--%>
    </div>

    <div class="clear">
    </div>
    <p>
        <div class="NewButtonContainer">
            <asp:LinkButton ID="ExportToLinkButton" runat="server" Text="Exportar a CVS" class="button">
            </asp:LinkButton>
        </div>
    </p>
</asp:Content>
