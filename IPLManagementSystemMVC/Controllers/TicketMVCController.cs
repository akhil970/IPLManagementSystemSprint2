using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using IPLManagementSystemMVC.Models;
namespace IPLManagementSystemMVC.Controllers
{
    public class TicketMVCController : Controller
    {
        // GET: TicketMVC
        public ActionResult Index()
        {
            List<Ticket> ticket = new List<Ticket>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/tickets").Result;
                if (result.IsSuccessStatusCode)
                {
                    ticket = result.Content.ReadAsAsync<List<Ticket>>().Result;
                }
            }
            return View(ticket);
        }
        public ActionResult Details()
        {
            List<TicketDetails> tickets = new List<TicketDetails>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/Tickets/TicketDetails").Result;
                if (result.IsSuccessStatusCode)
                {
                    tickets = result.Content.ReadAsAsync<List<TicketDetails>>().Result;
                }
            }
            return View(tickets);
        }
        // GET: TicketMVC/Create

        public ActionResult InsertTicket()
        {
            AllTableJoinsMVC tcs = new AllTableJoinsMVC();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/Tickets/TCandMatches").Result;
                if(result.IsSuccessStatusCode)
                {
                    tcs = result.Content.ReadAsAsync<AllTableJoinsMVC>().Result;
                    SelectList TCSL = new SelectList(tcs.TicketCategory, "Id", "Name");
                    TempData["TCSL"] = TCSL;
                    TempData.Keep();
                }
            }
            TempData.Keep();
            return View();
        }

        // POST: TicketMVC/Create
        [HttpPost]
        public ActionResult InsertTicket(Ticket ticket)
        {
            TempData.Keep();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PostAsJsonAsync("https://localhost:44307/api/tickets", ticket).Result;
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

        // GET: TicketMVC/Edit/5
        public ActionResult UpdateTicket(int id)
        {
            TempData.Keep();
            Ticket ticket = new Ticket();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/tickets/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    ticket = result.Content.ReadAsAsync<Ticket>().Result;
                    return View(ticket);
                }
            }
            return View();
        }

        // POST: TicketMVC/Edit/5
        [HttpPost]
        public ActionResult UpdateTicket(Ticket ticket)
        {
            try
            {
                TempData.Keep();
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PutAsJsonAsync("https://localhost:44307/api/tickets/" + ticket.Id.ToString(), ticket).Result;
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

        // GET: TicketMVC/Delete/5
        public ActionResult DeleteTicket(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.DeleteAsync("https://localhost:44307/api/tickets/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
    }
}
