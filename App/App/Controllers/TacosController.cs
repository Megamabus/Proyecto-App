using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using App.Models;

namespace App.Controllers
{
    public class TacosController : Controller
    {
        // GET: Tacos
        public ActionResult Index()
        {
            IEnumerable<TacosModel> tacos = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44349/api/");
                var responseTask = client.GetAsync("values");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<IList<TacosModel>>();
                    readJob.Wait();
                    tacos = readJob.Result;
                }
                else
                {
                    //return the error code here
                    tacos = Enumerable.Empty<TacosModel>();
                    ModelState.AddModelError(string.Empty, "Server error occured. Please contact admin(facu) for help!");
                }
            }

            return View(tacos);
        }
    }
}