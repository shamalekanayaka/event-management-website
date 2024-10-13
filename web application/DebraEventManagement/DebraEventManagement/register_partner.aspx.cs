using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DebraEventManagement.PartnerServiceRef;

namespace DebraEventManagement
{
    public partial class register_partner : System.Web.UI.Page
    {
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string partnerName = txtPartnerName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            try
            {
                PartnerServicesSoapClient service = new PartnerServicesSoapClient();
                bool registrationSuccess = service.RegisterPartner(partnerName, email, password);

                if (registrationSuccess)
                {
                    // Set the session variable for the partner's email
                    Session["PartnerEmail"] = email;

                    // Redirect to the partner dashboard
                    Response.Redirect("partner_dashboard.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Registration failed. Please try again.');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('An error occurred: {ex.Message}');</script>");
            }
        }
    }
}