using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyportfolioProject.Models;//tanımlaman gerek

namespace MyportfolioProject.Controllers
{
    public class FeatureController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        //Öne Çıkanlar Listeleme
        public ActionResult Index()
        {
            var values = db.Tbl_Features.ToList();
            return View(values);
        }

        //Öne Çıkanlar ekleme
        [HttpGet]
        public ActionResult AddFeature()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFeature(Tbl_Features t)
        {
            db.Tbl_Features.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");//ekle denildikten sonra bizi tekrar ındex yollasın
        }

        //Öne Çıkanlar Silme
        public ActionResult DeleteFeature(int id)
        {
            var values = db.Tbl_Features.Find(id);
            db.Tbl_Features.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Öne Çıkanlar Güncelleme ve Bilgileri Taşıma
        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var values = db.Tbl_Features.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateFeature(Tbl_Features features)
        {
            var values = db.Tbl_Features.Find(features.FatureId);
            values.NameSurname = features.NameSurname;
            values.Title= features.Title;
            values.ImageUrl = features.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}