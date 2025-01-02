﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using denemeportfolio.Models;


namespace Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial
        DbPortfolioEntities1 db = new DbPortfolioEntities1();
        public ActionResult Index()
        {
            var values = db.TblTestimonial.ToList();
            return View(values);

        }
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            
            return View();

        }
        [HttpPost]
        public ActionResult CreateTestimonial(TblTestimonial p)
        {
            db.TblTestimonial.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

           

        }
        public ActionResult DeleteTestimonial(int id)
        {
            var value = db.TblTestimonial.Find(id);
            db.TblTestimonial.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = db.TblTestimonial.Find(id);

            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonial p)
        {
            var value = db.TblTestimonial.Find(p.TestimonialId);
            value.TestimonialDescription = p.TestimonialDescription;
            value.TestimonialName = p.TestimonialName;
            value.TestimonialImageUrl = p.TestimonialImageUrl;
            value.TestimonialTitle = p.TestimonialTitle;
            value.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
} 