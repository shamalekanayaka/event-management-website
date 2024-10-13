using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DebraEventManagement.AdminServiceRef;


namespace DebraEventManagement
{
    public partial class admin_dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEvents();
                LoadPartners();
                LoadSalesInfo();
            }
        }

        private void LoadEvents()
        {
            try
            {
                AdminServicesSoapClient service = new AdminServicesSoapClient();
                var events = service.GetAllEvents();

                rptEvents.DataSource = events;
                rptEvents.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
            }
        }

        protected void LoadSalesInfo()
        {
            try
            {
                AdminServicesSoapClient service = new AdminServicesSoapClient();

                // Retrieve total sales and total commission from the web service
                decimal totalSales = service.GetTotalSales();
                decimal totalCommission = service.GetTotalCommission();

                // Display total sales and total commission on the UI
                lblTotalSales.Text = $"Total Sales: {totalSales:C}";
                lblTotalCommission.Text = $"Total Commission: {totalCommission:C}";

                // Retrieve ticket sales information
                var ticketSales = service.GetTicketSales();

                // Bind ticket sales data to repeater
                rptTicketSales.DataSource = ticketSales;
                rptTicketSales.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
            }
        }

        private void LoadPartners()
        {
            try
            {
                AdminServicesSoapClient service = new AdminServicesSoapClient();
                var partners = service.GetAllPartners();

                rptPartners.DataSource = partners;
                rptPartners.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
            }
        }

        protected void rptEvents_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DeleteEvent")
            {
                try
                {
                    int eventID = Convert.ToInt32(e.CommandArgument);
                    AdminServicesSoapClient service = new AdminServicesSoapClient();
                    bool success = service.DeleteEvent(eventID);

                    if (success)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Event deleted successfully');", true);
                        LoadEvents(); // Refresh event list after deletion
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Failed to delete event. Please try again.');", true);
                    }
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
                }
            }
        }

        protected void rptPartners_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DeletePartner")
            {
                try
                {
                    int partnerID = Convert.ToInt32(e.CommandArgument);
                    AdminServicesSoapClient service = new AdminServicesSoapClient();
                    bool success = service.DeletePartner(partnerID);

                    if (success)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Partner deleted successfully');", true);
                        LoadPartners(); // Refresh partner list after deletion
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Failed to delete partner. Please try again.');", true);
                    }
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
                }
            }
        }
    }
}