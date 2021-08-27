using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IPLManagementSystemMVC.Models
{
    public class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.UserRoles = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        [Display(Name = "Username")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Username")]
        public string Username { get; set; }
        [Display(Name = "Firstname")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Firstname")]
        public string FirstName { get; set; }
        [Display(Name = "Lastname")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Lastname")]
        public string LastName { get; set; }
        //public byte[] password { get; set; }
        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter Password")]
        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
