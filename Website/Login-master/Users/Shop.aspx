<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="Coffee_Shop.Members" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Styles/shop.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top: 5%"></div>
    <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />
    <div class="form-group">
    <div class=" col col-md-6 input-group">
      <input type="text" class="form-control" placeholder="Search for coffee" aria-describedby="basic-addon2"/>
      <span class="input-group-addon" id="basic-addon2"><i class="fa fa-search" aria-hidden="true"></i></span>      
    </div>
        <div class="col-md-2">
    <asp:LinkButton ID="btnSearch" runat="server" CausesValidation="False" Text="Search" CssClass="btn btn-success" OnClick="search"><i class="fa fa-search" aria-hidden="true"></i> Search</asp:LinkButton>  
    </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick">
                </asp:Timer>
            
        <asp:DataList ID="dlProducts" runat="server" BorderColor="Black" CellSpacing="20" DataSourceID="SqlDataSource1" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" RepeatColumns="6">           
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle" />     
            <ItemTemplate>
            <div id="productContainer" style="background-color: white;">
            <div id="productImage">
            <asp:Image ID="imgImage" runat="server" ToolTip="ASP Image Control" ImageUrl='<%# Eval("Picture","Shop.aspx?FileName={0}") %>' Height="156px" Width="174px"></asp:Image>
            </div>
            <br />
            Name:
            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            <br />
            Strength:
            <asp:Label ID="StrengthLabel" runat="server" Text='<%# Eval("Strength") %>' />
            <br />
            Grind:
            <asp:Label ID="GrindLabel" runat="server" Text='<%# Eval("Grind") %>' />
            <br />
            Origin:
            <asp:Label ID="OriginLabel" runat="server" Text='<%# Eval("Origin") %>' />
            <br />
            Available:
            <asp:Label ID="Available_QuantityLabel" runat="server" Text='<%# Eval("Available_Quantity") %>' />
            <br />
            Description:
            <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
            <br />
            </div>
        </ItemTemplate>       
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Name], [Strength], [Grind], [Origin], [Available_Quantity], [Picture], [Description] FROM [Coffee]"></asp:SqlDataSource>
    </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>
    
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
