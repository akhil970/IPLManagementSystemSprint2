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
        [Range(1, int.MaxValue, ErrorMessage = "Enter Proper Match ID")]
        [Required(ErrorMessage = "Enter Match ID")]
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Enter Proper Team ID")]
        [Required(ErrorMessage = "Enter Match ID")]
        public int TeamOneId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Enter Proper Team ID")]
        [Required(ErrorMessage = "Enter Team ID")]
        public int TeamTwoId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Enter Proper Venue ID")]
        [Required(ErrorMessage = "Enter Venue ID")]
        public int VenueId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Enter Proper Schedule ID")]
        [Required(ErrorMessage = "Enter Schedule ID")]
        public Nullable<int> ScheduleId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Enter Proper Match Photo")]
        [Required(ErrorMessage = "Upload Match Photo")]
        [DataType(DataType.ImageUrl, ErrorMessage = "Enter Proper Image URL")]
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