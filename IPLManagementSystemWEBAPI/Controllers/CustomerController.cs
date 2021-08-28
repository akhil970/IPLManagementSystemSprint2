using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IPLManagementSystemWEBAPI.Models;
using System.Web.Http.Description;

namespace IPLManagementSystemWEBAPI.Controllers
{
    public class CustomerController : ApiController
    { 
        private IPLDBEntities db = new IPLDBEntities();
        [ResponseType(typeof(Team))]
        public IHttpActionResult GetTeamspresent()
        {
            AllTablesListData teams = new AllTablesListData();
            teams.Team = db.Teams.ToList();
            return Ok(teams);
        }
    }
}
