<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PicBook.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <link rel="stylesheet" type="text/css" href="css/board.css" />

    <title></title>
  
    <script src="scripts/js171.js" type="text/javascript"></script>
        






</head>
<body>
  <form id="Form1" runat="server">

    <div id="wrapper">
	<div id="columns">
        <asp:Repeater ID="Repeater1" runat="server">
           <ItemTemplate>
               
		<div class="pin" >
            <a href="/Board.aspx?bid=<%#Eval("bid")%>">
                <asp:Image ID="Image1" ImageUrl='<%# Eval("thumbnail") %>' runat="server" />
		
                    </a>
			<p><%# Eval("descrip") %></p>
		</div>
             
           </ItemTemplate>
       </asp:Repeater>

        
    </div>
 
  

    </div>
       </form>
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
 
</body>
</html>
