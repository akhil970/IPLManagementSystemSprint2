using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPLManagementSystemMVC.Models
{
    public class News
    {
        [Required(ErrorMessage = "Enter News ID")]
        [Range(1, int.MaxValue, ErrorMessage = "Enter Proper News ID")]
        public int Id { get; set; }
        public System.DateTime News_Date { get; set; }
        public Nullable<int> MatchId { get; set; }
        public string Description { get; set; }

        public virtual Match Match { get; set; }
    }
}