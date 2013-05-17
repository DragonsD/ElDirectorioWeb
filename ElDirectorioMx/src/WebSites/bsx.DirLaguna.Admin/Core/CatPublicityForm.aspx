<%@ Page Title="Publicidad por categoria" Language="C#" MasterPageFile="~/Shared/Normal.master" AutoEventWireup="true"
    CodeBehind="CatPublicityForm.aspx.cs" Inherits="bsx.DirLaguna.Admin.Core.CatPublicityForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <script language="javascript" type="text/javascript">
        $(function () {
            $("#<%=StartTextBox.ClientID %>").datepicker();
            $("#<%=EndTextBox.ClientID %>").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>
        Publicidad</h1>
    <h3>
        <asp:Label ID="HeaderLabel" runat="server"></asp:Label></h3>
    <hr />
    <h3>
        Datos Generales</h3>
    <p>
        <div class="span-4">
            Nombre
        </div>
        <div class="span-8 append-12 last">
            <asp:TextBox ID="NameTextBox" runat="server" CssClass="text"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                ErrorMessage="Requerido" ControlToValidate="NameTextBox"></asp:RequiredFieldValidator>
        </div>
    </p>
    <p>
        <div class="span-4">
            Descripcion
        </div>
        <div class="span-8 append-12 last">
            <asp:TextBox ID="DescriptionTextBox" runat="server" CssClass="text"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                ErrorMessage="Requerido" ControlToValidate="DescriptionTextBox"></asp:RequiredFieldValidator>
        </div>
    </p>
    <p>
        <div class="span-4">
            Esta disponible
        </div>
        <div class="span-8 append-12 last">
            <asp:CheckBox ID="AvailableCheckBox" runat="server" />
        </div>
    </p>
    <div class="clear">
    </div>
    <p>
        <div class="span-4">
            Desde
        </div>
        <div class="span-8 append-12 last">
            <asp:TextBox ID="StartTextBox" runat="server" CssClass="text"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                ErrorMessage="Requerido" ControlToValidate="StartTextBox"></asp:RequiredFieldValidator>
        </div>
    </p>
    <p>
        <div class="span-4">
            Hasta
        </div>
        <div class="span-8 append-8 last">
            <asp:TextBox ID="EndTextBox" runat="server" CssClass="text"></asp:TextBox>
        </div>
    </p>
    <div class="clear">
    </div>
    <h3>
        Archivo (*.swf)</h3>
    <p>
        <div class="span-4">
            Archivo:</div>
        <div class="span-20 last">
            <asp:FileUpload ID="MediaUpload" runat="server" /></div>
    </p>
    <p>
        <object type="application/x-shockwave-flash" data='<%=this.FlashUrl %>' width="600"
            height="150">
            <param name="movie" value='<%=this.FlashFileName %>' />
            <param name="wmode" value="transparent" />
        </object>
    </p>
    <div class="clear">
    </div>
    <p>
        <div class="SearchButtonContainer">
            <asp:LinkButton ID="SaveButton" runat="server" Text="Guardar" class="button" />
            <asp:LinkButton ID="BackButton" runat="server" Text="Regresar" CausesValidation="false" class="clearSearch"></asp:LinkButton>
        </div>
    </p>
</asp:Content>
