<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Coffee_Shop.Users.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Styles/checkout.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="form-horizontal col-md-4 col-md-offset-4" id="buyForm">
        <asp:PlaceHolder runat="server" ID="PlaceHolder1" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="Literal1" />
            </p>
        </asp:PlaceHolder>
        <h4 style="color: white;">Delivery form</h4>
        <hr />
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label" style="color: white;">First Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Name" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Name" CssClass="text-danger" ErrorMessage="This field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="lastName" CssClass="col-md-2 control-label" style="color: white;">Last Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="lastName" TextMode="SingleLine" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="lastName" CssClass="text-danger" ErrorMessage="This field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Address" CssClass="col-md-2 control-label" style="color: white;">Address</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Address" TextMode="SingleLine" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Address" CssClass="text-danger" ErrorMessage="This field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="postCode" CssClass="col-md-2 control-label" style="color: white;">Post Code</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="postCode" TextMode="SingleLine" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="postCode" CssClass="text-danger" ErrorMessage="This field is required." />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cardNumber" CssClass="col-md-2 control-label" style="color: white;">Credit Card</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="cardNumber" TextMode="SingleLine" CssClass="form-control" MaxLength="16" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="cardNumber" CssClass="text-danger" ErrorMessage="This field is required." />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ccv" CssClass="col-md-2 control-label" style="color: white;">CCV</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ccv" TextMode="SingleLine" CssClass="form-control" MaxLength="3" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ccv" CssClass="text-danger" ErrorMessage="This field is required." />
            </div>
        </div>
        <div class="col-md-offset-3 col-md-7" id="buyButton">
            <asp:Button ID="Buy" CssClass="btn btn-lg btn-success btn-block" runat="server" Text="Place Order" OnClick="Buy_Click"/>
        </div>
    </div>
</asp:Content>
