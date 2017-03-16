<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="Coffee_Shop.Members" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top: 5%"></div>
 <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped" GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Name], [Strength], [Grind], [Origin], [Available_Quantity], [Picture], [Description] FROM [Coffee]"></asp:SqlDataSource>
</asp:Content>
