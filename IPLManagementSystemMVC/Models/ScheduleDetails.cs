using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPLManagementSystemMVC.Models
{
    public class ScheduleDetails
    {
        public int Match_Id { get; set; }
        public string Team_One { get; set; }
        public string Team_Two { get; set; }
        public string Venue { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> Start_Time { get; set; }
        public Nullable<System.TimeSpan> End_Time { get; set; }
    }
}