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
    /// Summary description for PartnerServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PartnerServices : System.Web.Services.WebService
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;

        [WebMethod]
        public bool RegisterPartner(string partnerName, string email, string password)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string query = "INSERT INTO Partners (PartnerName, Email, Password) VALUES (@PartnerName, @Email, @Password)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@PartnerName", partnerName);
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
                throw new ApplicationException("Error registering partner.", ex);
            }
        }

        [WebMethod]
        public bool LoginPartner(string email, string password)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(1) FROM Partners WHERE Email = @Email AND Password = @Password";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count == 1;
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new ApplicationException("Error logging in partner.", ex);
            }
        }

        [WebMethod]
        public bool CreateEvent(string partnerEmail, string eventName, string eventDescription, string eventDate, string eventTime, string location, string link)
        {
            try
            {
                // First, retrieve partner ID based on email
                int partnerId = GetPartnerIdByEmail(partnerEmail);

                if (partnerId != -1)
                {
                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        string query = "INSERT INTO events (PartnerId, EventName, EventDescription, EventDate, EventTime, Location, Link) " +
                                       "VALUES (@PartnerId, @EventName, @EventDescription, @EventDate, @EventTime, @Location, @Link)";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@PartnerId", partnerId);
                        cmd.Parameters.AddWithValue("@EventName", eventName);
                        cmd.Parameters.AddWithValue("@EventDescription", eventDescription);
                        cmd.Parameters.AddWithValue("@EventDate", eventDate);
                        cmd.Parameters.AddWithValue("@EventTime", eventTime);
                        cmd.Parameters.AddWithValue("@Location", location);
                        cmd.Parameters.AddWithValue("@Link", link); // Add parameter for Link

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                else
                {
                    throw new ApplicationException("Partner not found.");
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new ApplicationException("Error creating event.", ex);
            }
        }

        [WebMethod]
        public bool CreateEventAdmin(string eventName, string eventDescription, string eventDate, string eventTime, string location, string link)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string query = "INSERT INTO events (PartnerId, EventName, EventDescription, EventDate, EventTime, Location, Link) " +
                                   "VALUES (@PartnerId, @EventName, @EventDescription, @EventDate, @EventTime, @Location, @Link)";
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    // Hardcoded PartnerId value
                    cmd.Parameters.AddWithValue("@PartnerId", 13);

                    // Other parameters
                    cmd.Parameters.AddWithValue("@EventName", eventName);
                    cmd.Parameters.AddWithValue("@EventDescription", eventDescription);
                    cmd.Parameters.AddWithValue("@EventDate", eventDate);
                    cmd.Parameters.AddWithValue("@EventTime", eventTime);
                    cmd.Parameters.AddWithValue("@Location", location);
                    cmd.Parameters.AddWithValue("@Link", link); // Add parameter for Link

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new ApplicationException("Error creating event.", ex);
            }
        }






        [WebMethod]
        public bool SetTicketDetails(int eventId, string ticketName, decimal price, int quantity)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string query = "INSERT INTO Tickets (EventId, TicketName, Price, Quantity, CommissionRate) " +
                                   "VALUES (@EventId, @TicketName, @Price, @Quantity, @CommissionRate)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@EventId", eventId);
                    cmd.Parameters.AddWithValue("@TicketName", ticketName); // New parameter for TicketName
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);

                    // Calculate commission rate based on quantity
                    decimal commissionRate = 0;
                    if (quantity < 200)
                        commissionRate = 0.15m;
                    else if (quantity < 300)
                        commissionRate = 0.20m;
                    else
                        commissionRate = 0.10m;
                    cmd.Parameters.AddWithValue("@CommissionRate", commissionRate);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error setting ticket details.", ex);
            }
        }



        [WebMethod]
        public decimal CalculatePartnerEarnings(string partnerEmail)
        {
            try
            {
                int partnerId = GetPartnerIdByEmail(partnerEmail);
                if (partnerId == -1) throw new ApplicationException("Partner not found.");

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string query = @"
                SELECT t.Price, t.Sold, t.Quantity,
                       CASE
                           WHEN t.Quantity < 200 THEN 0.15
                           WHEN t.Quantity < 300 THEN 0.2
                           ELSE 0.1
                       END AS CommissionRate
                FROM Tickets t
                INNER JOIN Events e ON t.EventId = e.EventId
                WHERE e.PartnerId = @PartnerId";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@PartnerId", partnerId);

                    con.Open();
                    decimal totalEarnings = 0;
                    decimal totalCommission = 0;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            decimal price = reader.GetDecimal("Price");
                            int sold = reader.GetInt32("Sold");
                            decimal commissionRate = reader.GetDecimal("CommissionRate");

                            decimal earnings = price * sold;
                            decimal commission = earnings * commissionRate;

                            totalEarnings += earnings;
                            totalCommission += commission;
                        }
                    }

                    decimal netEarnings = totalEarnings - totalCommission;
                    return netEarnings;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error calculating earnings.", ex);
            }
        }





        [WebMethod]
        public List<Event> GetEventsByPartnerId(int partnerId)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string query = "SELECT EventId, EventName FROM events WHERE PartnerId = @PartnerId";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@PartnerId", partnerId);
                    con.Open();

                    List<Event> events = new List<Event>();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Event ev = new Event
                            {
                                EventId = reader.GetInt32("EventId"),
                                EventName = reader.GetString("EventName")
                            };
                            events.Add(ev);
                        }
                    }
                    return events;
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new ApplicationException("Error retrieving events.", ex);
            }
        }

        [WebMethod]
        public List<EventSales> GetPartnerTicketSales(int partnerId)
        {
            List<EventSales> eventSalesList = new List<EventSales>();

            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string query = @"SELECT e.EventId, e.EventName, SUM(t.Sold) AS TicketsSold
                             FROM events e
                             JOIN tickets t ON e.EventId = t.EventId
                             WHERE e.PartnerId = @PartnerId
                             GROUP BY e.EventId, e.EventName";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@PartnerId", partnerId);

                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EventSales eventSales = new EventSales
                            {
                                EventId = Convert.ToInt32(reader["EventId"]),
                                EventName = reader["EventName"].ToString(),
                                TicketsSold = Convert.ToInt32(reader["TicketsSold"])
                            };
                            eventSalesList.Add(eventSales);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error retrieving ticket sales data.", ex);
            }

            return eventSalesList;
        }

        public class EventSales
        {
            public int EventId { get; set; }
            public string EventName { get; set; }
            public int TicketsSold { get; set; }
        }



        [WebMethod]
        // Helper method to get Partner ID by Email
        public int GetPartnerIdByEmail(string email)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string query = "SELECT PartnerId FROM Partners WHERE Email = @Email";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Email", email);

                    con.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new ApplicationException("Error retrieving partner ID by email.", ex);
            }
        }
    }
}