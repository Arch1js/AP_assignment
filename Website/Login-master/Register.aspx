<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Coffee_Shop.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="/Styles/Register.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="registerModal" class="modal fade">
      <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header" style="background-color: #424242">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <img width="100px" height="40px" alt="Brand" src="../Asets/logo.svg" /><!-- Logo -->
            </div>
          <div class="modal-body">
              <p id="notifyText" runat="server">You are now registered!</p>              
          </div>
          <div class="modal-footer">
               <asp:Button type="button" ID="btnOK" runat="server" class="btn btn-primary" Text="Proceed to Shop?" CausesValidation="False" OnClick="btnOK_Click"/>              
          </div>
        </div>
      </div>
    </div>
   <script>
    $("#registerModal").on("show", function () {    // wire up the OK button to dismiss the modal when shown
        $("#registerModal a.btn").on("click", function (e) {
            $("#registerModal").modal('hide');     // dismiss the dialog
        });
    });
    $("#registerModal").on("hide", function () {    // remove the event listeners when the dialog is dismissed
        $("#myModal a.btn").off("click");
    });
    
    $("#registerModal").on("hidden", function () {  // remove the actual elements from the DOM when fully hidden
        $("#myModal").remove();
    });

    function openResetModal(parameters) {
        $("#registerModal").modal({                    // wire up the actual modal functionality and show the dialog
            "backdrop"  : "static",
            "keyboard"  : true,
            "show"      : true                     // ensure the modal is shown immediately
        });
    }
   </script>
     <div class="col-md-6" ></div>
    <div class="col-md-12">
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
    </div>
    <div class="form-horizontal col-md-offset-4 col-md-4 margin" style="background-color: rgba(34, 34, 34, .7); border-radius: 8px">
        <h4 style="color: white">Create a new account</h4>
         <hr/>
         <asp:PlaceHolder runat="server" ID="statusMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="MessageText" />
                        </p>
                    </asp:PlaceHolder>
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label" style="color: white;">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label" style="color: white;">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label" style="color: white;">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="secQuestion" CssClass="col-md-2 control-label" style="color: white;">Security Question</asp:Label>
            <div class="col-md-10">
              <asp:DropDownList ID="secQuestion" CssClass="form-control selectpicker" runat="server">
                 <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem>Name of your first pet?</asp:ListItem>
                <asp:ListItem>Favourite book?</asp:ListItem>
                <asp:ListItem>Something else?</asp:ListItem>   
            </asp:DropDownList>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="secQuestion" InitialValue="--Select--"
              CssClass="text-danger" Display="Dynamic" ErrorMessage="The security question field is required." />
            </div>         
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="secAnswer" CssClass="col-md-2 control-label" style="color: white;">Security question answer</asp:Label>
              <div class="col-md-10">
                <asp:TextBox runat="server" ID="secAnswer" TextMode="SingleLine" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="secAnswer"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The security question answer field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="Register" CssClass="btn btn-success" ID="btnRegister" OnClick="btnRegister_Click" style="float: right"/>
            </div>
        </div>
    </div>
</asp:Content>
