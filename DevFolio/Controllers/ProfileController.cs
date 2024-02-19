using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult ProfileList()
        {
            var value = db.TblProfile.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateProfile()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateProfile(TblProfile t)
        {
            db.TblProfile.Add(t);
            db.SaveChanges();
            return RedirectToAction("ProfileList");
        }

        public ActionResult DeleteProfile(int id)
        {
            var value = db.TblProfile.FirstOrDefault(a => a.ProfileId == id);
            db.TblProfile.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ProfileList");
        }

        [HttpGet]
        public ActionResult UpdateProfile(int id)
        {
            var values = db.TblProfile.Find(id);

            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateProfile(TblProfile p)
        {
            var values = db.TblProfile.Find(p.ProfileId);
            values.NameSurname = p.NameSurname;
            values.Title = p.Title;
            values.Email = p.Email;
            values.Phone = p.Phone;
            db.SaveChanges();

            return RedirectToAction("ProfileList");
        }
    }
}