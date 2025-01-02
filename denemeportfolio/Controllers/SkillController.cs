using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using denemeportfolio.Models;
namespace denemeportfolio.Controllers
{
    public class SkillController : Controller
    {
        DbPortfolioEntities1 db = new DbPortfolioEntities1();
        public ActionResult SkillList()
        {
            var Values = db.TblSkill.ToList();
            return View(Values);
        }
        [HttpGet]
        public ActionResult CreateSkill()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult CreateSkill(TblSkill p)
        {
            db.TblSkill.Add(p);
                db.SaveChanges();
            return RedirectToAction("SkillList");

            return View();
        }
        public ActionResult DeleteSkill(int id)
        {
            var value = db.TblSkill.Find(id);
            db.TblSkill.Remove(value);
            db.SaveChanges();
            return RedirectToAction("SkillList");
        }
        public ActionResult UpdateSkill(int id)
        {
            var value = db.TblSkill.Find(id);
            return View(value);
        }
        public ActionResult UpdateSkill( TblSkill p)
        {
            var value = db.TblSkill.Find(p.SkillId);
            value.Title = p.Title;
            value.Value = p.Value;
            value.LastWeekValue = p.LastWeekValue;
            value.LastMonthValue = p.LastMonthValue;
            db.SaveChanges();
            return RedirectToAction("SkillList");
            return View(value);
        }
    }
}