<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Coffee_Shop.Users.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div style="margin-top: 5%"></div>
    <div class="col-md-5">
    <asp:GridView ID="gCart" CssClass="table table-hover" runat="server" GridLines="None" AutoGenerateColumns="False" EmptyDataText="There is nothing in your shopping cart." Width="100%" CellPadding="5" ShowFooter="true" DataSourceID="SqlDataSource1" BackColor="White">
        <Columns>
            <asp:BoundField DataField="productID" HeaderText="ID" SortExpression="productID" HeaderStyle-BackColor=" #2196f3"/>
            <asp:BoundField DataField="product" HeaderText="Product" SortExpression="product" HeaderStyle-BackColor=" #2196f3"/>
            <asp:TemplateField HeaderText="Quantity" HeaderStyle-BackColor=" #2196f3">
                <ItemTemplate>
                    <asp:TextBox runat="server" ID="txtQuantity" Columns="5" OnTextChanged="txtQuantity_TextChanged" Text='<%# Eval("quantity") %>' AutoPostBack="True"></asp:TextBox><br />
                    <%--<asp:LinkButton runat="server" ID="btnRemove" Text="Remove" CommandName="Remove" CommandArgument='<%# Eval("ProductId") %>' style="font-size:12px;"></asp:LinkButton>--%>
 
                </ItemTemplate>
            </asp:TemplateField>     
            <asp:BoundField DataField="price" HeaderText="Price" SortExpression="price" HeaderStyle-BackColor=" #2196f3"/> 
            <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" HeaderStyle-BackColor=" #2196f3"/>             
        </Columns> 
    </asp:GridView>
         <br />
            <asp:Button runat="server" CssClass="btn btn-success" ID="btnCheckout" Text="Checkout"/>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [productID], [product], COUNT(quantity) as quantity, [price], [total] FROM Cart WHERE userID = @userID GROUP BY productID, quantity, product, price, total"></asp:SqlDataSource>
     </div>
        <%-- <table cellpadding="0" border="0" >
                        <tr>
                            <td align="right">
                                <asp:LinkButton ID="lbtnFirst" runat="server" CausesValidation="false" OnClick="lbtnFirst_Click">First</asp:LinkButton>
                                &nbsp;</td>
                            <td align="right">
                                <asp:LinkButton ID="lbtnPrevious" runat="server" CausesValidation="false" OnClick="lbtnPrevious_Click">Previous</asp:LinkButton>&nbsp;&nbsp;</td>
                            <td align="center" valign="middle">
                                <asp:DataList ID="dlPaging" runat="server" RepeatDirection="Horizontal" OnItemCommand="dlPaging_ItemCommand"
                                    OnItemDataBound="dlPaging_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnPaging" runat="server" CommandArgument='<%# Eval("PageIndex") %>'
                                            CommandName="Paging" Text='<%# Eval("PageText") %>'></asp:LinkButton>&nbsp;
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;<asp:LinkButton ID="lbtnNext" runat="server" CausesValidation="false"
                                    OnClick="lbtnNext_Click">Next</asp:LinkButton></td>
                            <td align="left">
                                &nbsp;
                                <asp:LinkButton ID="lbtnLast" runat="server" CausesValidation="false" OnClick="lbtnLast_Click">Last</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td colspan="5" align="center" style="height: 30px" valign="middle">
                                <asp:Label ID="lblPageInfo" runat="server"></asp:Label></td>
                        </tr>
                    </table>--%>
<%-- <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped" GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Strength" HeaderText="Strength" SortExpression="Strength" />
            <asp:BoundField DataField="Grind" HeaderText="Grind" SortExpression="Grind" />
            <asp:BoundField DataField="Origin" HeaderText="Origin" SortExpression="Origin" />
            <asp:BoundField DataField="Available_Quantity" HeaderText="Available_Quantity" SortExpression="Available_Quantity" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="Name" HeaderText="Image Name" />
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="imgImage" runat="server" ToolTip="ASP Image Control" ImageUrl='<%# Eval("Picture","Shop.aspx?FileName={0}") %>'
                            Height="156px" Width="174px"></asp:Image>
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select" CssClass="btn btn-success"><i class="fa fa-shopping-cart" aria-hidden="true"></i> Buy</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Name], [Strength], [Grind], [Origin], [Available_Quantity], [Picture], [Description] FROM [Coffee]"></asp:SqlDataSource>--%>
</asp:Content>
