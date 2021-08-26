using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPLManagementSystemMVC.Models;
using System.Net.Http;
namespace IPLManagementSystemMVC.Controllers
{
    public class NewsMVCController : Controller
    {
        public ActionResult Index()
        {
            List<News> news = new List<News>();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/news").Result;
                if (result.IsSuccessStatusCode)
                {
                    news = result.Content.ReadAsAsync<List<News>>().Result;
                }
            }
            return View(news);
        }

        //To insert data into statistics
        public ActionResult InsertNews()
        {
            return View();
        }
        [HttpPost] //works when submit button is clicked
        public ActionResult InsertNews(News news)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.PostAsJsonAsync("https://localhost:44307/api/news", news).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }

        public ActionResult UpdateNews(int id)
        {
            News news = new News();
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync("https://localhost:44307/api/news/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    news = result.Content.ReadAsAsync<News>().Result;
                    return View(news);
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult UpdateNews(News news)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.PutAsJsonAsync("https://localhost:44307/api/news/" + news.Id.ToString(), news).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }

        //To delete news
        public ActionResult DeleteNews(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.DeleteAsync("https://localhost:44307/api/news/" + id.ToString()).Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            }
            return View();
        }
    }
}