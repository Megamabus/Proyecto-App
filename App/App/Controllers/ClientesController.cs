using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Models;

namespace App.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetClientes()
        {

            List<ClienteViewModel> clientes = new ClienteViewModel().GetClientes();
            return Json(clientes, JsonRequestBehavior.AllowGet);
        }
    }
}