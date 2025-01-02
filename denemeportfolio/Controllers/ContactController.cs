using System.Linq;
using System.Web.Mvc;
using denemeportfolio.Models;

namespace denemeportfolio.Controllers
{
    public class ContactController : Controller
    {
        private DbPortfolioEntities1 db = new DbPortfolioEntities1();

        // Mesajlar sayfası
        public ActionResult Index()
        {
            var contacts = db.TblContact.ToList();
            return View(contacts);
        }

        // Yeni iletişim ekleme sayfası (GET)
        [HttpGet]
        public ActionResult CreateContact()
        {
            return View(new TblContact()); // Model olarak boş bir TblContact gönderiyoruz
        }

        // Yeni iletişim ekleme (POST)
        [HttpPost]
        public ActionResult CreateContact(TblContact p)
        {
            if (ModelState.IsValid)
            {
                db.TblContact.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        // Silme işlemi
        public ActionResult DeleteContacts(int id)
        {
            var contact = db.TblContact.Find(id);
            if (contact != null)
            {
                db.TblContact.Remove(contact);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Güncelleme işlemi (GET)
        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var contact = db.TblContact.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // Güncelleme işlemi (POST)
        [HttpPost]
        public ActionResult UpdateContact(TblContact p)
        {
            if (ModelState.IsValid)
            {
                var contact = db.TblContact.Find(p.ContactId);
                if (contact != null)
                {
                    contact.Name = p.Name;
                    contact.Email = p.Email;
                    contact.Subject = p.Subject;
                    contact.Description = p.Description;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(p);
        }
    }
}
