<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="set_ticket_details.aspx.cs" Inherits="DebraEventManagement.set_ticket_details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Set Ticket Details</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
    <link rel="shortcut icon" href="stuff/DEBRA LOGO.png" type="image/x-icon">
</head>
<body>
    <form id="form1" runat="server">
        <div class="eventcontainer">
            <h2>Set Ticket Details</h2>
            <div class="form-group">
                <label for="ddlEvents">Select Event:</label>
                <asp:DropDownList ID="ddlEvents" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtTicketName">Ticket Name:</label>
                <asp:TextBox ID="txtTicketName" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtPrice">Ticket Price:</label>
                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtQuantity">Ticket Quantity:</label>
                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnSetTicketDetails" runat="server" Text="Set Ticket Details" CssClass="btn" OnClick="btnSetTicketDetails_Click" />
            </div>
        </div>
    </form>
</body>
</html>
