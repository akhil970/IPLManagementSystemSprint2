using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPLManagementSystemMVC.Models
{
    public class Ticket
    {
        [Range(1, int.MaxValue, ErrorMessage = "Enter Proper Ticket ID")]
        [Required(ErrorMessage = "Enter Ticket ID")]
        [Display(Name = "Ticket ID")]
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Enter Proper Match ID")]
        [Required(ErrorMessage = "Enter Match ID")]
        public Nullable<int> MatchId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Enter Proper Ticket Category ID")]
        [Required(ErrorMessage = "Enter Ticket Category ID")]
        [Display(Name = "Ticket Category ID")]
        public Nullable<int> CategoryId { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Enter Proper Ticket Price")]
        [Required(ErrorMessage = "Enter Ticket Price")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> Price { get; set; }
    }
}