using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPLManagementSystemMVC.Models
{
    public class Schedule
    {
        [Range(1, int.MaxValue,ErrorMessage = "Enter Proper Schedule ID")]
        [Required(ErrorMessage = "Enter Schedule ID")]
        public int Id { get; set; }

        //[Range(1, int.MaxValue, ErrorMessage = "Enter Proper Match ID")]
        public Nullable<int> MatchId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Enter Proper Venue ID")]
        [Required(ErrorMessage = "Enter Venue ID")]
        public Nullable<int> VenueId { get; set; }

        [Required(ErrorMessage = "Enter Schedule Date")]
        [DataType(DataType.Date,ErrorMessage = "Enter Proper Date")]
        public Nullable<System.DateTime> Date { get; set; }

        [Required(ErrorMessage = "Enter Start Time")]
        [DataType(DataType.Time, ErrorMessage = "Enter Proper Time")]
        public Nullable<System.TimeSpan> Start_Time { get; set; }

        [Required(ErrorMessage = "Enter End Time")]
        [DataType(DataType.Time, ErrorMessage = "Enter Proper Time")]
        public Nullable<System.TimeSpan> End_Time { get; set; }
    }
}