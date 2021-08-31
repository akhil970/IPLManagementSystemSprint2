using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPLManagementSystemWEBAPI.Models
{
    public class Teamddl
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Home_Ground { get; set; }
        public string Franchise_Owners { get; set; }
        public string Logo_Image { get; set; }
    }
}