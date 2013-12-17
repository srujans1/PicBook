<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login2.aspx.cs" Inherits="PicBook.Login2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

    <h2><%: Title %>.</h2>
    <%--<div class="row">--%>
        <%--<div class="col-md-8">--%>
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Use a local account to log in.</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="Literal1" />
                        </p>
                    </asp:PlaceHolder>


                    
                    <form id="form1" runat="server">
                        <asp:Login runat="server" ID="PicLogin" DestinationPageUrl="~/allBoards.aspx" OnAuthenticate="PicLogin_Authenticate">
                            <LayoutTemplate>
                                <div class="jumbotron" style="background-color: #f0f0f0; opacity: .95; z-index = -1;">
                                <%--<div class="col-md-6">
                                    </div>--%>
                                <%--<div class="col-lg-9 col-lg-offset-9">--%>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">Username:</asp:Label>
                                        <br />
                                        <div class="col-md-12">
                                            <asp:TextBox ID="UserName" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" CssClass="text-danger" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="PicLogin">*</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password:</asp:Label>
                                            
                                        <div class="col-md-12">
                                            <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" CssClass="text-danger" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="PicLogin">*</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-offset-2 col-md-10">
                                            <div class="checkbox">
                                                 <asp:CheckBox runat="server" ID="RememberMe" />
                                                   <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>

                                    <div class="form-group">
                                        <div class="col-md-offset-2 col-md-10">
                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" CssClass="btn btn-primary" Text="Login" ValidationGroup="PicLogin" />
                                        </div>
                                    </div>
                                <%--</div>--%>
                               
                            </LayoutTemplate>

                        </asp:Login>
                    </form>
                </div>

            </section>
        <%--</div>--%>
    <%--</div>--%>
</asp:Content>
