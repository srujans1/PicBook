<%@ Page Title="Pin" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="pin2.aspx.cs" Inherits="PicBook.pin2" %>

<%@ Register TagPrefix="ajx" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="css/board.css" />
    <script src="scripts/js171.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="css/pin2.css" />
    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=70) !important;
            opacity: 0.7;
            top: 0px !important;
            left: 0px !important;
            position: fixed;
            z-index: 1 !important;
        }
    </style>

    <div style="text-align: center">
        <br />
        <br />
        <br />
        <br />
         <h2><%: Title %>.</h2>
                    <hr />
        <div class="wrapper">
            
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="pin">

                            <asp:Image ID="ImgPin" Height="400px" Width="700px" runat="server" />
                            <div class="form-group">
                                <div class="row">
                            <div class="col-md-3">
                                <h4>
                                Likes -
                                <asp:Label ID="LblLike" runat="server"></asp:Label></h4>
                             </div>
                                <div class="col-md-2">
                                <asp:Button ID="BtnLike" runat="server" CssClass="btn btn-primary btn-xs" OnClick="BtnLike_Click" UseSubmitBehavior="False" CausesValidation="False" />
                                </div>
                                    <div class="col-md-2">
                                    <asp:Button ID="BtnRepin" runat="server" CssClass="btn btn-primary btn-xs" Text="Repin" />
                                        </div>
                                    <div class="col-md-2">
                                        <asp:Button CssClass="btn btn-primary btn-xs" runat="server" ID="BtnDeletePin" OnClick="BtnDeletePin_Click"  Text="Delete Pin"/>
                                    </div>
                                    <h4><asp:Label ID="LblHashtags" runat="server"></asp:Label></h4>
                            </div>
                        </div>
                            <ajaxToolkit:ToolkitScriptManager ID="whatever" runat="server" />
                            <ajaxToolkit:ModalPopupExtender
                                ID="mdlPopup" BackgroundCssClass="modalBackground" runat="server" CancelControlID="popUpCancel" TargetControlID="BtnRepin" PopupControlID="pnlPopup" />
                            <asp:Panel ID="pnlPopup" runat="server" Width="500px" Style="display: none">

                                <div class="pin">
                                    <asp:Image ID="ImgRepin" runat="server" Height="300px" Width="500px" />
                                    <p>
                                       Description: <asp:TextBox CssClass="form-control" ID="TxtRepinDescp" runat="server"></asp:TextBox>
                                    </p>
                                    <p>
                                        select the board to pin this image :
                                        <asp:DropDownList CssClass="form-control" ID="CbBoards" runat="server"></asp:DropDownList>
                                    </p>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <asp:Button ID="BtnRepinSave" CssClass="btn btn-primary btn-xs" Text="Submit" OnClick="BtnRepin_Click" runat="server" />
                                        </div>
                                        <div class="col-md-4 col-md-offset-4">
                                            <asp:Button Text="Cancel" CssClass="btn btn-primary btn-xs" ID="popUpCancel" runat="server" />
                                        </div>
                                        
                                        
                                    </div>
                                </div>




                            </asp:Panel>

                        </div>
                        <br />
                        <div class="pin">

                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>

                                     <div class="jumbotron" style="background-color: #f0f0f0; opacity: .95; z-index = -1;text-align: left; margin-bottom: 8px; width: 700px; min-height: 50px;">
                                         <p><%# Eval("comment") %></p>
                                         
                                         <p style=" text-align:right; font-style:italic;">-<%# Eval("mname") %></p></div>



                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                        <br />
                        <div class="pin">
                            <asp:Label runat="server">Enter comment below:</asp:Label><br />
                            <asp:TextBox ID="TxtBxComment" Width="700px" runat="server" Height="56px" TextMode="MultiLine"></asp:TextBox><br />

                            <hr />

                            <div class="col-md-2 col-md-offset-10">
                            <asp:Button ID="BtnComment" Text="Post" runat="server" CssClass="btn btn-primary btn-xs" OnClick="BtnComment_Click" UseSubmitBehavior="False" />
                       </div>
                                 </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
           
        </div>
    </div>
</asp:Content>
