using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookshop.Models;

namespace Bookshop.Controllers
{
    public class SupplierController : Controller
    {
        BOOKSHOPEntities db = new BOOKSHOPEntities();
        // GET: Supplier
        public ActionResult Index()
        {
            return View(db.NHA_CUNG_CAP.ToList());
        }
        [HttpGet]
        public ActionResult AddSupplier()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult AddSupplier(NHA_CUNG_CAP ncc)
        {
            var check = db.NHA_CUNG_CAP.Find(ncc.ID_NCC);
            if(check == null)
            {
                db.NHA_CUNG_CAP.Add(ncc);
                db.SaveChanges();
            }
            return RedirectToRoute(new { controller= "Supplier", action= "Index"});
        }
        
        [HttpGet]
        public ActionResult EditSupplier(string id)
        {
            var foundSupplier = db.NHA_CUNG_CAP.Find(id);
            return View(foundSupplier);
        }
        [HttpPost]
        public RedirectToRouteResult EditSupplier(NHA_CUNG_CAP ncc)
        {
            var load = db.NHA_CUNG_CAP.Where(e => e.ID_NCC == ncc.ID_NCC).SingleOrDefault();
            load.Ten_NCC = ncc.Ten_NCC;
            load.Email = ncc.Email;
            load.DiaChi = ncc.DiaChi;
            load.SDT = ncc.SDT;
            db.SaveChanges();
            return RedirectToRoute(new { controller = "Supplier", action = "Index" });
        }

        public RedirectToRouteResult DeleteSupplier(string id)
        {
            var foundSupplier = db.NHA_CUNG_CAP.Find(id);
            db.NHA_CUNG_CAP.Remove(foundSupplier);
            db.SaveChanges();
            return RedirectToRoute(new { controller = "Supplier", action = "Index" });
        }
    }
}