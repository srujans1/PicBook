<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="PicBook.CreateUser" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <br />
         <h2><%: Title %>.</h2>
                    <hr />
    <div class="jumbotron" style="background-color: #f0f0f0; opacity: .95; z-index = -1;">
    
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" EnableViewState="False" OnCreatingUser="CreateUserWizard1_CreatingUser">
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server" />
                <asp:CompleteWizardStep runat="server" />
            </WizardSteps>
        </asp:CreateUserWizard>
        <asp:Label ID="LblSuccess" runat="server" Text="Label"></asp:Label>
    
    </div>
   </form>
</asp:Content>
