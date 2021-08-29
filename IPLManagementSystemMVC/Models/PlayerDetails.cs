using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPLManagementSystemMVC.Models
{
    public class PlayerDetails
    {
        public int ID { get; set; }
        public string Team_Name { get; set; }
        public string Player_Name { get; set; }
        public Nullable<int> Age { get; set; }
        public string Description { get; set; }
        public Nullable<int> PhotoId { get; set; }
    }
}