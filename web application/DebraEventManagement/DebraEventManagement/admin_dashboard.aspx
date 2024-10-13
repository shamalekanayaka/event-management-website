<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_dashboard.aspx.cs" Inherits="DebraEventManagement.admin_dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
    <link rel="stylesheet" href="styles.css" /> 
     <link rel="shortcut icon" href="stuff/DEBRA LOGO.png" type="image/x-icon">
</head>
<body>
    <form id="form1" runat="server">
        <h1>Admin Dashboard</h1>

              <div class="eventcontainer2">
            <h3>Total Sales and Commission</h3>
            <asp:Label ID="lblTotalSales" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblTotalCommission" runat="server" Text=""></asp:Label>
        </div>
        <div class="eventcontainer">
            <div class="events-container">
                <h2>Events</h2>
                <asp:Repeater ID="rptEvents" runat="server" OnItemCommand="rptEvents_ItemCommand">
                    <ItemTemplate>
                        <div class="dashboard-card">
                            <h3><%# Eval("EventName") %></h3>
                         
                            <asp:Button ID="btnDeleteEvent" runat="server" CommandName="DeleteEvent" CommandArgument='<%# Eval("EventID") %>' Text="Delete Event" CssClass="btn-delete" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            </div>

            <div class="eventcontainer">
                <h2>Partners</h2>
                <asp:Repeater ID="rptPartners" runat="server" OnItemCommand="rptPartners_ItemCommand">
                    <ItemTemplate>
                        <div class="dashboard-card">
                            <h3><%# Eval("PartnerName") %></h3>
                            <p><strong>Email:</strong> <%# Eval("Email") %></p>
                            <asp:Button ID="btnDeletePartner" runat="server" CommandName="DeletePartner" CommandArgument='<%# Eval("PartnerID") %>' Text="Delete Partner" CssClass="btn-delete" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

        

  
       


         <div class="eventcontainer">
            <h2>Ticket Sales</h2>
            <asp:Repeater ID="rptTicketSales" runat="server">
                <ItemTemplate>
                    <div class="dashboard-card">
                        <p><strong>Ticket ID:</strong> <%# Eval("TicketID") %></p>
                        <p><strong>Event:</strong> <%# Eval("EventName") %></p>
                        <p><strong>Price:</strong> <%# Eval("Price", "{0:C}") %></p>
                        <p><strong>Sold:</strong> <%# Eval("Sold") %></p>
                        <p><strong>Total Sale:</strong> <%# Eval("TotalSale", "{0:C}") %></p>
                        <p><strong>Admin Earnings:</strong> <%# Eval("AdminEarnings", "{0:C}") %></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
       </div>

    </form>
</body>
</html>
