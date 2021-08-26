using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPLManagementSystemMVC.Models;
using System.Net.Http;
namespace IPLManagementSystemMVC.Controllers
{
    public class PlayerPhotoMVCController : Controller
    {
        // GET: PlayerPhotoMVC
        public ActionResult Index()
        {
            List<PlayerPhoto> photo = new List<PlayerPhoto>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/playerphotoes").Result;
                if (result.IsSuccessStatusCode)
                {
                    photo = result.Content.ReadAsAsync<List<PlayerPhoto>>().Result;
                }
            }
            return View(photo);
        }

        // GET: PlayerPhotoMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlayerPhotoMVC/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayerPhotoMVC/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlayerPhotoMVC/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayerPhotoMVC/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlayerPhotoMVC/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
