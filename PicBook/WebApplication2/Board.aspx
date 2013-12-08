<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Board.aspx.cs" Inherits="PicBook.Board" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
            <a href="/Pin.aspx?pid=<%#Eval("pid")%>">
                <asp:Image ID="Image1" ImageUrl='<%# Eval("Url") %>' runat="server" />
		
                    </a>
			<p><%# Eval("Description") %></p>
		</div>
             
           </ItemTemplate>
       </asp:Repeater>

        
    </div>
 
  

    </div>
       </form>

 
</body>
</html>
