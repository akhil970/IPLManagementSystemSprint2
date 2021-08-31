using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPLManagementSystemMVC.Models
{
    public class TicketCategory
    {
        [Range(1, int.MaxValue, ErrorMessage = "Enter Proper Ticket Category ID")]
        [Required(ErrorMessage = "Enter Category ID")]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter Ticket Category Name")]
        public string Name { get; set; }
    }
}
