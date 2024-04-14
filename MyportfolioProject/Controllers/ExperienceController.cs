using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyportfolioProject.Models;

namespace MyportfolioProject.Controllers
{
    public class ExperienceController : Controller
    { 
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();

        //Deneyimler Listeleme
        public ActionResult Index()
        {
            var values = db.Tbl_Experiences.ToList();
            return View(values);
        }


        //Yeni Deneyim Ekle
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(Tbl_Experiences t)
        {
            db.Tbl_Experiences.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");//ekle denildikten sonra bizi tekrar ındex yollasın
        }

        //Deneyim Silme
        public ActionResult DeleteExperience(int id)
        {
            var values = db.Tbl_Experiences.Find(id);
            db.Tbl_Experiences.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");//sil denildikten sonra bizi tekrar ındex yollasın
            //ındex html butonun yolunu verdik
        }


        //Deneyimleri Alma ve Deneyim Güncelleme

        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            
            var values = db.Tbl_Experiences.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateExperience(Tbl_Experiences experience)
        {
            
            var values = db.Tbl_Experiences.Find(experience.Experienceld);
            values.StartYear = experience.StartYear;
            values.EndYear = experience.EndYear;
            values.Title = experience.Title;
            values.Description = experience.Description;
            values.Company = experience.Company;
            values.Locations = experience.Locations;
            db.SaveChanges();
            return RedirectToAction("Index");//ekle denildikten sonra bizi tekrar ındex yollasın
        }








    }
}