<%@ Page Title="Login" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Coffee_Shop.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Styles/Login.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-offset-4 col-md-4 margin" style="background-color: rgba(34, 34, 34, .7); border-radius: 8px">
            <section id="loginForm">
                <div class="form-horizontal">
                   <asp:PlaceHolder runat="server" ID="PlaceHolder1" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="Literal1" />
                        </p>
                    </asp:PlaceHolder>
                    <h4 style="color: white;">Log In</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label" style="color: white;">Email</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="The email field is required." />
                        </div>
                    </div>
                    <div class="form-group" id="nomargin">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label" style="color: white;">Password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-3">
                            <p><a runat="server" href="~/PasswordReset.aspx">Forgot posword?</a></p>
                        </div>
                        <div class="col-md-offset-4 col-md-3">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe" style="color: white;">Remember me?</asp:Label>
                            </div>                   
                        </div>                     
                    </div>
                    <div class="col-md-offset-3 col-md-7">
                        <asp:Button CssClass="btn btn-lg btn-success btn-block" runat="server" Text="Log In" OnClick="ValidateUser" style="margin-bottom: 15px;"/>
                    </div>
                </div>
            </section>
        </div>
</asp:Content>
