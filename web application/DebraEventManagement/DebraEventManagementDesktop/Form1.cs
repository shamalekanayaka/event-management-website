using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DebraEventManagementDesktop.MemberServiceRefDesktop;
using DebraEventManagementDesktop.AdminServiceRefDesktop;

namespace DebraEventManagementDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadEventData();
            LoadLogoImage();
            LoadEarnings();
        }

        private void LoadEventData()
        {
            try
            {
                MemberServicesSoapClient client = new MemberServicesSoapClient();
                var serviceEvents = client.GetAvailableEvents();

                List<EventData> events = serviceEvents.Select(e => new EventData
                {
                    EventName = e.EventName,
                    Description = e.Description,
                    EventDate = e.EventDate,
                    EventTime = e.EventTime,
                    Location = e.Location,
                
                }).ToList();

                dataGridViewEvents.DataSource = events;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching event data: " + ex.Message);
            }
        }

        private void LoadEarnings()
        {
            try
            {
                AdminServicesSoapClient client = new AdminServicesSoapClient();
                decimal totalCommission = client.GetTotalCommission();
                labelEarnings.Text = $"Earnings: {totalCommission:C}"; // Format as currency
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching earnings: " + ex.Message);
            }
        }


        private void LoadLogoImage()
        {
            pictureBoxLogo.Image = Properties.Resources.withname; // Replace with your image name
          //  pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage; // Adjust the size mode as needed
        }

        private void dataGridViewEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addevent_Click(object sender, EventArgs e)
        {
            // Create an instance of the createevent form
            createevent createEventForm = new createevent();

            // Show the createevent form
            createEventForm.ShowDialog(); // Use Show() if you want modeless form
        }

        private void addpartner_Click(object sender, EventArgs e)
        {
            try
            {
                // Create an instance of RegisterPartnerForm
                RegisterPartnerForm registerPartnerForm = new RegisterPartnerForm();

                // Show RegisterPartnerForm as a modal dialog
                registerPartnerForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void addpartner_Click_1(object sender, EventArgs e)
        {
            RegisterPartnerForm registerPartnerForm = new RegisterPartnerForm();
            registerPartnerForm.ShowDialog(); // Show as a modal dialog
        }
    }
}
