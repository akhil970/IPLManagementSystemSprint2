using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPLManagementSystemMVC.Models;
using System.Net.Http;
using System.Text;
namespace IPLManagementSystemMVC.Controllers
{
    public class UserTable
    {
        public int NUserId { set; get; }
        public string NUsername { set; get; }
        public string NFirstname { set; get; }
        public string NLastname { set; get; }
        public byte[] NPassword { set; get; }
    }

    public class UserMVCController : Controller
    {
        // GET: UserMVC
        public ActionResult Index()
        {
            List<User> usersview = new List<User>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/users1").Result;
                if (result.IsSuccessStatusCode)
                {
                    usersview = result.Content.ReadAsAsync<List<User>>().Result;
                }
            }
            return View(usersview);
        }

        // GET: UserMVC/Create
        public ActionResult InsertUser()
        {
            return View();
        }

        // POST: UserMVC/Create
        [HttpPost]
        public ActionResult InsertUser(User userdata)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PostAsJsonAsync("https://localhost:44307/api/users1", userdata).Result;
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

        // GET: UserMVC/Edit/5
        public ActionResult UpdateUser(int id)
        {
            User users = new User();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/users1/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    users = result.Content.ReadAsAsync<User>().Result;
                    return View(users);
                }
            }
            return View();
        }

        // POST: UserMVC/Edit/5
        [HttpPost]
        public ActionResult UpdateUser(User userdata)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PutAsJsonAsync("https://localhost:44307/api/users1/" + userdata.UserId.ToString(), userdata).Result;
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
