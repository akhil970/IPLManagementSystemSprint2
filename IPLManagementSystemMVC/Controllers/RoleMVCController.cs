using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using IPLManagementSystemMVC.Models;
namespace IPLManagementSystemMVC.Controllers
{
    public class RoleMVCController : Controller
    {
        [OutputCache(Duration = 60, VaryByParam = "none")]
        // GET: UserMVC
        //To get user details in a desired format specified in its view
        public ActionResult Index()
        {
            List<Role> rolesList = new List<Role>();
            using (HttpClient client = new HttpClient())
            {
                //To get the response code from the url specified if ok we will read the data
                var result = client.GetAsync("https://localhost:44307/api/roles").Result;
                if (result.IsSuccessStatusCode)
                {
                    rolesList = result.Content.ReadAsAsync<List<Role>>().Result;
                }
            }
            return View(rolesList);
        }

        //To insert a user
        public ActionResult InsertRole()
        {
            return View();
        }
        [HttpPost] //works when submit button is clicked
        public ActionResult InsertRole(Role roleData)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.PostAsJsonAsync("https://localhost:44307/api/roles", roleData).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
        //To delete a user
        public ActionResult DeleteRole(int id)
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
        public ActionResult UpdateRole(int id)
        {
            Role role = new Role();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/roles/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    role = result.Content.ReadAsAsync<Role>().Result;
                    return View(role);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult UpdateRole(Role roleData)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.PutAsJsonAsync("https://localhost:44307/api/roles/" + roleData.RoleId.ToString(), roleData).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
    }
}
