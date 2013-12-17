<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="PicBook.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
        <br />
         <h2><%: Title %>.</h2>
                    <hr />
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="jumbotron" style="background-color: #f0f0f0; opacity: .95; z-index = -1;">
                    <div class="row">
                        <div class="col-md-4">
                            <p>First Name</p>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="TxtFName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <p>Middle Name</p>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="TxtMName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <p>Last Name</p>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="TxtLName" CssClass="form-control" runat="server" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <p>Password</p>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="TxtPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <p>Confirm Password</p>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="TxtConPass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">                       
                        <div class="col-md-6 col-md-offset-3">
                            <asp:Button ID="BtnSave" CssClass="btn btn-primary" runat="server" Text="Save" Width="54px" OnClick="BtnSave_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    


</asp:Content>
