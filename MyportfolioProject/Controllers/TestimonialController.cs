using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyportfolioProject.Models;//tanımlaman gerek

namespace MyportfolioProject.Controllers
{
    public class TestimonialController : Controller
    {

        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.Tbl_Testimonials.ToList();
            return View(values);
        }

        //Öne Çıkanlar ekleme
        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonial(Tbl_Testimonials t)
        {
            db.Tbl_Testimonials.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");//ekle denildikten sonra bizi tekrar ındex yollasın
        }


        //Refaranslarım Silme
        public ActionResult DeleteTestimonial(int id)
        {
            var values = db.Tbl_Testimonials.Find(id);
            db.Tbl_Testimonials.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Öne Çıkanlar Güncelleme ve Bilgileri Taşıma
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var values = db.Tbl_Testimonials.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Tbl_Testimonials Testimonial)
        {
            var values = db.Tbl_Testimonials.Find(Testimonial.TestimonialId);
            values.ImageUrl = Testimonial.ImageUrl;
            values.Comment = Testimonial.Comment;
            values.NameSurname = Testimonial.NameSurname;
            values.Title = Testimonial.Title;
            values.Status = Testimonial.Status;
            values.CommentDate = Testimonial.CommentDate;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}