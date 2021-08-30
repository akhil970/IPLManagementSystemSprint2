using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPLManagementSystemMVC.Models;
using System.Net.Http;
namespace IPLManagementSystemMVC.Controllers
{
    public class CustomerMVCController : Controller
    {
        //AllTableJoinsMVC teamsAndPlayers = new AllTableJoinsMVC();
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerMVC
        public ActionResult Teams()
        {
            List<CustomerTeamNames> custTeams = new List<CustomerTeamNames>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/Customer/Teamspresent").Result;
                if(result.IsSuccessStatusCode)
                {
                    custTeams = result.Content.ReadAsAsync<List<CustomerTeamNames>>().Result;
                }
                return View(custTeams);
            }
        }
        public ActionResult Players(int id)
        {
            List<CustomerPlayers> custPlayers = new List<CustomerPlayers>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/Customer/players/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    custPlayers = result.Content.ReadAsAsync<List<CustomerPlayers>>().Result;
                }
                return View(custPlayers);
            }
        }

        //Completed matches
        public ActionResult CompletedMatches()
        {

            List<CustomerMatchResults> custMatchResults = new List<CustomerMatchResults>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/Customer/CompletedMatches").Result;
                if (result.IsSuccessStatusCode)
                {
                    custMatchResults = result.Content.ReadAsAsync<List<CustomerMatchResults>>().Result;
                }
                return View(custMatchResults);
            }
        }
        public ActionResult UpcomingMatches()
        {
            List<CustomerUpcomingMacthes> custUpMatches = new List<CustomerUpcomingMacthes>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/Customer/UpcomingMatches").Result;
                if (result.IsSuccessStatusCode)
                {
                    custUpMatches = result.Content.ReadAsAsync<List<CustomerUpcomingMacthes>>().Result;
                }
                return View(custUpMatches);
            }
        }
        public ActionResult Tickets()
        {
            TicketBooking();
            TicketCategories();
            TicketsAndPrices();
            return View();
        }
        //Tickets and Ticket Category
        public ActionResult TicketBooking()
        {
            List<CustomerMatchesddl> custMatchesScheduled = new List<CustomerMatchesddl>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/Customer/MatchesScheduled").Result;
                if(result.IsSuccessStatusCode)
                {
                    custMatchesScheduled = result.Content.ReadAsAsync<List<CustomerMatchesddl>>().Result;
                    SelectList MatchesSL = new SelectList(custMatchesScheduled, "Id","Match");
                    TempData["custMatchScheduled"] = MatchesSL;
                    TempData.Keep();
                }
            }
            return View();
        }

        public ActionResult TicketCategories()
        {
            List<CustomerTicketsddl> custMatchTickets = new List<CustomerTicketsddl>();
            using(HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/Customer/Tickets").Result;
                if (result.IsSuccessStatusCode)
                {
                    custMatchTickets = result.Content.ReadAsAsync<List<CustomerTicketsddl>>().Result;
                    SelectList TicketsSL = new SelectList(custMatchTickets, "Id", "Name");
                    TempData["custTickets"] = TicketsSL;
                    TempData.Keep();
                }
            }
            return View();
        }
        public ActionResult TicketsAndPrices()
        {
            List<CustomerTicketCategories> custTicketsAndPrices = new List<CustomerTicketCategories>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/Customer/TicketAndPrice").Result;
                if (result.IsSuccessStatusCode)
                {
                    custTicketsAndPrices = result.Content.ReadAsAsync<List<CustomerTicketCategories>>().Result;
                }
            }
            return View(custTicketsAndPrices);
        }

        //Statistics
        public ActionResult Points_Table()
        {
            List<CustomerPointsTable> pointsTable = new List<CustomerPointsTable>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/Customer/PointsTable").Result;
                if (result.IsSuccessStatusCode)
                {
                    pointsTable = result.Content.ReadAsAsync<List<CustomerPointsTable>>().Result;
                }
            }
            return View(pointsTable);
        }
    }
}
