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
        public ActionResult TeamsAndPlayers()
        {
            AllTableJoinsMVC teamsAndPlayers = new AllTableJoinsMVC();
            using (HttpClient client = new HttpClient())
            {
                SelectList TeamSL=null;
                var teamNames = client.GetAsync("https://localhost:44307/api/Customer/Teamspresent").Result;
                if (teamNames.IsSuccessStatusCode)
                {
                    teamsAndPlayers = teamNames.Content.ReadAsAsync<AllTableJoinsMVC>().Result;
                    TeamSL = new SelectList(teamsAndPlayers.Team, "Id", "Name");
                    TempData["TeamSL"] = TeamSL;
                    TempData.Keep();
                }
            }
            return View();
        }
        public ActionResult PlayersList(int? id)
        {
            if(id is null)
            {
                return View("TeamsAndPlayers");
            }
            else
            {
                using (HttpClient client = new HttpClient())
                {
                    AllTableJoinsMVC teamsAndPlayers = new AllTableJoinsMVC();
                    List<Player> playerNames = new List<Player>();
                    SelectList PlayerSL = null;
                    var result = client.GetAsync("https://localhost:44307/api/CustomerPlayer/" + id).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        playerNames = result.Content.ReadAsAsync<List<Player>>().Result;
                        PlayerSL = new SelectList(playerNames, "Id", "Name");
                        TempData["PlayerSL"] = PlayerSL;
                        TempData.Keep();
                    }
                    return View("TeamsAndPlayers");
                }
            }
            
        }
        //Completed matches
        public ActionResult Matches()
        {
            return View();
        }
        //Schedule 

        //Tickets and Ticket Category
        public ActionResult Tickets()
        {
            return View();
        }
        //Statistics
        public ActionResult Points_Table()
        {
            return View();
        }
    }
}
