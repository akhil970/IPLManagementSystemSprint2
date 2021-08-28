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

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter News Date")]
        public System.DateTime News_Date { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Enter Proper Match ID")]
        [Required(ErrorMessage = "Enter Match ID")]
        public Nullable<int> MatchId { get; set; }

        [DataType(DataType.Text, ErrorMessage = "Enter Proper Description")]
        [Required(ErrorMessage = "Enter Match Status")]
        [Display(Name = "Match Status")]
        public string Description { get; set; }

        public virtual Match Match { get; set; }
    }
}