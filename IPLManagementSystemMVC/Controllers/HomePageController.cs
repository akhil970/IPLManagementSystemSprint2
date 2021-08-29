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
        // For HomePage
        public ActionResult Index()
        {
            return View();
        }

        //User Login
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
                    var nameOfUser = userdetails.Select(fn => fn.Firstname).FirstOrDefault() +" "+ userdetails.Select(fn => fn.Lastname).FirstOrDefault();
                    var actualPassword = userdetails.Select(e => e.Password).FirstOrDefault();
                    if (actualPassword == login.Password)
                    {
                        var resultOfRoleId = client.GetAsync("https://localhost:44307/api/roleid/" + useridofclient.ToString()).Result;
                        if(resultOfRoleId.IsSuccessStatusCode)
                        {
                            
                            //Session["Username"] = userdetails.Firstname.ToString() + userdetails.Lastname.ToString();
                            roleData = resultOfRoleId.Content.ReadAsAsync<List<RoleViewModel>>().Result;
                            var roleId = roleData.Select(e => e.Roleid).FirstOrDefault();
                            if(roleId == 0 | roleData is null)
                            {
                                return RedirectToAction("Customer");
                            }
                            else 
                            {
                                switch (roleId)
                                {
                                    case 1:
                                        Session["Username"] = nameOfUser;
                                        return RedirectToAction("Admin");
                                    case 2:
                                        Session["Username"] = nameOfUser;
                                        return RedirectToAction("Employee");
                                    case 3:
                                        Session["Username"] = nameOfUser;
                                        return RedirectToAction("Customer");
                                }
                            }
                        }
                    }
                    else
                    {
                        //ViewBag.Notification("Invalid Password");
                        return View();
                    }
                }
                else
                {
                    //ViewBag.Notification("Invalid Username");
                    return View();
                }
                
            }
            return View();
        }
        //For Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "HomePage");
        }

        //Customer Registration Part
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserRegister userRegister)
        {
            try
            {
                UsersViewModel userreg = new UsersViewModel()
                {
                    Username = userRegister.Username,Firstname = userRegister.Firstname, Lastname = userRegister.Lastname, Password = userRegister.Password
                };
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PostAsJsonAsync("https://localhost:44307/api/usersn", userreg).Result;
                    
                    if (result.IsSuccessStatusCode)
                    {
                        Session["Username"] = userRegister.Firstname + userRegister.Lastname;
                        return RedirectToAction("Customer");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
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
    }
}
