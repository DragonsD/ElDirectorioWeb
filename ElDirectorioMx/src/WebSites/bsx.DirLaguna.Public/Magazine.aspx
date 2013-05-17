<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Base.Master" AutoEventWireup="true"
    CodeBehind="Magazine.aspx.cs" Inherits="bsx.DirLaguna.Public.Magazine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <script type="text/javascript" src="magazine/swfobject.js"></script>
    <style type="text/css">
        #flashcontent { width: 100%; height: 600px; }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="AdsPageContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PostPageContentPlaceHolder" runat="server">
    <div class="span-20">
        <div id="flashcontent">
            <strong>Necesitas actualizar tu resproductor de flash o activar javascript para este
                sitio.</strong>
        </div>
        <script type="text/javascript">
            function flashOnLoad(){                
            }

            <!--////////////Set your xml path//////////////////-->
            var myXMLFile= "<%=this.ConfigPath %>"; //"http://localhost:2552/files/magazine/config.xml"

            function getXMLFile(){return myXMLFile;}
            <!--///////////////////////////////////////-->
            var so = new SWFObject("magazine/FlipBook.swf", "sotester", "100%", "100%", "9.0.0", "#FFFFFF");
            so.addParam("allowFullScreen", "true");
            so.addParam("scale", "noscale");
            so.addParam("menu", "false");
            so.write("flashcontent");
        </script>
        <script type="text/javascript">
            function ShowPage(sender, number) {
                //alert("Show page number " + number);
                //http://blog.deconcept.com/2005/08/16/external-interface/                
                var myFlashMovie = document.getElementById("sotester");
                if (myFlashMovie)
                    myFlashMovie.moveToPage(number);
                return false;
            }

            
        </script>
        <script type="text/javascript">
            $(document).ready(function () {
                var defaultPage = <%=this.DefaultPage %>;
                if(defaultPage > 0){
                    setTimeout("ShowPage(null,"+defaultPage+");", 1350);
                }
                });
        </script>
    </div>
    <div class="span-4 last">
        <asp:ScriptManager runat="server" ID="XScriptManager">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="XUpdatePanel" runat="server" RenderMode="Block">
            <ContentTemplate>
                <asp:Panel ID="XPanel" runat="server" DefaultButton="SearchButton" CssClass="searchPanel">
                    <%--<label>
                        Buscar</label>--%>
                    <asp:TextBox ID="SearchTextBox" CssClass="lowSearchText" runat="server" placeholder="Buscar"></asp:TextBox>
                    <asp:ImageButton ID="SearchButton" CssClass="lowSearchButton" runat="server" Text="Buscar"
                        ImageUrl="~/Content/Image/magnifier-left.png" />
                        <asp:Image ID="SearchingImage" CssClass="searchingImage" style="display:none" runat="server" ImageUrl="~/Content/Image/ajax-loader.gif" />
                    <%--<asp:Button ID="SearchButton" runat="server" Text="Buscar" />--%>
                    <br />
                    <br />
                    <br />
                </asp:Panel>
                <asp:PlaceHolder ID="SearchPlaceHolder" runat="server" Visible="false">
                    <label>
                        Resultados</label>
                    <asp:DataList ID="XDataList" runat="server" GridLines="None" DataSourceID="XObjectDataSource"
                        RepeatLayout="Table" RepeatColumns="1" RepeatDirection="Vertical">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="XHyperLink" runat="server" NavigateUrl="#" Text='<%#Eval("Value")%>'
                                onclick='<%#Eval("Key", "javascript:return ShowPage(this,{0}); ")%>'>
                            </asp:HyperLink>
                            <asp:Label ID="XLabel" runat="server" CssClass="small" Text='<%#Eval("Key", "Pag {0}") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:ObjectDataSource ID="XObjectDataSource" runat="server" SelectMethod="FetchMagazineItemsByName"
                        TypeName="bsx.DirLaguna.Dal.AdvertiserController">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="SearchTextBox" PropertyName="Text" Name="filter"
                                Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </asp:PlaceHolder>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="CustomJavascriptContentPlaceHolder" runat="server" ID="Content100">
    <script type="text/javascript" src="/Scripts/jquery.placeholder.js">
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.searchPanel input[placeholder]').placeholder();
        });

        function endRequestHandler(sender, args) {
            $('.searchPanel input[placeholder]').placeholder();
        }

        function beginRequestHandler(sender, args) {
            $(".lowSearchButton").hide();
            $(".searchingImage").show();
        }

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandler);
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginRequestHandler);
    </script>
            

</asp:Content>
