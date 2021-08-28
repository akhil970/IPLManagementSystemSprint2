using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPLManagementSystemMVC.Models
{
    public class Speciality
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Speciality()
        {
            this.Players = new HashSet<Player>();
        }

        [Range(1,int.MaxValue, ErrorMessage = "Enter Proper Speciality ID")]
        [Required(ErrorMessage = "Enter Speciality ID")]
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Enter Speciality Description")]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Player> Players { get; set; }
    }
}