using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPLManagementSystemMVC.Models;
using System.Net.Http;
namespace IPLManagementSystemMVC.Controllers
{
    public class VenueMVCController : Controller
    {
        [OutputCache(Duration = 60, VaryByParam = "none")]
        // GET: VenueMVC
        public ActionResult Index()
        {
            List<Venue> venue = new List<Venue>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/venues").Result;
                if (result.IsSuccessStatusCode)
                {
                    venue = result.Content.ReadAsAsync<List<Venue>>().Result;
                }
            }
            return View(venue);
        }

        // GET: VenueMVC/Create
        public ActionResult InsertVenue()
        {
            return View();
        }

        // POST: VenueMVC/Create
        [HttpPost]
        public ActionResult InsertVenue(Venue venue)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PostAsJsonAsync("https://localhost:44307/api/venues", venue).Result;
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

        // GET: VenueMVC/Edit/5
        public ActionResult UpdateVenue(int id)
        {
            Venue venue = new Venue();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/venues/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    venue = result.Content.ReadAsAsync<Venue>().Result;
                    return View(venue);
                }
            }
            return View();
        }

        // POST: VenueMVC/Edit/5
        [HttpPost]
        public ActionResult UpdateVenue(Venue venue)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PutAsJsonAsync("https://localhost:44307/api/venues/" + venue.Id.ToString(), venue).Result;
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

        // GET: VenueMVC/Delete/5
        public ActionResult DeleteVenue(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.DeleteAsync("https://localhost:44307/api/venues/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }

    }
}
