using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPLManagementSystemMVC.Models
{
    public class Match
    {
        [Required(ErrorMessage = "Enter Match ID")]
        public int Id { get; set; }

     
        [Required(ErrorMessage = "Enter Match ID")]
        public int TeamOneId { get; set; }

    
        [Required(ErrorMessage = "Enter Team ID")]
        public int TeamTwoId { get; set; }

     
        [Required(ErrorMessage = "Enter Venue ID")]
        public int VenueId { get; set; }

        
        [Required(ErrorMessage = "Enter Schedule ID")]
        public Nullable<int> ScheduleId { get; set; }

      
        [Required(ErrorMessage = "Upload Match Photo")]
        
        public string MatchPhoto { get; set; }

    }
}