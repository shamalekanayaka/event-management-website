using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DebraEventManagement.PartnerServiceRef;


namespace DebraEventManagement
{
    public partial class create_event : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Ensure user is logged in
            if (!IsPostBack && Session["PartnerEmail"] == null)
            {
                Response.Redirect("login_partner.aspx");
            }
        }

        protected void btnCreateEvent_Click(object sender, EventArgs e)
        {
            string partnerEmail = Session["PartnerEmail"]?.ToString();
            string eventName = txtEventName.Text.Trim();
            string eventDescription = txtEventDescription.Text.Trim();
            string eventDate = txtEventDate.Text.Trim();
            string eventTime = txtEventTime.Text.Trim();
            string location = txtLocation.Text.Trim();
            string link = txtLink.Text.Trim(); // New field

            try
            {
                PartnerServicesSoapClient service = new PartnerServicesSoapClient();
                int partnerId = service.GetPartnerIdByEmail(partnerEmail);

                if (partnerId != -1)
                {
                    bool createEventSuccess = service.CreateEvent(partnerEmail, eventName, eventDescription, eventDate, eventTime, location, link); // Pass link to service method

                    if (createEventSuccess)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Event created successfully!');", true);
                        Response.Redirect("partner_dashboard.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Failed to create event. Please try again.');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Partner not found. Please login again.');", true);
                    Response.Redirect("login_partner.aspx");
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
            }
        }
    }
}
