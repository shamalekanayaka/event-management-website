<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="member_dashboard.aspx.cs" Inherits="DebraEventManagement.member_dashboard" %>

<!DOCTYPE html>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member Dashboard</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
     <link rel="shortcut icon" href="stuff/DEBRA LOGO.png" type="image/x-icon">
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
</head>
<body>

    <nav class="navbar">
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
         <h2 class="welcome">Welcome, <asp:Label ID="lblMemberEmail" runat="server" Text=""></asp:Label></h2>
      
       <div class="eventcontainer">
    <h1>EVENTS</h1>
    <div class="events-section">
        <asp:Repeater ID="rptEvents" runat="server">
            <ItemTemplate>
                <div class="membercard">
                    <div class="event-image">
                        <img src='<%# Eval("Link") %>' alt='<%# Eval("EventName") %>' />
                    </div>
                    <div class="event-details">
                        <h3><%# Eval("EventName") %></h3>
                        <p><%# Eval("Description") %></p>
                        <div class="event-info">
                            <span>Date: <%# Eval("EventDate") %></span><br />
                            <span>Time: <%# Eval("EventTime") %></span><br />
                            <span>Location: <%# Eval("Location") %></span>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>




      <div class="eventcontainer">
    <h1>TICKETS</h1>
    <div class="tickets-section">
        <asp:Repeater ID="rptTickets" runat="server">
            <ItemTemplate>
                <div class="ticket-card">
                    <h3 class="ticket-title"><%# Eval("TicketName") %></h3>
                    <p class="ticket-price">Price: <%# Eval("Price", "{0:C}") %></p>
                    <div class="ticket-footer">
                        <span class="tickets-left">Tickets Left: <%# Eval("Quantity") %></span>
                        <asp:Button ID="btnOrder" runat="server" Text="Order Now" CssClass="btn-order" OnClick="btnOrder_Click" CommandArgument='<%# Eval("TicketId") %>' />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>


 <footer>
        <div class="footer-content">
            <div class="social-media">
                <a href="#"><i class="fab fa-facebook-f"></i><i class="fab fa-twitter"></i><i class="fab fa-instagram"></i><i class="fab fa-linkedin-in"></i></a>
            </div>
            <div class="footer-buttons">
                <button class="footer-btn">Contact Us</button>
                <button class="footer-btn">Privacy Policy</button>
            </div>
        </div>
        <div class="footer-bottom">
            <p>&copy; 2024 Starshi. All rights reserved.</p>
        </div>
    </footer>



        
    </form>
            </ul>
    </nav>

    <nav class="navbar">
        <a href="your-link-here.html" class="navbar-logo">
            &nbsp;</a></nav>

    <div class="area" >
    </div >

   

      

</body>
</html>
