﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPLManagementSystemMVC.Models
{
    public class CustomerTicketBooking
    {
        public List<CustomerMatchesddl> MatchesDDL { set; get; }
        public List<CustomerTicketsddl> TicketsDDL { set; get; }
    }
}
