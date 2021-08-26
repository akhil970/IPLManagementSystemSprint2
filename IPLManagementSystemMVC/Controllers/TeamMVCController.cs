using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using IPLManagementSystemMVC.Models;
namespace IPLManagementSystemMVC.Controllers
{
    public class TeamMVCController : Controller
    {
        // GET: TeamMVC
        public ActionResult Index()
        {
            List<Team> team = new List<Team>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/teams").Result;
                if (result.IsSuccessStatusCode)
                {
                    team = result.Content.ReadAsAsync<List<Team>>().Result;
                }
            }
            return View(team);
        }

        // GET: TeamMVC/Create
        public ActionResult InsertTeam()
        {
            return View();
        }

        // POST: TeamMVC/Create
        [HttpPost]
        public ActionResult InsertTeam(Team team)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PostAsJsonAsync("https://localhost:44307/api/teams", team).Result;
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

        // GET: TeamMVC/Edit/5
        public ActionResult UpdateTeam(int id)
        {
            Team team = new Team();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/teams/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    team = result.Content.ReadAsAsync<Team>().Result;
                    return View(team);
                }
            }
            return View();
        }

        // POST: TeamMVC/Edit/5
        [HttpPost]
        public ActionResult UpdateTeam(Team team)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PutAsJsonAsync("https://localhost:44307/api/teams/" + team.Id.ToString(), team).Result;
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

        // GET: TeamMVC/Delete/5
        public ActionResult DeleteTeam(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.DeleteAsync("https://localhost:44307/api/teams/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
    }
}
