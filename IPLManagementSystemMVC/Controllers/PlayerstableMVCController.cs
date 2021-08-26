using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPLManagementSystemMVC.Models;
using System.Net.Http;
namespace IPLManagementSystemMVC.Controllers
{
    public class PlayerstableMVCController : Controller
    {
        public ActionResult Index()
        {
            List<Player> player = new List<Player>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/players1").Result;
                if (result.IsSuccessStatusCode)
                {
                    player = result.Content.ReadAsAsync<List<Player>>().Result;
                }
            }
            return View(player);
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
                    var result = client.PostAsJsonAsync("https://localhost:44307/api/players1", player).Result;
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
        public ActionResult UpdateEmployee(int id)
        {
            Player player = new Player();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/players1/" + id.ToString()).Result;
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
        public ActionResult UpdateEmployee(Player player)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PutAsJsonAsync("https://localhost:44307/api/players1/" + player.Id.ToString(), player).Result;
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
                var result = client.DeleteAsync("https://localhost:44307/api/players1/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
    }
}