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
            var roleidofUser = int.Parse(Session["RoleId"].ToString());
            if (roleidofUser == 1)
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
            else
            {
                return RedirectToAction("ErrorView", "HomePage");
            }
            
        }

        public ActionResult Details()
        {
            var roleidofUser = int.Parse(Session["RoleId"].ToString());
            if (roleidofUser == 1)
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
            else
            {
                return RedirectToAction("ErrorView", "HomePage");
            }
            
        }

        // GET: Userroles/Create
        public ActionResult InsertUserRole()
        {
            var roleidofUser = int.Parse(Session["RoleId"].ToString());
            if (roleidofUser == 1)
            {
                UsersAndRolesViewModel usersAndRoles = new UsersAndRolesViewModel();
                using (HttpClient client = new HttpClient())
                {
                    var result = client.GetAsync("https://localhost:44307/api/UsersAndRoles").Result;
                    if (result.IsSuccessStatusCode)
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
            else
            {
                return RedirectToAction("ErrorView", "HomePage");
            }
           
        }

        // POST: Userroles/Create
        [HttpPost]
        public ActionResult InsertUserRole(UserRolesViewModel userRolesData)
        {
            var roleidofUser = int.Parse(Session["RoleId"].ToString());
            if (roleidofUser == 1)
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
            else
            {
                return RedirectToAction("ErrorView", "HomePage");
            }
            
        }

        // GET: Userroles/Edit/5
        public ActionResult UpdateUserRole(int id)
        {
            var roleidofUser = int.Parse(Session["RoleId"].ToString());
            if (roleidofUser == 1)
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
            else
            {
                return RedirectToAction("ErrorView", "HomePage");
            }
            
        }

        // POST: Userroles/Edit/5
        [HttpPost]
        public ActionResult UpdateUserRole(UserRolesViewModel userRole)
        {
            var roleidofUser = int.Parse(Session["RoleId"].ToString());
            if (roleidofUser == 1)
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
            else
            {
                return RedirectToAction("ErrorView", "HomePage");
            }
            
        }

    }
}
