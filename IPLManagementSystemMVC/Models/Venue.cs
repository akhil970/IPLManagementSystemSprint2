using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPLManagementSystemMVC.Models
{
    public class Venue
    {
        [Range(1, int.MaxValue, ErrorMessage = "Enter Proper Venue ID")]
        [Required(ErrorMessage = "Enter Venue ID")]
        public int Id { get; set; }

        [DataType(DataType.Text, ErrorMessage = "Enter Proper Venue Location")]
        [Required(ErrorMessage = "Enter Venue Location")]
        public string Location { get; set; }

        [DataType(DataType.Text, ErrorMessage = "Enter Proper Stadium Name")]
        [Required(ErrorMessage = "Enter Stadium Name")]
        [Display(Name = "Ground Name")]
        public string Description { get; set; }
    }
}