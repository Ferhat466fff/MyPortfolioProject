using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyportfolioProject.Models;

namespace MyportfolioProject.Controllers
{
    public class ServiceController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();

        //Servis Listeleme
        public ActionResult Index()
        {
            var values = db.Tbl_Services.ToList();
            return View(values);
        }

        //Servis Ekleme
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddService(Tbl_Services id)
        {
            db.Tbl_Services.Add(id);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Servis Silme
        public ActionResult DeleteService(int id)
        {
            var values=db.Tbl_Services.Find(id);
            db.Tbl_Services.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Servis Bilgilerini Getirme ve Güncelleme
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var values = db.Tbl_Services.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateService(Tbl_Services k)
        {
            var values= db.Tbl_Services.Find(k.ServesId);
            values.Icon = k.Icon;
            values.Title = k.Title;
            values.Description = k.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Aktif Yapma Butonu
        public ActionResult MakeActive(int id)
        {
            var value = db.Tbl_Services.Find(id);
            value.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Pasif Yapma Butonu
        public ActionResult MakePassive(int id)
        {
            var value = db.Tbl_Services.Find(id);
            value.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }





    }
}