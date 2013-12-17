<%@ Page Title="Friends" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="PicBook.Friends" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="css/board.css" />
    <script src="scripts/js171.js" type="text/javascript"></script>
    
        <br />
         <h2><%: Title %>.</h2>
                    <hr />
        <div id="wrapper">
            <div id="columns">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>

                        <div class="pin">
                            <a href="/Member.aspx?mid=<%#Eval("mid")%>">
                                <h2 style="text-align:center"><%# Eval("fname") %><h2/>

                            </a>
                            <asp:Button CssClass="btn btn-primary btn-xs" runat="server" ID="BtnDeleteFriend" OnCommand="BtnDeleteFriend_Command" CommandName='<%#Eval("mid")%>' Text="Unfriend"/>
               
                        </div>

                    </ItemTemplate>
                </asp:Repeater>


            </div>



        </div>
 
    <%-- <div id="container" class="transitions-enabled infinite-scroll clearfix">
       <asp:Repeater ID="Repeater1" runat="server">
           <ItemTemplate>
               <div class="box">
                   <img src="<%# Eval("Url") %>" />
                   <p><%# Eval("Description") %></p>
               </div>
           </ItemTemplate>
       </asp:Repeater>
   </div>
    --%>
</asp:Content>
