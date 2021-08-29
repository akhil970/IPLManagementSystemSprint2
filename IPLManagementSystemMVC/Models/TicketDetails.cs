using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPLManagementSystemMVC.Models
{
    public class TicketDetails
    {
        public int Id { get; set; }
        public string Match { get; set; }
        public string Ticket { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}