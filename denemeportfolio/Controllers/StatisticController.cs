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
            var db = new DbPortfolioEntities1();

            // Kategorilerin sayısını al
            ViewBag.categoryCount = db.TblCategory.Count();

            // Projelerin sayısını al
            ViewBag.projectCount = db.TblProject.Count();

            // Yeteneklerin sayısını al
            ViewBag.skillCount = db.TblSkill.Count();

            // Referansların sayısını al
            ViewBag.testimonialCount = db.TblTestimonial.Count();

            // Hobilerin sayısını al
            ViewBag.hobbyCount = db.TblHobby.Count();

            // Yeteneklerin ortalama değerini al
            ViewBag.skillAvgValue = db.TblSkill.Average(x => x.Value);

            // Son eklenen yetenek başlığını al
            ViewBag.lastSkillTitleName = db.GetLastSkillTitle().FirstOrDefault();

          
            ViewBag.mvcCategoryProjectCount = db.TblProject.Where(x => x.ProjectCategory == 4).Count();
            ViewBag.webCategoryProjectCount = db.TblProject.Where(x => x.ProjectCategory == 1).Count();
            ViewBag.mobilCategoryProjectCount = db.TblProject.Where(x => x.ProjectCategory == 2).Count();

        
            return View();
        }

    }
}