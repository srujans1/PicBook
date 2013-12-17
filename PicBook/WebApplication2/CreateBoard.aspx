<%@ Page Title="Add Board" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateBoard.aspx.cs" Inherits="PicBook.CreateBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="css/board.css" />
    <script src="scripts/js171.js" type="text/javascript"></script>

    <div>
        <br />
         <h2><%: Title %>.</h2>
                    <hr />
        <div class="row">
        <div class="col-md-6 col-md-offset-3">
        <div class="jumbotron" style="background-color: #f0f0f0; opacity: .95; z-index = -1;">  
        <table class="auto-style1" width="100%">
            <tr>
                <td>BoardName</td>
                <td>
                    <asp:TextBox ID="TxtBoardName" CssClass="form-control" runat="server" Width="344px" Height="35px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Description</td>
                <td>
                    <asp:TextBox ID="TxtBoardDescription" Textmode="Multiline" resize="none" CssClass="form-control" runat="server" Height="92px" Width="344px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Who Can Comment</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Selected="True" Value="e">Every One</asp:ListItem>
                        <asp:ListItem Value="f">Friends Only</asp:ListItem>
                        <asp:ListItem Value="m">Me only</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BtnCreateBoard" runat="server" CssClass="btn btn-primary" OnClick="BtnCreateBoard_Click" Text="Create" />
                </td>
            </tr>
        </table>
            </div>
    </div>
        </div>
    </div>
        

</asp:Content>
