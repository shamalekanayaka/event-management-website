using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DebraEventManagement.PartnerServiceRef;

namespace DebraEventManagement
{
    public partial class login_partner : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            using (PartnerServiceRef.PartnerServicesSoapClient client = new PartnerServiceRef.PartnerServicesSoapClient())
            {
                bool isAuthenticated = client.LoginPartner(email, password);
                if (isAuthenticated)
                {
                    // Redirect to partner dashboard
                    Session["PartnerEmail"] = email;
                    Response.Redirect("partner_dashboard.aspx");
                }
                else
                {
                    // Show error message
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid email or password.');", true);
                }
            }
        }
    }
}