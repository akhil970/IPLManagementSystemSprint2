using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPLManagementSystemWEBAPI.Models
{
    public class Scheduleddl
    {
        public int Id { get; set; }
        public Nullable<int> MatchId { get; set; }
        public Nullable<int> VenueId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> Start_Time { get; set; }
        public Nullable<System.TimeSpan> End_Time { get; set; }
    }
}