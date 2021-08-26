using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using IPLManagementSystemMVC.Models;
namespace IPLManagementSystemMVC.Controllers
{
    public class SpecialityMVCController : Controller
    {
        [OutputCache (Duration = 60, VaryByParam = "none")]
        // GET: SpecialityMVC
        public ActionResult Index()
        {
            List<Speciality> speciality = new List<Speciality>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/speciality").Result;
                if (result.IsSuccessStatusCode)
                {
                    speciality = result.Content.ReadAsAsync<List<Speciality>>().Result;
                }
            }
            return View(speciality);
        }

        // GET: SpecialityMVC/Create
        public ActionResult InsertSpeciality()
        {
            return View();
        }

        // POST: SpecialityMVC/Create
        [HttpPost]
        public ActionResult InsertSpeciality(Speciality speciality)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PostAsJsonAsync("https://localhost:44307/api/speciality", speciality).Result;
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

        // GET: SpecialityMVC/Edit/5
        public ActionResult UpdateSpeciality(int id)
        {
            Speciality speciality = new Speciality();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/speciality/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    speciality = result.Content.ReadAsAsync<Speciality>().Result;
                    return View(speciality);
                }
            }
            return View();
        }

        // POST: SpecialityMVC/Edit/5
        [HttpPost]
        public ActionResult UpdateSpeciality(Speciality speciality)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PutAsJsonAsync("https://localhost:44307/api/players/" + speciality.Id.ToString(), speciality).Result;
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

        // GET: SpecialityMVC/Delete/5
        public ActionResult DeleteSpeciality(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.DeleteAsync("https://localhost:44307/api/speciality/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        } 
    }
}
