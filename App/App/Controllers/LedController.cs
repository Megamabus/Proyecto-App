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
        //ParaIntranet
        //public string routeControllerPath = "http://192.168.0.13/Led/ModificarLed";//ruta para usar cuando s publica
        //public string serviceArduinoPath = "http://192.168.0.13:70/api/Notification";//ruta para usar cuando s publica

        //ParaVisualStudio
        //public string routeControllerPath = "https://localhost:44354/Led/ModificarLed";//ruta de debug para prebas
        //public string serviceArduinoPath = "https://localhost:44324/api/Notification";//ruta de debug para prebas

        //ParaLocalhost
        public string routeControllerPath = "http://localhost/Led/ModificarLed";//ruta de debug para prebas
        public string serviceArduinoPath = "http://localhost:8010/api/Notification";//ruta de debug para prebas


        // GET: Led
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.routeControllerPath = routeControllerPath;
            return View(ViewBag);
        }

        [HttpPost]
        public ActionResult ModificarLed(NotificationViewModel RGB)
        {
            

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serviceArduinoPath);
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