using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using denemeportfolio.Models;

namespace denemeportfolio.Controllers
{
    public class ServiceController : Controller
    {
        DbPortfolioEntities1 db = new DbPortfolioEntities1();

        // Service Listesi
        public ActionResult ServiceList()
        {
            var Values = db.TblService.ToList();
            return View(Values);
        }

        // Yeni Service Ekleme Formu
        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }

        // Yeni Service Ekleme İşlemi
        [HttpPost]
        public ActionResult CreateService(TblService p)
        { // URL formatında simge alınıyor, veritabanına kaydediliyor
            if (!string.IsNullOrEmpty(p.IconUrl))
            {
                db.TblService.Add(p);
                db.SaveChanges();
            }
            return RedirectToAction("ServiceList");
        }

        // Service Silme
        public ActionResult DeleteService(int id)
        {
            var value = db.TblService.Find(id);
            if (value == null)
            {
                return HttpNotFound(); // Bulunamazsa hata döndür
            }

            db.TblService.Remove(value);
            db.SaveChanges();
            TempData["SuccessMessage"] = "Service successfully deleted!"; // Başarı mesajı
            return RedirectToAction("ServiceList");
        }

        // Service Güncelleme Formu
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = db.TblService.Find(id);
            if (value == null)
            {
                return HttpNotFound(); // Bulunamazsa hata döndür
            }
            return View(value); // Bulunduysa güncelleme formunu döndür
        }

        // Service Güncelleme İşlemi
        [HttpPost]
        public ActionResult UpdateService(TblService p)
        {
            if (ModelState.IsValid) // Form verisi geçerli ise
            {
                var value = db.TblService.Find(p.ServiceId);
                
                    value.Title = p.Title;
                    value.Description = p.Description;
                    value.IconUrl = p.IconUrl;
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Service successfully updated!"; // Başarı mesajı
                    return RedirectToAction("ServiceList");
               
            }
            return View(p); // Geçerli değilse, hata mesajıyla aynı sayfayı geri döndür
        }
    }
}
