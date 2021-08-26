using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPLManagementSystemMVC.Models
{
    public class PlayerPhoto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlayerPhoto()
        {
            this.Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public string Photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Player> Players { get; set; }
    }
}