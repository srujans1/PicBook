<%@ Page Title="Boards" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="allBoards.aspx.cs" Inherits="PicBook.allBoards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="css/board.css" />
    <br />
    <div class="row">
    <div class="col-md-5">
  <div class="jumbotron" style="background-color: #f0f0f0; opacity: .95; z-index = -1; padding: 5px; margin-bottom: 5px; font-size: 12px;">
     <h2 style="text-align: center;"><asp:Label ID="LblUserName" runat="server"></asp:Label>'s <%: Title %>.</h2>
      </div>
        </div>
        </div>
                    <hr />
    
        <div id="wrapper">
            <div id="columns">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="pin">
                            <a href="/Board2.aspx?bid=<%#Eval("bid")%>">
                                <asp:Image ID="Image1" ImageUrl='<%# Eval("thumbnail") %>' runat="server" />
                            </a>
                            <h4><%# Eval("descrip") %></h4>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
               
                
            </div>
        </div>
         <hr />
        <div class="row">
        <div class="col-md-5">
        <div class="jumbotron" style="background-color: #f0f0f0; opacity: .95; z-index = -1; padding: 5px; margin-bottom: 5px; font-size: 12px;">
        <h2 style="text-align: center;"><asp:Label ID="lblFBoards" runat="server"></asp:Label>'s Followed Boards</h2>
            </div>
            </div>
            </div>
         <hr />
            <div id="wrapper2">
                <div id="columns2">
                
                <asp:Repeater ID="Repeater2" runat="server">
                    <ItemTemplate>
                        <div class="pin">
                            <a href="/Board2.aspx?bid=<%#Eval("bid")%>">
                                <asp:Image ID="Image1" ImageUrl='<%# Eval("thumbnail") %>' runat="server" />
                            </a>
                            <h4><%# Eval("descrip") %></h4>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
    </div></div>
          
</asp:Content>
