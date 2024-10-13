using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace DebraEventManagement
{

    
    /// <summary>
    /// Summary description for MemberServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. C:\Users\Lenovo T460\Desktop\fiiiiiinaaal debraaa\WIP\DebraEventManagement\DebraEventManagement\App_Data\
    // [System.Web.Script.Services.ScriptService]
    public class MemberServices : System.Web.Services.WebService
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;

        [WebMethod]
        public bool RegisterMember(string memberName, string email, string password)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string query = "INSERT INTO Members (MemberName, Email, Password) VALUES (@MemberName, @Email, @Password)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@MemberName", memberName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new ApplicationException("Error registering member.", ex);
            }
        }

        [WebMethod]
        public List<Ticket> GetAvailableTickets()
        {
            List<Ticket> tickets = new List<Ticket>();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = "SELECT TicketId, TicketName, Price, Quantity FROM Tickets";
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ticket ticket = new Ticket
                        {
                            TicketId = Convert.ToInt32(reader["TicketId"]),
                            TicketName = reader["TicketName"].ToString(),
                            Price = Convert.ToDecimal(reader["Price"]),
                            Quantity = Convert.ToInt32(reader["Quantity"]) // Fetch Quantity
                        };
                        tickets.Add(ticket);
                    }
                }
            }

            return tickets;
        }


        [WebMethod]
        public bool BookTicket(int ticketId, string memberEmail)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    // Get the TicketName and Quantity from the tickets table
                    string getTicketInfoQuery = "SELECT TicketName, Quantity FROM tickets WHERE TicketId = @TicketId";
                    MySqlCommand getTicketInfoCmd = new MySqlCommand(getTicketInfoQuery, con);
                    getTicketInfoCmd.Parameters.AddWithValue("@TicketId", ticketId);

                    using (MySqlDataReader reader = getTicketInfoCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string ticketName = reader["TicketName"].ToString();
                            int quantity = Convert.ToInt32(reader["Quantity"]);

                            if (quantity > 0) // Ensure there are available tickets
                            {
                                // Close the reader before executing the next command
                                reader.Close();

                                // Insert booking details into the bookings table
                                string insertQuery = "INSERT INTO bookings (TicketId, MemberEmail, TicketName) VALUES (@TicketId, @MemberEmail, @TicketName)";
                                MySqlCommand insertCmd = new MySqlCommand(insertQuery, con);
                                insertCmd.Parameters.AddWithValue("@TicketId", ticketId);
                                insertCmd.Parameters.AddWithValue("@MemberEmail", memberEmail);
                                insertCmd.Parameters.AddWithValue("@TicketName", ticketName);
                                insertCmd.ExecuteNonQuery();

                                // Update the 'Sold' and 'Quantity' fields in the tickets table
                                string updateQuery = "UPDATE tickets SET Sold = Sold + 1, Quantity = Quantity - 1 WHERE TicketId = @TicketId";
                                MySqlCommand updateCmd = new MySqlCommand(updateQuery, con);
                                updateCmd.Parameters.AddWithValue("@TicketId", ticketId);
                                updateCmd.ExecuteNonQuery();

                                return true;
                            }
                            else
                            {
                                throw new ApplicationException("No available tickets left for this event.");
                            }
                        }
                        else
                        {
                            throw new ApplicationException("Ticket not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error booking ticket.", ex);
            }

            return false;
        }




        [WebMethod]
        public List<EventData> GetAvailableEvents()
        {
            List<EventData> events = new List<EventData>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT EventName, EventDescription, EventDate, EventTime, Location, Link FROM Events";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    events.Add(new EventData
                    {
                        EventName = reader["EventName"].ToString(),
                        Description = reader["EventDescription"].ToString(),
                        EventDate = reader["EventDate"].ToString(),
                        EventTime = reader["EventTime"].ToString(),
                        Location = reader["Location"].ToString(),
                        Link = reader["Link"].ToString() // Ensure to map the Link field
                    });
                }
            }
            return events;
        }




        [WebMethod]
        public bool LoginMember(string email, string password)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM Members WHERE Email = @Email AND Password = @Password";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    int userCount = Convert.ToInt32(cmd.ExecuteScalar());
                    return userCount > 0;
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new ApplicationException("Error logging in member.", ex);
            }
        }
    }
}

public class EventData
{
    public string EventName { get; set; }
    public string Description { get; set; }
    public string EventDate { get; set; }
    public string EventTime { get; set; }
    public string Location { get; set; }
    public string Link { get; set; }
}