﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="Coffee_Shop.Users.Shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Styles/shop.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top: 5%"></div>
    <div class="form-inline">
    <div class="col-md-offset-4  col col-md-2 input-group">
      <input type="text" id="searchText" runat="server" class="form-control" placeholder="Search for coffee" aria-describedby="basic-addon2" onkeypress="searchValue"/>
      <span class="input-group-addon" id="basic-addon2"><i class="fa fa-search" aria-hidden="true"></i></span>      
    </div>
        <asp:Label ID="myTempLabel" runat="server" Text="Label"></asp:Label>
        <asp:LinkButton runat="server" CssClass="btn btn-success" ID="btnSearch" onclick="searchValue" CausesValidation="False"><i class="fa fa-search" aria-hidden="true"></i> Search</asp:LinkButton>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick">
                </asp:Timer>            
        <asp:DataList ID="dlProducts" runat="server" BorderColor="Black" CellSpacing="20" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" RepeatColumns="6" BackColor="#696969" OnItemCommand="dlProducts_ItemCommand">           
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle" />     
            <ItemTemplate>
            <div id="productContainer" style="background-color: white;">
            <div id="productImage">
            <asp:Image ID="imgImage" runat="server" ToolTip="ASP Image Control" ImageUrl='<%# Eval("Picture","Shop.aspx?FileName={0}") %>' Height="156px" Width="174px"></asp:Image>
            </div>
            <div style="padding: 10px">
                <br />
                <b>Name:</b>
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                <br />
                <b>Strength:</b>
                <asp:Label ID="StrengthLabel" runat="server" Text='<%# Eval("Strength") %>' />
                <br />
                <b>Grind:</b>
                <asp:Label ID="GrindLabel" runat="server" Text='<%# Eval("Grind") %>' />
                <br />
                <b>Origin:</b>
                <asp:Label ID="OriginLabel" runat="server" Text='<%# Eval("Origin") %>' />
                <br />
                <b>Available:</b>
                <asp:Label ID="Available_QuantityLabel" runat="server" Text='<%# Eval("Available_Quantity") %>' />
                <br />
                <b>Description:</b>
                <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                <br />
                 <asp:LinkButton runat="server" CssClass="btn btn-info" ID="btnCart" CausesValidation="False" ><i class="fa fa-shopping-cart" aria-hidden="true"></i> Add To Cart</asp:LinkButton>
            </div>
            </div>
        </ItemTemplate> 
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Name], [Strength], [Grind], [Origin], [Available_Quantity], [Picture], [Description] FROM [Coffee]"></asp:SqlDataSource>
    </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>
    <div class="col-md-offset-4 col-md-8">
     <div class="col-md-2">
      <asp:Label ID="lblPageInfo" runat="server" ForeColor="White"></asp:Label>
     </div>
     <div class="col-md-4">
         <ul class="pagination">
          <li><asp:LinkButton ID="lbtnFirst" runat="server" CausesValidation="false" OnClick="lbtnFirst_Click">First</asp:LinkButton></li>
          <li><asp:LinkButton ID="lbtnPrevious" runat="server" CausesValidation="false" OnClick="lbtnPrevious_Click">Previous</asp:LinkButton></li>
          <li><asp:DataList ID="dlPaging" runat="server" RepeatDirection="Horizontal" OnItemCommand="dlPaging_ItemCommand"
                                OnItemDataBound="dlPaging_ItemDataBound" RepeatLayout="Flow">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnPaging" runat="server" CommandArgument='<%# Eval("PageIndex") %>'
                                        CommandName="Paging" Text='<%# Eval("PageText") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:DataList></li>
          <li><asp:LinkButton ID="lbtnNext" runat="server" CausesValidation="false" OnClick="lbtnNext_Click">Next</asp:LinkButton></li>
          <li><asp:LinkButton ID="lbtnLast" runat="server" CausesValidation="false" OnClick="lbtnLast_Click">Last</asp:LinkButton></li>
          <li></li>
         </ul>
     </div>
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
