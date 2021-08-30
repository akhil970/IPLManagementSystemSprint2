using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPLManagementSystemMVC.Models
{
    public class UsersAndRolesViewModel
    {
        public List<UsersViewModel> Users { get; set; }
        public List<Role> Roles { get; set; }
    }
}