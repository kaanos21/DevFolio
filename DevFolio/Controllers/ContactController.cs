using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SendMessage()
        {
            return View();
        }

        public ActionResult MessageList()
        {
            return View();
        }
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult ContactList()
        {
            var value = db.TblContact.ToList();
            return View(value);
        }

        [HttpGet]

        public ActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateContact(TblContact t)
        {
            db.TblContact.Add(t);
            db.SaveChanges();
            return RedirectToAction("ContactList");
        }

        public ActionResult DeleteContact(int id)
        {
            var value = db.TblContact.FirstOrDefault(a => a.ContactId == id);
            db.TblContact.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ContactList");
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = db.TblContact.FirstOrDefault(a => a.ContactId == id);
            return View(value);
        }

    }
}