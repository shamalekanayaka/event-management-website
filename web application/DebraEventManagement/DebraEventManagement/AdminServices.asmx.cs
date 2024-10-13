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

    public class EventInfo
    {
        public int EventID { get; set; }
        public int PartnerID { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventDate { get; set; }
        public string EventTime { get; set; }
        public string Location { get; set; }
    }

    /// <summary>
    /// Summary description for AdminServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AdminServices : System.Web.Services.WebService
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;

        [WebMethod]
        public List<EventInfo> GetAllEvents()
        {
            List<EventInfo> events = new List<EventInfo>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM events";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EventInfo ev = new EventInfo
                    {
                        EventID = reader.GetInt32("EventID"),
                        PartnerID = reader.GetInt32("PartnerID"),
                        EventName = reader.GetString("EventName"),
                        EventDescription = reader.GetString("EventDescription"),
                        EventDate = reader.GetString("EventDate"),
                        EventTime = reader.GetString("EventTime"),
                        Location = reader.GetString("Location")
                    };
                    events.Add(ev);
                }
            }
            return events;
        }

        [WebMethod]
        public bool DeleteTicketsForEvent(int eventID)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Step 1: Delete bookings associated with tickets of the event
                    string deleteBookingsQuery = "DELETE FROM bookings WHERE TicketId IN (SELECT TicketID FROM tickets WHERE EventID = @eventID)";
                    MySqlCommand deleteBookingsCommand = new MySqlCommand(deleteBookingsQuery, connection);
                    deleteBookingsCommand.Parameters.AddWithValue("@eventID", eventID);
                    deleteBookingsCommand.ExecuteNonQuery();

                    // Step 2: Delete tickets for the given eventID
                    string deleteTicketsQuery = "DELETE FROM tickets WHERE EventID = @eventID";
                    MySqlCommand deleteTicketsCommand = new MySqlCommand(deleteTicketsQuery, connection);
                    deleteTicketsCommand.Parameters.AddWithValue("@eventID", eventID);

                    int rowsAffected = deleteTicketsCommand.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Handle exceptions as needed
                    throw new Exception("Failed to delete tickets for event.", ex);
                }
            }
        }

        [WebMethod]
        public List<Partner> GetAllPartners()
        {
            List<Partner> partners = new List<Partner>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT PartnerID, PartnerName, Email FROM partners";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Partner partner = new Partner();
                            partner.PartnerID = Convert.ToInt32(reader["PartnerID"]);
                            partner.PartnerName = reader["PartnerName"].ToString();
                            partner.Email = reader["Email"].ToString();

                            partners.Add(partner);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions as needed
                    throw new Exception("Failed to retrieve partners.", ex);
                }
            }

            return partners;
        }

        public class Partner
        {
            public int PartnerID { get; set; }
            public string PartnerName { get; set; }
            public string Email { get; set; }
        }

        [WebMethod]
        public bool DeletePartner(int partnerID)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Step 1: Delete tickets associated with the events of the partner
                    string deleteTicketsQuery = "DELETE FROM tickets WHERE EventID IN (SELECT EventID FROM events WHERE PartnerID = @partnerID)";
                    MySqlCommand deleteTicketsCommand = new MySqlCommand(deleteTicketsQuery, connection);
                    deleteTicketsCommand.Parameters.AddWithValue("@partnerID", partnerID);
                    deleteTicketsCommand.ExecuteNonQuery();

                    // Step 2: Delete events associated with the partner
                    string deleteEventsQuery = "DELETE FROM events WHERE PartnerID = @partnerID";
                    MySqlCommand deleteEventsCommand = new MySqlCommand(deleteEventsQuery, connection);
                    deleteEventsCommand.Parameters.AddWithValue("@partnerID", partnerID);
                    deleteEventsCommand.ExecuteNonQuery();

                    // Step 3: Delete the partner
                    string deletePartnerQuery = "DELETE FROM partners WHERE PartnerID = @partnerID";
                    MySqlCommand deletePartnerCommand = new MySqlCommand(deletePartnerQuery, connection);
                    deletePartnerCommand.Parameters.AddWithValue("@partnerID", partnerID);

                    int rowsAffected = deletePartnerCommand.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Handle exceptions as needed
                    throw new Exception("Failed to delete partner.", ex);
                }
            }
        }



        [WebMethod]
        public decimal GetTotalSales()
        {
            decimal totalSales = 0;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT SUM(Price * Sold) AS TotalSales FROM tickets";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        totalSales = Convert.ToDecimal(result);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to retrieve total sales.", ex);
                }
            }
            return totalSales;
        }

        [WebMethod]
        public decimal GetTotalCommission()
        {
            decimal totalCommission = 0;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT SUM((Price * CommissionRate) * Sold) AS TotalCommission FROM tickets";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        totalCommission = Convert.ToDecimal(result);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to retrieve total commission.", ex);
                }
            }
            return totalCommission;
        }

        [WebMethod]
        public List<TicketSaleInfo> GetTicketSales()
        {
            List<TicketSaleInfo> ticketSales = new List<TicketSaleInfo>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT t.TicketID, e.EventName, t.Price, t.Sold, (t.Price * t.Sold) AS TotalSale, ((t.Price * t.CommissionRate) * t.Sold) AS AdminEarnings " +
                               "FROM tickets t " +
                               "JOIN events e ON t.EventID = e.EventID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                try
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TicketSaleInfo saleInfo = new TicketSaleInfo
                            {
                                TicketID = reader.GetInt32("TicketID"),
                                EventName = reader.GetString("EventName"),
                                Price = reader.GetDecimal("Price"),
                                Sold = reader.GetInt32("Sold"),
                                TotalSale = reader.GetDecimal("TotalSale"),
                                AdminEarnings = reader.GetDecimal("AdminEarnings")
                            };
                            ticketSales.Add(saleInfo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to retrieve ticket sales information.", ex);
                }
            }
            return ticketSales;
        }

        // Helper class to store ticket sale information
        public class TicketSaleInfo
        {
            public int TicketID { get; set; }
            public string EventName { get; set; }
            public decimal Price { get; set; }
            public int Sold { get; set; }
            public decimal TotalSale { get; set; }
            public decimal AdminEarnings { get; set; }
        }



        [WebMethod]
        public bool DeleteEvent(int eventID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM events WHERE EventID = @EventID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EventID", eventID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }

}
