using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPLManagementSystemMVC.Models
{
    public class Speciality
    {
        [Range(1,int.MaxValue, ErrorMessage = "Enter Proper Speciality ID")]
        [Required(ErrorMessage = "Enter Speciality ID")]
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter Speciality Description")]
        public string Description { get; set; }
    }
}