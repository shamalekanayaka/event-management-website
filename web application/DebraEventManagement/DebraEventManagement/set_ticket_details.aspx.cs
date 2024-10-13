using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DebraEventManagement.PartnerServiceRef;


namespace DebraEventManagement
{
    public partial class set_ticket_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Ensure user is logged in
            if (!IsPostBack && Session["PartnerEmail"] == null)
            {
                Response.Redirect("login_partner.aspx");
            }

            if (!IsPostBack)
            {
                LoadEvents();
            }
        }

        private void LoadEvents()
        {
            try
            {
                string partnerEmail = Session["PartnerEmail"]?.ToString();
                PartnerServicesSoapClient service = new PartnerServicesSoapClient();
                int partnerId = service.GetPartnerIdByEmail(partnerEmail);

                if (partnerId != -1)
                {
                    var events = service.GetEventsByPartnerId(partnerId);

                    ddlEvents.DataSource = events;
                    ddlEvents.DataTextField = "EventName";
                    ddlEvents.DataValueField = "EventId";
                    ddlEvents.DataBind();

                    ddlEvents.Items.Insert(0, new ListItem("--Select Event--", "0"));
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

        protected void btnSetTicketDetails_Click(object sender, EventArgs e)
        {
            int eventId = int.Parse(ddlEvents.SelectedValue);
            string ticketName = txtTicketName.Text.Trim();
            decimal price = decimal.Parse(txtPrice.Text.Trim());
            int quantity = int.Parse(txtQuantity.Text.Trim());

            try
            {
                PartnerServicesSoapClient service = new PartnerServicesSoapClient();
                bool success = service.SetTicketDetails(eventId, ticketName, price, quantity);

                if (success)
                {
                    string partnerEmail = Session["PartnerEmail"].ToString();
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Ticket details set successfully!'); window.location='partner_dashboard.aspx';", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Failed to set ticket details. Please try again.');", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
            }
        }
    }
}