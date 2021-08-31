using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPLManagementSystemMVC.Models
{
    public class Match
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Match()
        {
            this.News = new HashSet<News>();
            this.Tickets = new HashSet<Ticket>();
        }
        
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

        public virtual Team Team { get; set; }
        public virtual Team Team1 { get; set; }
        public virtual Venue Venue { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<News> News { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}