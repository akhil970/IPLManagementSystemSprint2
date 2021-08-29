using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using IPLManagementSystemWEBAPI.Models;
namespace IPLManagementSystemWEBAPI.Controllers
{
    public class RoleIdController : ApiController
    {
        private IPLDBEntities db = new IPLDBEntities();
        [ResponseType(typeof(usp_newRoleId_Result))]
        [Route("api/roleid/{userid}")]
        [HttpGet, HttpPost]
        public IHttpActionResult GetUserRoleId(int userid)
        {
            //gets role id based on the user id
            var result = db.usp_newRoleId(userid); //this returns a row of user information if user exists
            if(result is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
