<%@ Page Title="Boards" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="member.aspx.cs" Inherits="PicBook.member" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="css/board.css" />
    <br />
     <h2><asp:Label ID="LblUserName" runat="server"></asp:Label>'s <%: Title %>.</h2>
                    <hr />
    
        <div id="wrapper">
            <div id="columns">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="pin">
                            <a href="/Board2.aspx?bid=<%#Eval("bid")%>">
                                <asp:Image ID="Image1" ImageUrl='<%# Eval("thumbnail") %>' runat="server" />
                            </a>
                            <p><%# Eval("descrip") %></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
   
</asp:Content>

