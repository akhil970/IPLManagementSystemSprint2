using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPLManagementSystemMVC.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public Nullable<int> MatchId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<decimal> Price { get; set; }

        public virtual Match Match { get; set; }
        public virtual TicketCategory TicketCategory { get; set; }
    }
}