﻿using System;
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
        public ActionResult InsertPhoto()
        {
            return View();
        }

        // POST: PlayerPhotoMVC/Create
        [HttpPost]
        public ActionResult InsertPhoto(PlayerPhoto playerPhoto)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PostAsJsonAsync("https://localhost:44307/api/playerphotoes", playerPhoto).Result;
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

        // GET: PlayerPhotoMVC/Edit/5
        public ActionResult UpdatePhoto(int id)
        {
            PlayerPhoto photo = new PlayerPhoto();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/playerphotoes/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    photo = result.Content.ReadAsAsync<PlayerPhoto>().Result;
                    return View(photo);
                }
            }
            return View();
        }

        // POST: PlayerPhotoMVC/Edit/5
        [HttpPost]
        public ActionResult UpdatePhoto(PlayerPhoto playerPhoto)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = client.PutAsJsonAsync("https://localhost:44307/api/playerphotoes/" + playerPhoto.Id.ToString(), playerPhoto).Result;
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

        // GET: PlayerPhotoMVC/Delete/5
        public ActionResult DeletePhoto(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.DeleteAsync("https://localhost:44307/api/playerphotoes/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
    }
}
