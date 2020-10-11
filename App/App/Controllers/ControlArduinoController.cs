using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace App.Controllers
{
    public class ControlArduinoController : Controller
    {
        //ParaIntranet
        //public string mvcMainPagePath = "http://192.168.0.13/";//ruta para usar cuando s publica
        //public string serviceArduinoPath = "http://192.168.0.13:70/";//ruta para usar cuando s publica

        //ParaVisualStudio
        //public string mvcMainPagePath = "https://localhost:44354/";//ruta de debug para prebas
        //public string serviceArduinoPath = "https://localhost:44324/";//ruta de debug para prebas

        //ParaLocalhost
        public string mvcMainPagePath = "http://localhost/";//ruta de debug para prebas
        public string serviceArduinoPath = "http://localhost:8010/";//ruta de debug para prebas


        // GET: Led
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.mvcMainPagePath = mvcMainPagePath;
            return View(ViewBag);
        }

        [HttpPost]
        public ActionResult ModificarLed(NotificationViewModel notification)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{serviceArduinoPath}api/Notification");
                var postJob = client.PostAsJsonAsync<NotificationViewModel>("notification", notification);
                postJob.Wait();

                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
              
            return View("Index");
        }

        [HttpPost]
        public ActionResult SetearRele(NotificationViewModel notification)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{serviceArduinoPath}api/Notification");
                var postJob = client.PostAsJsonAsync<NotificationViewModel>("notification/Rele", notification);
                postJob.Wait();

                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }

            return View("Index");
        }

        [HttpPost]
        public void AddItem(FormCollection data)
        {
            String userName = data["username"];
            String userPassword = data["password"];

            
        }
    }
}