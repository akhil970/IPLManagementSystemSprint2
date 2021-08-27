using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPLManagementSystemMVC.Controllers
{
    public class CustomerMVCController : Controller
    {
        // GET: CustomerMVC
        public ActionResult TeamsAndPlayers()
        {
            return View();
        }
        //Completed matches
        public ActionResult PlayedMatches()
        {
            return View();
        }
        //Schedule 
        public ActionResult UpcomingMatches()
        {
            return View();
        }
        //Tickets and Ticket Category
        public ActionResult Tickets()
        {
            return View();
        }
        //Statistics
        public ActionResult Points_Table()
        {
            return View();
        }
    }
}