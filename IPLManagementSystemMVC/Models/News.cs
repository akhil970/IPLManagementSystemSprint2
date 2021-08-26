using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPLManagementSystemMVC.Models
{
    public class News
    {
        public int Id { get; set; }
        public System.DateTime News_Date { get; set; }
        public Nullable<int> MatchId { get; set; }
        public string Description { get; set; }

        public virtual Match Match { get; set; }
    }
}