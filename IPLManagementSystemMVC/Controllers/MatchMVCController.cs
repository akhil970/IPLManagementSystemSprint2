using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using IPLManagementSystemMVC.Models;
namespace IPLManagementSystemMVC.Controllers
{
    public class MatchMVCController : Controller
    {
        // GET: MatchMVC
        public ActionResult Index()
        {
            List<Match> match = new List<Match>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/matches").Result;
                if (result.IsSuccessStatusCode)
                {
                    match = result.Content.ReadAsAsync<List<Match>>().Result;
                }
            }
            return View(match);
        }
        public ActionResult Details()
        {
            List<MatchDetails> matchDetails = new List<MatchDetails>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/Matches/MatchesDetails").Result;
                if (result.IsSuccessStatusCode)
                {
                    matchDetails = result.Content.ReadAsAsync<List<MatchDetails>>().Result;
                }
            }
            return View(matchDetails);
        }
        // GET: MatchMVC/Create
        public ActionResult InsertMatch()
        {
            return View();
        }

        // POST: MatchMVC/Create
        [HttpPost]
        public ActionResult InsertMatch(Match match)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PostAsJsonAsync("https://localhost:44307/api/matches", match).Result;
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

        // GET: MatchMVC/Edit/5
        public ActionResult UpdateMatch(int id)
        {
            Match match = new Match();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/matches/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    match = result.Content.ReadAsAsync<Match>().Result;
                    return View(match);
                }
            }
            return View();
        }

        // POST: MatchMVC/Edit/5
        [HttpPost]
        public ActionResult UpdateMatch(Match match)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PutAsJsonAsync("https://localhost:44307/api/matches/" + match.Id.ToString(), match).Result;
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

        // GET: MatchMVC/Delete/5
        public ActionResult DeleteMatch(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.DeleteAsync("https://localhost:44307/api/matches/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
    }
}
