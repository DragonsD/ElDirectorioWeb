<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="bsx.DirLaguna.Public.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Directorio Laguna</title>
    <script language="javascript" type="text/javascript">
        var navegador = navigator.userAgent;
        var isiPad = navigator.userAgent.match(/iPad/i) != null;
        if (isiPad) {
            window.location = '<%=this.UrlSiteDesktop %>';
        }
        else {
            if (navegador.indexOf('MSIE') != -1 | navegador.indexOf('Firefox') != -1
            | navegador.indexOf('Chrome') != -1 | navegador.indexOf('Opera') != -1
            | navegador.indexOf('Safari') != -1) {

                if (navegador.indexOf('PlayBook') != -1 | navegador.indexOf('BlackBerry') != -1 | navegador.indexOf('iPhone') != -1 | navegador.indexOf('iPad') != -1 | navegador.indexOf('Android') != -1) {
                    window.location = '<%=this.UrlSiteMovil %>';
                }
                else {
                    window.location = '<%=this.UrlSiteDesktop %>';
                }

            } else if (navegador.indexOf('iPhone') != -1 | navegador.indexOf('iPad') != -1 | navegador.indexOf('Android') != -1 | navegador.indexOf('PlayBook') != -1 | navegador.indexOf('BlackBerry') != -1) {
                window.location = '<%=this.UrlSiteMovil %>';
            } else {
                window.location = '<%=this.UrlSiteDesktop %>';
            }
        }

        /*if (navegador.indexOf('MSIE') != -1 | navegador.indexOf('Firefox') != -1
            | navegador.indexOf('Chrome') != -1 | navegador.indexOf('Opera') != -1
            | navegador.indexOf('Safari') != -1) {
            if (navegador.indexOf('Safari') != -1) {
                if (navegador.indexOf('PlayBook') != -1 | navegador.indexOf('BlackBerry') != -1) {
                    window.location = '<%=this.UrlSiteMovil %>';
                }
                else {
                    if (navegador.indexOf('iPhone') != -1 | navegador.indexOf('iPad') != -1 | navegador.indexOf('Android') != -1) {
                        window.location = '<%=this.UrlSiteMovil %>';
                    } else {
                        window.location = '<%=this.UrlSiteDesktop %>';
                    }
                }
            } else {
                window.location = '<%=this.UrlSiteDesktop %>';
            }

        } else if (navegador.indexOf('iPhone') != -1 | navegador.indexOf('iPad') != -1 | navegador.indexOf('Android') != -1) {
            window.location = '<%=this.UrlSiteMovil %>';
        } else {
            window.location = '<%=this.UrlSiteDesktop %>';
        }*/
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Pagina para redireccionar dependiendo del tipo de navegador
    </div>
    </form>
</body>
</html>
