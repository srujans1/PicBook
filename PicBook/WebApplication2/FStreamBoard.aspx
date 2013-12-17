<%@ Page Title="Follow Streams" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FStreamBoard.aspx.cs" Inherits="PicBook.FStreamBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="css/board.css" />
    <script src="scripts/js171.js" type="text/javascript"></script>
    <br />

     <h2><asp:label ID="LblFSBoard" runat="server"></asp:label></h2>
         <hr />

        <div id="wrapper">
            <div id="columns">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="pin">
                            <a href="/Pin2.aspx?pid=<%#Eval("pid")%>">
                                <asp:Image ID="Image1" ImageUrl='<%# Eval("Url") %>' runat="server" />
                            </a>
                            <p><%# Eval("Description") %></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
  
</asp:Content>


