using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPLManagementSystemWEBAPI.Models
{
    public class CusstomerTicketsMatches
    {
        public List<CustomerSelectMatches> CustomerMatches { set; get; }
        public List<CustomerSelectTickets> CustomerTickets { set; get; }
    }
}