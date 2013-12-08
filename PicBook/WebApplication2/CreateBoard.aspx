<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateBoard.aspx.cs" Inherits="PicBook.CreateBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 72%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <table class="auto-style1">
            <tr>
                <td>Board Name</td>
                <td>
                    <asp:TextBox ID="TxtBoardName" runat="server" Width="238px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Description</td>
                <td>
                    <asp:TextBox ID="TxtBoardDescription" runat="server" Height="54px" Width="238px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BtnCreateBoard" runat="server" OnClick="BtnCreateBoard_Click" Text="Create" />
                </td>
            </tr>
        </table>
        
    </div>
        
    </form>
</body>
</html>
