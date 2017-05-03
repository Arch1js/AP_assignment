<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="Coffee_Shop.Users.PasswordReset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Styles/passwordReset.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="resetModal" class="modal fade"><%--reset success modal window--%>
      <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header" style="background-color: #424242">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <img width="100px" height="40px" alt="Brand" src="../Asets/logo.svg" /><!-- Logo -->
            </div>
          <div class="modal-body">
              <p id="notifyText" runat="server"></p>              
          </div>
          <div class="modal-footer">
               <asp:Button type="button" ID="btnOK" runat="server" class="btn btn-primary" Text="OK" data-dismiss="modal" CausesValidation="False" />              
          </div>
        </div>
      </div>
    </div>
    <script>
    $("#resetModal").on("show", function () { 
        $("#resetModal a.btn").on("click", function (e) {
            console.log("button pressed");  
            $("#resetModal").modal('hide');   
        });
    });
    $("#resetModal").on("hide", function () {   
        $("#myModal a.btn").off("click");
    });
    
    $("#resetModal").on("hidden", function () { 
        $("#myModal").remove();
    });

    function openResetModal(parameters) {
        $("#resetModal").modal({              
            "backdrop"  : "static",
            "keyboard"  : true,
            "show"      : true           
        });
    }
   </script>
    <div class="form-horizontal col-md-offset-4 col-md-4 margin" style="background-color: rgba(34, 34, 34, .7); border-radius: 8px">
        <h4 style="color: white">Reset password</h4>
         <hr/>
         <asp:PlaceHolder runat="server" ID="statusMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="MessageText" />
            </p>
        </asp:PlaceHolder>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label" ForeColor="White">Email</asp:Label>
                <div class="col-md-10">
                   <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                   <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="The email field is required." />
               </div>         
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="secAnswer" CssClass="col-md-2 control-label" ForeColor="White">Security Answer</asp:Label>
              <div class="col-md-10">
                <asp:TextBox runat="server" ID="secAnswer" TextMode="SingleLine" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="secAnswer" CssClass="text-danger" Display="Dynamic" ErrorMessage="The security question answer field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label" ForeColor="White">New Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label" ForeColor="White">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="Reset Password" CssClass="btn btn-success" ID="btnReset" OnClick="btnReset_Click" style="float: right"/>
            </div>
        </div>
     </div>
</asp:Content>
