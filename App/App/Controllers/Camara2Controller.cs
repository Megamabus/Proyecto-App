using App.Models;
using App.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class Camara2Controller : Controller
    {
        DB_TESTEntities db = new Models.DB_TESTEntities();
        // GET: Camara2
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult addnewrecord()
        {
            ViewBag.Message = "Yout contact Page";
            return View();
        }
        [HttpPost]
        public ActionResult addnewrecord(tblProduct item)
        //public ActionResult addnewrecord(tbl_data d, HttpPostedFileBase imgfile)
        {
            if (ModelState.IsValid)
            {

                tbl_data tbl = new tbl_data()
                {
                    P_name = item.ProductName,
                    P_DES = item.Price.ToString(),
                    img = ConvertToByte(item.ImageUpload)

                };

                db.tbl_data.Add(tbl);
                db.SaveChanges();
            }
            //tbl_data di = new tbl_data();
            //string path = uploadimage(imgfile);

            //if (path.Equals("-1"))
            //{

            //}
            //else
            //{
            //    di.P_name = d.P_name;
            //    di.P_DES = d.P_DES;
            //    di.P_IMAGE = d.P_IMAGE;
            //    db.tbl_data.Add(di);
            //    db.SaveChanges();
            //    ViewBag.Message = "Data added....";
            //}
            return View();
        }
        
        [HttpGet]
        public JsonResult GetRecord()
        {
            List<tbl_dataViewModel> lstproduct = this.List();
             var  product1 = lstproduct.FirstOrDefault();
            var produc = new {
                ProductId = product1.P_id,
                ProductName = product1.P_name,
                Price = int.Parse(product1.P_DES),
                ImageUpload = Convert.ToBase64String(product1.img)
            };

            return Json(produc, JsonRequestBehavior.AllowGet);
        }
       
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
        private List<tbl_dataViewModel> List()
        {
            return (from x in db.tbl_data
                    where x.P_id == 2
                    select new tbl_dataViewModel
                    {
                        P_id = x.P_id,
                        P_name = x.P_name,
                        P_DES = x.P_DES,
                        P_IMAGE = x.P_IMAGE,
                        img  = x.img
                    }).ToList();

        }

    }
}