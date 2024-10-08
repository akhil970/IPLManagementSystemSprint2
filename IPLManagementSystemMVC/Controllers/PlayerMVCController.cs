﻿using System;
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
