using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IPLManagementSystemMVC.Models
{
    public class User
    {
        [Range(1,int.MaxValue, ErrorMessage = "Enter Proper User Id")]
        [Required(ErrorMessage = "Enter UserId")]
        [Display(Name = "User ID")]
        public int UserId { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage ="Please Enter proper email id")]
        [Required(ErrorMessage = "Enter Email Address")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [DataType(DataType.Text, ErrorMessage = "Please Enter First Name")]
        [Required(ErrorMessage = "Enter First Name")]
        [Display(Name = "Firstname")]
        public string FirstName { get; set; }

        [DataType(DataType.Text, ErrorMessage = "Please Enter Last Name")]
        [Required(ErrorMessage = "Enter Last Name")]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }

        [DataType(DataType.Password, ErrorMessage ="Please Enter Valid Password")]
        [MinLength(6)]
        [Required(ErrorMessage = "Enter Password")]
        [Display(Name = "Password")]
        public string password { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter Confirm Password")]
        [Compare("password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
