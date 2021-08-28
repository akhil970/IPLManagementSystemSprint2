using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace IPLManagementSystemMVC.Models
{
    public class PlayerPhoto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlayerPhoto()
        {
            this.Players = new HashSet<Player>();
        }
        [Required(ErrorMessage = "Enter Photo ID")]
        public int Id { get; set; }

        [DataType(DataType.ImageUrl, ErrorMessage = "Enter Proper Photo URL")]
        [Required(ErrorMessage = "Enter Photo URL")]
        [Display(Name = "Photo URL")]
        public string Photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Player> Players { get; set; }
    }
}