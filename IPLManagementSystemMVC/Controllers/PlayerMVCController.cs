using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using IPLManagementSystemMVC.Models;
namespace IPLManagementSystemMVC.Controllers
{
    public class PlayerMVCController : Controller
    {

        // GET: PlayerMVC
        public ActionResult Index()
        {
            List<Player> player = new List<Player>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/players").Result;
                if (result.IsSuccessStatusCode)
                {
                    player = result.Content.ReadAsAsync<List<Player>>().Result;
                }
            }
            return View(player);
        }
        public ActionResult Details()
        {
            List<PlayerDetails> playerDetails = new List<PlayerDetails>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/Players/PlayerDetails").Result;
                if (result.IsSuccessStatusCode)
                {
                    playerDetails = result.Content.ReadAsAsync<List<PlayerDetails>>().Result;
                }
            }
            return View(playerDetails);
        }
        // GET: PlayerMVC/Create
        [OutputCache(Duration = 60, VaryByParam = "None")]
        public ActionResult InsertPlayer()
        {
            AllTableJoinsMVC teamsAndSpeciality = new AllTableJoinsMVC();
            using(HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/Players/TeamSpeciality").Result;
                if(result.IsSuccessStatusCode)
                {
                    teamsAndSpeciality = result.Content.ReadAsAsync<AllTableJoinsMVC>().Result;
                    SelectList TeamSL = new SelectList(teamsAndSpeciality.Team, "Id", "Name");
                    TempData["TeamSL"] = TeamSL;
                    SelectList SpecialitySL = new SelectList(teamsAndSpeciality.Speciality, "Id", "Description");
                    TempData["SpecialitySL"] = SpecialitySL;
                    TempData.Keep();
                }
            }
            return View();
        }

        // POST: PlayerMVC/Create
        [HttpPost]
        public ActionResult InsertPlayer(Player player)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PostAsJsonAsync("https://localhost:44307/api/players", player).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayerMVC/Edit/5
        public ActionResult UpdatePlayer(int id)
        {
            TempData.Keep();
            Player player = new Player();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/players/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    player = result.Content.ReadAsAsync<Player>().Result;
                    return View(player);
                }
            }
            return View();
        }

        // POST: PlayerMVC/Edit/5
        [HttpPost]
        public ActionResult UpdatePlayer(Player player)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PutAsJsonAsync("https://localhost:44307/api/players/" + player.Id.ToString(), player).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayerMVC/Delete/5
        public ActionResult DeletePlayer(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.DeleteAsync("https://localhost:44307/api/players/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
    }
}
