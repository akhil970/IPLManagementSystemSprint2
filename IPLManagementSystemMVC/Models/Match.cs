using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public int Id { get; set; }
        public int TeamOneId { get; set; }
        public int TeamTwoId { get; set; }
        public int VenueId { get; set; }
        public Nullable<int> ScheduleId { get; set; }
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