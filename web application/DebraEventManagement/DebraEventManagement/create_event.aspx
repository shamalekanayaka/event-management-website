<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create_event.aspx.cs" Inherits="DebraEventManagement.create_event" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Event</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
    <link rel="shortcut icon" href="stuff/DEBRA LOGO.png" type="image/x-icon">
</head>
<body>
    <form id="form1" runat="server">
        <div class="eventcontainer">
            <h2>Create Event</h2>
            <div class="form-group">
                <label for="txtEventName">Event Name:</label>
                <asp:TextBox ID="txtEventName" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtEventDescription">Event Description:</label>
                <asp:TextBox ID="txtEventDescription" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtEventDate">Event Date:</label>
                <asp:TextBox ID="txtEventDate" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtEventTime">Event Time:</label>
                <asp:TextBox ID="txtEventTime" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtLocation">Location:</label>
                <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtLink">Link:</label>
                <asp:TextBox ID="txtLink" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnCreateEvent" runat="server" Text="Create Event" CssClass="btn" OnClick="btnCreateEvent_Click" />
            </div>
        </div>
    </form>
</body>
</html>