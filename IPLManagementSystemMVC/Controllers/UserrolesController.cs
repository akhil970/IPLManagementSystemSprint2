using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using IPLManagementSystemMVC.Models;
namespace IPLManagementSystemMVC.Controllers
{
    public class UserrolesController : Controller
    {
        // GET: Userroles
        public ActionResult Index()
        {
            List<UserRolesViewModel> userRolesList = new List<UserRolesViewModel>();
            using (HttpClient client = new HttpClient())
            {
                //To get the response code from the url specified if ok we will read the data
                var result = client.GetAsync("https://localhost:44307/api/userrolesn").Result;
                if (result.IsSuccessStatusCode)
                {
                    userRolesList = result.Content.ReadAsAsync<List<UserRolesViewModel>>().Result;
                }
            }
            return View(userRolesList);
        }

        public ActionResult Details()
        {
            List<UserRolesDetails> userRoles = new List<UserRolesDetails>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/userrolesn/UserRolesDetails").Result;
                if (result.IsSuccessStatusCode)
                {
                    userRoles = result.Content.ReadAsAsync<List<UserRolesDetails>>().Result;
                }
            }
            return View(userRoles);
        }

        // GET: Userroles/Create
        public ActionResult InsertUserRole()
        {
            UsersAndRolesViewModel usersAndRoles = new UsersAndRolesViewModel();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/UsersAndRoles").Result;
                if(result.IsSuccessStatusCode)
                {
                    usersAndRoles = result.Content.ReadAsAsync<UsersAndRolesViewModel>().Result;
                    SelectList UsersSL = new SelectList(usersAndRoles.Users, "UserID", "Firstname");
                    TempData["UsersSL"] = UsersSL;
                    SelectList RolesSL = new SelectList(usersAndRoles.Roles, "RoleId", "RoleName");
                    TempData["RolesSL"] = RolesSL;
                    TempData.Keep();
                }
            }
            return View();
        }

        // POST: Userroles/Create
        [HttpPost]
        public ActionResult InsertUserRole(UserRolesViewModel userRolesData)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PostAsJsonAsync("https://localhost:44307/api/userrolesn", userRolesData).Result;
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

        // GET: Userroles/Edit/5
        public ActionResult UpdateUserRole(int id)
        {
            UserRolesViewModel userRole = new UserRolesViewModel();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/userrolesn/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    userRole = result.Content.ReadAsAsync<UserRolesViewModel>().Result;
                    return View(userRole);
                }
            }
            return View();
        }

        // POST: Userroles/Edit/5
        [HttpPost]
        public ActionResult UpdateUserRole(UserRolesViewModel userRole)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PutAsJsonAsync("https://localhost:44307/api/userrolesn/" + userRole.Id.ToString(), userRole).Result;
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
