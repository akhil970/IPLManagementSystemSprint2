using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPLManagementSystemMVC.Models;
using System.Net.Http;
namespace IPLManagementSystemMVC.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            var roleidofUser = int.Parse(Session["RoleId"].ToString());
            if (roleidofUser == 1)
            {
                List<UsersViewModel> usersview = new List<UsersViewModel>();
                using (HttpClient client = new HttpClient())
                {
                    var result = client.GetAsync("https://localhost:44307/api/usersn").Result;
                    if (result.IsSuccessStatusCode)
                    {
                        usersview = result.Content.ReadAsAsync<List<UsersViewModel>>().Result;
                    }
                }
                return View(usersview);
            }
            else
            {
                return RedirectToAction("ErrorView", "HomePage");
            }
        }

        // GET: Users/Create
        public ActionResult InsertUser()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult InsertUser(UsersViewModel userdata)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PostAsJsonAsync("https://localhost:44307/api/usersn", userdata).Result;
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

        // GET: Users/Edit/5
        public ActionResult UpdateUser(int id)
        {
            UsersViewModel users = new UsersViewModel();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/usersn/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    users = result.Content.ReadAsAsync<UsersViewModel>().Result;
                    return View(users);
                }
            }
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult UpdateUser(UsersViewModel userData)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PutAsJsonAsync("https://localhost:44307/api/usersn/" + userData.UserID.ToString(), userData).Result;
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
    }
}
