using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPLManagementSystemMVC.Models;
using System.Net.Http;
namespace IPLManagementSystemMVC.Controllers
{
    public class PlayerMVCController : Controller
    {
        // GET: PlayerMVC
        public ActionResult Index()
        {
            List<Player> players = new List<Player>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/players").Result;
                if (result.IsSuccessStatusCode)
                {
                    players = result.Content.ReadAsAsync<List<Player>>().Result;
                }
            }
            return View(players);
        }
        
        // GET: PlayerMVC/Create
        public ActionResult InsertPlayer()
        {
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
            Player players = new Player();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/players/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    players = result.Content.ReadAsAsync<Player>().Result;
                    return View(players);
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
