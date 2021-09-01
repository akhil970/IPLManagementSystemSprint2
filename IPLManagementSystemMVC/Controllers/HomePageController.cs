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
            //Refer LoginController in WebApi Controllers
            using (HttpClient client = new HttpClient())
            {
                //Select the userdetails and role data as lists to store data
                List<LoginViewModel> userdetails = new List<LoginViewModel>();
                List<RoleViewModel> roleData = new List<RoleViewModel>();
                //Getasync method as it returns the user data which includes password, firstname, lastname, user id
                var result = client.GetAsync("https://localhost:44307/api/login/UserLogin?username=" + login.Username).Result;
                
                if(result.IsSuccessStatusCode)
                {
                    //if user exists 
                    userdetails = result.Content.ReadAsAsync<List<LoginViewModel>>().Result;
                    var useridofclient = userdetails.Select(id => id.UserID).FirstOrDefault();
                    var nameOfUser = userdetails.Select(fn => fn.Firstname).FirstOrDefault() +" "+ userdetails.Select(fn => fn.Lastname).FirstOrDefault();
                    var actualPassword = userdetails.Select(e => e.Password).FirstOrDefault();
                    //verifies password with password present in data base and user entered password
                    if (actualPassword == login.Password)
                    {
                        //if password matches collect role id based on the user id from user roles table
                        var resultOfRoleId = client.GetAsync("https://localhost:44307/api/roleid/" + useridofclient.ToString()).Result;
                        if(resultOfRoleId.IsSuccessStatusCode)
                        {
                            //Refer RoleId Controller in WebApi Controllers                
                            roleData = resultOfRoleId.Content.ReadAsAsync<List<RoleViewModel>>().Result;
                            var roleId = roleData.Select(e => e.Roleid).FirstOrDefault();
                            if(roleId == 0 | roleData is null)
                            {
                                Session["Username"] = nameOfUser;
                                return RedirectToAction("Customer");
                            }
                            else 
                            {   //based on the role id the specific page/view opens
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
        public RedirectResult Logout()
        {
            Session.Clear();
            return Redirect("https://localhost:44349/HomePage/Index");
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
