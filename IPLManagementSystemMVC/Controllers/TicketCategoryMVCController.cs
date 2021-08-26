using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using IPLManagementSystemMVC.Models;
namespace IPLManagementSystemMVC.Controllers
{
    public class TicketCategoryMVCController : Controller
    {
        // GET: TikcetCategoryMVC
        public ActionResult Index()
        {
            List<TicketCategory> ticketCategory = new List<TicketCategory>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/ticketcategories").Result;
                if (result.IsSuccessStatusCode)
                {
                    ticketCategory = result.Content.ReadAsAsync<List<TicketCategory>>().Result;
                }
            }
            return View(ticketCategory);
        }

        // GET: TikcetCategoryMVC/Create
        public ActionResult InsertTicketCategory()
        {
            return View();
        }

        // POST: TikcetCategoryMVC/Create
        [HttpPost]
        public ActionResult InsertTicketCategory(TicketCategory ticketCategory)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PostAsJsonAsync("https://localhost:44307/api/ticketcategories", ticketCategory).Result;
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

        // GET: TikcetCategoryMVC/Edit/5
        public ActionResult UpdateTicketCategory(int id)
        {
            TicketCategory ticketCategory = new TicketCategory();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/ticketcategories/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    ticketCategory = result.Content.ReadAsAsync<TicketCategory>().Result;
                    return View(ticketCategory);
                }
            }
            return View();
        }

        // POST: TikcetCategoryMVC/Edit/5
        [HttpPost]
        public ActionResult UpdateTicketCategory(TicketCategory ticketCategory)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PutAsJsonAsync("https://localhost:44307/api/ticketcategories/" + ticketCategory.Id.ToString(), ticketCategory).Result;
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

        // GET: TikcetCategoryMVC/Delete/5
        public ActionResult DeleteTicketCategory(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.DeleteAsync("https://localhost:44307/api/ticketcategories/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
    }
}
