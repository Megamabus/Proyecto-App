using App.Models;
using App.Models.ViewModels;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class ComprasController : Controller
    {
        dbAppEntities1 db = new dbAppEntities1();
        // GET: Compras
        public ActionResult Index()
        {
            List<FacturaViewModel> model ;
            var message = "";
            try
            {
                model  = (from fs in db.Facturas
                              select new FacturaViewModel { 
                                Id = fs.Id,
                                Total = fs.Total,
                                FechaCompra = fs.FechaCompra
                              }).ToList();

                message = "success";
            }
            catch (Exception e)
            {
                message = "fail: " + e.StackTrace;
                throw;
            }            

            return View(model);
        }

        public ActionResult Nuevo()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(FacturaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oFactura = new Factura(){ 
                        Total = model.Total,
                        FechaCompra = model.FechaCompra
                    };

                    db.Facturas.Add(oFactura);
                    db.SaveChanges();

                    return Redirect("~/Compras");
                }

                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public ActionResult Edit(int Id)
        {
            
            
                var oFactura = db.Facturas.Find(Id);

            FacturaViewModel model = new FacturaViewModel()
            {
                Total = oFactura.Total,
                FechaCompra = oFactura.FechaCompra,
                Id = oFactura.Id
            };
            

             return View(model);

        }

        [HttpPost]
        public ActionResult Edit(FacturaViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var oFactura = db.Facturas.Find(model.Id);
                    oFactura.Total = model.Total;
                    oFactura.FechaCompra = model.FechaCompra;

                    db.Entry(oFactura).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return Redirect("~/Compras");
                }

                return View(model);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public ActionResult Delete(int Id)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var oFactura = db.Facturas.Find(Id);
                    db.Facturas.Remove(oFactura);
                    db.SaveChanges();

                    return Redirect("~/Compras");
                }
            }
            catch (Exception e)
            {

                throw;
            }

            return Redirect("~/Compras");
        }
    }
}