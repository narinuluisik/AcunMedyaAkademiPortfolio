using denemeportfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using denemeportfolio.Models;

namespace denemeportfolio.Controllers
{
   
    public class DefaultController : Controller
    {

        DbPortfolioEntities1 db = new DbPortfolioEntities1();
        // GET: Default
         public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialFeature()
        {
            var values = db.TblFeature.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAbout()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSkill()
        {
            var values = db.TblSkill.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialStatistic()
        {
            var skillcount = db.TblSkill.ToList().Count();
            ViewBag.SkillCount = skillcount;
            var projectcount = db.TblProject.ToList().Count();
            ViewBag.ProjectCount = projectcount;
            var servicecount = db.TblService.ToList().Count();
            ViewBag.ServiceCount =servicecount;
            var testimonialcount = db.TblTestimonial.ToList().Count();
            ViewBag.TestimonialCount = testimonialcount;
            return PartialView();
        }
        public PartialViewResult PartialAdress()
        {
            var values = db.TblAdress.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialHobby()
        {
            var values = db.TblHobby.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialService()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialContact()
        {
            var values = db.TblContact.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialProject()
        {
            var values = db.TblProject.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialFooterService()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialFooterAddress()
        {
            var values = db.TblAdress.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTestimonial()
        {
            var values = db.TblTestimonial.ToList();
            return PartialView(values);
        }
    }
}