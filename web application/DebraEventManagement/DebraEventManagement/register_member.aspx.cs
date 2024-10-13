using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DebraEventManagement.MemberServiceRef;

namespace DebraEventManagement
{
    public partial class register_member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string memberName = txtMemberName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            try
            {
                MemberServicesSoapClient service = new MemberServicesSoapClient();
                bool success = service.RegisterMember(memberName, email, password);

                if (success)
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Registration successful!');", true);
                    Response.Redirect("login_member.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Registration failed. Please try again.');", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
            }
        }
    }
}