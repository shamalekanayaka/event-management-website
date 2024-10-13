using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DebraEventManagement.PartnerServiceRef;

namespace DebraEventManagement
{
    public partial class partner_dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["PartnerEmail"] == null)
                {
                    Response.Redirect("login_partner.aspx");
                }
                else
                {
                    string partnerEmail = Session["PartnerEmail"].ToString();
                    lblPartnerEmail.Text = partnerEmail;
                    LoadPartnerInfo(partnerEmail);
                }
            }
        }

        private void LoadPartnerInfo(string partnerEmail)
        {
            PartnerServicesSoapClient service = new PartnerServicesSoapClient();
            int partnerId = service.GetPartnerIdByEmail(partnerEmail);
            Session["PartnerId"] = partnerId;

            CalculateEarnings(partnerEmail);
            LoadEventSales(partnerId);
        }

        private void CalculateEarnings(string partnerEmail)
        {
            try
            {
                PartnerServicesSoapClient service = new PartnerServicesSoapClient();
                decimal earnings = service.CalculatePartnerEarnings(partnerEmail);
                lblEarnings.Text = $"Net Earnings: {earnings:C}";
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
            }
        }

        private void LoadEventSales(int partnerId)
        {
            try
            {
                PartnerServicesSoapClient service = new PartnerServicesSoapClient();
                var eventSales = service.GetPartnerTicketSales(partnerId);
                rptEventSales.DataSource = eventSales;
                rptEventSales.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
            }
        }

        protected void btnCreateEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("create_event.aspx");
        }

        protected void btnSetTicketDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("set_ticket_details.aspx");
        }
    }

    public class EventSales
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int TicketsSold { get; set; }
    }
}