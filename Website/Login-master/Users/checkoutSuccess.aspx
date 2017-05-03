<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="checkoutSuccess.aspx.cs" Inherits="Coffee_Shop.Users.checkoutSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Styles/checkoutSuccess.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container">
    <div class="jumbotron">
      <h1>Success!</h1>
      <p>Your order is placed!</p>
      <p><asp:Button ID="Back" CssClass="btn btn-success btn-lg" runat="server" Text="Back To Shop" OnClick="Back_Click"/></p>
    </div>
   </div>
</asp:Content>
