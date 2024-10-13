using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DebraEventManagementDesktop.PartnerServiceRefDesktop;

namespace DebraEventManagementDesktop
{
    public partial class RegisterPartnerForm : Form
    {

        private void regBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string partnerName = partnerNameTextBox.Text;
                string email = emailTextBox.Text;
                string password = passwordTextBox.Text;

                PartnerServicesSoapClient client = new PartnerServicesSoapClient();
                bool registrationSuccessful = client.RegisterPartner(partnerName, email, password);

                if (registrationSuccessful)
                {
                    MessageBox.Show("Partner registered successfully!");
                    // Optionally, clear input fields or close the form
                    // ClearInputFields();
                    // Close();
                }
                else
                {
                    MessageBox.Show("Failed to register partner.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
