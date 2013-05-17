<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CouponPrint.aspx.cs" Inherits="bsx.DirLaguna.Public.CouponPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #main
        {
            margin: 0 auto;
            text-align: center;
            width: 950px;
            font-family:Helvetica,Arial,Helvetica,sans-serif;
        }
        #imageDiv
        {
        }
        #conditionsDiv
        {
            margin: 0 auto;
            padding-top: 20px;
            text-align: left;
            width: 400px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <h1>
            <asp:Label ID="TitleLabel" runat="server"></asp:Label>
        </h1>
        <div id="imageDiv">
            <asp:Image ID="CouponImage" runat="server" ImageUrl="~/Content/coupons/default_large.jpg" />
        </div>
        <div id="conditionsDiv" runat="server">
            <asp:Label ID="ConditionsLabel" runat="server"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
