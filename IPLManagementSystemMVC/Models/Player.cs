using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPLManagementSystemMVC.Models
{
    public class Player
    {
        [Range(1, int.MaxValue, ErrorMessage = "Enter Numbers Only")]
        [Display(Name="Player ID")]
        public int Id { get; set; }

        [Range(1, 10, ErrorMessage = "Enter Valid Team ID")]
        [Display(Name = "Team ID")]
        [Required(ErrorMessage = "Enter Team ID")]
        public Nullable<int> TeamId { get; set; }

        [Required(ErrorMessage = "Enter Player Name")]
        [Display (Name = "Player Name")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Enter Age")]
        public Nullable<int> Age { get; set; }

        [Required(ErrorMessage = "Enter Speciality ID")]
        public Nullable<int> SpecialityId { get; set; }
        

        [Required(ErrorMessage = "Enter Photo ID")]
        [Display (Name = "Photo ID")]
        public Nullable<int> PhotoId { get; set; }



        public virtual PlayerPhoto PlayerPhoto { get; set; }
        public virtual Speciality Speciality { get; set; }
        public virtual Team Team { get; set; }
    }
}
