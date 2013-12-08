<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pin.aspx.cs" Inherits="PicBook.Pin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="css/pin2.css" />
    <title></title>
</head>
<body>
    <div style="text-align: center">
        <div class="wrapper">
            <form id="form1" runat="server">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="pin">

                            <asp:Image ID="ImgPin" Height="400px" Width="700px" runat="server" />
                            <p>
                                Likes -
                        <asp:Label ID="LblLike" runat="server"></asp:Label>
                                <asp:Button ID="BtnLike" runat="server" OnClick="BtnLike_Click" UseSubmitBehavior="False" CausesValidation="False" />
                            </p>



                        </div>
                        <br />
                        <div class="pin">

                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>

                                    <p style="text-align: left; margin-bottom: 8px; width: 700px; min-height: 50px; background-color: #d9dddd"><%# Eval("comment") %></p>



                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                        <br />
                        <div class="pin">
                            <asp:Label runat="server">Enter comment below:</asp:Label><br />
                            <asp:TextBox ID="TxtBxComment" Width="700px" runat="server" Height="56px" TextMode="MultiLine"></asp:TextBox><br />
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>


                            <asp:Button ID="BtnComment" Text="Post" runat="server" OnClick="BtnComment_Click" UseSubmitBehavior="False" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </form>
        </div>
    </div>
</body>
</html>
