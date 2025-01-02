﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using denemeportfolio.Models;


namespace Controllers
{
    public class BannerController : Controller
    {
        // GET: Testimonial
        DbPortfolioEntities1 db = new DbPortfolioEntities1();
        public ActionResult Index()
        {
            var values = db.TblBanner.ToList();
            return View(values);

        }
        [HttpGet]
        public ActionResult CreateBanner()
        {

            return View();

        }
        [HttpPost]
        public ActionResult CreateBanner(TblBanner p)
        {
            db.TblBanner.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");



        }
        public ActionResult DeleteBanner(int id)
        {
            var value = db.TblBanner.Find(id);
            db.TblBanner.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdateBanner(int id)
        {
            var value = db.TblBanner.Find(id);

            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateBanner(TblBanner p)
        {
            var value = db.TblBanner.Find(p.BannerId);
            value.Description = p.Description;
            value.Title = p.Title;
            value.ImageUrl = p.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}