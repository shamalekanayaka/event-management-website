using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DebraEventManagement.MemberServiceRef;

namespace DebraEventManagement
{
    public partial class login_member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            try
            {
                MemberServicesSoapClient service = new MemberServicesSoapClient();
                bool success = service.LoginMember(email, password);

                if (success)
                {
                    Session["MemberEmail"] = email;
                    Response.Redirect("member_dashboard.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Login failed. Please try again.');", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
            }
        }
    }
}