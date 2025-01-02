using denemeportfolio.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace denemeportfolio.Controllers
{
    public class AboutController : Controller
    {
        DbPortfolioEntities1 db = new DbPortfolioEntities1();

        // GET: About
        public ActionResult AboutList()
        {
            ViewBag.Abouts = db.TblAbout.ToList();
            ViewBag.Hobbies = db.TblHobby.ToList();
            ViewBag.Services = db.TblService.ToList();
            ViewBag.Projects = db.TblProject.ToList();

            return View();
        }

        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAbout(TblAbout p)
        {
            db.TblAbout.Add(p);
            db.SaveChanges();
            return RedirectToAction("AboutList");
        }

        public ActionResult DeleteAbout(int id)
        {
            var value = db.TblAbout.Find(id);
            db.TblAbout.Remove(value);
            db.SaveChanges();
            return RedirectToAction("AboutList");
        }

        // HttpGet method to load the update form
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = db.TblAbout.Find(id);
            if (value == null)
            {
                return HttpNotFound();
            }
            return View(value);
        }

        // HttpPost method to update the About details
        [HttpPost]
        public ActionResult UpdateAbout(TblAbout p)
        {
            if (ModelState.IsValid)
            {
                var value = db.TblAbout.Find(p.AboutId);
                if (value == null)
                {
                    return HttpNotFound();
                }

                value.Title = p.Title;
                value.Description = p.Description;
                value.ImageUrl = p.ImageUrl;

                db.SaveChanges();
                return RedirectToAction("AboutList");
            }
            return View(p);
        }
    }
}
