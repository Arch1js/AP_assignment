<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="Coffee_Shop.Users.Shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Styles/shop.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top: 5%"></div>
    <div id="emailModal" class="modal fade"><%--email notification modal--%>
      <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header" style="background-color: #424242">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <img width="100px" height="40px" alt="Brand" src="../Asets/logo.svg" /><!-- Logo -->
            </div>
          <div class="modal-body">
              <p>We will notify you when this product is back in stock!</p>              
          </div>
          <div class="modal-footer">
               <asp:Button type="button" ID="btnOK" runat="server" class="btn btn-primary" Text="OK" data-dismiss="modal" CausesValidation="False" />              
          </div>
        </div>
      </div>
    </div>
     <div id="cartModal" class="modal fade"><%--added to cart modal--%>
      <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header" style="background-color: #424242">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <img width="100px" height="40px" alt="Brand" src="../Asets/logo.svg" /><!-- Logo -->
            </div>
          <div class="modal-body">
              <p>Product is added to your basket!</p>              
          </div>
          <div class="modal-footer">
               <asp:Button type="button" ID="btnOK2" runat="server" class="btn btn-primary" Text="OK" data-dismiss="modal" CausesValidation="False" />             
          </div>
        </div>
      </div>
    </div>
<script>
    $("#emailModal").on("show", function () {
        $("#emailModal a.btn").on("click", function (e) {
            $("#emailModal").modal('hide'); 
        });
    });
    $("#emailModal").on("hide", function () { 
        $("#myModal a.btn").off("click");
    });
    
    $("#emailModal").on("hidden", function () {  
        $("#myModal").remove();
    });

    function openEmailModal(parameters) {
        $("#emailModal").modal({                   
            "backdrop"  : "static",
            "keyboard"  : true,
            "show"      : true                     
        });
    }

    $("#cartModal").on("show", function () {   
        $("#cartModal a.btn").on("click", function (e) {
            $("#emailModal").modal('hide');    
        });
    });
    $("#cartModal").on("hide", function () { 
        $("#myModal a.btn").off("click");
    });

    $("#cartModal").on("hidden", function () {  
        $("#myModal").remove();
    });

    function openCartModal(parameters) {
        $("#cartModal").modal({          
            "backdrop": "static",
            "keyboard": true,
            "show": true           
        });
    }
