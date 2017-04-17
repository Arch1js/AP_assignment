<%@ Page Title="Default" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Coffee_Shop.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Styles/default.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <!-- Image Background Page Header -->
    <!-- Note: The background image is set within the business-casual.css file. -->
    <div id="myCarousel" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators">
    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
    <li data-target="#myCarousel" data-slide-to="1"></li>
    <li data-target="#myCarousel" data-slide-to="2"></li>
  </ol>

  <!-- Wrapper for slides -->
  <div class="carousel-inner" role="listbox">
    <div class="item active">
      <img src='<%= this.picID1 %>' alt='<%= this.picAlt1 %>'/>
    </div>

    <div class="item">
      <img src='<%= this.picID2 %>' alt='<%= this.picAlt2 %>'/>
    </div>

<div class="item">
      <img src='<%= this.picID3 %>' alt='<%= this.picAlt3 %>'/>
    </div>
  </div>

  <!-- Left and right controls -->
  <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>

    <!-- Page Content -->
    <div class="container">

        <hr>
        <div class="row">
            <div class="col-sm-8">
                <h1>Largest coffee beans shop in existance!</h1>
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ornare convallis odio quis convallis. Etiam vitae commodo nunc. Aliquam non tristique tellus. Suspendisse posuere, nulla eu fermentum sagittis, est sapien interdum turpis, sit amet aliquam velit metus sit amet justo.</p>
                <p>Nam eget lectus lobortis tellus porta feugiat. Nulla vulputate id quam sit amet convallis. Suspendisse eu tortor a lacus venenatis imperdiet eu non purus. Pellentesque iaculis mi in risus vestibulum elementum. Sed diam magna, maximus eget tempus vel, sodales vitae odio. Aliquam egestas magna id velit lacinia feugiat. </p>
                <p>
                    <a class="btn btn-success btn-lg" href="/Users/Shop.aspx">Shop Now &raquo;</a>
                </p>
            </div>
            <div class="col-sm-4">
                <h2>Contact Us</h2>
                <address>
                    <strong>Console Coffee</strong>
                    <br>10 Coffee street
                    <br>PE1 1AA
                    <br>
                </address>
                <address>
                    <abbr title="Phone">P:</abbr>(123) 456-7890
                    <br>
                    <abbr title="Email">E:</abbr> <a href="mailto:#">a.dobrajs@gmail.com</a>
                </address>
            </div>
        </div>
        <!-- /.row -->

        <hr>

        <div class="row">
            <div class="col-sm-4">
                <img class="img-circle img-responsive img-center" src="https://images-na.ssl-images-amazon.com/images/I/615mmwpaPOL._SL1000_.jpg" alt="">
                <h2>Sumatra</h2>
                <p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui.</p>
            </div>
            <div class="col-sm-4">
                <img class="img-circle img-responsive img-center" src="https://images-eu.ssl-images-amazon.com/images/I/61mc0gmASuL._SL1000_.jpg" alt="">
                <h2>Lavazza</h2>
                <p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui.</p>
            </div>
            <div class="col-sm-4">
                <img class="img-circle img-responsive img-center" src="https://i5.walmartimages.com/asr/5a06faa2-00b0-44e8-8271-e9b63cf98abc_1.b5122b51d15c766313ae2ff5ffe3a121.jpeg" alt="">
                <h2>Eight O'Clock</h2>
                <p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui.</p>
            </div>
        </div>
        <!-- /.row -->

        <hr>

        <!-- Footer -->
        <footer>
            <div class="row">
                <div class="col-lg-12">
                    <p>Copyright &copy; >_Coffee 2017</p>
                </div>
            </div>
            <!-- /.row -->
        </footer>

    </div>
</asp:Content>
