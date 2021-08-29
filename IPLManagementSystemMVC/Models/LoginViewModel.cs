using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPLManagementSystemMVC.Models
{
    public class LoginViewModel
    {
        public int UserID { get; set; }
        
        [Required(ErrorMessage = "Enter Username")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
