using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPLManagementSystemMVC.Models
{
    public class AllStatistic
    {
        [Range(1,int.MaxValue,ErrorMessage = "Enter Numbers Only")]
        [Required(ErrorMessage = "Enter Statistics ID")]
        public int Id { get; set; }

        [Range(1,10,ErrorMessage ="Enter Valid Team ID")]
        [Required(ErrorMessage = "Enter Team ID")]
        [Display(Name = "Team ID")]
        public int TeamId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Enter Numbers Only")]
        [Required(ErrorMessage = "Enter Total Played Matches")]
        [Display(Name = "Played")]
        public Nullable<int> Played { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Enter Numbers Only")]
        [Required(ErrorMessage = "Enter Total Won Matches")]
        [Display(Name = "Won")]
        public int Won { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Enter Numbers Only")]
        [Required(ErrorMessage = "Enter Total Lost Matches")]
        [Display(Name = "Lost")]
        public int Lost { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Enter Numbers Only")]
        [Required(ErrorMessage = "Enter Total Tied Matches")]
        [Display(Name = "Tied")]
        public int Tied { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Enter Numbers Only")]
        [Required(ErrorMessage = "Enter No Result Matches")]
        [Display(Name = "No Result")]
        public int NoResult { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Enter Numbers Only")]
        [Required(ErrorMessage = "Enter NRR")]
        [Display(Name = "Net Run Rate")]
        public decimal NRR { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Enter Numbers Only")]
        [Required(ErrorMessage = "Enter Total Points")]
        [Display(Name = "Points")]
        public Nullable<int> Points { get; set; }
    }
}