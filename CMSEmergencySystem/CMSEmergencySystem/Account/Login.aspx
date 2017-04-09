<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CMSEmergencySystem.Account.Login" %>

<html>
    <head runat="server">
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/sandstone.bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/sandstone.bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/custom.css" rel="stylesheet" type="text/css" />
        </head>
<script type="text/javascript">
        function validate() {
            if (document.getElementById("UserName").value == "" & document.getElementById("Password").value == "") {
                alert("Name Field and Password Field cannot be blank");
                document.getElementById("userName").focus();
                return false;
            }
            if (document.getElementById("UserName").value == "") {
                  alert("Name Field cannot be blank");
                  document.getElementById("UserName").focus();
                  return false;
              }
              else if (document.getElementById("Password").value == "") {
                  alert("Password Field cannot be blank");
                  document.getElementById("Password").focus();
                  return false;
              }
              else {
                  return true;
              }
         }
</script>
<body style="background-image:url(/Images/loginPage.jpg);background-size:cover">
    <form id="form1" runat="server" style="margin:0;">
        <div style="width:100%;height:100%;">
    <div style="display: inline-block;margin: auto;padding: 10px 20px;vertical-align: middle;text-align: center;background-color: #f8f5f0;position: fixed;top: 50%;left: 50%;margin-top: -150px;margin-left: -350px;opacity: 0.8;border-radius:4px;-moz-border-radius:4px;-webkit-border-radius:4px;">
        <h2>WELCOME TO CRISIS MANAGEMENT SYSTEM (CMS)</h2>
        <h3>ACCOUNT INFORMATION</h3>
    <p>Username: <asp:TextBox ID="UserName" runat="server"></asp:TextBox></p>

    <p>Password: <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox></p>

    <asp:Button CssClass="btn btn-primary" ID="LoginUser" runat="server" text="Login" OnClick="LoginUser_Click" OnClientClick="return validate();"/>
        <br /><asp:Label ID="displayError" runat="server"></asp:Label>
    </div>
            </div>
    </form>
</body>
</html>