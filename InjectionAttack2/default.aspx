<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="InjectionAttack2._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title></title>

    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrapcss">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <link href="Scripts/Login.css"

</head>
<body>
    <form id="form1" runat="server">


<script type="text/javascript">
    function onTxtKeyUp() {
        document.getElementById("lblSelect").innerText = "SELECT * FROM Users WHERE UserName='" + document.getElementById("txtUsername").value + "' AND Password='" + document.getElementById("txtPassword").value + "';";


//                    txtUsername.Text + "' " +
//                    "AND Password='" + txtPassword.Text + "'";
//            __doPostBack("<%=txtUsername.UniqueID %>", "");
        }

    </script>


                
        <div>


<section class="login-block">
    <div class="container">
	<div class="row">
		<div class="col-md-4 login-sec">
		    <h2 class="text-center">
                
                Customer Login</h2>
		    <form class="login-form">
  <div class="form-group">
    <label for="txtUsername" class="text-uppercase">Username</label>
    <asp:TextBox ID="txtUsername" runat="server" class="form-control" ControlID="txtUsername" onkeyup="onTxtKeyUp();"></asp:TextBox>    
  </div>
  <div class="form-group">
    <label for="txtPassword" class="text-uppercase">Password</label>
    <asp:TextBox ID="txtPassword" runat="server" class="form-control" TextMode="Password" onkeyup="onTxtKeyUp();"></asp:TextBox>
  </div>
  
  
    <div class="form-check">
    <label class="form-check-label">
      <input type="checkbox" class="form-check-input">
      <small>Remember Me</small>
    </label>

        <asp:Button ID="cmdLogin" runat="server" Text="Login" class="btn btn-login float-right" OnClick="cmdLoginSanitized_Click" />
    <br /><asp:Label ID="lblError" runat="server" Text="" Visible="false" CssClass="text-danger"></asp:Label>

        <br />
        <br />
        <p ID="lblSelect" CssClass="text-primary"></p>


  </div>
  
</form>
		</div>
		<div class="col-md-8 banner-sec">
            <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                 <ol class="carousel-indicators">
                    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                  </ol>
            <div class="carousel-inner" role="listbox">
    <div class="carousel-item active">
      <img class="d-block img-fluid" src="https://static.pexels.com/photos/33972/pexels-photo.jpg" alt="First slide">
      <div class="carousel-caption d-none d-md-block">
        <div class="banner-text">
        </div>	
  </div>
    </div>
    <div class="carousel-item">
      <img class="d-block img-fluid" src="https://images.pexels.com/photos/7097/people-coffee-tea-meeting.jpg" alt="First slide">
      <div class="carousel-caption d-none d-md-block">
        <div class="banner-text">
        </div>	
    </div>
    </div>
    <div class="carousel-item">
      <img class="d-block img-fluid" src="https://images.pexels.com/photos/872957/pexels-photo-872957.jpeg" alt="First slide">
      <div class="carousel-caption d-none d-md-block">
        <div class="banner-text">
        </div>	
    </div>
  </div>
            </div>	   
		    
		</div>
	</div>
</div>
</section>                                        


                                        
                            

        </div>

    </form>
</body>
</html>
