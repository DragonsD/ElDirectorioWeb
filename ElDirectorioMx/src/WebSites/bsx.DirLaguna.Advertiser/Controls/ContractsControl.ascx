<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContractsControl.ascx.cs"
    Inherits="bsx.DirLaguna.Advertiser.Controls.ContractsControl" %>
<p style="text-align: right; padding-bottom: 20px">
    <asp:LinkButton ID="NewContractButton" runat="server" Text="Nuevo" class="button"
        CausesValidation="false" />
</p>
<asp:GridView ID="ContractGridView" runat="server" AutoGenerateColumns="False" DataSourceID="ContractObjectDataSource"
    EnableModelValidation="True">
    <Columns>
        <asp:TemplateField HeaderText="Contenido">
            <ItemTemplate>
                <asp:BulletedList ID="SpecsBulletedList" runat="server">
                </asp:BulletedList>
                <asp:HyperLink ID="ProcedToPayHyperLink" runat="server" Text="Tu contratación no esta pagada. Pasa a pagar" Visible='<%#!(bool)Eval("IsPaid") %>'
                    NavigateUrl='<%#Eval("ContractId","~/ContractForm.aspx?contractId={0}") %>'></asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Activo">
            <ItemTemplate>
                <asp:Label ID="ActiveLabel" runat="server" Text='<%#((bool)Eval("IsActive"))?"Si":"No" %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="ContractDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Contratacion"
            SortExpression="ContractDate" />
        <asp:BoundField DataField="EndDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Final"
            SortExpression="EndDate" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink ID="PdfLinkButton" runat="server" NavigateUrl='<%# PrintDocumentUrl(Eval("InvoiceId"),true) %>'
                    Visible='<%# Eval("InvoiceId") !=null %>'>
                    <asp:Image ID="PdfImage" ImageUrl="~/Content/Image/document-pdf-text.png" ToolTip="Pdf"
                        runat="server" />
                </asp:HyperLink>
            </ItemTemplate>
            <ItemStyle Width="20px" />
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink ID="XmlLinkButton" runat="server" NavigateUrl='<%# PrintDocumentUrl(Eval("InvoiceId"),false) %>'
                    Visible='<%# Eval("InvoiceId") !=null %>'>
                    <asp:Image ID="Image1" ImageUrl="~/Content/Image/blue-document-template.png" ToolTip="Xml"
                        runat="server" />
                </asp:HyperLink>
            </ItemTemplate>
            <ItemStyle Width="20px" />
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink ID="EditHyperlink" runat="server" NavigateUrl='<%# ContractForm((int)Eval("ContractId")) %>'
                    Visible='<%#!(bool)Eval("IsActive") && Eval("InvoiceId")==null %>'>
                    <asp:Image ID="ContactImage" ImageUrl="~/Content/Image/pencil.png" ToolTip="Editar"
                        runat="server" />
                </asp:HyperLink>
                <asp:Label ID="InvoiceIdLabel" runat="server" Text='<%# Eval("InvoiceId") %>' Style="display: none;"></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="20px" />
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="DeleteImageButton" runat="server" CommandArgument='<%#Eval("ContractId") %>'
                    ImageUrl="~/Content/Image/minus-button.png" CommandName="delContract" CausesValidation="false"
                    ToolTip="Eliminar" OnClientClick="return confirm('Estas seguro que deseas Eliminar esta contratacion?');"
                    Visible='<%#!(bool)Eval("IsActive") && Eval("InvoiceId")==null %>' />
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
            ImageUrl="~/Content/Image/arrow-first.png" Height="14px" Width="16px" />
        <asp:ImageButton ID="imgPrev" runat="server" CommandName="Page" CommandArgument="Prev"
            ImageUrl="~/Content/Image/arrow-prev.png" Height="14px" Width="11px" />
        <asp:DropDownList ID="PageDropDownList" AutoPostBack="true" OnSelectedIndexChanged="PageDropDownList_SelectedIndexChanged"
            runat="server" />
        <asp:ImageButton ID="imgNext" runat="server" CommandName="Page" CommandArgument="Next"
            ImageUrl="~/Content/Image/arrow-next.png" Height="14px" Width="11px" />
        <asp:ImageButton ID="imgLast" runat="server" CommandName="Page" CommandArgument="Last"
            ImageUrl="~/Content/Image/arrow-last.png" Height="14px" Width="16px" />
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
<asp:ObjectDataSource ID="ContractObjectDataSource" runat="server" SelectMethod="FetchAllByAdvertiserId"
    TypeName="bsx.DirLaguna.Dal.ContractController">
    <SelectParameters>
        <asp:Parameter Name="advertiserId" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HyperLink ID="BackHyperLink" runat="server" class="clearSearch">Regresar</asp:HyperLink>
