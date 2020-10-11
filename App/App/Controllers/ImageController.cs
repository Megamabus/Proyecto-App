using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Models;

namespace App.Controllers
{
    public class ImageController : Controller
    {
        DB_TESTEntities db = new Models.DB_TESTEntities();
        // GET: Image
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
        public ActionResult addnewrecord(tbl_data d,HttpPostedFileBase imgfile)
        {
            tbl_data di = new tbl_data();
            string path = uploadimage(imgfile);

            if (path.Equals("-1"))
            {

            }
            else
            {
                di.P_name = d.P_name;
                di.P_DES = d.P_DES;
                di.P_IMAGE = d.P_IMAGE;
                db.tbl_data.Add(di);
                db.SaveChanges();
                ViewBag.Message = "Data added....";
            }
            return View();
        }
        public string uploadimage(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Content/upload"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Content/upload" + random + Path.GetFileName(file.FileName);
                    }
                    catch (Exception e )
                    {

                        path = "-1";
                    }

                }
                else
                {
                    Response.Write("<script>alert('Please select a file');</script>");
                    path = "-1";
                }
            }
            return path;
        }
    }
}