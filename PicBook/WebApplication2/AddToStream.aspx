<%@ Page Title="Add to streams" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddToStream.aspx.cs" Inherits="PicBook.AddToStream" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div>
        <br />
        <br />
        <br />
         <div class="row">
        <div class="col-md-6 col-md-offset-3">
         <div class="jumbotron" style="background-color: #f0f0f0; opacity: .95; z-index = -1;">
             <div class="row">
                 <p>Select boards to add to the stream:</p>
             </div>
             <div class="row">
                 <asp:ListBox runat="server" ID="LstBoards" Height="266px" Width="264px" SelectionMode="Multiple"></asp:ListBox>
             </div>
             <div class="row">
                 <asp:Button ID="BtnAdd" CssClass="btn btn-primary" runat="server" OnClick="BtnAdd_Click" Text="Add" />
             </div>
         </div>
    </div>
             </div>
    </div>
    

    
</asp:Content>
