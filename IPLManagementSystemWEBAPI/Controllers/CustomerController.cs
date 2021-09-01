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

        [Route("api/Customer/Teamspresent")]
        [ResponseType(typeof(usp_customer_teamnames_Result))]
        public IHttpActionResult GetTeamspresent()
        {
            //Teams present in the data base
            var teamsData = db.usp_customer_teamnames();
            return Ok(teamsData);
        }

        [Route("api/Customer/Players/{id}")]
        [ResponseType(typeof(usp_customer_players_view_Result))]
        public IHttpActionResult GetPlayers(int id)
        {
            var playersData = db.usp_customer_players_view(id);
            if(playersData != null)
            {
                return Ok(playersData);
            }
            return BadRequest(ModelState);
        }

        [Route("api/Customer/CompletedMatches")]
        [ResponseType(typeof(usp_customer_matches_Result))]
        public IHttpActionResult GetCompletedMatches()
        {
            var customerCompltedMatches = db.usp_news_matchphoto_view(); 
            return Ok(customerCompltedMatches);
        }

        [Route("api/Customer/UpcomingMatches")]
        [ResponseType(typeof(usp_news_matchphoto_view_Result))]
        public IHttpActionResult GetUpcomingMatches()
        {
            var customerMatchResults = db.usp_customer_matches();
            return Ok(customerMatchResults);
        }

        [Route("api/Customer/MatchesScheduled")]
        [ResponseType(typeof(usp_cust_match_selection_Result))]
        public IHttpActionResult GetMatchesScheduled()
        {
            var result = db.usp_cust_match_selection();
            return Ok(result);
        }

        [Route("api/Customer/Tickets")]
        [ResponseType(typeof(usp_cust_ticket_selection_Result))]
        public IHttpActionResult GetTickets()
        {
            var result = db.usp_cust_ticket_selection();
            return Ok(result);
        }

        [Route("api/Customer/TicketAndPrice")]
        [ResponseType(typeof(customer_ticket_category_Result))]
        public IHttpActionResult GetTicketAndPrice()
        {
            var results = db.customer_ticket_category();
            return Ok(results);
        }

        [Route("api/Customer/PointsTable")]
        [ResponseType(typeof(usp_allstatistics_teamname_Result))]
        public IHttpActionResult GetPointsTable()
        {
            var results = db.usp_allstatistics_teamname();
            return Ok(results);
        }
    }
}
