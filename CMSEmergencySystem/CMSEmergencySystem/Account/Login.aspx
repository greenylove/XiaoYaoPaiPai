<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CMSEmergencySystem.Account.Login" %>

<html>

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
<body>
    <form id="form1" runat="server">
    <div>
        <h2>WELCOME TO CRISIS MANAGEMENT SYSTEM (CMS)</h2>
        <h3> Account Information</h3>
    Username : 
        <asp:TextBox ID="UserName" runat="server"></asp:TextBox> <br />

    Password :
        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox> <br />

    <asp:Button ID="LoginUser" runat="server" text="Login" OnClick="LoginUser_Click" OnClientClick="return validate();"/>
        <br /><asp:Label ID="displayError" runat="server"></asp:Label>


    </div>
    </form>
</body>
</html>