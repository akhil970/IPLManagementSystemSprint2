using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPLManagementSystemMVC.Models
{
    public class UserRolesViewModel
    {
        public int Id { get; set; }
     
        [Required(ErrorMessage = "Enter User Id")]
        [Range(1, int.MaxValue, ErrorMessage = "Enter Proper User Id")]
        public Nullable<int> UserId { get; set; }


        [Required(ErrorMessage = "Enter Role Id")]
        [Range(1, 3, ErrorMessage = "Enter Proper Role Id")]
        public Nullable<int> RoleId { get; set; }

    }
}
