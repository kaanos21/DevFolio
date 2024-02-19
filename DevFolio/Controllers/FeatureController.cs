using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class FeatureController : Controller
    {
        // GET: Feature
        public ActionResult Index()
        {
            return View();
        }
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult FeatureList()
        {
            var value = db.TblFeature.ToList();
            return View(value);
        }
        [HttpGet]

        public ActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateFeature(TblFeature t)
        {
            db.TblFeature.Add(t);
            db.SaveChanges();
            return RedirectToAction("FeatureList");
        }

        public ActionResult DeleteFeature(int id)
        {
            var value = db.TblFeature.FirstOrDefault(a => a.FeatureId == id);
            db.TblFeature.Remove(value);
            db.SaveChanges();
            return RedirectToAction("FeatureList");
        }
        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var values = db.TblFeature.Find(id);

            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateFeature(TblFeature p)
        {
            var values = db.TblFeature.Find(p.FeatureId);
            values.HeaderTitle = p.HeaderTitle;
            values.HeaderDescription = p.HeaderDescription;
            db.SaveChanges();

            return RedirectToAction("FeatureList");
        }
    }
}