using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IPLManagementSystemWEBAPI.Models;
namespace IPLManagementSystemWEBAPI.Controllers
{
    public class UsersAndRolesController : ApiController
    {
        private IPLDBEntities db = new IPLDBEntities();
        //GET Users and Roles
        public IHttpActionResult Get()
        {
            UsersAndRoles usersAndRoles = new UsersAndRoles();
            usersAndRoles.Users = db.UsersTables.ToList();
            usersAndRoles.Roles = db.Roles.ToList();
            return Ok(usersAndRoles);
        }
    }
}
