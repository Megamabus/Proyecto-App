using App.Models;
using App.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class CamaraController : Controller
    {
        DB_TESTEntities db = new DB_TESTEntities();
        // GET: Camara
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult GuardarImagen(CamaraViewModel item)
        {

            if (ModelState.IsValid)
            {
                tbl_imagen tbl = new tbl_imagen() {
                    imagen = ConvertToByte(item.ImageUpload)
                };

                db.tbl_imagen.Add(tbl);
                db.SaveChanges();
            }

            return View();
        }
        
        [HttpGet]
        public JsonResult GetImageCamara()
        {
            var product = db.tbl_imagen.Where<tbl_imagen>(y => y.id >0).ToList().LastOrDefault();

            var x = new {
                ImageUpload = Convert.ToBase64String(product.imagen)
            };

            return Json(x , JsonRequestBehavior.AllowGet);
        }
        #region Metodos auxiliares
        public byte[] ConvertToByte(HttpPostedFileBase file)
        {
            byte[] data;
            using (Stream inputStream = file.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                data = memoryStream.ToArray();
            }
            return data;
        }

        private byte[] StringToArrayBytes(string sBase64String)
        {
            byte[] bytes = null;
            if (!string.IsNullOrEmpty(sBase64String))
            {
                bytes = System.Text.Encoding.UTF8.GetBytes(sBase64String);
            }
            return bytes;
        }
        #endregion

    }
}