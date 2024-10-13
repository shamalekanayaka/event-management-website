using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebraEventManagementDesktop
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            LoadLogoImage();
        }

        private void LoadLogoImage()
        {
            pictureBox1.Image = Properties.Resources.withname; // Replace with your image name
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Adjust the size mode as needed
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string useremail = email.Text.Trim();
                string userpassword = password.Text.Trim();

                // Check if credentials are correct
                if (useremail == "admin@debra.com" && userpassword == "admin@debra")
                {
                    // Navigate to Form1.cs
                    Form1 form1 = new Form1();
                    this.Hide(); // Hide the current form
                    form1.ShowDialog(); // Show Form1 as a modal dialog
                    this.Close(); // Close the current form after Form1 is closed
                }
                else
                {
                    MessageBox.Show("Incorrect credentials. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
