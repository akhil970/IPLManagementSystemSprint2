using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using IPLManagementSystemMVC.Models;
namespace IPLManagementSystemMVC.Controllers
{
    public class UserRoleMVCController : Controller
    {
        // GET: UserMVC
        //To get user details in a desired format specified in its view
        public ActionResult Index()
        {
            List<UserRole> userRolesList = new List<UserRole>();
            using (HttpClient client = new HttpClient())
            {
                //To get the response code from the url specified if ok we will read the data
                var result = client.GetAsync("https://localhost:44307/api/userroles").Result;
                if (result.IsSuccessStatusCode)
                {
                    userRolesList = result.Content.ReadAsAsync<List<UserRole>>().Result;
                }
            }
            return View(userRolesList);
        }

        //To insert a user
        public ActionResult InsertUserRole()
        {
            return View();
        }
        [HttpPost] //works when submit button is clicked
        public ActionResult InsertUserRole(User userRolesData)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.PostAsJsonAsync("https://localhost:44307/api/userroles", userRolesData).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
        //To delete a user
        public ActionResult DeleteUserRole(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.DeleteAsync("https://localhost:44307/api/userroles/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
        //To update a user
        public ActionResult UpdateUserRole(int id)
        {
            UserRole userRole = new UserRole();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/userroles/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    userRole = result.Content.ReadAsAsync<UserRole>().Result;
                    return View(userRole);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult UpdateUserRole(UserRole userRole)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.PutAsJsonAsync("https://localhost:44307/api/userroles/" + userRole.Id.ToString(), userRole).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
    }
}
