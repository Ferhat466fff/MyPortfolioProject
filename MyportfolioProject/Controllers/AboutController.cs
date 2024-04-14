using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolio.Settings;//sessionout için eklemen gerek
using MyportfolioProject.Models;//tanımlaman gerek

namespace MyportfolioProject.Controllers
{
    

    public class AboutController : Controller
    {
        // GET: About
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        //hakkımda listeleme
        public ActionResult Index()
        {
           
            var values = db.Tbl_Abauts.ToList();
            return View(values);
        }


        //yeni hakkımda ekle
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(Tbl_Abauts t)
        {
            db.Tbl_Abauts.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");//ekle denildikten sonra bizi tekrar ındex yollasın

        }

        //Hakkımda Silme
        public ActionResult DeleteAbout(int id)
        {
            var about = db.Tbl_Abauts.Find(id);//id'ye göre silecek
            db.Tbl_Abauts.Remove(about);
            db.SaveChanges();
            return RedirectToAction("Index");//sil denildikten sonra bizi tekrar ındex yollasın
            //ındex html butonun yolunu verdik
        }

        //Güncelle tıklandığında verileri getirme ve güncelleme
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
          //verileri getirme
            var about = db.Tbl_Abauts.Find(id);
            if (about != null)//id'si varsa kısaca verileri al
            {
                return View(about); 
            }
            else
            {
                return RedirectToAction("Index");//yoksa indexe gonder
            }
        }

        [HttpPost]
        public ActionResult UpdateAbout(Tbl_Abauts about)
        {   //verileri güncelleme
            var value = db.Tbl_Abauts.Find(about.AboutId);
            value.ImageUrl = about.ImageUrl;
            value.Title = about.Title;
            value.Description = about.Description;
            db.SaveChanges();
            return RedirectToAction("Index");

        }



    }
}