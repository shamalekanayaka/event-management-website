using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DebraEventManagement
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string TicketName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; internal set; }
    }
}