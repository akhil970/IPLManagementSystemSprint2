using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPLManagementSystemMVC.Models
{
    public class TicketCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TicketCategory()
        {
            this.Tickets = new HashSet<Ticket>();
        }
        [Range(1, int.MaxValue, ErrorMessage = "Enter Proper Ticket Category ID")]
        [Required(ErrorMessage = "Enter Category ID")]
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter Ticket Category Name")]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
