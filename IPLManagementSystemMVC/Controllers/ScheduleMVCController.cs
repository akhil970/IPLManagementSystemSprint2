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
        public ActionResult Details()
        {
            List<ScheduleDetails> scheduleDetails = new List<ScheduleDetails>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/Schedules/ScheduleDetails").Result;
                if (result.IsSuccessStatusCode)
                {
                    scheduleDetails = result.Content.ReadAsAsync<List<ScheduleDetails>>().Result;
                }
            }
            return View(scheduleDetails);
        }

        // GET: ScheduleMVC/Create
        public ActionResult InsertSchedule()
        {
            List<Venue> venue = new List<Venue>();
            using(HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/Schedules/Venuename").Result;
                if(result.IsSuccessStatusCode)
                {
                    venue = result.Content.ReadAsAsync<List<Venue>>().Result;
                    SelectList VenueSL = new SelectList(venue, "Id", "Location");
                    TempData["VenueSL"] = VenueSL;
                    TempData.Keep();
                }
            }
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
            TempData.Keep();
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
