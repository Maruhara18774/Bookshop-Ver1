using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookshop.Models;

namespace Bookshop.Controllers
{
    public class PublisherController : Controller
    {
        BOOKSHOPEntities db = new BOOKSHOPEntities();
        // GET: Publisher
        public ActionResult Index()
        {
            return View(db.NHA_XUAT_BAN.ToList());
        }

        [HttpGet]
        public ActionResult AddPublisher()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult AddPublisher(NHA_XUAT_BAN nxb)
        {
            var check = db.NHA_XUAT_BAN.Find(nxb.ID_NXB);
            if (check == null)
            {
                db.NHA_XUAT_BAN.Add(nxb);
                db.SaveChanges();
            }
            return RedirectToRoute(new { controller = "Publisher", action = "Index" });
        }

        [HttpGet]
        public ActionResult EditPublisher(string id)
        {
            var foundPublisher = db.NHA_XUAT_BAN.Find(id);
            return View(foundPublisher);
        }
        [HttpPost]
        public RedirectToRouteResult EditPublisher(NHA_XUAT_BAN ncc)
        {
            var load = db.NHA_XUAT_BAN.Where(e => e.ID_NXB == ncc.ID_NXB).SingleOrDefault();
            load.Ten_NXB = ncc.Ten_NXB;
            load.Email = ncc.Email;
            load.DiaChi = ncc.DiaChi;
            load.SDT = ncc.SDT;
            db.SaveChanges();
            return RedirectToRoute(new { controller = "Publisher", action = "Index" });
        }

        public RedirectToRouteResult DeletePublisher(string id)
        {
            var foundPublisher = db.NHA_XUAT_BAN.Find(id);
            db.NHA_XUAT_BAN.Remove(foundPublisher);
            db.SaveChanges();
            return RedirectToRoute(new { controller = "Publisher", action = "Index" });
        }
    }
}