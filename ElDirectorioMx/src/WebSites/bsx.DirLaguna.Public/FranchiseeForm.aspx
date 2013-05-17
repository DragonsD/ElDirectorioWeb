<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FranchiseeForm.aspx.cs"
    Inherits="bsx.DirLaguna.Public.FranchiseeForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Franquiciatarios</title>
    <style type="text/css">
        body { text-align: center; background-color: #076DFC; }        
        #mainDiv { width: 850px; margin: 0 auto; }        
        #logoDiv { margin: 100px 20px 20px 20px; }        
        .linkDiv { width: 400px; float: left; margin-top: 50px; }        
        .linkDiv a { text-decoration: none; }
        .linkDiv .text { color: #FFFFFF; font-family: Arial; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="mainDiv">
        <div id="logoDiv">
            <a href="http://eldirectorio.mx/HomeForm.aspx">
                <img src="content/css2/img/LogoElDirectorio.png" alt="Franquiciatarios" />
            </a>
        </div>
        <div class="linkDiv">
            <div class="link">
                <asp:HyperLink ID="ProspectationHyperLink" runat="server">
                    <img src="Content/Image/prospectacion.png" alt="Prospectación" />
                <div class="text">
                    <h1>
                        Prospectación</h1>
                </div>
                </asp:HyperLink>
            </div>
        </div>
        <div class="linkDiv">
            <div class="link">
                <asp:HyperLink ID="FranchiseeHyperLink" runat="server">
                    <img src="Content/Image/admin.png" alt="Franquciatarios" />
                <div class="text">
                    <h1>
                        Administrador</h1>
                </div>
                </asp:HyperLink>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
