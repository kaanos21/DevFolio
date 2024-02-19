using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutList()
        {
            var values = db.TblAbout.ToList();
            return View(values);
        }
        [HttpGet]

        public ActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateAbout(TblAbout t)
        {
            db.TblAbout.Add(t);
            db.SaveChanges();
            return RedirectToAction("AboutList");
        }

        

        public ActionResult DeleteAbout(int id)
        {
            var value = db.TblAbout.FirstOrDefault(x => x.AboutId == id);
            db.TblAbout.Remove(value);
            db.SaveChanges();
            return RedirectToAction("AboutList");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = db.TblAbout.Find(id);
            return View(values);
        }

        [HttpPost]

        public ActionResult UpdateAbout(TblAbout t)
        {
            var value = db.TblAbout.FirstOrDefault(x => x.AboutId == t.AboutId);
            value.Description = t.Description;
            db.SaveChanges();
            return RedirectToAction("AboutList");
        }







        
        
    }
}