<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="new_store.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <link rel="icon" type="image/png" sizes="16x16" href="plugins/images/favicon.png"/>
    <title>Elite Admin Template - The Ultimate Multipurpose admin template</title>
    <!-- Bootstrap Core CSS -->
    <link href="plugins/bower_components/bootstrap-rtl-master/dist/css/bootstrap-rtl.min.css" rel="stylesheet"/>
    <!-- animation CSS -->
    <link href="css/animate.css" rel="stylesheet"/>
    <!-- Custom CSS -->
    <link href="css/style.css" rel="stylesheet"/>
    <!-- color CSS -->
    <link href="css/colors/blue.css" id="theme" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
     <!-- Preloader -->
    <div class="preloader">
        <div class="cssload-speeding-wheel"></div>
    </div>
    <section id="wrapper" class="login-register">
        <div class="login-box">
            <div class="white-box">
                <div class="form-horizontal form-material" id="loginform">
                    <h3 class="box-title m-b-20">Sign In</h3>
                    <div class="form-group ">
                        <div class="col-xs-12">
                            <asp:TextBox ID="txt_name" class="form-control"  tabindex="1" placeholder="Username" ClientIDMode="Static" runat="server"></asp:TextBox>
    	    
  	            <asp:RequiredFieldValidator ForeColor="Red"  ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txt_name"  ErrorMessage="*"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12">
                            <asp:TextBox ID="txt_pass" placeholder="Password" class="form-control"  tabindex="2" runat="server" 
                TextMode="Password"></asp:TextBox>

  	            <asp:RequiredFieldValidator ForeColor="Red"  ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txt_pass" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group text-center m-t-20">
                        <div class="col-xs-12">
                              <asp:Button ID="btn_login" class="btn btn-info btn-lg btn-block text-uppercase  waves-light" tabindex="3" runat="server" Text="Signin" onclick="LoginButton_Click" />
                        </div>
                    </div>
                    <div class="col-xs-12">
                         <asp:Label ID="lbl_result" style="color:red" runat="server"></asp:Label></div>
                </div>
                
            </div>
        </div>
    </section>
    <!-- jQuery -->
    <script src="plugins/bower_components/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="bootstrap/dist/js/tether.min.js"></script>
    <script src="bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="plugins/bower_components/bootstrap-rtl-master/dist/js/bootstrap-rtl.min.js"></script>
    <!-- Menu Plugin JavaScript -->
    <script src="plugins/bower_components/sidebar-nav/dist/sidebar-nav.min.js"></script>
    <!--slimscroll JavaScript -->
    <script src="js/jquery.slimscroll.js"></script>
    <!--Wave Effects -->
    <script src="js/waves.js"></script>
    <!-- Custom Theme JavaScript -->
    <script src="js/custom.min.js"></script>
    <!--Style Switcher -->
    <script src="plugins/bower_components/styleswitcher/jQuery.style.switcher.js"></script>
    </form>
</body>
</html>
