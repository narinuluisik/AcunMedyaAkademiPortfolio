﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using denemeportfolio.Models;


namespace Controllers
{
    public class ProjectController : Controller
    {
     
        DbPortfolioEntities1 db = new DbPortfolioEntities1();
        public ActionResult Index()
        {
            var values = db.TblProject.ToList();
            return View(values);

        }
        [HttpGet]
        public ActionResult CreateProject()
        {

            return View();

        }
        [HttpPost]
        public ActionResult CreateProject(TblProject p)
        {
            db.TblProject.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");



        }
        public ActionResult DeleteProject(int id)
        {
            var value = db.TblProject.Find(id);
            db.TblProject.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var value = db.TblProject.Find(id);

            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateProject(TblProject p)
        {
            var value = db.TblProject.Find(p.ProjectId);
            if (value == null)
            {
                // Hata mesajı dönebilir veya kullanıcıyı bilgilendirebilirsiniz.
                return HttpNotFound("Belirtilen proje bulunamadı.");
            }

            value.ProjectName = p.ProjectName;
            value.ProjectImageUrl = p.ProjectImageUrl;
            value.ProjectCategory = p.ProjectCategory;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}