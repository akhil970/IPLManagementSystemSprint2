using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPLManagementSystemMVC.Models
{
    public class UserRole
    {
        [Required(ErrorMessage = "Enter User ID")]
        [Display(Name = "User ID")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Enter Role ID")]
        [Display(Name = "Role ID")]
        public int RoleId { get; set; }
        public int Id { get; set; }
    }
}