using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyportfolioProject.Models;

namespace MyportfolioProject.Controllers
{
    public class ContactController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();

        //İletişim Bilgilerini Listeleme
        public ActionResult Index()
        {
            var values = db.Tbl_Contacts.ToList();
            return View(values);
        }

        //Yeni İletişim Bilgileri Ekleme
        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(Tbl_Contacts id)
        {
            db.Tbl_Contacts.Add(id);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //İletişim Bilgileri Silme
        public ActionResult DeleteContact(int id)
        {
            var values = db.Tbl_Contacts.Find(id);
            db.Tbl_Contacts.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //İletişim Bilgileri Güncelleme ve Bilgileri Taşıma
        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var values = db.Tbl_Contacts.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateContact(Tbl_Contacts Contact)
        {
            var values = db.Tbl_Contacts.Find(Contact.ContactId);
            values.NameSurname = Contact.NameSurname;
            values.Address = Contact.Address;
            values.Phone = Contact.Phone;
            values.Email = Contact.Email;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}