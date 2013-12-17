<%@ Page Title="Follow Streams" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FStream.aspx.cs" Inherits="PicBook.FStream" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="css/board.css" />
    <script src="scripts/js171.js" type="text/javascript"></script>
    <br />
 
        <h2>
            <asp:Label ID="LblFSBoard" runat="server"></asp:Label></h2>
        &nbsp;&nbsp;<asp:Button runat="server" ID="BtnCreate" Text="Create Stream" />
        <hr />
        <div id="wrapper">
            <div id="columns">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="pin">
                            <a href="/FStreamBoard.aspx?fsid=<%#Eval("fsid")%>">
                                <asp:Image ID="Image1" ImageUrl='<%# Eval("thumbnail") %>' runat="server" />
                            </a>
                            <p><%# Eval("fsname") %></p>
                            <p><asp:Button ID="BtnAddToStream" runat="server" Text="Add To Stream" OnCommand="BtnAddToStream_Command" CommandName='<%#Eval("fsid")%>'/></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>


            </div>
        </div>
        <hr />
        <ajaxToolkit:ToolkitScriptManager ID="whatever" runat="server" />
        <ajaxToolkit:ModalPopupExtender
            ID="mdlPopup" BackgroundCssClass="modalBackground" runat="server" CancelControlID="popUpCancel" TargetControlID="BtnCreate" PopupControlID="pnlPopup" />
        <asp:Panel ID="pnlPopup" runat="server" Width="500px" Style="display: none">

            <div class="pin">
                <table class="nav-justified">
                    <tr>
                        <td style="height: 19px; width: 484px">Stream Name</td>
                        <td style="height: 19px">
                            <asp:TextBox ID="TxtFSName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 484px">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 484px">&nbsp;</td>
                        <td>
                            <asp:Button ID="BtnFsCreate" runat="server" OnClick="BtnFsCreate_Click" Text="Create" Width="68px" />&nbsp;<asp:Button ID="popUpCancel" runat="server" Text="Cancel" Width="68px" />
                        </td>
                    </tr>
                </table>
            </div>




        </asp:Panel>
       
 
</asp:Content>




