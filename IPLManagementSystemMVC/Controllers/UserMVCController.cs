using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http; //for http client class
using System.Web;
using System.Web.Mvc;
using IPLManagementSystemMVC.Models;
namespace IPLManagementSystemMVC.Controllers
{
    public class UserMVCController : Controller
    {
        // GET: UserMVC
        //To get user details in a desired format specified in its view
        public ActionResult Index()
        {
            List<User> usersList = new List<User>();
            using (HttpClient client = new HttpClient())
            {
                //To get the response code from the url specified if ok we will read the data
                var result = client.GetAsync("https://localhost:44307/api/users").Result;
                if (result.IsSuccessStatusCode)
                {
                    usersList = result.Content.ReadAsAsync<List<User>>().Result;
                }
            }
            return View(usersList);
        }

        //To insert a user
        public ActionResult InsertUser()
        {
            return View();
        }
        [HttpPost] //works when submit button is clicked
        public ActionResult InsertUser(User userData)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.PostAsJsonAsync("https://localhost:44307/api/users", userData).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
        //To delete a user
        public ActionResult DeleteUser(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.DeleteAsync("https://localhost:44307/api/users/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
        //To update a user
        public ActionResult UpdateUser(int id)
        {
            User user = new User();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/users/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    user = result.Content.ReadAsAsync<User>().Result;
                    return View(user);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult UpdateUser(User user)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.PutAsJsonAsync("https://localhost:44307/api/users/" + user.UserId.ToString(), user).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
    }
}
