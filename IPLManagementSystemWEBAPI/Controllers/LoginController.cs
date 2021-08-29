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
    public class LoginController : ApiController
    {
        private IPLDBEntities db = new IPLDBEntities();
        [ResponseType(typeof(usp_newLogin_Result))]
        [Route("api/login/{username}")]
        [HttpGet, HttpPost]
        public IHttpActionResult GetUserLogin(string username)
        {
            //Takes username and returns row data if user exists
            var result = db.usp_newLogin(username); //this returns a row of user information if user exists
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
