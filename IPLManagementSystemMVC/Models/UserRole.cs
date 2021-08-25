using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPLManagementSystemMVC.Models
{
    public class UserRole
    {
        public partial class UserRoles
        {
            public int UserId { get; set; }
            public int RoleId { get; set; }
            public int Id { get; set; }

            public virtual Role Role { get; set; }
            public virtual User User { get; set; }
        }
    }
}