using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyportfolioProject.Models;

namespace MyportfolioProject.Controllers
{
    public class SocialMediaController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();

        //Listeleme
        public ActionResult Index()
        {
            var values = db.Tbl_Social_Medias.ToList();
            return View(values);
        }

        //Sosyal Medya Ekleme
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(Tbl_Social_Medias id)
        {
            db.Tbl_Social_Medias.Add(id);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Silme
        public ActionResult DeleteSocialMedia(int id)
        {
            var values=db.Tbl_Social_Medias.Find(id);
            db.Tbl_Social_Medias.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Medayayı getirme ve güncelleme
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var values = db.Tbl_Social_Medias.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(Tbl_Social_Medias k)
        {
            var values=db.Tbl_Social_Medias.Find(k.SocialMediaId);
            values.SocialMediaName = k.SocialMediaName;
            values.Url = k.Url;
            values.Icon = k.Icon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}