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
    public partial class createevent : Form
    {
        public createevent()
        {
            InitializeComponent();
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string eventName = textBoxEventName.Text;
                string eventDescription = textBoxEventDescription.Text;
                string eventDate = textBoxEventDate.Text;
                string eventTime = textBoxEventTime.Text;
                string location = textBoxLocation.Text;
                string link = textBoxLink.Text;

                PartnerServiceRefDesktop.PartnerServicesSoapClient client = new PartnerServiceRefDesktop.PartnerServicesSoapClient();
                bool result = client.CreateEventAdmin(eventName, eventDescription, eventDate, eventTime, location, link);

                if (result)
                {
                    MessageBox.Show("Event created successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to create event.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }



    }
}
