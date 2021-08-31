using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPLManagementSystemWEBAPI.Models
{
    public class TeamVenueScheduleddl
    {
        public List<Teamddl> Team { set; get; }
        public List<Scheduleddl> Schedule { set; get; }
        public List<Venueddl> Venue { set; get; }
    }
}