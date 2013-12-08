<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PicBook.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
         
    <asp:Login runat="server" ID="PicLogin" DestinationPageUrl="~/Home.aspx" OnAuthenticate="PicLogin_Authenticate">
        
    </asp:Login>
           


            </div>
    </form>
</body>
</html>
