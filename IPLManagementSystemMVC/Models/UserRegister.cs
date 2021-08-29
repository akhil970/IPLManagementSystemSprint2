using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPLManagementSystemMVC.Models
{
    public class UserRegister
    {
        [Required(ErrorMessage = "Enter Username")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Enter Proper email address")]
        [Display(Name = "Email")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password, ErrorMessage = "Enter Password with minimum lenght of 6 characters")]
        [MinLength(6)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Enter Firstname")]
        [DataType(DataType.Text, ErrorMessage = "Enter Proper Firstname")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Enter Lastname")]
        [DataType(DataType.Text, ErrorMessage = "Enter Proper Lastname")]
        public string Lastname { get; set; }
    }
}