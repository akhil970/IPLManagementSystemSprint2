using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using IPLManagementSystemMVC.Models;
namespace IPLManagementSystemMVC.Controllers
{
    public class ScheduleMVCController : Controller
    {
        [OutputCache(Duration = 60, VaryByParam = "none")]
        // GET: ScheduleMVC
        public ActionResult Index()
        {
            List<Schedule> schedule = new List<Schedule>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/schedules").Result;
                if (result.IsSuccessStatusCode)
                {
                    schedule = result.Content.ReadAsAsync<List<Schedule>>().Result;
                }
            }
            return View(schedule);
        }


        // GET: ScheduleMVC/Create
        public ActionResult InsertSchedule()
        {
            return View();
        }

        // POST: ScheduleMVC/Create
        [HttpPost]
        public ActionResult InsertSchedule(Schedule schedule)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PostAsJsonAsync("https://localhost:44307/api/schedules", schedule).Result;
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

        // GET: ScheduleMVC/Edit/5
        public ActionResult UpdateSchedule(int id)
        {
            Schedule schedule = new Schedule();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/schedules/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    schedule = result.Content.ReadAsAsync<Schedule>().Result;
                    return View(schedule);
                }
            }
            return View();
        }

        // POST: ScheduleMVC/Edit/5
        [HttpPost]
        public ActionResult UpdateSchedule(Schedule schedule)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PutAsJsonAsync("https://localhost:44307/api/schedules/" + schedule.Id.ToString(), schedule).Result;
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
        // GET: ScheduleMVC/Delete/5
        public ActionResult DeleteSchedule(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.DeleteAsync("https://localhost:44307/api/schedules/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
    }
}
