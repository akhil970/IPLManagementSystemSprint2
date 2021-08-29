using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPLManagementSystemMVC.Models
{
    public class NewsDetails
    {
        public int Id { get; set; }
        public System.DateTime News_Date { get; set; }
        public string Match { get; set; }
        public string Description { get; set; }
    }
}