<%@ Page Title="Pending Friend Requests" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PFriends.aspx.cs" Inherits="PicBook.PFriends" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="css/board.css" />
    <script src="scripts/js171.js" type="text/javascript"></script>

      <br />
       <h2><%: Title %>.</h2>
                    <hr />
    <div id="wrapper">
	<div id="columns">
        <asp:Repeater ID="Repeater1"  runat="server">
           <ItemTemplate>
               
		<div class="pin" >
            <a href="/Member.aspx?mid=<%#Eval("mid")%>">
                <p style="text-align:center"><%# Eval("fname") %></p>
		
                    </a>
            <div class="row">
                <div class="col-md-6">
                    <asp:Button ID="BtnAccept" CssClass="btn btn-primary btn-xs" runat="server" OnCommand="BtnReject_Command" CausesValidation="false" UseSubmitBehavior="false" CommandName="accept" CommandArgument='<%# Eval("mid") %>' Text="Accept" />
                </div>
                <div class="col-md-6">
                    <asp:Button ID="BtnReject" CssClass="btn btn-primary btn-xs" OnCommand="BtnReject_Command" CausesValidation="false" UseSubmitBehavior="false" CommandName="reject" CommandArgument='<%# Eval("mid") %>' runat="server" Text="Reject" />
                      </div>
            </div>
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
