using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        DbDevFolioEntities db = new DbDevFolioEntities();
        
        public ActionResult Index()
        {
            ViewBag.CateogoryCount = db.TblCategory.Count();
            ViewBag.ProjectCount = db.TblProject.Count();
            ViewBag.SkillCount = db.TblSkill.Count();
            ViewBag.SkillAvgValue = db.TblSkill.Average(x => x.SkillValue);
            ViewBag.LastSkillTitleName = db.GetlastSkillTitle().FirstOrDefault();
            ViewBag.CoreCategoryProjectCount = db.TblProject.Where(x => x.ProjectCategory == 1).Count();
            ViewBag.totaladmin = db.TblAdmin.Count();
            ViewBag.totaltestimonial = db.TblTestimonial.Count();
            ViewBag.totalsocialmedia = db.TblSocialMedia.Count();
            ViewBag.totalmessage = db.TblContact.Count();
            return View();
            
        }
    }
}