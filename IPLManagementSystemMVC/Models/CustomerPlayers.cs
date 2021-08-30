using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPLManagementSystemMVC.Models
{
    public class CustomerPlayers
    {
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public string PlayerRole { get; set; }
        public string Photo { get; set; }
    }
}