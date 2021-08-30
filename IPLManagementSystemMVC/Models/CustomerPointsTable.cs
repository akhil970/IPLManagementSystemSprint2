using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPLManagementSystemMVC.Models
{
    public class CustomerPointsTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Played { get; set; }
        public int Won { get; set; }
        public int Lost { get; set; }
        public int Tied { get; set; }
        public int NoResult { get; set; }
        public Nullable<int> Points { get; set; }
        public decimal NRR { get; set; }
    }
}