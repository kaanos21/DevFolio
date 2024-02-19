using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;
using System.Net;

namespace DevFolio.Controllers
{
    public class AdminLayoutController : Controller
    {
        // GET: AdminLayout
        DbDevFolioEntities db = new DbDevFolioEntities();
        
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult SidePartial()
        {
            var value = db.TblFeature.FirstOrDefault();
            
            
                return PartialView(value);
            
            
        }



        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
    }
}