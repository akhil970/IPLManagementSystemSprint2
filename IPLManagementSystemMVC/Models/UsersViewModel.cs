using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPLManagementSystemMVC.Models
{
    public class UsersViewModel
    {
        public int UserID { get; set; }

        
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter Proper email address")]
        [Required(ErrorMessage = "Enter Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter Firstname")]
        [DataType(DataType.Text, ErrorMessage = "Enter Proper Firstname")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Enter Lastname")]
        [DataType(DataType.Text, ErrorMessage = "Enter Proper Lastname")]
        public string Lastname { get; set; }

    }
}