using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using IPLManagementSystemMVC.Models;
namespace IPLManagementSystemMVC.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            using (HttpClient client = new HttpClient())
            {
                List<LoginViewModel> userdetails = new List<LoginViewModel>();
                List<RoleViewModel> roleData = new List<RoleViewModel>();
                var result = client.GetAsync("https://localhost:44307/api/login/UserLogin?username=" + login.Username).Result;
                if(result.IsSuccessStatusCode)
                {
                    userdetails = result.Content.ReadAsAsync<List<LoginViewModel>>().Result;
                    var useridofclient = userdetails.Select(id => id.UserID).FirstOrDefault();
                    var actualPassword = userdetails.Select(e => e.Password).FirstOrDefault();
                    if (actualPassword == login.Password)
                    {
                        var resultOfRoleId = client.GetAsync("https://localhost:44307/api/roleid/" + useridofclient.ToString()).Result;
                        if(resultOfRoleId.IsSuccessStatusCode)
                        {
                            
                            //Session["Username"] = userdetails.Firstname.ToString() + userdetails.Lastname.ToString();
                            roleData = resultOfRoleId.Content.ReadAsAsync<List<RoleViewModel>>().Result;
                            var roleId = roleData.Select(e => e.Roleid).FirstOrDefault();
                            switch (roleId)
                            {
                                case 1:
                                    return RedirectToAction("Admin");
                                case 2:
                                    return RedirectToAction("Employee");
                                case 3:
                                    return RedirectToAction("Customer");
                            }
                        }
                    }
                    else
                    {
                        ViewBag.Notification("Invalid Password");
                    }
                }
                else
                {
                    return View();
                    //ViewBag.Notification("Invalid Username or User Does Not Exists");
                }
                
            }
            return View();
        }
        [HttpPost]
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Employee()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult Customer()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "HomePage");
        }
    }
}
