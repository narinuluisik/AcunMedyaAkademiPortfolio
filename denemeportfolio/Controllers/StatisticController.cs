using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using denemeportfolio.Models;
namespace denemeportfolio.Controllers
   
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        DbPortfolioEntities1 db = new DbPortfolioEntities1();
        public ActionResult Index()
        {
        ViewBag.categoryCount = db.TblCategory.Count();
        ViewBag.projectCount = db.TblProject.Count();
        ViewBag.skillCount = db.TblSkill.Count();
            ViewBag.skillAvgValue = db.TblSkill.Average(x => x.Value);
            ViewBag.lastSkillTitleName = db.GetLastSkillTitle().FirstOrDefault();
            ViewBag.mvcCategoryProjectCount = db.TblProject.Where(x => x.ProjectCategory == 4).Count();
            return View();
        }
    }
}