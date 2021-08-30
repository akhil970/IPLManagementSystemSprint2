using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPLManagementSystemWEBAPI.Models
{
    public class UsersAndRoles
    {
        public List<UsersTable> Users { get; set; }
        public List<Role> Roles { get; set; }
    }
}