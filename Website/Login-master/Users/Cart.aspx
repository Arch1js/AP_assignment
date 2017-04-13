<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Coffee_Shop.Users.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div style="margin-top: 5%"></div>
    <div class="col-md-5 col-md-offset-3">
        <h2 style="color: white;">My shopping cart</h2>
    <asp:GridView ID="gCart" CssClass="table table-hover" runat="server" GridLines="None" AutoGenerateColumns="False" EmptyDataText="There is nothing in your shopping cart." Width="100%" CellPadding="5" ShowFooter="true" DataSourceID="SqlDataSource1" BackColor="White" OnSelectedIndexChanged = "OnSelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="productID" HeaderText="ID" SortExpression="productID" HeaderStyle-BackColor=" #2196f3"/>
            <asp:BoundField DataField="product" HeaderText="Product" SortExpression="product" HeaderStyle-BackColor=" #2196f3"/>
            <asp:TemplateField HeaderText="Quantity" HeaderStyle-BackColor=" #2196f3">
                <ItemTemplate>
                    <asp:TextBox runat="server" ID="txtQuantity" Columns="5" Text='<%# Eval("quantity") %>' AutoPostBack="True" OnTextChanged="txtQuantity_TextChanged"></asp:TextBox><br />
                    <asp:LinkButton runat="server" ID="btnRemove" Text="Remove" CommandName="Select" style="font-size:12px;"></asp:LinkButton>
 
                </ItemTemplate>
            </asp:TemplateField>     
            <asp:BoundField DataField="price" HeaderText="Price" SortExpression="price" HeaderStyle-BackColor=" #2196f3" DataFormatString="{0:C}" /> 
            <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" HeaderStyle-BackColor=" #2196f3" DataFormatString="{0:C}"/>             
        </Columns> 
    </asp:GridView>
         <br />
            <asp:LinkButton runat="server" CssClass="btn btn-success" ID="btnCheckout" Style="float: right;" PostBackUrl="~/Users/Checkout.aspx"><i class="fa fa-shopping-cart" aria-hidden="true"></i> Checkout</asp:LinkButton>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [productID], [product], [quantity],[price], SUM(quantity*price) as total FROM Cart WHERE userID = @userID GROUP BY productID, quantity, product, price"></asp:SqlDataSource>
     </div>
</asp:Content>
