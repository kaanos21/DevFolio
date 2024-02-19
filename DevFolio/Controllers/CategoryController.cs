using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public string cumle()
        {
            return "Merhaba Dünya";
        }
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult CategoryList()
        {
            var value = db.TblCategory.ToList();
            return View(value);
        }

        [HttpGet]

        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateCategory(TblCategory t)
        {
            db.TblCategory.Add(t);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult DeleteCategory(int b)
        {
            var value = db.TblCategory.FirstOrDefault(a => a.CategoryId == b);
            db.TblCategory.Remove(value);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = db.TblCategory.Find(id);

            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(TblCategory p)
        {
            var value = db.TblCategory.Find(p.CategoryId);
            value.CategoryName = p.CategoryName;
            db.SaveChanges();

            return RedirectToAction("CategoryList");
        }
    }
}