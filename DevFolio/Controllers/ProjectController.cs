using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult ProjectList()
        {
            var value = db.TblProject.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            List<SelectListItem> category = (from i in db.TblCategory.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CategoryName,
                                                 Value = i.CategoryId.ToString()
                                             }).ToList();
            ViewBag.category = category;
            return View();
        }
        [HttpPost]
        public ActionResult CreateProject(TblProject t)
        {
            var category = db.TblCategory.Where(m => m.CategoryId == t.TblCategory.CategoryId).FirstOrDefault();
            t.TblCategory = category;
            t.CreatedDate = DateTime.Now;
            db.TblProject.Add(t);
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }

        public ActionResult DeleteProject(int id)
        {
            var value = db.TblProject.FirstOrDefault(a => a.ProjectId == id);
            db.TblProject.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var values = db.TblProject.Find(id);
            List<SelectListItem> category = (from i in db.TblCategory.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CategoryName,
                                                 Value = i.CategoryId.ToString()
                                             }).ToList();
            ViewBag.category = category;

            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateProject(TblProject p)
        {
            var values = db.TblProject.Find(p.ProjectId);
            values.Title = p.Title;
            values.ProjectCategory = p.TblCategory.CategoryId;
            values.CoverImageUrl = p.CoverImageUrl;
            values.CreatedDate = p.CreatedDate;
            db.SaveChanges();

            return RedirectToAction("ProjectList");
        }


    }
}