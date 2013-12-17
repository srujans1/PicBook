<%@ Page Title="Add Pin" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreatePin.aspx.cs" Inherits="PicBook.CreatePin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="css/board.css" />
    <script src="scripts/js171.js" type="text/javascript"></script>

    <div>
        <br />
         <h2><%: Title %>.</h2>
                    <hr />
        <div class="row">
        <div class="col-md-6 col-md-offset-3">
         <div class="jumbotron" style="background-color: #f0f0f0; opacity: .95; z-index = -1;">  
        <table class="auto-style1" width="100%">
            <tr>
                <td style="height: 58px">Image Url</td>
                <td style="height: 58px">
                    <asp:TextBox ID="TxtUrl" CssClass="form-control" runat="server" Width="350px"></asp:TextBox>
                &nbsp;</td>
            </tr>
            <tr>
                <td style="height: 58px">Source Url</td>
                <td style="height: 58px">
                    <asp:TextBox ID="TxtSourceUrl" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="rbUrl" runat="server" Checked="True" GroupName="UploadMode"  Text="Url" />
                    <asp:RadioButton ID="rbUpload" runat="server" GroupName="UploadMode"  Text="Upload" />
                </td>
                <td>
                    <asp:FileUpload ID="ImgFileUpload" runat="server" />
                    <asp:Button ID="BtnUpload" runat="server" OnClick="BtnUpload_Click" /><asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Select Board</td>
                <td>
                    <asp:DropDownList ID="CbBoard" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Description</td>
                <td>
                    <asp:TextBox ID="TxtDescription" Textmode="Multiline" resize="none" CssClass="form-control" runat="server" Height="89px" Width="347px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Tags:</td>
                <td>
                   <asp:TextBox ID="TxtHashTag" CssClass="form-control" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="BtnPin" runat="server" CssClass="btn btn-primary" OnClick="BtnPin_Click" Text="Submit" UseSubmitBehavior="False" />
                </td>

            </tr>
        </table>
             </div>  
    </div>
         </div>  
    </div>
 
</asp:Content>
