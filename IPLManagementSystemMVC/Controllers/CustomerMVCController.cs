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
                SelectList PlayerSL=null;
                var teamNames = client.GetAsync("https://localhost:44307/api/Customer/Teamspresent").Result;
                if (teamNames.IsSuccessStatusCode)
                {
                    teamsAndPlayers = teamNames.Content.ReadAsAsync<AllTableJoinsMVC>().Result;
                    TeamSL = new SelectList(teamsAndPlayers.Team, "Name", "Name");
                    TempData["TeamSL"] = TeamSL;
                    TempData.Keep();
                    if (TeamSL.SelectedValue is null)
                    {
                        ViewBag.Data = "Hello";
                    }
                    else
                    {
                        var playerNames = client.GetAsync("https://localhost:44307/api/CustomerPlayer/GetPlayersofTeam/"+ (string)TeamSL.SelectedValue).Result;
                        if (playerNames.IsSuccessStatusCode)
                        {
                            teamsAndPlayers = playerNames.Content.ReadAsAsync<AllTableJoinsMVC>().Result;
                            PlayerSL = new SelectList(teamsAndPlayers.Player, "Name", "Name");
                            TempData["PlayerSL"] = PlayerSL;
                            TempData.Keep();
                        }
                    }
                }
            }
            return View();
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
