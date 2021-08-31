using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPLManagementSystemMVC.Models
{
    public class PlayerPhoto
    {
        [Required(ErrorMessage = "Enter Photo ID")]
        public int Id { get; set; }

        [DataType(DataType.ImageUrl, ErrorMessage = "Enter Proper Photo URL")]
        [Required(ErrorMessage = "Enter Photo URL")]
        [Display(Name = "Photo URL")]
        public string Photo { get; set; }
    }
}