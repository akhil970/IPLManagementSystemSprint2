using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPLManagementSystemMVC.Models
{
    public class Role
    {
        [Range(1, 3, ErrorMessage = "Enter Proper Role Id")]
        [Required(ErrorMessage = "Enter Role ID")]
        [Display(Name = "Role ID")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Enter Role Name")]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
