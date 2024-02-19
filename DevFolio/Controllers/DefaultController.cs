using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavBar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            var values = db.TblFeature.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialProfile()
        {
            var values = db.TblProfile.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialSkill()
        {
            var values = db.TblSkill.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAbout()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialService()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialStats()
        {
            
            ViewBag.totaladmin = db.TblAdmin.Count();
            ViewBag.totalproject = db.Database.SqlQuery<int>("exec totalproject").FirstOrDefault();
            ViewBag.totaltestimonial = db.TblTestimonial.Count();
            ViewBag.totalAspNetCoreProject = db.TblProject.Count(x => x.ProjectCategory == db.TblCategory.FirstOrDefault(a=>a.CategoryName=="Asp.Net Core").CategoryId);
            return PartialView();
        }

        public PartialViewResult PartialPortfolio()
        {
            var value = db.TblProject.ToList();
            return PartialView(value);
        }

        public PartialViewResult PartialTestimonial()
        {
            var value = db.TblTestimonial.ToList();
            return PartialView(value);
        }

        public PartialViewResult PartialContact()
        {
            var value = db.TblContact.ToList();
            return PartialView(value);
        }
        [HttpPost]
        public PartialViewResult SendMessage(TblContact t)
        {
            t.SendMessageDate = DateTime.Now;
            t.IsRead = true;
            db.TblContact.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}