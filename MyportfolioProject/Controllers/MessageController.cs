using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyportfolioProject.Models;

namespace MyportfolioProject.Controllers
{
    public class MessageController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();

        //listeleme
        public ActionResult Index()
        {
            var values = db.Tbl_Messages.ToList();
            return View(values);
        }

        //Mesaj Ekleme
        [HttpGet]
        public ActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMessage(Tbl_Messages id)
        {
            var values = db.Tbl_Messages.Add(id);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Mesaj Silme
        public ActionResult DeleteMessage(int id)
        {
            var values = db.Tbl_Messages.Find(id);
            db.Tbl_Messages.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Mesaj Bilgilerini Getirme ve Güncelleme
        [HttpGet]
        public ActionResult UpdateMessage(int id)
        {
            //verileri getirme
            var values = db.Tbl_Messages.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateMessage(Tbl_Messages k)
        {   //verileri güncelleme
            var value = db.Tbl_Messages.Find(k.MessageId);
            value.Name = k.Name;
            value.Email = k.Email;
            value.Subject = k.Subject;
            value.MessageContent = k.MessageContent;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
       



    }
}