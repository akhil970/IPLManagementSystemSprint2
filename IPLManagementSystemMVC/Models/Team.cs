using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPLManagementSystemMVC.Models
{
    public class Team
    {
        [Range(1, int.MaxValue, ErrorMessage = "Enter Proper Team ID")]
        [Required(ErrorMessage = "Enter Team ID")]
        [Display (Name = "Team ID")]
        public int Id { get; set; }
        
        [DataType(DataType.Text, ErrorMessage = "Enter Proper Team Name")]
        [Required(ErrorMessage = "Enter Team Name")]
        public string Name { get; set; }


        [DataType(DataType.Text, ErrorMessage = "Enter Proper Home Ground Name")]
        [Required(ErrorMessage = "Enter Home Ground")]
        [Display(Name="Home Ground")]
        public string Home_Ground { get; set; }


        [DataType(DataType.Text, ErrorMessage = "Enter Proper Owner Name")]
        [Required(ErrorMessage = "Enter Franchise Owner")]
        [Display(Name = "Owner")]
        public string Franchise_Owners { get; set; }


        [DataType(DataType.ImageUrl, ErrorMessage = "Enter Proper Match Photo URL")]
        [Required(ErrorMessage = "Enter Team Logo URL")]
        public string Logo_Image { get; set; }
    }
}