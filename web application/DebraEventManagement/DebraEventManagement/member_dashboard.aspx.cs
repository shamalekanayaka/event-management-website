using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DebraEventManagement.MemberServiceRef;

namespace DebraEventManagement
{
    public partial class member_dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["MemberEmail"] != null)
                {
                    lblMemberEmail.Text = Session["MemberEmail"].ToString();
                    LoadEvents();
                    LoadTickets();
                }
                else
                {
                    Response.Redirect("login_member.aspx");
                }
            }
        }

        private void LoadTickets()
        {
            try
            {
                MemberServicesSoapClient service = new MemberServicesSoapClient();
                var tickets = service.GetAvailableTickets(); // Implement this method in service

                rptTickets.DataSource = tickets;
                rptTickets.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
            }
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnOrder = (Button)sender;
                int ticketId = int.Parse(btnOrder.CommandArgument);

                // Implement booking logic here using MemberServiceRef.MemberServicesSoapClient
                MemberServicesSoapClient service = new MemberServicesSoapClient();
                bool success = service.BookTicket(ticketId, Session["MemberEmail"].ToString());

                if (success)
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ticket booked successfully!');", true);
                    LoadTickets(); // Refresh ticket list after booking
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Failed to book ticket. Please try again.');", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
            }
        }

        private void LoadEvents()
        {
            try
            {
                MemberServicesSoapClient service = new MemberServicesSoapClient();
                var events = service.GetAvailableEvents();
                rptEvents.DataSource = events;
                rptEvents.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
            }
        }
    }
}