<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="partner_dashboard.aspx.cs" Inherits="DebraEventManagement.partner_dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Partner Dashboard</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
    <link rel="shortcut icon" href="stuff/DEBRA LOGO.png" type="image/x-icon">
</head>
<body>

     <div class="area" >
            <ul class="circles">
                    <li></li>
                    <li></li>
                    <li></li>
                    <li></li>
                    <li></li>
                    <li></li>
                    <li></li>
                    <li></li>
                    <li></li>
                    <li></li>

    <form id="form1" runat="server">
      &nbsp
            <h2>Welcome, <asp:Label ID="lblPartnerEmail" runat="server" Text=""></asp:Label></h2>

          <div class="eventcontainer">
           <div class="form-group button-group">
            <asp:Button ID="btnCreateEvent" runat="server" Text="Create Event" CssClass="btn" OnClick="btnCreateEvent_Click" />
        </div>
        <div class="form-group button-group">
            <asp:Button ID="btnSetTicketDetails" runat="server" Text="Set Ticket Details" CssClass="btn" OnClick="btnSetTicketDetails_Click" />
        </div>
           
        </div>

         <div class="eventcontainer">
            <h2>Event Ticket Sales</h2>
              <div class="form-group">
                <h2 class="earnings"><asp:Label ID="lblEarnings" runat="server" Text=""></asp:Label></h2>
            </div>
            <div class="events-section">
                <asp:Repeater ID="rptEventSales" runat="server">
                    <ItemTemplate>
                        <div class="dashboard-card">
                            <h3><%# Eval("EventName") %></h3>
                            <p>Tickets Sold: <%# Eval("TicketsSold") %></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>


    </form>

                </ul>
         </div>
</body>
</html>