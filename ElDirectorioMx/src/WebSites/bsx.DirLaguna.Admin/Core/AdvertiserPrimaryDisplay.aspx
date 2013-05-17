<%@ Page Title="Anunciantes" Language="C#" MasterPageFile="~/Shared/Normal.master"
    AutoEventWireup="true" CodeBehind="AdvertiserPrimaryDisplay.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.AdvertiserPrimaryDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#<%=StartDateTextBox.ClientID %>").datepicker();
            $("#format").change(function () {
                $("#<%=StartDateTextBox.ClientID %>").datepicker("option", "dateFormat", $(this).val());
            });
            $("#<%=EndDateTextBox.ClientID %>").datepicker();
            $("#format").change(function () {
                $("#<%=EndDateTextBox.ClientID %>").datepicker("option", "dateFormat", $(this).val());
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="headerTitle">
        <div class="span-24 last">
            <div class="span-12">
                <h1>
                    Anunciantes
                </h1>
            </div>
            <div class="span-12 last">
                <div class="span-4 prepend-8 last">
                    <div class="NewButtonContainer">
                        <asp:LinkButton ID="NewAdvertiserButton" runat="server" Text="Nuevo" Visible="false"
                            class="button" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <hr />
    <p>
        <div class="span-4">
            Nombre
        </div>
        <div class="span-8">
            <asp:TextBox ID="NameTextBox" runat="server" CssClass="text" Width="250px"></asp:TextBox>
        </div>
        <div class="span-4">
            Ciudad
        </div>
        <div class="span-8 last">
            <asp:DropDownList ID="CityDropDownList" runat="server" Width="250px">
            </asp:DropDownList>
        </div>
        <div class="clear">
        </div>
    </p>
    <p>
        <div class="span-4">
            Descripcion
        </div>
        <div class="span-8">
            <asp:TextBox ID="DescriptionTextBox" runat="server" CssClass="text" Width="250px"></asp:TextBox>
        </div>
        <div class="span-4">
            Franquiciatario
        </div>
        <div class="span-8 last">
            <asp:DropDownList ID="FranchiseeDropDownList" runat="server" Width="250px">
            </asp:DropDownList>
        </div>
        <div class="clear">
        </div>
    </p>
    <p>
        <div class="span-4">
            Vence antes de
        </div>
        <div class="span-8">
            <asp:TextBox ID="EndDateTextBox" runat="server" CssClass="text" Width="50%"></asp:TextBox>
            <asp:RegularExpressionValidator ID="EndRegularExpressionValidator" runat="server"
                ErrorMessage="Formato de Fecha invalido" ControlToValidate="EndDateTextBox" Display="Dynamic"
                ValidationExpression="(\d{1,2}\/\d{1,2}\/\d{4})"></asp:RegularExpressionValidator>
        </div>
        <div class="span-4">
            Vence despues de
        </div>
        <div class="span-8">
            <asp:TextBox ID="StartDateTextBox" runat="server" CssClass="text" Width="50%"></asp:TextBox>
            <asp:RegularExpressionValidator ID="StartDateRegularExpressionValidator" runat="server"
                ErrorMessage="Formato de Fecha invalido" ControlToValidate="StartDateTextBox"
                Display="Dynamic" ValidationExpression="(\d{1,2}\/\d{1,2}\/\d{4})"></asp:RegularExpressionValidator>
        </div>
    </p>
    <div class="span-24 last">
        <div class="SearchButtonContainer">
            <asp:LinkButton ID="SearchAdvertiserButton" runat="server" Text="Buscar" class="button" />
            <asp:LinkButton ID="BackLinkButton" runat="server" Text="Regresar" class="clearSearch" />
            <asp:LinkButton ID="CleanFiltersLinkButton" runat="server" Text="Limpiar" class="clearSearch" />
        </div>
    </div>
    <div class="span-24 last">
        <asp:GridView ID="AdvertisersGridView" runat="Server" AutoGenerateColumns="False"
            DataSourceID="AdvertiserDataSource" EnableModelValidation="True" AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="AdvertiserId" HeaderText="AdvertiserId" SortExpression="AdvertiserId"
                    Visible="false" />
                <%--<asp:BoundField DataField="Name" HeaderText="Nombre" SortExpression="Name" />--%>
                <asp:TemplateField HeaderText="Nombre" SortExpression="Name" ItemStyle-Width="50%">
                    <ItemTemplate>
                        <asp:Label ID="NameLabel" runat="server" Text="Label" Font-Bold="true"> - </asp:Label><asp:Label
                            ID="FranchiseeLabel" runat="server"></asp:Label><br />
                        <asp:Label ID="CityLabel" runat="server" Text="Label" ForeColor="Gray"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Descripcion" SortExpression="Description" ItemStyle-Width="50%">
                    <ItemTemplate>
                        <asp:Label ID="DescriptionLabel" runat="server" Text='<%#Eval("Description") %>'></asp:Label><br />
                        <asp:HyperLink ID="WebPageHyperlink" runat="server" NavigateUrl='<%#Eval("WebPage") %>'
                            Target="_blank" Text='<%#Eval("WebPage") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='<%# ContractForm((int)Eval("AdvertiserId")) %>'>
                            <asp:Image ID="Image2" ImageUrl="~/App_Themes/Laguna/images/blue-folder-open-document-text.png"
                                ToolTip="Contrataciones" runat="server" />
                        </a>
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="DeleteImageButton" runat="server" CommandArgument='<%#Eval("AdvertiserId") %>'
                            ImageUrl="~/App_Themes/Laguna/images/minus-button.png" CommandName="delAdvertiser"
                            ToolTip="Eliminar" OnClientClick="return confirm('Estas seguro que deseas Eliminar este anunciante?');" />
                        <%--                        <asp:LinkButton ID="DeleteLinkButton" runat="server" Text="Delete" CommandArgument='<%#Eval("AdvertiserId") %>'
                                CommandName="delAdvertiser" OnClientClick="return confirm('Estas seguro que deseas Eliminar este anunciante?');">
                            </asp:LinkButton>--%>
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
        <asp:ObjectDataSource ID="AdvertiserDataSource" runat="server" SelectMethod="FetchAllForFranchiseePrimary"
            EnablePaging="true" SelectCountMethod="FetchAllCountForFranchiseePrimary" TypeName="bsx.DirLaguna.Dal.AdvertiserController">
            <SelectParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="description" Type="String" />
                <asp:Parameter Name="cityId" Type="Int32" />
                <asp:Parameter Name="statusId" Type="Int32" />
                <asp:Parameter Name="franchiseeId" Type="Int32" />
                <asp:Parameter Name="publishedIn" Type="Int32" />
                <asp:Parameter Name="startDate" Type="DateTime" />
                <asp:Parameter Name="endDate" Type="DateTime" />
                <asp:Parameter Name="startRowIndex" Type="Int32" />
                <asp:Parameter Name="maximumRows" Type="Int32" />
                <asp:Parameter Name="sort" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
