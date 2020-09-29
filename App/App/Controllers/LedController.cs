using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace App.Controllers
{
    public class LedController : Controller
    {


        // GET: Led
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ModificarLed(NotificationViewModel RGB)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44368/api/Notification");
                var postJob = client.PostAsJsonAsync<NotificationViewModel>("notification", RGB);
                postJob.Wait();

                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
              
            return View("Index");
        }
    }
}