</script>
    <div class="form-inline" style="margin-bottom: 5px">
    <asp:Panel runat="server" DefaultButton="btnSearch">
      <div class="col-md-offset-4  col col-md-3 input-group">
         <input type="text" id="searchText" runat="server" class="form-control" placeholder="Search by name, origin, grind or strenght" aria-describedby="basic-addon2"/>
         <span class="input-group-addon" id="basic-addon2"><i class="fa fa-search" aria-hidden="true"></i></span>      
      </div>
      <asp:LinkButton runat="server" CssClass="btn btn-success" ID="btnSearch" onclick="searchValue" CausesValidation="False"><i class="fa fa-search" aria-hidden="true"></i> Search</asp:LinkButton>
      <div class="col col-md-4 input-group">
        <div class="col-md-2">
            <asp:Label AssociatedControlID="sortBy" runat="server" Text="Sort By:" style="color: #e84d4d"/>
        </div>
        <div class="col-md-2">
            <asp:DropDownList ID="sortBy" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="sortBy_SelectedIndexChanged">
                <asp:ListItem Enabled="False" Selected="True"></asp:ListItem>
                <asp:ListItem>Origin</asp:ListItem>
                <asp:ListItem>Strength</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-2">
          <asp:Button runat="server" ID="btn_Advanced" CssClass="btn btn-info" text="Advanced" OnClick="btn_Advanced_Click"/> 
        </div>
       </div>
    </asp:Panel>
        <div class="col-md-offset-4 col-md-5" ID="advanced_panel" visible="false" runat="server" style="margin-top: 5px; margin-bottom: 5px;">
            <asp:DropDownList ID="advancedDropdown" runat="server" CssClass="form-control">
                <asp:ListItem Enabled="False" Selected="True"></asp:ListItem>
                <asp:ListItem>Price</asp:ListItem>
                <asp:ListItem>Strength</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtFrom" ></asp:TextBox>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtTo" ></asp:TextBox>
            <asp:Button runat="server" CssClass="btn btn-success" Text="Sort" ID="advancedSearch" OnClick="advancedSearch_Click"/>
        </div>   
    </div>
    <div class="container col-md-offset-2 col-md-8"> 
    <div class="" style="background-color: whitesmoke;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Timer ID="Timer1" runat="server" Interval="10000" OnTick="Timer1_Tick">
                </asp:Timer>               
        <asp:DataList ID="dlProducts" runat="server" BorderColor="Black" CellSpacing="20" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" RepeatColumns="6" OnItemCommand="dlProducts_ItemCommand" OnItemDataBound="dlProducts_OnItemDataBound" RepeatDirection="Horizontal">           
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle" />     
            <ItemTemplate>
            <div id="productContainer" style="background-color: white;">
            <div id="productImage">
            <asp:Image ID="imgImage" runat="server" ToolTip='<%# Eval("Name") %>' ImageUrl='<%# Eval("Picture","Shop.aspx?FileName={0}") %>' Height="156px" Width="174px"></asp:Image>
            </div>
            <div style="padding: 10px">
                <br />
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' Font-Size="X-Large" />
                <br />  
                <asp:Label ID="ProductID" runat="server" Visible="false" Text='<%# Eval("Id") %>' />                    
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
                <b>In Stock:</b>
                <asp:Label ID="lblStock" runat="server" Text='<%# Eval("Stock") %>' />
                <br />
                <b>Price:</b>
                <asp:Label ID="PriceLabel" runat="server" Value='<%# Eval("Price") %>' Text='<%# string.Format("{0:C}", Eval("Price"))%>'/>
                <br />
                <b>Description:</b>
                <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                <br />
                 <asp:LinkButton runat="server" CssClass="btn btn-info" style="margin: 10px" ID="btnCart" CausesValidation="False" OnCommand="btnAdd_OnClick" CommandArgument="cart"><i class="fa fa-shopping-cart" aria-hidden="true"></i> Add To Cart</asp:LinkButton>
                 <asp:LinkButton runat="server" CssClass="btn btn-warning" style="margin: 10px" ID="btnNotify"  CausesValidation="False" Visible="False" OnCommand="btnNotify_OnClick" CommandArgument="email"><i class="fa fa-envelope-o" aria-hidden="true"></i> Notify Me</asp:LinkButton>
            </div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            <footerstyle backcolor="Red" />
            <div Visible='<%#bool.Parse((dlProducts.Items.Count==0).ToString())%>' runat="server" class="alert alert-danger">
                <strong>Ooops!</strong> We didn't find anything with this search term. Please try again!.
            </div>
        </FooterTemplate> 
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ></asp:SqlDataSource>
    </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>
    </div>  
   </div>
    <div class="col-md-5" style="float: right">
     <div class="col-md-2" Style="margin: 20px 0;">
      <asp:Label ID="lblPageInfo" runat="server" ForeColor="White"></asp:Label>
     </div>
     <div class="col-md-6">
         <ul class="pagination">
          <li><asp:LinkButton ID="lbtnFirst" runat="server" CausesValidation="false" OnClick="lbtnFirst_Click">First</asp:LinkButton></li>
          <li><asp:LinkButton ID="lbtnPrevious" runat="server" CausesValidation="false" OnClick="lbtnPrevious_Click">Previous</asp:LinkButton></li>
          <li><asp:DataList ID="dlPaging" runat="server" RepeatDirection="Horizontal" OnItemCommand="dlPaging_ItemCommand" OnItemDataBound="dlPaging_ItemDataBound" RepeatLayout="Flow">
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
</asp:Content>
