using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using IPLManagementSystemMVC.Models;
namespace IPLManagementSystemMVC.Controllers
{
    public class AllStatisticsMVCController : Controller
    {
        // GET: AllStatisticsMVC
        public ActionResult Index() 
        {
            List<AllStatistic> stats = new List<AllStatistic>();
            using(HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/AllStatistics").Result;
                if(result.IsSuccessStatusCode)
                {
                    stats = result.Content.ReadAsAsync<List<AllStatistic>>().Result;
                }
            }
            return View(stats);
        }

        //To insert data into statistics
        public ActionResult InsertStatistics()
        {
            return View();
        }
        [HttpPost] //works when submit button is clicked
        public ActionResult InsertStatistics(AllStatistic stats)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.PostAsJsonAsync("https://localhost:44307/api/allstatistics", stats).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }

        public ActionResult UpdateStatistics(int id)
        {
            AllStatistic stats = new AllStatistic();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/allstatistics/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    stats = result.Content.ReadAsAsync<AllStatistic>().Result;
                    return View(stats);
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult UpdateStatistics(AllStatistic stats)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.PutAsJsonAsync("https://localhost:44307/api/allstatistics/" + stats.Id.ToString(), stats).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }

        //To delete a user
        public ActionResult DeleteStatistics(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.DeleteAsync("https://localhost:44307/api/allstatistics/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
    }
}
