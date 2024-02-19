using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class AddressController : Controller
    {
        // GET: Address
        public ActionResult Index()
        {
            return View();
        }
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult AddressList()
        {
            var values = db.TblAddress.ToList();
            return View(values);
        }

        [HttpGet]

        public ActionResult CreateAddress()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateAddress(TblAddress t)
        {
            db.TblAddress.Add(t);
            db.SaveChanges();
            return RedirectToAction("AddressList");
        }

         
        
        public ActionResult DeleteAddress(int id)
        {
            var value = db.TblAddress.FirstOrDefault(a => a.AddresId == id);
            db.TblAddress.Remove(value);
            db.SaveChanges();
            return RedirectToAction("AddressList");
        }

        [HttpGet]
        public ActionResult UpdateAddress(int id)
        {
            var values = db.TblAddress.Find(id);

            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAddress(TblAddress p)
        {
            var values = db.TblAddress.Find(p.AddresId);
            values.Description = p.Description;
            values.Location = p.Location;
            values.Email = p.Email;
            values.PhoneNumber = p.PhoneNumber;
            db.SaveChanges();

            return RedirectToAction("AddressList");
        }
    }
}