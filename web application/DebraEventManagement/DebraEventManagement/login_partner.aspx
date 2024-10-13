<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login_partner.aspx.cs" Inherits="DebraEventManagement.login_partner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Partner Login</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
    <link rel="shortcut icon" href="stuff/DEBRA LOGO.png" type="image/x-icon">
</head>
<body>
     <img src="resources/LOGO%20with%20name.png" / class="formimg">
    <form id="form1" runat="server">
        
        <div class="eventcontainer">
            <h2>Partner Login</h2>
           
            <div class="form-group">
                <label for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtPassword">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" />
            </div>
        </div>
          
    </form>
</body>
</html>
