<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Coffee_Shop.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="/Styles/Register.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="col-md-6"></div>
    <div class="col-md-12">
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
    </div>
    <div class="form-horizontal col-md-4 margin">
        <h4>Create a new account</h4>
         <hr/>
         <asp:PlaceHolder runat="server" ID="statusMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="MessageText" />
                        </p>
                    </asp:PlaceHolder>
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="secQuestion" CssClass="col-md-2 control-label">Security Question</asp:Label>
            <div class="col-md-10">
              <asp:DropDownList ID="secQuestion" CssClass="form-control selectpicker" runat="server">
                 <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem>Name of your first pet?</asp:ListItem>
                <asp:ListItem>Favourite book?</asp:ListItem>
                <asp:ListItem>Something else?</asp:ListItem>   
            </asp:DropDownList>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="secQuestion" InitialValue="--Select--"
              CssClass="text-danger" Display="Dynamic" ErrorMessage="The security question field is required." />
            </div>         
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="secAnswer" CssClass="col-md-2 control-label">Security question answer</asp:Label>
              <div class="col-md-10">
                <asp:TextBox runat="server" ID="secAnswer" TextMode="SingleLine" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="secAnswer"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The security question answer field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="Register" CssClass="btn btn-success" ID="btnRegister" OnClick="btnRegister_Click" />
            </div>
        </div>
    </div>
</asp:Content>
